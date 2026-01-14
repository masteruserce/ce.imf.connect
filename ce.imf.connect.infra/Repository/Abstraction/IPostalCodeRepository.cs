using ce.imf.connect.models;
namespace ce.imf.connect.infra.Repository.Abstraction
{
    public interface IPostalCodeRepository
    {
        Task<List<PostalCode>> GetAsync(int pincode);
        Task<List<string>> GetSatateAsync(string input);
        Task<List<string>> GetDistrictAsync(string state, string district);
    }
}
