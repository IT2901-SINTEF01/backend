using Backend.Models.Base.Metadata.GraphQLTypes;
using Xunit;

namespace BackendTests.GraphQLTests
{
    public class VisualisationTypeTest
    {
        private readonly VisualisationType _visualisationType;

        public VisualisationTypeTest()
        {
            _visualisationType = new VisualisationType();
        }

        [Fact]
        public void TestType()
        {
            Assert.IsType<VisualisationType>(_visualisationType);
        }
    }
}