using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic;
using Anthropic.Core;
using Anthropic.Exceptions;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests;

public class ApiExceptionTest : TestBase
{
    record class BlankParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // do nothing
        }

        public override Uri Url(ClientOptions _options)
        {
            return new Uri("http://localhost/something");
        }
    }

    [Theory]
    [InlineData(
        "length limit exceeded",
        "Status Code: RequestEntityTooLarge\nlength limit exceeded"
    )]
    [InlineData("", "Status Code: RequestEntityTooLarge")]
    public async Task NonJsonErrorBody_Works(string body, string expectedMessage)
    {
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(
                new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.RequestEntityTooLarge,
                    Content = new StringContent(body, null, "text/plain"),
                }
            );

        var httpClient = new HttpClient(handlerMock.Object);

        AnthropicClient client = new() { HttpClient = httpClient };

        var exception = await Assert.ThrowsAnyAsync<AnthropicApiException>(() =>
            client.WithRawResponse.Execute(
                new HttpRequest<BlankParams> { Method = HttpMethod.Get, Params = new() },
                TestContext.Current.CancellationToken
            )
        );

        Assert.Equal(HttpStatusCode.RequestEntityTooLarge, exception.StatusCode);
        Assert.Equal(body, exception.ResponseBody);
        Assert.Equal(expectedMessage, exception.Message);
    }
}
