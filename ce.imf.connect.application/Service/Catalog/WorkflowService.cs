using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra;
using ce.imf.connect.infra.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Catalog
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowExecutionRepository _engine;
        private readonly AppDbContext _db;

        public WorkflowService(
            IWorkflowExecutionRepository engine,
            AppDbContext db)
        {
            _engine = engine;
            _db = db;
        }

        public async Task InitializeAsync(InitializeWorkflowRequestDto request)
        {
            await _engine.InitializeAsync(
                request.TransactionId,
                request.FormId,
                request.ClientId,
                request.InitiatedBy);
        }

        public async Task<WorkflowAvailableActionsDto> GetAvailableActionsAsync(
            string transactionId,
            Guid roleId)
        {
            var instance = await _db.WorkflowInstances
                .Include(i => i.CurrentState)
                .FirstOrDefaultAsync(i => i.TransactionId == transactionId);

            if (instance == null)
                throw new Exception("Workflow instance not found");

            var actions = await _engine.GetAvailableActionsAsync(transactionId, roleId);

            return new WorkflowAvailableActionsDto
            {
                TransactionId = transactionId,
                CurrentState = instance.CurrentState.Name,
                AvailableActions = actions.ToList()
            };
        }

        public async Task ExecuteActionAsync(ExecuteWorkflowActionRequestDto request)
        {
            await _engine.ExecuteActionAsync(
                request.TransactionId,
                request.ActionName,
                request.UserRoleId,
                request.PerformedBy,
                request.Comments,
                null,
                null);
        }

        public async Task<WorkflowInstanceDto?> GetInstanceAsync(string transactionId)
        {
            var instance = await _db.WorkflowInstances
                .Include(i => i.CurrentState)
                .FirstOrDefaultAsync(i => i.TransactionId == transactionId);

            if (instance == null)
                return null;

            return new WorkflowInstanceDto
            {
                TransactionId = instance.TransactionId,
                CurrentState = instance.CurrentState.Name,
                IsCompleted = instance.IsCompleted,
                StartedAt = instance.StartedAt,
                CompletedAt = instance.CompletedAt
            };
        }
    }
}
