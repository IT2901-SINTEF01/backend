using System;
using Backend.Mocks.SSB;
using Backend.Models.SSBPopulationStatistics.POCO;
using Backend.utils;
using Xunit;

namespace BackendTests.UnitTests
{
    public class PopulationInNorwayTests
    {
        private readonly int _numMunicipalities = NorwayTools.MunicipalityCodeToIndex.Count;
        private readonly int _numYears = NorwayTools.YearToIndex.Count;
        private readonly PopulationPerMunicipalityNorway _population;
        private readonly Random _r;

        public PopulationInNorwayTests()
        {
            _r = new Random();
            _population = MockPopulationInNorway.GenerateSamplePopulationsInNorway();
        }

        [Fact]
        public void PopulationInNorwayAPIShouldReturnData()
        {
            Assert.NotNull(_population);
        }

        [Fact]
        public void PopulationInNorwayShouldIncreasePerMunicipality()
        {
            var randomSample = _r.Next(_numMunicipalities, _population.Dataset.Value.Count - 1);
            var currYearPopulation = _population.Dataset.Value[randomSample];
            var prevYearPopulation = _population.Dataset.Value[randomSample - _numMunicipalities];

            Assert.True(currYearPopulation > prevYearPopulation);
            Assert.True(currYearPopulation - prevYearPopulation <= 500);
            Assert.True(currYearPopulation - prevYearPopulation >= 1);
        }

        [Fact]
        public void PopulationInNorwayCorrectLabelAndSource()
        {
            Assert.Equal("07459: Befolkning, etter region, år og statistikkvariabel", _population.Dataset.Label);
            Assert.Equal("Statistisk sentralbyrå", _population.Dataset.Source);
        }

        [Fact]
        public void PopulationInNorwayGeneratesCorrectAmountOfData()
        {
            Assert.Equal(_numMunicipalities * _numYears, _population.Dataset.Value.Count);
        }
    }
}