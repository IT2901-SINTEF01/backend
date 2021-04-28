using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.Mocks.SSB;
using Backend.Models.SSBTaxAssessment.POCO;

namespace Backend.API.Services
{
    public interface ITaxAssessmentService
    {
        public Task<TaxAssessment> GetTaxAssessment();
    }

    public class TaxAssessmentService : ITaxAssessmentService
    {
        private readonly HttpClient _httpClient;

        public TaxAssessmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TaxAssessment> GetTaxAssessment()
        {
            var response =
                await _httpClient.GetAsync("https://data.ssb.no/api/v0/dataset/49607.json?lang=no");
            return await response.Content.ReadFromJsonAsync<TaxAssessment>();
        }
    }

    public class TaxAssessmentServiceMocked : ITaxAssessmentService
    {
        public async Task<TaxAssessment> GetTaxAssessment()
        {
            return await Task.FromResult(MockTaxAssessmentInNorway.GenerateSampleTaxAssessments())
                .ConfigureAwait(false);
        }
    }
}