using System.Threading.Tasks;
using Backend.API.MetAPI;
using Backend.API.Services;
using BackendTests.tools;
using NUnit.Framework;

namespace BackendTests.UnitTests {
    public class MetAPITests {
        private float _lon;
        private float _lat;
        private ForecastDataRetrievalService _service;
        private Forecast _forecast;

        [SetUp]
        public async Task Setup() {
            _lon = 63.446827f;
            _lat = 10.421906f;
            _service = new ForecastDataRetrievalService();
            _forecast = await _service.GetForecast(_lat, _lon);
        }

        [Test]
        public void MetAPIShouldReturnData() {
            Assert.NotNull(_forecast);
        }

        [Test]
        public void MetAPIShouldReturnCorrectCoordinates() {
            Assert.That("Feature", Is.EqualTo(_forecast.Type).NoClip);
            Assert.That(_lon, Is.EqualTo(_forecast.ForecastGeometry.Coordinates[0]).Within(0.0001).Percent);
            Assert.That(_lat, Is.EqualTo(_forecast.ForecastGeometry.Coordinates[1]).Within(0.0001).Percent);
        }

        [Test]
        public void MetAPIShouldReturnCorrectSymbolCode() {
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next1Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next6Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next12Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
        }
    }
}