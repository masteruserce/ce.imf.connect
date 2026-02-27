using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IWorkflowTemplateRepository
    {
        Task<Guid> SaveAsync(WorkflowTemplateCreateDto dto);
    }
}
