using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce.imf.connect.application.Service.Catalog
{
    public class SourcingDetailsService : ISourcingDetailsService
    {
        private readonly ISourcingDetailsRepository _repository;

        public SourcingDetailsService(ISourcingDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<SourcingDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<SourcingDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors
                    {
                        Code = "NOT_FOUND",
                        Details = $"SourcingDetails with ID {id} not found."
                    }
                    },
                    "Failed"
                );
            }

            return new ImfResponse<SourcingDetailsDto>(entity.ToDto(), "Record fetched successfully");
        }

        public async Task<ImfResponse<IEnumerable<SourcingDetailsDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtoList = entities.Select(e => e.ToDto()).ToList();
            return new ImfResponse<IEnumerable<SourcingDetailsDto>>(dtoList, "Data fetched successfully");
        }

        public async Task<ImfResponse<SourcingDetailsDto>> CreateAsync(SourcingDetailsDto dto)
        {
            dto.IsActive = true;
            dto.CreatedBy = "Test";
            var entity = await _repository.AddAsync(dto.ToModel());
            return new ImfResponse<SourcingDetailsDto>(entity.ToDto(), "Record created successfully");
        }

        public async Task<ImfResponse<SourcingDetailsDto>> UpdateAsync(SourcingDetailsDto dto)
        {
            if (dto.Id != null || dto.Id != Guid.Empty)
            {
                return new ImfResponse<SourcingDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "INVALID_ID", Details = "Id cannot be null or empty." }
                    },
                    "Failed"
                );
            }

            var existing = await _repository.GetByIdAsync(dto.Id.Value);
            if (existing == null)
            {
                return new ImfResponse<SourcingDetailsDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "NOT_FOUND", Details = $"SourcingDetails with ID {dto.Id} not found." }
                    },
                    "Failed"
                );
            }

            var updatedEntity = await _repository.UpdateAsync(dto.ToModel());
            return new ImfResponse<SourcingDetailsDto>(updatedEntity.ToDto(), "Record updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "NOT_FOUND", Details = $"SourcingDetails with ID {id} not found." }
                    },
                    "Failed"
                );
            }

            return new ImfResponse<bool>(true, "Record deleted successfully");
        }
    }


}
