using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Exceptions;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Bedrock;

/// <summary>
/// Verifies that the Bedrock adaptation rewrites the request URL without losing
/// parts of the configured base URL (e.g. a non-default port for a local proxy
/// or test server).
/// </summary>
public class BedrockAdaptationUrlTests
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
        public string Model { get; set; } = "claude-sonnet-4-5";

        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // Skip default headers so ambient ANTHROPIC_* env vars can't interfere.
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent($"{{\"model\":\"{Model}\",\"max_tokens\":1024}}");
    }

    private static async Task<Uri> SendWithModel(string model, List<Uri>? sent = null)
    {
        Uri? wireUri = null;
        var handlerMock = new Mock<HttpMessageHandler>();
        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .Callback<HttpRequestMessage, CancellationToken>(
                (req, _) =>
                {
                    wireUri = req.RequestUri;
                    sent?.Add(req.RequestUri!);
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
            BaseUrl = "http://127.0.0.1:8080",
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>(),
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams>
            {
                Method = HttpMethod.Post,
                Params = new() { Model = model },
            },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(wireUri);
        return wireUri!;
    }

    [Fact]
    public async Task AdaptRequest_BaseUrlWithNonDefaultPort_PreservesPort()
    {
        var wireUri = await SendWithModel("claude-sonnet-4-5");

        Assert.Equal("127.0.0.1:8080", wireUri.Authority);
        Assert.Equal(8080, wireUri.Port);
        Assert.Equal("/model/claude-sonnet-4-5/invoke", wireUri.AbsolutePath);
    }

    [Theory]
    [InlineData(
        "us.anthropic.claude-sonnet-4-20250514-v1:0",
        "us.anthropic.claude-sonnet-4-20250514-v1:0"
    )]
    [InlineData(
        "arn:aws:bedrock:us-east-1:123456789012:inference-profile/us.anthropic.claude-sonnet-4-20250514-v1:0",
        "arn:aws:bedrock:us-east-1:123456789012:inference-profile%2Fus.anthropic.claude-sonnet-4-20250514-v1:0"
    )]
    [InlineData("a;b", "a;b")]
    [InlineData("...;x", "...;x")]
    [InlineData("x;..", "x;..")]
    public async Task AdaptRequest_Model_IsOnePathSegment(string model, string expectedSegment)
    {
        var wireUri = await SendWithModel(model);

        Assert.Equal($"http://127.0.0.1:8080/model/{expectedSegment}/invoke", wireUri.AbsoluteUri);
    }

    [Theory]
    [InlineData("")]
    [InlineData(".")]
    [InlineData("..")]
    // A server may drop ";" and what follows it, which leaves the part before it as the segment.
    [InlineData(";x")]
    [InlineData(".;x")]
    [InlineData("..;x")]
    public async Task AdaptRequest_EmptyOrDotSegmentModel_Throws(string model)
    {
        var sent = new List<Uri>();

        var exception = await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            SendWithModel(model, sent)
        );

        Assert.Contains("model", exception.Message);
        Assert.Empty(sent);
    }
}
