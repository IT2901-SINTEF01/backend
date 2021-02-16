using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class InstantType : ObjectGraphType<Instant>
    {
        public InstantType()
        {
            Field(instant => instant.Details, false, typeof(DetailsType));
        }
        
    }
}