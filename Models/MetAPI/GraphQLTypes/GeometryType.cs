using Backend.Models.MetAPI.POCO;
using GraphQL.Types;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class GeometryType : ObjectGraphType<Geometry>
    {
        public GeometryType()
        {
            Field(geometry => geometry.Coordinates, false, typeof(ListGraphType<FloatGraphType>))
                .Description("A list of lon, lat and altitude");
            Field(geometry => geometry.Type).Description("The type of geographical data");
        }
    }
}