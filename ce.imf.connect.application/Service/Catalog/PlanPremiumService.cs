using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Catalog
{
    public class PlanPremiumService : IPlanPremiumService
    {
        private readonly IPlanPremiumRepository _repository;

        public PlanPremiumService(IPlanPremiumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<PlanPremiumDetailsDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var result = entities.Select(e => e.ToDto());
            return new ImfResponse<IEnumerable<PlanPremiumDetailsDto>>(result, "Fetched successfully.");
        }

        public async Task<ImfResponse<PlanPremiumDetailsDto?>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<PlanPremiumDetailsDto?>(new List<ImfErrors>
            {
                new ImfErrors { Code = "NOT_FOUND", Details = $"No record found for Id {id}" }
            }, "Record not found.");
            }

            return new ImfResponse<PlanPremiumDetailsDto?>(entity.ToDto(), "Fetched successfully.");
        }

        public async Task<ImfResponse<PlanPremiumDetailsDto>> AddAsync(PlanPremiumDetailsDto dto)
        {
            try
            {
                var entity = dto.ToEntity();
                var created = await _repository.AddAsync(entity);
                return new ImfResponse<PlanPremiumDetailsDto>(created.ToDto(), "Created successfully.");
            }
            catch (Exception ex)
            {
                return new ImfResponse<PlanPremiumDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "ADD_FAILED", Details = ex.Message, Trace = ex.StackTrace ?? "" }
                    }, "Failed to create PlanPremiumDetails."
                );
            }
        }

        public async Task<ImfResponse<PlanPremiumDetailsDto?>> UpdateAsync(PlanPremiumDetailsDto dto)
        {
            try
            {
                var entity =    dto.ToEntity();
                var updated = await _repository.UpdateAsync(entity);

                if (updated == null)
                {
                    return new ImfResponse<PlanPremiumDetailsDto?>(new List<ImfErrors>
                {
                    new ImfErrors { Code = "NOT_FOUND", Details = $"No record found for Id {dto.Id}" }
                }, "Update failed. Record not found.");
                }

                return new ImfResponse<PlanPremiumDetailsDto?>(updated.ToDto(), "Updated successfully.");
            }
            catch (Exception ex)
            {
                return new ImfResponse<PlanPremiumDetailsDto?>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "UPDATE_FAILED", Details = ex.Message, Trace = ex.StackTrace ?? "" }
                    }, "Failed to update PlanPremiumDetails."
                );
            }
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            try
            {
                var success = await _repository.DeleteAsync(id);
                if (!success)
                {
                    return new ImfResponse<bool>(new List<ImfErrors>
                {
                    new ImfErrors { Code = "NOT_FOUND", Details = $"No record found for Id {id}" }
                }, "Delete failed. Record not found.");
                }

                return new ImfResponse<bool>(true, "Deleted successfully.");
            }
            catch (Exception ex)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "DELETE_FAILED", Details = ex.Message, Trace = ex.StackTrace ?? "" }
                    }, "Failed to delete PlanPremiumDetails."
                );
            }
        }
    }

}
