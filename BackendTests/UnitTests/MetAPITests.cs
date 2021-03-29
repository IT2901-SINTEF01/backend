using System;
using System.Diagnostics.CodeAnalysis;
using Backend.Mocks.MetAPI;
using Backend.Models.MetAPI.POCO;
using Backend.utils;
using Xunit;

namespace BackendTests.UnitTests
{
    [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
    public class MetAPITests
    {
        private readonly Forecast _forecast;
        private readonly float _lat;
        private readonly float _lon;

        public MetAPITests()
        {
            var random = new Random();
            _lon = (float) random.NextDouble() * (63.433f - 63.42f) + 63.42f;
            _lat = (float) random.NextDouble() * (10.4f - 10.38f) + 10.38f;
            _forecast = Compact.GenerateSampleForecast(_lon, _lat);
        }

        [Fact]
        public void MetAPIShouldReturnData()
        {
            Assert.NotNull(_forecast);
        }

        [Fact]
        public void MetAPIShouldReturnCorrectCoordinates()
        {
            Assert.Equal("Feature", _forecast.Type);
            Assert.Equal(_lon, _forecast.ForecastGeometry.Coordinates[0], 3);
            Assert.Equal(_lat, _forecast.ForecastGeometry.Coordinates[1], 3);
        }

        [Fact]
        public void MetAPIShouldReturnCorrectSymbolCode()
        {
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next1Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next6Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
            Assert.Contains(_forecast.ForecastProperties.Timeseries[0].ForecastData.Next12Hours.Summary.SymbolCode,
                MetAPITools.ValidSymbolCodes);
        }
    }
}