using Backend.API.MetAPI.SubClasses;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class Next1HoursType : ObjectGraphType<Next1Hours>
    {
        public Next1HoursType()
        {
            Field(next => next.Details, false, typeof(DetailsType));
            Field(next => next.Summary.SymbolCode);
        }
    }
}