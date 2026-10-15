using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Aws;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Foundry;
using Anthropic.GoogleCloud;
using Anthropic.Models.Messages;
using Anthropic.Vertex;
using Google.Apis.Auth.OAuth2;

namespace Anthropic.Tests;

public class ClientDisposalTest
{
    const string MessageJson = """
        {"id":"msg_x","type":"message","role":"assistant","model":"claude-sonnet-4-5","content":[{"type":"text","text":"hi"}],"stop_reason":"end_turn","stop_sequence":null,"usage":{"input_tokens":1,"output_tokens":1}}
        """;

    sealed class TrackingHandler : HttpMessageHandler
    {
        public bool Disposed { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(MessageJson, Encoding.UTF8, "application/json"),
                }
            );
        }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }

    sealed class TrackingDelegatingHandler : DelegatingHandler
    {
        public bool Disposed { get; private set; }

        protected override void Dispose(bool disposing)
        {
            Disposed = true;
            base.Dispose(disposing);
        }
    }

    static MessageCreateParams NewParams() =>
        new()
        {
            MaxTokens = 64,
            Messages = [new() { Content = "hello", Role = Role.User }],
            Model = Model.ClaudeSonnet4_5,
        };

    static AnthropicClient NewClient(HttpMessageHandler handler) =>
        new(new ClientOptions { ApiKey = "test-key", HttpClient = new HttpClient(handler) });

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WithOptions_DisposingDerivedClient_KeepsParentUsable(bool parentSentFirst)
    {
        var handler = new TrackingHandler();
        var parent = NewClient(handler);
        if (parentSentFirst)
        {
            await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);
        }

        var child = parent.WithOptions(o => o with { MaxRetries = 0 });
        child.Dispose();

        Assert.False(handler.Disposed);
        await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);

        parent.Dispose();
        Assert.True(handler.Disposed);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WithRawResponse_DisposingFacade_KeepsParentUsable(bool parentSentFirst)
    {
        var handler = new TrackingHandler();
        var parent = NewClient(handler);
        if (parentSentFirst)
        {
            await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);
        }

        parent.WithRawResponse.Dispose();

        Assert.False(handler.Disposed);
        await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);

        parent.Dispose();
        Assert.True(handler.Disposed);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task WithRawResponse_WithOptions_DisposingDerivedFacade_KeepsParentUsable(
        bool parentSentFirst
    )
    {
        var handler = new TrackingHandler();
        var parent = NewClient(handler);
        if (parentSentFirst)
        {
            await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);
        }

        parent.WithRawResponse.WithOptions(o => o with { MaxRetries = 0 }).Dispose();

        Assert.False(handler.Disposed);
        await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);

        parent.Dispose();
        Assert.True(handler.Disposed);
    }

    [Fact]
    public void WithOptions_DerivedClientWithOwnHttpClient_DisposesIt()
    {
        var parentHandler = new TrackingHandler();
        var childHandler = new TrackingHandler();
        using var parent = NewClient(parentHandler);
        var child = parent.WithOptions(o => o with { HttpClient = new HttpClient(childHandler) });

        child.Dispose();

        Assert.True(childHandler.Disposed);
        Assert.False(parentHandler.Disposed);
    }

    [Fact]
    public async Task WithOptions_DerivedClientWithOwnHandlers_DisposesThemButNotSharedHttpClient()
    {
        var handler = new TrackingHandler();
        var childHandler = new TrackingDelegatingHandler();
        using var parent = NewClient(handler);
        var child = parent.WithOptions(o =>
            o with
            {
                Handlers = new List<DelegatingHandler> { childHandler },
            }
        );
        // Attaches the child's own handler chain over the HttpClient it shares with the parent.
        await child.Messages.Create(NewParams(), TestContext.Current.CancellationToken);

        child.Dispose();

        Assert.True(childHandler.Disposed);
        Assert.False(handler.Disposed);
        await parent.Messages.Create(NewParams(), TestContext.Current.CancellationToken);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Dispose_DisposesHttpClientAndAttachedHandlers(bool sentRequest)
    {
        var handler = new TrackingHandler();
        var userHandler = new TrackingDelegatingHandler();
        var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = "test-key",
                HttpClient = new HttpClient(handler),
                Handlers = new List<DelegatingHandler> { userHandler },
            }
        );
        if (sentRequest)
        {
            await client.Messages.Create(NewParams(), TestContext.Current.CancellationToken);
        }

        client.Dispose();

        Assert.True(handler.Disposed);
        if (sentRequest)
        {
            // The first request attaches the handlers, which the client then disposes.
            Assert.True(userHandler.Disposed);
        }
    }

    static IAnthropicClient NewPlatformClient(string platform) =>
        platform switch
        {
            "aws" => new AnthropicAwsClient(
                new()
                {
                    ApiKey = "test-key",
                    BaseUrl = "http://localhost",
                    WorkspaceId = "ws",
                }
            ),
            "bedrock" => new AnthropicBedrockClient(
                new AnthropicBedrockApiTokenCredentials
                {
                    BearerToken = "test-key",
                    Region = "us-east-1",
                }
            ),
            "bedrock-mantle" => new AnthropicBedrockMantleClient(
                new() { ApiKey = "test-key", BaseUrl = "http://localhost" }
            ),
            "foundry" => new AnthropicFoundryClient(
                new AnthropicFoundryApiKeyCredentials("test-key", "test-resource")
            ),
            "google-cloud" => new AnthropicGoogleCloudClient(
                new()
                {
                    TokenProvider = _ => Task.FromResult("tok"),
                    WorkspaceId = "ws",
                    BaseUrl = "http://localhost",
                }
            ),
            "vertex" => new AnthropicVertexClient(
                new AnthropicVertexCredentials(
                    "us-east5",
                    "test-project",
                    GoogleCredential.FromAccessToken("tok")
                )
            ),
            _ => throw new ArgumentOutOfRangeException(nameof(platform)),
        };

    [Theory]
    [InlineData("aws")]
    [InlineData("bedrock")]
    [InlineData("bedrock-mantle")]
    [InlineData("foundry")]
    [InlineData("google-cloud")]
    [InlineData("vertex")]
    public void WithOptions_PlatformClient_DisposingDerivedClient_KeepsSharedHttpClient(
        string platform
    )
    {
        var handler = new TrackingHandler();
        using var client = NewPlatformClient(platform);
        var parent = client.WithOptions(o => o with { HttpClient = new HttpClient(handler) });
        var child = parent.WithOptions(o => o with { MaxRetries = 0 });

        child.Dispose();

        Assert.False(handler.Disposed);

        parent.Dispose();
        Assert.True(handler.Disposed);
    }
}
