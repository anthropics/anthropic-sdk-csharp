using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Oidc;

namespace Anthropic.Tests.Oidc;

public class AnthropicOidcClientTests
{
    private class FakeCredentials : IAnthropicOidcCredentials
    {
        public int ApplyCount { get; private set; }
        public int InvalidateCount { get; private set; }
        public bool Disposed { get; private set; }

        public ValueTask ApplyAsync(
            HttpRequestMessage requestMessage,
            CancellationToken cancellationToken = default
        )
        {
            ApplyCount++;
            requestMessage.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "test-token");
            requestMessage.Headers.TryAddWithoutValidation("anthropic-beta", "oauth-2025-04-20");
            return default;
        }

        public void InvalidateToken()
        {
            InvalidateCount++;
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }

    [Fact]
    public void CanConstructWithCredentials()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicOidcClient(creds);
        Assert.NotNull(client);
    }

    [Fact]
    public void CanConstructWithCredentialResult()
    {
        var creds = new FakeCredentials();
        var result = new CredentialResult(
            creds,
            new Dictionary<string, string> { ["anthropic-workspace-id"] = "wrkspc_test" }
        );
        using var client = new AnthropicOidcClient(result);
        Assert.NotNull(client);
    }

    [Fact]
    public void DisposesCascadesToCredentials()
    {
        var creds = new FakeCredentials();
        var client = new AnthropicOidcClient(creds);
        client.Dispose();
        Assert.True(creds.Disposed);
    }

    [Fact]
    public void WithRawResponse_IsNotNull()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicOidcClient(creds);
        Assert.NotNull(client.WithRawResponse);
    }

    [Fact]
    public void WithOptions_ReturnsNewClient()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicOidcClient(creds);
        var newClient = client.WithOptions(o =>
        {
            o.BaseUrl = "https://custom.example.com";
            return o;
        });
        Assert.NotNull(newClient);
        Assert.NotSame(client, newClient);
    }
}
