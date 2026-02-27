using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IWorkflowService
    {
        Task InitializeAsync(InitializeWorkflowRequestDto request);
        Task<WorkflowAvailableActionsDto> GetAvailableActionsAsync(string transactionId, Guid roleId);
        Task ExecuteActionAsync(ExecuteWorkflowActionRequestDto request);
        Task<WorkflowInstanceDto?> GetInstanceAsync(string transactionId);
    }
}
