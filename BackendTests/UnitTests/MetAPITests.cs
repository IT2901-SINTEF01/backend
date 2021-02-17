using System;
using System.Text.Json;
using Backend.API.MetAPI;
using Backend.API.Queries;
using Backend.API.Schemas;
using Backend.API.Services;
using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Abstractions.Websocket;
using GraphQL.Client.Http;
using Moq;
using NUnit.Framework;

namespace BackendTests.UnitTests {
    public class MetAPITests {
        private float _lon;
        private float _lat;
        private ForecastDataRetrievalService _service;

        [SetUp]
        public void Setup() {
            _lon = 63.446827f;
            _lat = 10.421906f;
            _service = new ForecastDataRetrievalService();
        }

        [Test]
        public void MetAPI_ShouldReturnDefaultValues() {
            var response = _service.GetForecast(_lat, _lon);
            Console.WriteLine(response);
        }
    }
}