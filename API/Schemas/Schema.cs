using System;
using Backend.API.Queries;
using Backend.API.Services;

namespace Backend.API.Schemas
{
    public class Schema : GraphQL.Types.Schema
    {
        public Schema(IDataRetrievalService dataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new Query(dataRetrievalService);
        }
    }
}