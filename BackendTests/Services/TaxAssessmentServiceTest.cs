using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.API.Services;
using BackendTests.Helpers;
using Xunit;

namespace BackendTests.Services
{
    public class TaxAssessmentServiceTest
    {
        private const string Url = "https://data.ssb.no/api/v0/dataset/49607.json?lang=no";
        private HttpClient _httpClient;
        private TaxAssessmentServiceMocked _mockedService;
        private TaxAssessmentService _service;

        [Fact]
        public async Task TaxAssessmentServiceShouldReturnData()
        {
            _mockedService = new TaxAssessmentServiceMocked();

            _httpClient =
                HttpClientMocker.SetupHttpClientMock(Url,
                    await CreateTaxAssessmentAsString().ConfigureAwait(false));

            _service = new TaxAssessmentService(_httpClient);

            var result = _service.GetTaxAssessment();

            Assert.NotNull(result);
        }

        private async Task<string> CreateTaxAssessmentAsString()
        {
            var result = await _mockedService.GetTaxAssessment();
            return JsonSerializer.Serialize(result);
        }
    }
}