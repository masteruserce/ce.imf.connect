using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.common.Mapper;
using ce.imf.connect.comon.Helper;
using System.Net;
using ce.imf.connect.models;

namespace ce.imf.connect.application.Service.Catalog
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repo;
        private readonly IUserRepository _userRepository;
        private readonly IFormRepository _formRepository;
        public ClientService(IClientRepository repo, IUserRepository userRepository, IFormRepository formRepository)
        {
            _repo = repo;
            _userRepository = userRepository;
            _formRepository = formRepository;
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
            if (await _repo.IfUserNameExists(dto.UserName))
            {
               return new ImfResponse<ClientDto>(
                    new List<ImfErrors> { new ImfErrors { Code = HttpStatusCode.BadRequest.ToString(), Details = $"User Name {dto.UserName} is already taken, please choose a different user name", Trace = "" } });
              
            }
            dto.IsActive = true;
            var entity = dto.ToEntity();
            entity.UserPassword = entity.UserPassword.HashPassword();
            var created = await _repo.AddAsync(entity);
            if (created != null) 
            {

                await AddUser(created);
            }
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

        private async Task AddUser(Clients clients)
        {
            var menus = new List<UserMenuDto>();
            var forms = await _formRepository.GetFormByClientIdAsync(clients.ClientId);

            foreach (var form in forms)
            {
                menus.Add(new UserMenuDto { MenuName = form.FormName, Visible = true });
            }
            CreateUserRequest request = new()
            {
                ClientId = clients.ClientId,
                UserName = clients.UserName,
                Password = clients.UserPassword,
                Role = "ClientAdmin",
                CanRead = true,
                CanWrite = true,
                Menus = menus
            };
            request.Password = request.Password;
            var user = request.ToEntity();
            await _userRepository.AddAsync(user);
        }
    }
}
