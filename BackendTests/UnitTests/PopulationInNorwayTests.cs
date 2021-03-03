using System;
using Backend.Mocks.SSB;
using Backend.Models.SSB.POCO;
using Backend.utils;
using NUnit.Framework;

namespace BackendTests.UnitTests
{
    public class PopulationInNorwayTests
    {
        private Random _r;
        private readonly int _numMunicipalities = NorwayTools.MunicipalityCodeToIndex.Count;
        private readonly int _numYears = NorwayTools.YearToIndex.Count;
        private PopulationPerMunicipalityNorway _population;

        [SetUp]
        public void Setup()
        {
            _r = new Random();
            _population = MockPopulationInNorway.GenerateSamplePopulationsInNorway();
        }

        [Test]
        public void PopulationInNorwayAPIShouldReturnData()
        {
            Assert.NotNull(_population);
        }

        [Test]
        public void PopulationInNorwayShouldIncreasePerMunicipality()
        {
            var randomSample = _r.Next(_numMunicipalities, _population.Dataset.Value.Count - 1);
            var currYearPopulation = _population.Dataset.Value[randomSample];
            var prevYearPopulation = _population.Dataset.Value[randomSample - _numMunicipalities];
            Assert.Greater(currYearPopulation, prevYearPopulation);
            Assert.That(currYearPopulation - prevYearPopulation <= 500);
            Assert.That(currYearPopulation - prevYearPopulation >= 1);
        }

        [Test]
        public void PopulationInNorwayCorrectLabelAndSource()
        {
            Assert.AreEqual("07459: Befolkning, etter region, år og statistikkvariabel", _population.Dataset.Label);
            Assert.AreEqual("Statistisk sentralbyrå", _population.Dataset.Source);
        }

        [Test]
        public void PopulationInNorwayGeneratesCorrectAmountOfData()
        {
            Assert.AreEqual(_numMunicipalities * _numYears, _population.Dataset.Value.Count);
        }
    }
}