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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<CustomerDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync( id);
            if (entity == null)
            {
                return new ImfResponse<CustomerDto>(
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

            return new ImfResponse<CustomerDto>(CustomerMapper.ToDto(entity), "Record fetched successfully");
        }

        public async Task<ImfResponse<IEnumerable<CustomerDto>>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            var dtoList = entities.Select(CustomerMapper.ToDto).ToList();
            return new ImfResponse<IEnumerable<CustomerDto>>(dtoList, "Data fetched successfully");
        }

        public async Task<ImfResponse<CustomerDto>> CreateAsync(CustomerDto dto)
        {
            var entity = await _repository.AddAsync(CustomerMapper.ToEntity(dto));
            return new ImfResponse<CustomerDto>(CustomerMapper.ToDto(entity), "Record created successfully");
        }

        public async Task<ImfResponse<CustomerDto>> UpdateAsync(CustomerDto dto)
        {
            if (dto.Id != Guid.Empty)
            {
                return new ImfResponse<CustomerDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "INVALID_ID", Details = "Id cannot be null or empty." }
                    },
                    "Failed"
                );
            }

            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null)
            {
                return new ImfResponse<CustomerDto>(
                    new List<ImfErrors>
                    {
                    new ImfErrors { Code = "NOT_FOUND", Details = $"SourcingDetails with ID {dto.Id!} not found." }
                    },
                    "Failed"
                );
            }

            var updatedEntity = await _repository.UpdateAsync(CustomerMapper.ToEntity(dto));
            return new ImfResponse<CustomerDto>(CustomerMapper.ToDto(updatedEntity), "Record updated successfully");
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
