using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backend.utils.GraphQLTypes;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQL.Resolvers.Helpers
{
    public class DictionaryStringCollectionStringTypeTest
    {
        private readonly DictionaryStringCollectionStringType _dictionaryStringCollectionStringType = new();

        private object ResolveField(string field)
        {
            return _dictionaryStringCollectionStringType.GetField(field).Resolver.Resolve(new ResolveFieldContext
            {
                Source = new Dictionary<string, Collection<string>>
                {
                    {"key1", new Collection<string>(new List<string> {"value1"})},
                    {"key2", new Collection<string>(new List<string> {"value2"})}
                }
            });
        }

        [Fact]
        public void GetKeys()
        {
            var keys = ResolveField("Keys");
            keys.ShouldBeOfType<Dictionary<string, Collection<string>>.KeyCollection>();

            ((Dictionary<string, Collection<string>>.KeyCollection) keys).ShouldContain("key1");
            ((Dictionary<string, Collection<string>>.KeyCollection) keys).ShouldContain("key2");
        }

        [Fact]
        public void GetValues()
        {
            var values = ResolveField("Values");
            values.ShouldBeOfType<Dictionary<string, Collection<string>>.ValueCollection>();

            // Only two elements, so we can safely use First/Last
            ((Dictionary<string, Collection<string>>.ValueCollection) values).First().First().ShouldBe("value1");
            ((Dictionary<string, Collection<string>>.ValueCollection) values).Last().First().ShouldBe("value2");
        }
    }
}