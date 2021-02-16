using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class MetaType : ObjectGraphType<Forecast.Meta>
    {
        public MetaType()
        {
            Field(meta => meta.Units, false, typeof(UnitsType));
            Field(meta => meta.UpdatedAt);
        }
    }
}