using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Catalog
{
    public class WorkflowExecutionRepository : IWorkflowExecutionRepository
    {
        private readonly AppDbContext _db;
        public WorkflowExecutionRepository(AppDbContext db) => _db = db;

        public async Task InitializeAsync(
            string transactionId,
            Guid formId,
            Guid? clientId,
            string initiatedBy,
            CancellationToken cancellationToken = default)
        {
            var template = await _db.WorkflowTemplates
                .Include(t => t.States)
                .Where(t => t.FormId == formId && t.IsActive)
                .OrderByDescending(t => t.Version)
                .FirstOrDefaultAsync(cancellationToken);

            if (template == null)
                throw new InvalidOperationException("No active workflow template found.");

            var startState = template.States.FirstOrDefault(s => s.IsStart);
            if (startState == null)
                throw new InvalidOperationException("Start state not defined.");

            var instance = new WorkflowInstance
            {
                TransactionId = transactionId,
                TemplateId = template.Id,
                CurrentStateId = startState.Id,
                ClientId = clientId,
                StartedAt = DateTime.UtcNow,
                IsCompleted = false
            };

            _db.WorkflowInstances.Add(instance);

            _db.WorkflowHistories.Add(new WorkflowHistory
            {
                Instance = instance,
                FromStateId = startState.Id,
                ToStateId = startState.Id,
                ActionName = "Initialize",
                PerformedBy = initiatedBy
            });

            await _db.SaveChangesAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<string>> GetAvailableActionsAsync(
    string transactionId,
    Guid userRoleId,
    CancellationToken cancellationToken = default)
        {
            var instance = await _db.WorkflowInstances
                .Include(i => i.CurrentState)
                .Include(i => i.Template)
                .FirstOrDefaultAsync(i => i.TransactionId == transactionId, cancellationToken);

            if (instance == null)
                throw new InvalidOperationException("Workflow instance not found.");

            var transitions = await _db.WorkflowTransitions
                .Include(t => t.Roles)
                .Where(t => t.FromStateId == instance.CurrentStateId)
                .ToListAsync(cancellationToken);

            var allowed = transitions
                .Where(t =>
                    !t.Roles.Any() ||
                    t.Roles.Any(r => r.RoleId == userRoleId))
                .Select(t => t.ActionName)
                .Distinct()
                .ToList();

            return allowed;
        }

        public async Task ExecuteActionAsync(
    string transactionId,
    string actionName,
    Guid userRoleId,
    string performedBy,
    string? comments,
    string? ipAddress,
    string? deviceInfo,
    CancellationToken cancellationToken = default)
        {
            var instance = await _db.WorkflowInstances
                .Include(i => i.Template)
                .FirstOrDefaultAsync(i => i.TransactionId == transactionId, cancellationToken);

            if (instance == null)
                throw new InvalidOperationException("Workflow instance not found.");

            if (instance.IsCompleted)
                throw new InvalidOperationException("Workflow already completed.");

            var transition = await _db.WorkflowTransitions
                .Include(t => t.Roles)
                .FirstOrDefaultAsync(t =>
                    t.TemplateId == instance.TemplateId &&
                    t.FromStateId == instance.CurrentStateId &&
                    t.ActionName == actionName,
                    cancellationToken);

            if (transition == null)
                throw new InvalidOperationException("Invalid transition.");

            if (transition.Roles.Any() &&
                !transition.Roles.Any(r => r.RoleId == userRoleId))
                throw new UnauthorizedAccessException("User not authorized for this action.");

            var previousStateId = instance.CurrentStateId;
            instance.CurrentStateId = transition.ToStateId;

            var nextState = await _db.WorkflowStates
                .FirstAsync(s => s.Id == transition.ToStateId, cancellationToken);

            if (nextState.IsEnd)
            {
                instance.IsCompleted = true;
                instance.CompletedAt = DateTime.UtcNow;
            }

            _db.WorkflowHistories.Add(new WorkflowHistory
            {
                InstanceId = instance.Id,
                FromStateId = previousStateId,
                ToStateId = transition.ToStateId,
                ActionName = actionName,
                PerformedBy = performedBy,
                Comments = comments,
                IPAddress = ipAddress,
                DeviceInfo = deviceInfo
            });

            await _db.SaveChangesAsync(cancellationToken);

            await HandleEventTriggersAsync(instance, nextState, cancellationToken);
        }

        private async Task HandleEventTriggersAsync(
    WorkflowInstance instance,
    WorkflowState currentState,
    CancellationToken cancellationToken)
        {
            var triggers = await _db.WorkflowEventTriggers
                .Where(t =>
                    t.SourceTemplateId == instance.TemplateId &&
                    t.SourceStateId == currentState.Id &&
                    t.IsActive)
                .ToListAsync(cancellationToken);

            foreach (var trigger in triggers)
            {
                // Example placeholder
                // In real ERP, raise domain event or enqueue message
                Console.WriteLine($"Triggering form {trigger.TargetFormId}");
            }
        }
    }
}
