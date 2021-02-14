using Backend.API.ObjectGraphTypes;
using Backend.API.Queries.Resolvers;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class Query : ObjectGraphType
    {
        public Query(IWeatherPredictionResolver resolver)
        {
            Field<WeatherPrediction>("value", resolve: _ => resolver.GetValue());
        }
    }
}