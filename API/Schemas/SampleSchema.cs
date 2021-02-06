using System;
using Backend.API.Queries;
using GraphQL.Types;

namespace Backend.API.Schemas
{
    public class SampleSchema : Schema
    {
        public SampleSchema(IServiceProvider provider) : base(provider)
        {
            Query = new SampleQuery();
        }
    }
}