using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class MetaType : ObjectGraphType<Meta>
    {
        public MetaType()
        {
            Field(meta => meta.Units, false, typeof(UnitsType));
            Field(meta => meta.UpdatedAt);
        }
    }
}