using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
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