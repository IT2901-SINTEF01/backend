using System;
using Backend.API.Queries;
using Backend.API.Services;

namespace Backend.API.Schemas
{
    public class RootSchema : GraphQL.Types.Schema
    {
        public RootSchema(IDataRetrievalService dataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new Query(dataRetrievalService);
        }
    }
}