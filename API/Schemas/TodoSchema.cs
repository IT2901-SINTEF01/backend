using System;
using Backend.API.Queries;
using Backend.API.Services;

namespace Backend.API.Schemas
{
    public class TodoSchema : GraphQL.Types.Schema
    {
        public TodoSchema(IDataRetrievalService dataRetrievalService, IServiceProvider provider) : base(provider)
        {
            Query = new TodoQuery(dataRetrievalService);
        }
    }
}