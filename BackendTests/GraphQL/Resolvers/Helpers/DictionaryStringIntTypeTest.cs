using System.Collections.Generic;
using Backend.utils.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.Helpers
{
    public class DictionaryStringIntTypeTest
    {
        private readonly DictionaryStringIntType _dictionaryStringIntType = new();

        private object ResolveField(string field)
        {
            return _dictionaryStringIntType.GetField(field).Resolver.Resolve(new ResolveFieldContext
            {
                Source = new Dictionary<string, int>()
                {
                    {"key1", 123},
                    {"key2", 456}
                }
            });
        }

        [Fact]
        public void GetKeys()
        {
            var keys = ResolveField("Keys");
            keys.ShouldBeOfType<Dictionary<string, int>.KeyCollection>();

            ((Dictionary<string, int>.KeyCollection) keys).ShouldBe(new[] {"key1", "key2"});
        }

        [Fact]
        public void GetValues()
        {
            var values = ResolveField("Values");
            values.ShouldBeOfType<Dictionary<string, int>.ValueCollection>();

            ((Dictionary<string, int>.ValueCollection) values).ShouldBe(new[] {123, 456});
        }
    }
}