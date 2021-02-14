using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Backend.API.Queries;
using Backend.API.Queries.Resolvers;
using Backend.API.Schemas;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using GraphQL;
using GraphQL.Client.Http;
using NUnit.Framework;

namespace BackendTests
{
    public class GeoJsonTest
    {
        [Test]
        public async Task GeoJson_SampleTest()
        {
            // Using an IDisposable interface to quickly and easily do GC when running tests.
            // Reasoning as to why mocking loosely: https://stackoverflow.com/questions/4996327/moq-strict-vs-loose-usage
            using (var mock = AutoMock.GetLoose())
            {
                // Sets up the mocking of a query.
                mock.Mock<SampleQuery>()
                    // Here, what should be happening is that we execute some query
                    // e.g. ".Setup(x => x.LoadGeoJSONDataFromMetAPI<FeatureCollection>()"
                    .Setup(_ => GetSampleData())
                    // This is simply what is returned.
                    .Returns(GetSampleData());

                /*
                 Change this. As of how the code is written right now, the SampleQuery will return the data from
                 the GetSampleData method. Although
                */
                var cls = mock.Create<SampleSchema>();

                var expected = GetSampleData();

                var client = new GraphQLHttpClient("", null!);
                var request = new GraphQLRequest(@"query { value }");
                var actual = await client.SendQueryAsync<FeatureCollection>(request);

                Assert.IsNotNull(actual.Data);
                Assert.AreEqual(expected.Features.Count, actual.Data.Features.Count);
                
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Generates some dummy GeoJSON data.
        /// </summary>
        /// <returns>An arbitrarily chosen <see cref="GeoJSON.Net.Feature.FeatureCollection"/></returns>
        private FeatureCollection GetSampleData()
        {
            IEnumerable<Position> positions = new[]
            {
                new Position(63.43423, 10.39684), new Position(63.41811, 10.39610)
            };
            FeatureCollection outData = new FeatureCollection(
                new List<Feature>
                {
                    new(
                        new Point(new Position(63.43423, 10.39684))),
                    new(new LineString(positions))
                });
            return outData;
        }
    }
}