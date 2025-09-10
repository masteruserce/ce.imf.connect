using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;

        public ClientService(IClientRepository repo)
        {
            _repo = repo;
        }

        public async Task<ImfResponse<List<ClientDto>>> GetAllAsync()
        {
            var data = (await _repo.GetAllAsync()).Select(c => c.ToDto()).ToList();
            return new ImfResponse<List<ClientDto>>(data, "Clients fetched successfully");
        }

        public async Task<ImfResponse<ClientDto>> GetByIdAsync(Guid clientId)
        {
            var entity = await _repo.GetByIdAsync(clientId);
            if (entity == null)
                return new ImfResponse<ClientDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Client not found", Trace = "" } });

            return new ImfResponse<ClientDto>(entity.ToDto(), "Client fetched successfully");
        }

        public async Task<ImfResponse<ClientDto>> AddAsync(ClientDto dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.AddAsync(entity);
            return new ImfResponse<ClientDto>(created.ToDto(), "Client created successfully");
        }

        public async Task<ImfResponse<ClientDto>> UpdateAsync(ClientDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.ClientId);
            if (entity == null)
                return new ImfResponse<ClientDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Client not found", Trace = "" } });

            entity.UpdateEntity(dto);
            var updated = await _repo.UpdateAsync(entity);
            return new ImfResponse<ClientDto>(updated.ToDto(), "Client updated successfully");
        }

        public async Task<ImfResponse<string>> DeleteAsync(Guid clientId)
        {
            await _repo.DeleteAsync(clientId);
            return new ImfResponse<string>("Client deleted successfully");
        }

        public async Task<ImfResponse<ClientDto>> ActivateAsync(Guid clientId)
        {
            var updated = await _repo.ActivateAsync(clientId);
            return new ImfResponse<ClientDto>(updated.ToDto(), "Client updated successfully");
        }

        public async Task<ImfResponse<ClientDto>> DeActivateAsync(Guid clientId)
        {
            var updated = await _repo.DeativateAsync(clientId);
            return new ImfResponse<ClientDto>(updated.ToDto(), "Client updated successfully");
        }
    }
}
