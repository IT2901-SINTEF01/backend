using System;
using System.Diagnostics.CodeAnalysis;
using Backend.Mocks.MetAPI;
using Backend.Models.MetAPI.POCO;
using BackendTests.utils;
using NUnit.Framework;

namespace BackendTests.UnitTests
{
    [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
    public class MetAPITests
    {
        private Forecast _forecast;
        private float _lat;
        private float _lon;
        private Random _random;

        [SetUp]
        public void Setup()
        {
            _random = new Random();
            _lon = (float) _random.NextDouble() * (63.433f - 63.42f) + 63.42f;
            _lat = (float) _random.NextDouble() * (10.4f - 10.38f) + 10.38f;
            _forecast = Compact.GenerateSampleForecast(_lon, _lat);
        }

        [Test]
        public void MetAPIShouldReturnData()
        {
            Assert.NotNull(_forecast);
        }

        [Test]
        public void MetAPIShouldReturnCorrectCoordinates()
        {
            Assert.That("Feature", Is.EqualTo(_forecast.Type).NoClip);
            Assert.That(_lon, Is.EqualTo(_forecast.ForecastGeometry.Coordinates[0]).Within(0.0001).Percent);
            Assert.That(_lat, Is.EqualTo(_forecast.ForecastGeometry.Coordinates[1]).Within(0.0001).Percent);
        }

        [Test]
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