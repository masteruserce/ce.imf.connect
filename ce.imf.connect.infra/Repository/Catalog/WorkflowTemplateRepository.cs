using ce.imf.connect.comon.DTOs;
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
    public class WorkflowTemplateRepository : IWorkflowTemplateRepository
    {
        private readonly AppDbContext _db;

        public WorkflowTemplateRepository(AppDbContext db) => _db = db;

        public async Task<Guid> SaveAsync(WorkflowTemplateCreateDto dto)
        {
            WorkflowTemplate template;

            if (dto.Id.HasValue)
            {
                template = await _db.WorkflowTemplates
                    .Include(t => t.States)
                    .Include(t => t.Transitions)
                    .ThenInclude(t => t.Roles)
                    .FirstAsync(t => t.Id == dto.Id.Value);

                template.Name = dto.Name;
                template.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                template = new WorkflowTemplate
                {
                    Id = Guid.NewGuid(),
                    Name = dto.Name,
                    FormId = dto.FormId,
                    ClientId = dto.ClientId,
                    CreatedAt = DateTime.UtcNow,
                    Version = 1
                };

                _db.WorkflowTemplates.Add(template);
            }

            // Clear existing children on update
            template.States.Clear();
            template.Transitions.Clear();

            // Map States
            foreach (var stateDto in dto.States)
            {
                var state = new WorkflowState
                {
                    Id = Guid.NewGuid(),
                    TemplateId = template.Id,
                    Name = stateDto.Name,
                    Sequence = stateDto.Sequence,
                    IsStart = stateDto.IsStart,
                    IsEnd = stateDto.IsEnd,
                    AllowEdit = stateDto.AllowEdit
                };

                template.States.Add(state);
            }

            await _db.SaveChangesAsync();

            // Need state id mapping
            var stateMap = template.States
                .ToDictionary(s => s.Name, s => s.Id);

            foreach (var transDto in dto.Transitions)
            {
                var transition = new WorkflowTransition
                {
                    Id = Guid.NewGuid(),
                    TemplateId = template.Id,
                    FromStateId = stateMap.First(x => x.Value == transDto.FromStateId).Value,
                    ToStateId = stateMap.First(x => x.Value == transDto.ToStateId).Value,
                    ActionName = transDto.ActionName,
                    RequiresApproval = transDto.RequiresApproval,
                    AutoTransition = transDto.AutoTransition
                };

                foreach (var roleId in transDto.RoleIds)
                {
                    transition.Roles.Add(new WorkflowTransitionRole
                    {
                        Id = Guid.NewGuid(),
                        RoleId = roleId
                    });
                }

                template.Transitions.Add(transition);
            }

            await _db.SaveChangesAsync();

            return template.Id;
        }
    }
}
