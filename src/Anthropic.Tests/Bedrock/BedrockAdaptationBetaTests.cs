using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Bedrock;

public class BedrockAdaptationBetaTests
{
    private sealed class FakeBedrockCredentials : IAnthropicBedrockCredentials
    {
        public string Region => "us-east-1";

        public Task Apply(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation(
                "Authorization",
                "AWS4-HMAC-SHA256 test-signature"
            );
            return Task.CompletedTask;
        }
    }

    private record class JsonBodyParams : ParamsBase
    {
        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        ) { }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent("{\"model\":\"claude-sonnet-4-5\",\"max_tokens\":1024}");
    }

    private static async Task<string[]> SendWithBetaHeaderValues(params string[] headerValues)
    {
        string? wireBody = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>(
                (req, cancellationToken) =>
                {
                    wireBody = req.Content!.ReadAsStringAsync(
#if NET
                            cancellationToken
#endif
                        )
                        .GetAwaiter()
                        .GetResult();
                }
            )
            .ReturnsAsync(
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );

        var client = new AnthropicBedrockClient(new FakeBedrockCredentials())
        {
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>
            {
                Handler.Create(
                    (request, next, cancellationToken) =>
                    {
                        foreach (var headerValue in headerValues)
                        {
                            request.Headers.TryAddWithoutValidation("anthropic-beta", headerValue);
                        }
                        return next(request, cancellationToken);
                    }
                ),
            },
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(wireBody);
        var betas = JsonNode.Parse(wireBody!)!["anthropic_beta"]!.AsArray();
        return [.. betas.Select(beta => beta!.GetValue<string>())];
    }

    [Fact]
    public async Task AdaptRequest_SeparateBetaHeaderValues_SendsEachAsABeta()
    {
        var betas = await SendWithBetaHeaderValues("a", "b");
        Assert.Equal(["a", "b"], betas);
    }

    [Theory]
    [InlineData("a,b")]
    [InlineData("a, b")]
    public async Task AdaptRequest_CommaJoinedBetaHeaderValue_SendsEachAsABeta(string headerValue)
    {
        var betas = await SendWithBetaHeaderValues(headerValue);
        Assert.Equal(["a", "b"], betas);
    }
}
