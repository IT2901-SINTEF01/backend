using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Mocks.SSB;
using Backend.Models.SSBTaxAssessment.POCO;

namespace Backend.API.Services
{
    public interface ITaxAssesmentService
    {
        public Task<TaxAssessment> GetTaxAssesment();
    }
    public class TaxAssesmentService : ITaxAssesmentService
    {
        private readonly HttpClient _httpClient;

        public TaxAssesmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaxAssessment> GetTaxAssesment()
        {
            var response = 
                await _httpClient.GetAsync("https://data.ssb.no/api/v0/dataset/49613.json?lang=no");
            return await response.Content.ReadFromJsonAsync<TaxAssessment>();
        }
    }
    
    public class TaxAssesmentServiceMocked : ITaxAssesmentService
    {
        public Task<TaxAssessment> GetTaxAssesment()
        {
            throw new System.NotImplementedException();
        }
    }
}