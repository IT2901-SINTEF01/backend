using System.Collections.Generic;
using Backend.utils.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.Helpers
{
    public class DictionaryStringStringTypeTest
    {
        private readonly DictionaryStringStringType _dictionaryStringStringType = new();

        private object ResolveField(string field)
        {
            return _dictionaryStringStringType.GetField(field).Resolver.Resolve(new ResolveFieldContext
            {
                Source = new Dictionary<string, string>
                {
                    {"key1", "value1"},
                    {"key2", "value2"}
                }
            });
        }

        [Fact]
        public void GetKeys()
        {
            var keys = ResolveField("Keys");
            keys.ShouldBeOfType<Dictionary<string, string>.KeyCollection>();

            ((Dictionary<string, string>.KeyCollection) keys).ShouldBe(new[] {"key1", "key2"});
        }

        [Fact]
        public void GetValues()
        {
            var values = ResolveField("Values");
            values.ShouldBeOfType<Dictionary<string, string>.ValueCollection>();

            ((Dictionary<string, string>.ValueCollection) values).ShouldBe(new[] {"value1", "value2"});
        }
    }
}