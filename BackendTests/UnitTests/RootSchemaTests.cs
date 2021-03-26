using System;
using Backend.API.Queries;
using Backend.API.Schemas;
using Moq;
using Shouldly;
using Xunit;

namespace BackendTests.UnitTests
{
    public class RootSchemaTests
    {
        private readonly RootSchema _rootSchema;


        public RootSchemaTests()
        {
            var serviceProvider = Mock.Of<IServiceProvider>();
            _rootSchema = new RootSchema(serviceProvider);
        }

        [Fact]
        public void RootSchemaIsCorrectType()
        {
            Assert.IsType<RootSchema>(_rootSchema);
        }

        [Fact]
        public void RootSchemaHasQueryType()
        {
            _rootSchema.Query.ShouldBeOfType<RootQuery>();
        }

        [Fact]
        public void RootSchemaIsNotNull()
        {
            Assert.NotNull(_rootSchema);
        }
    }
}