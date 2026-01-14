using ce.imf.connect.application.Service.Abstraction;
using ce.imf.connect.comon.DTOs;
using ce.imf.connect.infra.Repository.Abstraction;
using ce.imf.connect.comon.Mapper;
using ce.imf.connect.models;

namespace ce.imf.connect.application.Service.Catalog
{
    public class PostalCodeService : IPostalCodeService
    {
        private readonly IPostalCodeRepository _repo;

        public PostalCodeService(IPostalCodeRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<PostalCodeDto>> GetAsync(int pinCode)
        {
            var response = await _repo.GetAsync(pinCode);
            return [.. response.Select(s => s.ToDto())];
        }
        public async Task<List<string>> GetDistrictAsync(string state, string district)
        {
            return await _repo.GetDistrictAsync(state, district);
        }

        public async Task<List<string>> GetSatateAsync(string input)
        {
            return await _repo.GetSatateAsync(input);
        }
    }

}
