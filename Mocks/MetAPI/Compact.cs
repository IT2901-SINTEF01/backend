using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Backend.Models.MetAPI.POCO;
using BackendTests.utils;
using Bogus;

namespace Backend.Mocks.MetAPI
{
    [SuppressMessage("Rule Category", "CA5394", Justification = "No security threat on data mocking.")]
    public sealed class Compact
    {
        public static Forecast GenerateSampleForecast(float lon, float lat)
        {
            Random random = new();
            var numInTimeseries = 0;
            var startTime = DateTime.Now.AddMinutes(random.Next(-120, 0));
            var timeseriesDateTime = startTime.AddMinutes(-startTime.Minute).AddSeconds(-startTime.Second)
                .AddMilliseconds(-startTime.Millisecond);

            var forecastGeometry = new Faker<Geometry>()
                .StrictMode(true)
                .RuleFor(o => o.Coordinates, f => new Collection<float>
                {
                    lon, lat
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
                .RuleFor(o => o.UpdatedAt, f => startTime);

            var forecastDetails = new Faker<Details>()
                .RuleFor(o => o.AirTemperature, f => (float) random.Next(-30, 49) + random.NextDouble())
                .RuleFor(o => o.AirPressureAtSeaLevel, f => (float) random.Next(900, 1100) + random.NextDouble())
                .RuleFor(o => o.CloudAreaFraction, f => (float) random.Next(50, 100) + random.NextDouble())
                .RuleFor(o => o.PrecipitationAmount, f => (float) random.NextDouble())
                .RuleFor(o => o.RelativeHumidity, f => (float) random.NextDouble() * 100)
                .RuleFor(o => o.WindFromDirection, f => (float) random.NextDouble() * 359)
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

            var forecastTimeseries = new Faker<Timeseries>().RuleFor(o => o.Time, f =>
                {
                    numInTimeseries++;
                    switch (numInTimeseries)
                    {
                        case < 56:
                            timeseriesDateTime = timeseriesDateTime.AddHours(1);
                            return timeseriesDateTime;
                        case 56:
                            timeseriesDateTime = timeseriesDateTime.AddHours(-(timeseriesDateTime.Hour % 6) + 6);
                            return timeseriesDateTime;
                        default:
                            timeseriesDateTime = timeseriesDateTime.AddHours(6);
                            return timeseriesDateTime;
                    }
                })
                .RuleFor(o => o.ForecastData, f => forecastData.Generate());

            var forecastProperties = new Faker<Properties>()
                .RuleFor(o => o.Meta, f => forecastMeta.Generate())
                .RuleFor(o => o.Timeseries, f =>
                {
                    var outCollection = new Collection<Timeseries>();
                    foreach (var timeseries in forecastTimeseries.Generate(85)) outCollection.Add(timeseries);

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