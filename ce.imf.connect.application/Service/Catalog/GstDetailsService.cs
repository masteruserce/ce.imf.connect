using ce.imf.connect.comon.DTOs;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.common.Mapper;

namespace ce.imf.connect.application.Service.Catalog
{
    public class GstDetailsService : IGstDetailsService
    {
        private readonly IGstDetailsRepository _repository;

        public GstDetailsService(IGstDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ImfResponse<IEnumerable<GstDetailsDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            return new ImfResponse<IEnumerable<GstDetailsDto>>(
                data.Select(x => x.ToDto()).ToList(),
                "Fetched all GST details"
            );
        }

        public async Task<ImfResponse<GstDetailsDto>> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ImfResponse<GstDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "GST details not found" } },
                    "Not Found"
                );
            }

            return new ImfResponse<GstDetailsDto>(entity.ToDto(), "Fetched GST details by Id");
        }

        public async Task<ImfResponse<GstDetailsDto>> GetByApplicationNoAsync(string applicationNo)
        {
            var entity = await _repository.GetByApplicationNoAsync(applicationNo);
            if (entity == null)
            {
                return new ImfResponse<GstDetailsDto>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "GST details not found for ApplicationNo" } },
                    "Not Found"
                );
            }

            return new ImfResponse<GstDetailsDto>(entity.ToDto(), "Fetched GST details by ApplicationNo");
        }

        public async Task<ImfResponse<GstDetailsDto>> AddAsync(GstDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.AddAsync(entity);
            return new ImfResponse<GstDetailsDto>(result.ToDto(), "GST details added successfully");
        }

        public async Task<ImfResponse<GstDetailsDto>> UpdateAsync(GstDetailsDto dto)
        {
            var entity = dto.ToEntity();
            var result = await _repository.UpdateAsync(entity);
            return new ImfResponse<GstDetailsDto>(result.ToDto(), "GST details updated successfully");
        }

        public async Task<ImfResponse<bool>> DeleteAsync(Guid id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
            {
                return new ImfResponse<bool>(
                    new List<ImfErrors> { new ImfErrors { Code = "404", Details = "GST details not found for deletion" } },
                    "Delete failed"
                );
            }

            return new ImfResponse<bool>(true, "GST details deleted successfully");
        }
    }
}
