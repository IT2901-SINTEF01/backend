using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using Backend.Mocks.Metadata;
using Backend.Models.MetAPI.POCO;
using Backend.utils;
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
                .RuleFor(o => o.Coordinates, _ => new Collection<float>
                {
                    lon, lat
                })
                .RuleFor(o => o.Type, _ => "Point");

            var forecastUnits = new Faker<Units>()
                .RuleFor(o => o.AirTemperature, _ => "celsius")
                .RuleFor(o => o.AirPressureAtSeaLevel, _ => "hPa")
                .RuleFor(o => o.CloudAreaFraction, _ => "%")
                .RuleFor(o => o.PrecipitationAmount, _ => "mm")
                .RuleFor(o => o.RelativeHumidity, _ => "%")
                .RuleFor(o => o.WindFromDirection, _ => "degrees")
                .RuleFor(o => o.WindSpeed, _ => "m/s");

            var forecastMeta = new Faker<Meta>()
                .RuleFor(o => o.Units, _ => forecastUnits.Generate())
                .RuleFor(o => o.UpdatedAt, _ => startTime);

            var forecastDetails = new Faker<Details>()
                .RuleFor(o => o.AirTemperature, _ => (float) random.Next(-30, 49) + random.NextDouble())
                .RuleFor(o => o.AirPressureAtSeaLevel, _ => (float) random.Next(900, 1100) + random.NextDouble())
                .RuleFor(o => o.CloudAreaFraction, _ => (float) random.Next(50, 100) + random.NextDouble())
                .RuleFor(o => o.PrecipitationAmount, _ => (float) random.NextDouble())
                .RuleFor(o => o.RelativeHumidity, _ => (float) random.NextDouble() * 100)
                .RuleFor(o => o.WindFromDirection, _ => (float) random.NextDouble() * 359)
                .RuleFor(o => o.WindSpeed, _ => (float) random.NextDouble() * 32.7);

            var forecastInstant = new Faker<Instant>()
                .RuleFor(o => o.Details, _ => forecastDetails.Generate());

            var forecastSummary = new Faker<Summary>()
                .RuleFor(o => o.SymbolCode,
                    _ => MetAPITools.ValidSymbolCodes[random.Next(MetAPITools.ValidSymbolCodes.Count)]);

            var next1Hours = new Faker<Next1Hours>()
                .RuleFor(o => o.Details, _ => forecastDetails.Generate())
                .RuleFor(o => o.Summary, _ => forecastSummary.Generate());

            var next6Hours = new Faker<Next6Hours>()
                .RuleFor(o => o.Details, _ => forecastDetails.Generate())
                .RuleFor(o => o.Summary, _ => forecastSummary.Generate());

            var next12Hours = new Faker<Next12Hours>()
                .RuleFor(o => o.Details, _ => forecastDetails.Generate())
                .RuleFor(o => o.Summary, _ => forecastSummary.Generate());

            var forecastData = new Faker<ForecastData>()
                .RuleFor(o => o.Instant, _ => forecastInstant.Generate())
                .RuleFor(o => o.Next1Hours, _ => next1Hours.Generate())
                .RuleFor(o => o.Next6Hours, _ => next6Hours.Generate())
                .RuleFor(o => o.Next12Hours, _ => next12Hours.Generate());

            var forecastTimeseries = new Faker<Timeseries>().RuleFor(o => o.Time, _ =>
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
                .RuleFor(o => o.ForecastData, _ => forecastData.Generate());

            var forecastProperties = new Faker<Properties>()
                .RuleFor(o => o.Meta, _ => forecastMeta.Generate())
                .RuleFor(o => o.Timeseries, _ =>
                {
                    var outCollection = new Collection<Timeseries>();
                    foreach (var timeseries in forecastTimeseries.Generate(85)) outCollection.Add(timeseries);

                    return outCollection;
                });

            var outForecast = new Faker<Forecast>()
                .StrictMode(true)
                .RuleFor(o => o.Type, _ => "Feature")
                .RuleFor(o => o.ForecastGeometry, _ => forecastGeometry.Generate())
                .RuleFor(o => o.ForecastProperties, _ => forecastProperties.Generate())
                .RuleFor(o => o.StoredMetadata, MockMetadata.GenerateStoredMetadata());

            return outForecast;
        }
    }
}