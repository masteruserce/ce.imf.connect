using ce.imf.connect.comon.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IClientService
    {
        Task<ImfResponse<List<ClientDto>>> GetAllAsync();
        Task<ImfResponse<ClientDto>> GetByIdAsync(Guid clientId);
        Task<ImfResponse<ClientDto>> AddAsync(ClientDto dto);
        Task<ImfResponse<ClientDto>> UpdateAsync(ClientDto dto);
        Task<ImfResponse<string>> DeleteAsync(Guid clientId);
        Task<ImfResponse<ClientDto>> ActivateAsync(Guid clientId);
        Task<ImfResponse<ClientDto>> DeActivateAsync(Guid clientId);
    }
}
