using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public sealed class ForecastDataType : ObjectGraphType<ForecastData>
    {
        public ForecastDataType()
        {
            Field(data => data.Instant, false, typeof(InstantType)).Description("Details about current data");
            Field(data => data.Next1Hours, false, typeof(Next1HoursType))
                .Description("Summary and details(inconsistent data available)");
            Field(data => data.Next6Hours, false, typeof(Next6HoursType))
                .Description("Summary and details(inconsistent data available)");
            Field(data => data.Next12Hours, false, typeof(Next12HoursType))
                .Description("Summary and details(inconsistent data available)");
            /*
             * Instant does only contain Details, while the others also have a summary
             */
        }
    }
}