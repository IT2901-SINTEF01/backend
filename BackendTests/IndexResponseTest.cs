using System;
using NUnit.Framework;
using Backend;

namespace BackendTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SanityCheck()
        {
            Assert.Pass();
        }

        [Test]
        public void SetAndGet()
        {
            var today = DateTime.Today;
            var message = "Testing, Jeremiah. How do you feel about birds taking the train?";

            var response = new Backend.IndexResponse()
            {
                Date = today,
                Message = message
            };

            Assert.AreEqual(today, response.Date);
            Assert.AreEqual(message, response.Message);
        }
    }
}