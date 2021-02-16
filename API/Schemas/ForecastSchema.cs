using System;
using Backend.API.Queries;
using Backend.API.Services;

namespace Backend.API.Schemas
{
    public class ForecastSchema : GraphQL.Types.Schema
    {
        public ForecastSchema(IForecastDataRetrievalService forecastDataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new ForecastQuery(forecastDataRetrievalService);
        }
    }
}