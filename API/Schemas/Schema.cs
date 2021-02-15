using System;
using Backend.API.Queries;
using Backend.API.Services;

namespace Backend.API.Schemas
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(IForecastDataRetrievalService forecastDataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new ForecastQuery(forecastDataRetrievalService);
            //Query = new TodoQuery(dataRetrievalService);
        }
    }
}