using Backend.API.Data;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class InstantType : ObjectGraphType<Forecast.Instant>
    {
        public InstantType()
        {
            Field(instant => instant.Details, false, typeof(DetailsType));
        }
        
    }
}