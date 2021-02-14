using System;
using Backend.API.Queries;
using Backend.API.Queries.Resolvers;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.API.Schemas
{
    public class SampleSchema : Schema
    {
        public SampleSchema(IServiceProvider provider) : base(provider)
        {
            Query = new Query(provider.GetService<IWeatherPredictionResolver>());
        }
    }
}