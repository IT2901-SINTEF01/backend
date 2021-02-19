using System.Text.Json.Serialization;

namespace Backend.Models.MetAPI.POCO
{
    public class Details
    {
        [JsonPropertyName("fog_area_fraction")]
        public double FogAreaFraction { get; set; }

        [JsonPropertyName("dew_point_temperature")]
        public double DewPointTemperature { get; set; }

        [JsonPropertyName("relative_humidity")]
        public double RelativeHumidity { get; set; }

        [JsonPropertyName("cloud_area_fraction_high")]
        public double CloudAreaFractionHigh { get; set; }

        [JsonPropertyName("wind_from_direction")]
        public double WindFromDirection { get; set; }

        [JsonPropertyName("cloud_area_fraction_medium")]
        public double CloudAreaFractionMedium { get; set; }

        [JsonPropertyName("cloud_area_fraction")]
        public double CloudAreaFraction { get; set; }

        [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; }

        [JsonPropertyName("air_temperature")] public double AirTemperature { get; set; }

        [JsonPropertyName("wind_speed_of_gust")]
        public double WindSpeedOfGust { get; set; }

        [JsonPropertyName("air_pressure_at_sea_level")]
        public double AirPressureAtSeaLevel { get; set; }

        [JsonPropertyName("cloud_area_fraction_low")]
        public double CloudAreaFractionLow { get; set; }

        [JsonPropertyName("air_temperature_max")]
        public double AirTemperatureMax { get; set; }

        [JsonPropertyName("precipitation_amount_max")]
        public double PrecipitationAmountMax { get; set; }

        [JsonPropertyName("precipitation_amount_min")]
        public double PrecipitationAmountMin { get; set; }

        [JsonPropertyName("probability_of_precipitation")]
        public int ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("probability_of_thunder")]
        public double ProbabilityOfThunder { get; set; }

        [JsonPropertyName("ultraviolet_index_clear_sky_max")]
        public int UltravioletIndexClearSkyMax { get; set; }

        [JsonPropertyName("air_temperature_min")]
        public double AirTemperatureMin { get; set; }

        [JsonPropertyName("precipitation_amount")]
        public double PrecipitationAmount { get; set; }
    }
}