using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Vertex;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.Vertex;

/// <summary>
/// Verifies that the Vertex adaptation rewrites the request URL without losing
/// parts of the configured base URL (e.g. a non-default port for a local proxy
/// or test server).
/// </summary>
public class VertexAdaptationUrlTests
{
    private sealed class FakeVertexCredentials : IAnthropicVertexCredentials
    {
        public string Region { get; set; } = "us-east5";
        public string Project { get; set; } = "test-project";

        public ValueTask ApplyAsync(HttpRequestMessage requestMessage)
        {
            requestMessage.Headers.TryAddWithoutValidation("Authorization", "Bearer vertex-token");
            return default;
        }
    }

    private record class JsonBodyParams : ParamsBase
    {
        public string Model { get; set; } = "claude-sonnet-4-5";
        public bool Stream { get; set; }

        internal override void AddHeadersToRequest(
            HttpRequestMessage _request,
            ClientOptions _options
        )
        {
            // Skip default headers so ambient ANTHROPIC_* env vars can't interfere.
        }

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}/v1/messages");

        internal override HttpContent? BodyContent() =>
            new StringContent(
                $"{{\"model\":\"{Model}\",\"max_tokens\":1024{(Stream ? ",\"stream\":true" : "")}}}"
            );
    }

    private static async Task<Uri> SendWithModel(
        string model,
        string project = "test-project",
        string region = "us-east5",
        bool stream = false,
        List<Uri>? sent = null
    )
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

        var client = new AnthropicVertexClient(
            new FakeVertexCredentials { Project = project, Region = region }
        )
        {
            BaseUrl = "http://127.0.0.1:8080",
            HttpClient = new HttpClient(handlerMock.Object),
            Handlers = new List<DelegatingHandler>(),
        };

        var response = await client.WithRawResponse.Execute(
            new HttpRequest<JsonBodyParams>
            {
                Method = HttpMethod.Post,
                Params = new() { Model = model, Stream = stream },
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
        Assert.Equal(
            "/v1/projects/test-project/locations/us-east5/publishers/anthropic/models/claude-sonnet-4-5:rawPredict",
            wireUri.AbsolutePath
        );
    }

    [Theory]
    [InlineData("claude-sonnet-4-5@20250929", "claude-sonnet-4-5@20250929")]
    [InlineData("../../x", "..%2F..%2Fx")]
    public async Task AdaptRequest_Model_IsOnePathSegment(string model, string expectedSegment)
    {
        var wireUri = await SendWithModel(model);

        Assert.Equal(
            $"/v1/projects/test-project/locations/us-east5/publishers/anthropic/models/{expectedSegment}:rawPredict",
            wireUri.AbsolutePath
        );
    }

    [Theory]
    // The suffix is part of the segment, so a server that drops ";" parameters would drop it after a raw ";".
    [InlineData("a;b", false, "a%3Bb:rawPredict")]
    [InlineData("a;b", true, "a%3Bb:streamRawPredict")]
    [InlineData("...;x", false, "...%3Bx:rawPredict")]
    [InlineData("..x;y", false, "..x%3By:rawPredict")]
    [InlineData("x;..", false, "x%3B..:rawPredict")]
    // With the suffix, these aren't dot-segments.
    [InlineData("..", false, "..:rawPredict")]
    [InlineData(".", true, ".:streamRawPredict")]
    public async Task AdaptRequest_ModelThatLeavesNoDotSegment_IsSent(
        string model,
        bool stream,
        string expectedSegment
    )
    {
        var wireUri = await SendWithModel(model, stream: stream);

        Assert.Equal(
            $"http://127.0.0.1:8080/v1/projects/test-project/locations/us-east5/publishers/anthropic/models/{expectedSegment}",
            wireUri.AbsoluteUri
        );
    }

    [Theory]
    [InlineData("..;x", false)]
    [InlineData("..;x", true)]
    [InlineData(".;x", false)]
    [InlineData("..;", false)]
    [InlineData(".;a=b", true)]
    public async Task AdaptRequest_ModelThatIsADotSegmentBeforeSemicolon_Throws(
        string model,
        bool stream
    )
    {
        var exception = await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            SendWithModel(model, stream: stream)
        );
        Assert.Equal(
            $"'model' value \"{model}\" is a dot-segment and can't be safely passed as a path parameter",
            exception.Message
        );
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("", true)]
    [InlineData(";x", false)]
    [InlineData(";x", true)]
    [InlineData(";", false)]
    [InlineData(";a=b", false)]
    public async Task AdaptRequest_ModelThatIsEmptyOrEmptyBeforeSemicolon_Throws(
        string model,
        bool stream
    )
    {
        var exception = await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            SendWithModel(model, stream: stream)
        );
        Assert.Equal("Expected a non-empty value for `model`", exception.Message);
    }

    [Theory]
    [InlineData("my-proj-123", "us-east5", "my-proj-123", "us-east5")]
    [InlineData("example.com:my-proj", "global", "example.com:my-proj", "global")]
    [InlineData("a/b", "us-east5", "a%2Fb", "us-east5")]
    [InlineData("my-proj-123", "../x", "my-proj-123", "..%2Fx")]
    [InlineData("a;b", "us-east5", "a;b", "us-east5")]
    [InlineData("...;x", "us-east5", "...;x", "us-east5")]
    [InlineData("my-proj-123", "a;b", "my-proj-123", "a;b")]
    [InlineData("my-proj-123", "x;..", "my-proj-123", "x;..")]
    public async Task AdaptRequest_ProjectAndRegion_AreOnePathSegmentEach(
        string project,
        string region,
        string expectedProject,
        string expectedRegion
    )
    {
        var wireUri = await SendWithModel("claude-sonnet-4-5", project, region);

        Assert.Equal(
            $"http://127.0.0.1:8080/v1/projects/{expectedProject}/locations/{expectedRegion}/publishers/anthropic/models/claude-sonnet-4-5:rawPredict",
            wireUri.AbsoluteUri
        );
    }

    [Theory]
    [InlineData("", "us-east5", "project")]
    [InlineData("..", "us-east5", "project")]
    [InlineData("test-project", "", "region")]
    [InlineData("test-project", "..", "region")]
    // A server may drop ";" and what follows it, which leaves the part before it as the segment.
    [InlineData(";x", "us-east5", "project")]
    [InlineData(".;x", "us-east5", "project")]
    [InlineData("..;x", "us-east5", "project")]
    [InlineData("test-project", ";x", "region")]
    [InlineData("test-project", ".;x", "region")]
    [InlineData("test-project", "..;x", "region")]
    public async Task AdaptRequest_EmptyOrDotSegmentProjectOrRegion_Throws(
        string project,
        string region,
        string expectedName
    )
    {
        var sent = new List<Uri>();

        var exception = await Assert.ThrowsAsync<AnthropicInvalidDataException>(() =>
            SendWithModel("claude-sonnet-4-5", project, region, sent: sent)
        );

        Assert.Contains(expectedName, exception.Message);
        Assert.Empty(sent);
    }
}
