using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class UnitsType : ObjectGraphType<Units>
    {
        public UnitsType()
        {
            Field(units => units.AirTemperature);
            Field(units => units.PrecipitationAmount);
            Field(units => units.RelativeHumidity);
            Field(units => units.WindSpeed);
            Field(units => units.AirTemperatureMax);
            Field(units => units.AirTemperatureMin);
            Field(units => units.CloudAreaFraction);
            Field(units => units.DewPointTemperature);
            Field(units => units.FogAreaFraction);
            Field(units => units.PrecipitationAmountMax);
            Field(units => units.PrecipitationAmountMin);
            Field(units => units.ProbabilityOfPrecipitation);
            Field(units => units.ProbabilityOfThunder);
            Field(units => units.WindFromDirection);
            Field(units => units.CloudAreaFractionHigh);
            Field(units => units.CloudAreaFractionLow);
            Field(units => units.CloudAreaFractionMedium);
            Field(units => units.WindSpeedOfGust);
            Field(units => units.AirPressureAtSeaLevel);
            Field(units => units.UltravioletIndexClearSkyMax);
        }
        
    }
}