using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;

namespace BackendTests.MockHelpers
{
    public static class HttpClientMocker
    {
        /// <summary>
        /// Creates a HTTP-client with overridden return value used for mocking purposes.
        /// </summary>
        /// <param name="url">URL that should be mocked.</param>
        /// <param name="responseValue">Serialised object that should be returned.</param>
        /// <returns></returns>
        public static HttpClient SetupHttpClientMock(string url, string responseValue)
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(responseValue),
                })
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(url),
            };

            return httpClient;
        }
    }
}