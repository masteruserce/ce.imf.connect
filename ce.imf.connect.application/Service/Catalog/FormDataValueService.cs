using Azure;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.DTOs;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;

namespace ce.imf.connect.application.Service.Catalog
{
    public class FormDataValueService : IFormDataValueService
    {
        private readonly IFormDataValueRepository _repo;
        private readonly IFormRepository _formRepository;
        private readonly IGenericRepository<AutoInsuranceFormDataValues> _autoRepo;
        private readonly IGenericRepository<LifeInsuranceFormDataValues> _lifeRepo;
        private readonly IGenericRepository<HealthInsuranceFormDataValues> _healthRepo;
        private readonly IGenericRepository<PropertyInsuranceFormDataValues> _propRepo;
        private readonly IGenericRepository<CropInsuranceFormDataValues> _cropRepo;
        private readonly IGenericRepository<CommercialInsuranceFormDataValues> _commRepo;
        private readonly IGenericRepository<TravelInsuranceFormDataValues> _travlRepo;
        private readonly IGenericRepository<MarineInsuranceFormDataValues> _marineRepo;
        private readonly IGenericRepository<FieldConfig> _fieldConfigRepo;
        private readonly IGenericRepository<Section> _sectionRepo;

        public FormDataValueService(IFormDataValueRepository repo, IFormRepository formRepository,
            IGenericRepository<AutoInsuranceFormDataValues> autoRepo,
            IGenericRepository<LifeInsuranceFormDataValues> lifeRepo,
        IGenericRepository<HealthInsuranceFormDataValues> healthRepo,
        IGenericRepository<PropertyInsuranceFormDataValues> propRepo,
        IGenericRepository<CropInsuranceFormDataValues> cropRepo,
        IGenericRepository<CommercialInsuranceFormDataValues> commRepo,
        IGenericRepository<TravelInsuranceFormDataValues> travlRepo,
        IGenericRepository<MarineInsuranceFormDataValues> marineRepo,
        IGenericRepository<FieldConfig> fieldConfigRepo,
        IGenericRepository<Section> sectionRepo
            )
        {
            _repo = repo;
            _formRepository = formRepository;
            _autoRepo = autoRepo;
            _lifeRepo = lifeRepo;
            _healthRepo = healthRepo;
            _propRepo = propRepo;
            _cropRepo = cropRepo;
            _commRepo = commRepo;
            _travlRepo = travlRepo;
            _marineRepo = marineRepo;
            _fieldConfigRepo = fieldConfigRepo;
            _sectionRepo = sectionRepo;
        }

        public async Task<ImfResponse<List<FormDataValueDto>>> SaveRangeAsync(List<FormDataValueDto> dto)
        {

            var form = await _formRepository.GetFormById(dto[0].FormId);

            return await SaveFormDataAsync(dto, form!.FormName);
        }
        public async Task<ImfResponse<FormDataValueDto>> SaveAsync(FormDataValueDto dto)
        {
            var entity = dto.ToEntity();
            var saved = await _repo.AddAsync(entity);
            return new ImfResponse<FormDataValueDto>(saved.ToDto(), "Saved successfully");
        }

        public async Task<ImfResponse<FormDataValueDto>> UpdateAsync(FormDataValueDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);
            if (entity == null) return new ImfResponse<FormDataValueDto>(
                new List<ImfErrors> { new ImfErrors { Code = "404", Details = "Not Found" } }, "Entity not found");

            entity.UpdateEntity(dto);
            await _repo.UpdateAsync(entity);
            return new ImfResponse<FormDataValueDto>(entity.ToDto(), "Updated successfully");
        }

        public async Task<ImfResponse<bool>> ActivateAsync(Guid id)
        {
            await _repo.ActivateAsync(id);
            return new ImfResponse<bool>(true, "Activated successfully");
        }

        public async Task<ImfResponse<bool>> DeactivateAsync(Guid id)
        {
            await _repo.DeactivateAsync(id);
            return new ImfResponse<bool>(true, "Deactivated successfully");
        }

        public async Task<ImfResponse<List<FormDataValueDto>>> GetByFormAsync(Guid formId, Guid? clientId)
        {
            return await GetFormDataAsync(formId, clientId);
        }

