using GraphQL.Types;

namespace Backend.API.ObjectGraphTypes
{
    /// <summary>
    /// The GraphQL object type that will be the result of the resolution.
    /// This represents what the client may request.
    /// </summary>
    public class WeatherPrediction : ObjectGraphType
    {
        public WeatherPrediction(string name, int temp)
        {
            Field<StringGraphType>("name", resolve: _ => name);
            Field<IntGraphType>("temperature", resolve: _ => temp);
        }
    }
}