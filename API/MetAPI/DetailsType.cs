using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class DetailsType : ObjectGraphType<Forecast.Details>
    {
        public DetailsType()
        {
            Field(details => details.AirTemperature);
            Field(details => details.PrecipitationAmount);
            Field(details => details.RelativeHumidity);
            Field(details => details.WindSpeed);
            Field(details => details.AirTemperatureMax);
            Field(details => details.AirTemperatureMin);
            Field(details => details.CloudAreaFraction);
            Field(details => details.DewPointTemperature);
            Field(details => details.FogAreaFraction);
            Field(details => details.PrecipitationAmountMax);
            Field(details => details.PrecipitationAmountMin);
            Field(details => details.ProbabilityOfPrecipitation);
            Field(details => details.ProbabilityOfThunder);
            Field(details => details.WindFromDirection);
            Field(details => details.CloudAreaFractionHigh);
            Field(details => details.CloudAreaFractionLow);
            Field(details => details.CloudAreaFractionMedium);
            Field(details => details.WindSpeedOfGust);
            Field(details => details.AirPressureAtSeaLevel);
            Field(details => details.UltravioletIndexClearSkyMax);
        }
        
    }
}