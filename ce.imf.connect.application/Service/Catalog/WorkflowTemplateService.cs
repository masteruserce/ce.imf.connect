using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Catalog
{
    public class WorkflowTemplateService : IWorkflowTemplateService
    {
        public readonly IWorkflowTemplateRepository _repository;
        public WorkflowTemplateService(IWorkflowTemplateRepository repository)
        {
            _repository = repository;
        }
        public Task<Guid> SaveAsync(WorkflowTemplateCreateDto dto)
        {
            return _repository.SaveAsync(dto);
        }
    }
}
