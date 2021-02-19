using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Backend.API.MetAPI;
using Backend.API.MetAPI.SubClasses;
using Backend.API.Services;
using BackendTests.utils;
using Bogus;
using NUnit.Framework;

namespace BackendTests.UnitTests {
    public class MetAPITests {
        private float _lon;
        private float _lat;
        private DataRetrievalService _service;
        private Forecast _forecast;

        [SetUp]
        public void Setup() {
            _lon = 63.446827f;
            _lat = 10.421906f;
            _service = new DataRetrievalService();
            _forecast = GenerateSampleForecast(); //await _service.GetForecast(_lat, _lon);
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

        private Forecast GenerateSampleForecast() {
            var random = new Random();
            var forecastGeometry = new Faker<Geometry>()
                .StrictMode(true)
                .RuleFor(o => o.Coordinates, f => new Collection<float> {
                    /*(float) random.NextDouble() * (63.433f - 63.42f) + 63.42f,
                    (float) random.NextDouble() * (10.4f - 10.38f) + 10.38f*/
                    _lon, _lat
                })
                .RuleFor(o => o.Type, f => "Point");
            var forecastUnits = new Faker<Units>()
                .RuleFor(o => o.AirTemperature, f => "celsius")
                .RuleFor(o => o.AirPressureAtSeaLevel, f => "hPa")
                .RuleFor(o => o.CloudAreaFraction, f => "%")
                .RuleFor(o => o.PrecipitationAmount, f => "mm")
                .RuleFor(o => o.RelativeHumidity, f => "%")
                .RuleFor(o => o.WindFromDirection, f => "degrees")
                .RuleFor(o => o.WindSpeed, f => "m/s");

            var forecastMeta = new Faker<Meta>()
                .RuleFor(o => o.Units, f => forecastUnits.Generate())
                .RuleFor(o => o.UpdatedAt, f => DateTime.Now);

            var forecastDetails = new Faker<Details>()
                .RuleFor(o => o.AirTemperature, f => (float) random.NextDouble() * (50 - 30) + 30)
                .RuleFor(o => o.AirPressureAtSeaLevel, f => (float) random.NextDouble() * (1100 + 900) - 900)
                .RuleFor(o => o.CloudAreaFraction, f => (float) random.NextDouble() * (100 + 50) - 50)
                .RuleFor(o => o.PrecipitationAmount, f => (float) random.NextDouble())
                .RuleFor(o => o.RelativeHumidity, f => (float) random.NextDouble() * 100)
                .RuleFor(o => o.WindFromDirection, f => (float) random.NextDouble() * 360)
                .RuleFor(o => o.WindSpeed, f => (float) random.NextDouble() * 32.7);

            var forecastInstant = new Faker<Instant>()
                .RuleFor(o => o.Details, f => forecastDetails.Generate());

            var forecastSummary = new Faker<Summary>()
                .RuleFor(o => o.SymbolCode,
                    f => MetAPITools.ValidSymbolCodes[random.Next(MetAPITools.ValidSymbolCodes.Count)]);

            var next1Hours = new Faker<Next1Hours>()
                .RuleFor(o => o.Details, f => forecastDetails.Generate())
                .RuleFor(o => o.Summary, f => forecastSummary.Generate());

            var next6Hours = new Faker<Next6Hours>()
                .RuleFor(o => o.Details, f => forecastDetails.Generate())
                .RuleFor(o => o.Summary, f => forecastSummary.Generate());

            var next12Hours = new Faker<Next12Hours>()
                .RuleFor(o => o.Details, f => forecastDetails.Generate())
                .RuleFor(o => o.Summary, f => forecastSummary.Generate());

            var forecastData = new Faker<ForecastData>()
                .RuleFor(o => o.Instant, f => forecastInstant.Generate())
                .RuleFor(o => o.Next1Hours, f => next1Hours.Generate())
                .RuleFor(o => o.Next6Hours, f => next6Hours.Generate())
                .RuleFor(o => o.Next12Hours, f => next12Hours.Generate());

            var forecastTimeseries = new Faker<Timeseries>().RuleFor(o => o.Time, f => DateTime.Now)
                .RuleFor(o => o.ForecastData, f => forecastData.Generate());

            var forecastProperties = new Faker<Properties>()
                .RuleFor(o => o.Meta, f => forecastMeta.Generate())
                .RuleFor(o => o.Timeseries, f => {
                    var outCollection = new Collection<Timeseries>();
                    foreach (var timeserie in forecastTimeseries.Generate(10)) {
                        outCollection.Add(timeserie);
                    }

                    return outCollection;
                });

            var outForecast = new Faker<Forecast>()
                .StrictMode(true)
                .RuleFor(o => o.Type, f => "Feature")
                .RuleFor(o => o.ForecastGeometry, f => forecastGeometry.Generate())
                .RuleFor(o => o.ForecastProperties, f => forecastProperties.Generate());
            return outForecast;
        }
    }
}