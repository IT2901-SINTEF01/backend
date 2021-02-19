using System;
using Backend.API.Queries;
using GraphQL.Types;

namespace Backend.API.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider provider) : base(provider)
        {
            Query = new RootQuery(provider);
        }
    }
}