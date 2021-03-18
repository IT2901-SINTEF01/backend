using System;
using Backend.API.Queries;
using Moq;
using Xunit;

namespace BackendTests.UnitTests
{
    public class RootQueryTests
    {
        private readonly RootQuery _rootQuery;

        public RootQueryTests()
        {
            var serviceProver = Mock.Of<IServiceProvider>();
            _rootQuery = new RootQuery(serviceProver);
        }

        [Fact]
        public void RootQueryIsCorrectType()
        {
            Assert.IsType<RootQuery>(_rootQuery);
        }

        [Fact]
        public void RootQueryIsNotNull()
        {
            Assert.NotNull(_rootQuery);
        }

        [Fact]
        public void RootQueryHasField_allMetadata()
        {
            Assert.True(_rootQuery.HasField("allMetadata"));
        }

        [Fact]
        public void RootQueryHasField_forecast()
        {
            Assert.True(_rootQuery.HasField("forecast"));
        }
    }
}