using System;
using Backend.API.Services;
using Xunit;

namespace BackendTests.UnitTests
{
    public class MetAPIServiceTests
    {
        private readonly float _lat;
        private readonly float _lon;
        private readonly MetAPIServiceMocked _metAPIServiceMocked;
        private readonly Random _random;


        public MetAPIServiceTests()
        {
            _metAPIServiceMocked = new MetAPIServiceMocked();
            _random = new Random();
            _lon = (float) _random.NextDouble() * (63.433f - 63.42f) + 63.42f;
            _lat = (float) _random.NextDouble() * (10.4f - 10.38f) + 10.38f;
        }

        [Fact]
        public void MetAPIServiceMockedIsNotNull()
        {
            Assert.NotNull(_metAPIServiceMocked.GetCompactForecast(_lat, _lon));
        }

        [Fact]
        public void MetAPIServiceMockedIsCorrectType()
        {
            Assert.IsType<MetAPIServiceMocked>(_metAPIServiceMocked);
        }
    }
}