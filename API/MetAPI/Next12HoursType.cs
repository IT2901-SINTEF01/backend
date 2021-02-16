using Backend.API.Data;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class Next12HoursType : ObjectGraphType<Forecast.Next12Hours>
    {
        public Next12HoursType()
        {
            Field(next => next.Details, false, typeof(DetailsType));
            Field(next => next.Summary.SymbolCode);
        }
    }
}