using System.Linq;
using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.MetAPI.GraphQLTypes;
using Backend.Models.MetAPI.POCO;
using GraphQL;
using Shouldly;
using Xunit;

namespace BackendTests.GraphQLTests
{
    public static class FieldBuilderTests
    {
        [Fact]
        public static void ShouldHaveDescriptionAndType()
        {
            var forecastObjectType = new ForecastType(new MetadataServiceMocked());
            var fields = forecastObjectType.Fields.ToList();
            fields.Count.ShouldBe(4);
            fields[0].Description.ShouldBe("Metadata for a data source with id MET_API.");
            fields[0].Type.ShouldBe(typeof(StoredMetadataType));
            fields[1].Description.ShouldBe("The Geo-Data used in the query");
            fields[1].Type.ShouldBe(typeof(GeometryType));
        }

        [Fact]
        public static void CanAccessObject()
        {
            var forecastObjectType = new ForecastType(new MetadataServiceMocked());
            forecastObjectType.Field<GeometryType>().Resolve(context =>
            {
                context.Source.ShouldBe(new Forecast());
                return null;
            });
            var field = forecastObjectType.Fields.First();
            field.Resolver.Resolve(new ResolveFieldContext
            {
                Source = new Forecast()
            });
        }
    }
}