        private async Task<ImfResponse<List<FormDataValueDto>>> SaveFormDataAsync(List<FormDataValueDto> dto, string formName)
        {
            var response = new ImfResponse<List<FormDataValueDto>>();
            switch (formName)
            {
                case "Auto Insurance":
                    var autoForm = dto.Select(s => s.ToAutoEntity()).ToList();
                    var auto = await _autoRepo.AddRangeAsync(autoForm);
                    response.Data = [.. auto.Select(s => s.AutoToDto())];
                    response.Message = "Auto Insurance saved successfully";
                    break;
                case "Commercial Insurance":
                    var commercianForm = dto.Select(s => s.CommToEntity()).ToList();
                    var comm = await _commRepo.AddRangeAsync(commercianForm);
                    response.Data = [.. comm.Select(s => s.CommToDto())];
                    response.Message = "Commercial Insurance saved successfully";
                    break;
                case "Life Insurance":
                    var lifeForm = dto.Select(s => s.LifeToEntity()).ToList();
                    var life = await _lifeRepo.AddRangeAsync(lifeForm);
                    response.Data = [.. life.Select(s => s.LifeToDto())];
                    response.Message = "Life Insurance saved successfully";
                    break;
                case "Crop Insurance":
                    var cropForm = dto.Select(s => s.CropToEntity()).ToList();
                    var crop = await _cropRepo.AddRangeAsync(cropForm);
                    response.Data = [.. crop.Select(s => s.CropToDto())];
                    response.Message = "Crop Insurance saved successfully";
                    break;
                case "Property Insurance":
                    var propForm = dto.Select(s => s.PropertyToEntity()).ToList();
                    var prop = await _propRepo.AddRangeAsync(propForm);
                    response.Data = [.. prop.Select(s => s.PropertyToDto())];
                    response.Message = "Property Insurance saved successfully";
                    break;
                case "Travel Insurance":
                    var traveForm = dto.Select(s => s.TravelToEntity()).ToList();
                    var travel = await _travlRepo.AddRangeAsync(traveForm);
                    response.Data = [.. travel.Select(s => s.TravelToDto())];
                    response.Message = "Travel Insurance saved successfully";
                    break;
                case "Health Insurance":
                    var healthForm = dto.Select(s => s.HealthToEntity()).ToList();
                    var health = await _healthRepo.AddRangeAsync(healthForm);
                    response.Data = [.. health.Select(s => s.HealthToDto())];
                    response.Message = "Health Insurance saved successfully";
                    break;
                case "Marine Insurance":
                    var marineForm = dto.Select(s => s.MarineToEntity()).ToList();
                    var marine = await _marineRepo.AddRangeAsync(marineForm);
                    response.Data = [.. marine.Select(s => s.MarineToDto())];
                    response.Message = "Marine Insurance saved successfully";
                    break;
                default:
                    break;
            }
            return response;
        }

        private async Task<ImfResponse<List<FormDataValueDto>>> GetFormDataAsync(Guid formId, Guid? clientId)
        {
            var response = new ImfResponse<List<FormDataValueDto>>();
            var form = await _formRepository.GetFormById(formId);
            switch (form!.FormName)
            {
                case "Auto Insurance":
                    var auto = await _autoRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. auto.Select(s => s.AutoToDto())];
                    response.Message = "Fetched Auto Insurance data successfully";
                    break;
                case "Commercial Insurance":
                    var comm = await _commRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. comm.Select(s => s.CommToDto())];
                    response.Message = "Fetched Commercial Insurance data successfully";
                    break;
                case "Life Insurance":
                    var life = await _lifeRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. life.Select(s => s.LifeToDto())];
                    response.Message = "Fetched Life Insurance data successfully";
                    break;
                case "Crop Insurance":
                    var crop = await _cropRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. crop.Select(s => s.CropToDto())];
                    response.Message = "Fetched Crop Insurance data successfully";
                    break;
                case "Property Insurance":
                    var prop = await _propRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. prop.Select(s => s.PropertyToDto())];
                    response.Message = "Fetched Property Insurance data successfully";
                    break;
                case "Travel Insurance":
                    var travel = await _travlRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. travel.Select(s => s.TravelToDto())];
                    response.Message = "Fetched Travel Insurance data successfully";
                    break;
                case "Health Insurance":
                    var health = await _healthRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. health.Select(s => s.HealthToDto())];
                    response.Message = "Fetched Health Insurance data successfully";
                    break;
                case "Marine Insurance":
                    var marine = await _marineRepo.FindAsync(x => x.FormId == formId && x.ClientId == clientId);
                    response.Data = [.. marine.Select(s => s.MarineToDto())];
                    response.Message = "Fetched Marine Insurance data successfully";
                    break;
                default:
                    break;
            }
            return response;
        }

        public async Task<PaginatedResult<TransactionGridDto>> GetByFormPagedAsync(
           Guid formId,
           Guid? clientId,
           int pageNumber,
           int pageSize,
           bool ascending = true,
           CancellationToken cancellationToken = default)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var form = await _formRepository.GetFormById(formId);
            if (form is null)
                throw new ArgumentException($"Form with id {formId} not found.", nameof(formId));

            var formData = await _repo.GetByFormPagedAsync(formId, clientId, pageNumber, pageSize, ascending, cancellationToken);

            return formData;
        }
    }
}
