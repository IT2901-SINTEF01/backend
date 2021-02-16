using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class ForecastDataType : ObjectGraphType<ForecastData>
    {
        public ForecastDataType()
        {
            Field(data => data.Instant, false, typeof(InstantType)); 
            Field(data => data.Next1Hours, false, typeof(Next1HoursType));
            Field(data => data.Next6Hours, false, typeof(Next6HoursType));
            Field(data => data.Next12Hours, false, typeof(Next12HoursType));
            /*
             * Instant does only contain Details, while the others also have a summary
             * Very redundant solution of creating a Type for each when in essence they are the same, but it works.
             */
        }
    }
}