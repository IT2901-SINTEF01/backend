using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Backend.API.Data.GeographicalModels {
    public class MetApiCompact {
        public class Geometry {
            [JsonPropertyName("type")] public string Type { get; set; }

            [JsonPropertyName("coordinates")] public List<double> Coordinates { get; set; }
        }

        public class Units {
            [JsonPropertyName("air_pressure_at_sea_level")]
            public string AirPressureAtSeaLevel { get; set; }

            [JsonPropertyName("air_temperature")] public string AirTemperature { get; set; }

            [JsonPropertyName("cloud_area_fraction")]
            public string CloudAreaFraction { get; set; }

            [JsonPropertyName("precipitation_amount")]
            public string PrecipitationAmount { get; set; }

            [JsonPropertyName("relative_humidity")]
            public string RelativeHumidity { get; set; }

            [JsonPropertyName("wind_from_direction")]
            public string WindFromDirection { get; set; }

            [JsonPropertyName("wind_speed")] public string WindSpeed { get; set; }
        }

        public class Meta {
            [JsonPropertyName("updated_at")] public DateTime UpdatedAt { get; set; }

            [JsonPropertyName("units")] public Units Units { get; set; }
        }

        public class Details {
            [JsonPropertyName("air_pressure_at_sea_level")]
            public double AirPressureAtSeaLevel { get; set; }

            [JsonPropertyName("air_temperature")] public double AirTemperature { get; set; }

            [JsonPropertyName("cloud_area_fraction")]
            public double CloudAreaFraction { get; set; }

            [JsonPropertyName("relative_humidity")]
            public double RelativeHumidity { get; set; }

            [JsonPropertyName("wind_from_direction")]
            public double WindFromDirection { get; set; }

            [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; }

            [JsonPropertyName("precipitation_amount")]
            public double PrecipitationAmount { get; set; }
        }

        public class Instant {
            [JsonPropertyName("details")] public Details Details { get; set; }
        }

        public class Summary {
            [JsonPropertyName("symbol_code")] public string SymbolCode { get; set; }
        }

        public class Next12Hours {
            [JsonPropertyName("summary")] public Summary Summary { get; set; }
        }

        public class Next1Hours {
            [JsonPropertyName("summary")] public Summary Summary { get; set; }

            [JsonPropertyName("details")] public Details Details { get; set; }
        }

        public class Next6Hours {
            [JsonPropertyName("summary")] public Summary Summary { get; set; }

            [JsonPropertyName("details")] public Details Details { get; set; }
        }

        public class Data {
            [JsonPropertyName("instant")] public Instant Instant { get; set; }

            [JsonPropertyName("next_12_hours")] public Next12Hours Next12Hours { get; set; }

            [JsonPropertyName("next_1_hours")] public Next1Hours Next1Hours { get; set; }

            [JsonPropertyName("next_6_hours")] public Next6Hours Next6Hours { get; set; }
        }

        public class Timeseries {
            [JsonPropertyName("time")] public DateTime Time { get; set; }

            [JsonPropertyName("data")] public Data Data { get; set; }
        }

        public class Properties {
            [JsonPropertyName("meta")] public Meta Meta { get; set; }

            [JsonPropertyName("timeseries")] public List<Timeseries> Timeseries { get; set; }
        }

        public class Root {
            [JsonPropertyName("type")] public string Type { get; set; }

            [JsonPropertyName("geometry")] public Geometry Geometry { get; set; }

            [JsonPropertyName("properties")] public Properties Properties { get; set; }
        }
    }
}