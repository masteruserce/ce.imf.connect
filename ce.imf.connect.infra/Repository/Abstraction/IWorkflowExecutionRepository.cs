using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IWorkflowExecutionRepository
    {
        Task InitializeAsync(
            string transactionId,
            Guid formId,
            Guid? clientId,
            string initiatedBy,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyList<string>> GetAvailableActionsAsync(
            string transactionId,
            Guid userRoleId,
            CancellationToken cancellationToken = default);

        Task ExecuteActionAsync(
            string transactionId,
            string actionName,
            Guid userRoleId,
            string performedBy,
            string? comments,
            string? ipAddress,
            string? deviceInfo,
            CancellationToken cancellationToken = default);
    }
}
