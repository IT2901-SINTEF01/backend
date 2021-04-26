using Backend.Mocks.SSB;
using Backend.Models.SSBTaxAssessment.POCO;
using Backend.utils;
using Xunit;

namespace BackendTests.Mocks
{
    public class TaxAssessmentTest
    {
        private readonly int _numMunicipalities = NorwayTools.MunicipalityCodeToIndexTaxes.Count;

        private readonly int
            _numsPerMunicipality =
                typeof(AnnualTaxes).GetProperties().Length -
                1; // -1 because "Year" isn't an actual field in the data source

        private readonly int _numYears = NorwayTools.YearToIndexTaxes.Count;
        private readonly TaxAssessment _taxAssessment;

        public TaxAssessmentTest()
        {
            _taxAssessment = MockTaxAssessmentInNorway.GenerateSampleTaxAssessments();
        }

        [Fact]
        public void PopulationInNorwayAPIShouldReturnData()
        {
            Assert.NotNull(_taxAssessment);
        }

        [Fact]
        public void PopulationInNorwayCorrectLabelAndSource()
        {
            Assert.Equal(
                "Hovedposter fra skatteoppgjøret. Personer, etter alder. Gjennomsnitt og median (kr). Kommuner, 1999 - siste år",
                _taxAssessment.Dataset.Label);
            Assert.Equal("Statistisk sentralbyrå", _taxAssessment.Dataset.Source);
        }

        [Fact]
        public void PopulationInNorwayGeneratesCorrectAmountOfData()
        {
            Assert.Equal(_numMunicipalities * _numYears * _numsPerMunicipality, _taxAssessment.Dataset.Value.Count);
        }
    }
}