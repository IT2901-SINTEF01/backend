using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public sealed class InstantType : ObjectGraphType<Instant>
    {
        public InstantType()
        {
            Field(instant => instant.Details, false, typeof(DetailsType))
                .Description("Details about the forecast, fields should be self explanatory");
        }
    }
}