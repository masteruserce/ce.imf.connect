using ce.imf.connect.comon.DTOs;
using ce.imf.connect.models;
namespace ce.imf.connect.application.Service.Abstraction
{
    public interface IPostalCodeService
    {
        Task<List<PostalCodeDto>> GetAsync(int pinCode);
        Task<List<string>> GetSatateAsync(string input);
        Task<List<string>> GetDistrictAsync(string state, string district);
    }

}
