using Backend.API.Data;
using GraphQL.Types;

namespace Backend.API.MetAPI
{
    public class DataType : ObjectGraphType<Forecast.Data>
    {
        public DataType()
        {
            Field(data => data.Instant, false, typeof(InstantType));
            Field(data => data.Next1Hours, false, typeof(Next1HoursType));
            Field(data => data.Next6Hours, false, typeof(Next6HoursType));
            Field(data => data.Next12Hours, false, typeof(Next12HoursType));
        }
    }
}