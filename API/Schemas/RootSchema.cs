using System;
using Backend.API.Queries;
using Backend.API.Services;
using GraphQL.Types;

namespace Backend.API.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IDataRetrievalService dataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new RootQuery(dataRetrievalService);
        }
    }
}