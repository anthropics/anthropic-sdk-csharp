#pragma warning disable xUnit1051
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Credentials;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Credentials;

[Collection("EnvVarMutating")]
public class AnthropicClientCredentialsTests
{
    private class FakeHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, int, HttpResponseMessage> _handler;
        public List<HttpRequestMessage> Requests { get; } = new();

        public FakeHandler()
            : this((_, _) => OkMessageResponse()) { }

        public FakeHandler(Func<HttpRequestMessage, int, HttpResponseMessage> handler)
        {
            _handler = handler;
        }

        public HttpRequestMessage? LastRequest => Requests.LastOrDefault();

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests.Add(request);
            return Task.FromResult(_handler(request, Requests.Count));
        }
    }

    private static HttpResponseMessage OkMessageResponse()
    {
        var json = JsonSerializer.Serialize(
            new
            {
                id = "msg_test",
                type = "message",
                role = "assistant",
                content = new[] { new { type = "text", text = "hello" } },
                model = "claude-sonnet-4-5",
                stop_reason = "end_turn",
                usage = new { input_tokens = 10, output_tokens = 5 },
            }
        );
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
    }

    private class FakeCredentials : IAccessTokenProvider
    {
        private readonly Func<int, bool, AccessToken> _factory;

        public int CallCount { get; private set; }
        public int ForceRefreshCount { get; private set; }
        public bool Disposed { get; private set; }

        public FakeCredentials()
            : this((_, _) => new AccessToken("test-token")) { }

        public FakeCredentials(Func<int, bool, AccessToken> factory)
        {
            _factory = factory;
        }

        public ValueTask<AccessToken> GetTokenAsync(
            bool forceRefresh = false,
            CancellationToken cancellationToken = default
        )
        {
            CallCount++;
            if (forceRefresh)
            {
                ForceRefreshCount++;
            }
            return new ValueTask<AccessToken>(_factory(CallCount, forceRefresh));
        }

        public void Dispose()
        {
            Disposed = true;
        }
    }

    private static MessageCreateParams TestParams() =>
        new()
        {
            Model = "claude-sonnet-4-5",
            MaxTokens = 1,
            Messages = [new() { Role = Role.User, Content = "hi" }],
        };

    [Fact]
    public void Constructor_WarnsWhenApiKeyShadowsCredentials()
    {
        AnthropicClient.ResetShadowWarningForTests();
        var originalErr = Console.Error;
        var captured = new StringWriter();
        Console.SetError(captured);
        try
        {
            // Both ApiKey (explicit) and Credentials set → one-time warning.
            using var c1 = new AnthropicClient(
                new ClientOptions { ApiKey = "sk-x", Credentials = new FakeCredentials() }
            );
            var first = captured.ToString();
            Assert.Contains("explicit API key/auth token", first);
            Assert.Contains("ignored", first);

            // Second construction → no additional warning (one-time).
            captured.GetStringBuilder().Clear();
            using var c2 = new AnthropicClient(
                new ClientOptions { ApiKey = "sk-x", Credentials = new FakeCredentials() }
            );
            Assert.Equal(string.Empty, captured.ToString());
        }
        finally
        {
            Console.SetError(originalErr);
            AnthropicClient.ResetShadowWarningForTests();
        }
    }

    [Fact]
    public async Task Constructor_ExplicitApiKey_DoesNotAttachProfileWorkspaceId()
    {
        // Regression guard: auto-resolve is gated on !ApiKeyExplicit, so a profile's
        // workspace-id must never ride a request when an explicit ApiKey is set.
        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = "sk-explicit",
                Credentials = new FakeCredentials(),
                ExtraHeaders = null,
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
        Assert.True(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task Constructor_AutoResolve_MergesExtraHeaders()
    {
        // User passes ExtraHeaders AND token credentials with profile-style headers
        // (simulated via direct ExtraHeaders since auto-resolve is env-dependent).
        // BeforeSend must apply both.
        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = new FakeCredentials(),
                ExtraHeaders = new Dictionary<string, string>
                {
                    ["x-corp-trace"] = "abc",
                    ["anthropic-workspace-id"] = "wrkspc_test",
                },
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.Equal("abc", req.Headers.GetValues("x-corp-trace").Single());
        Assert.Equal("wrkspc_test", req.Headers.GetValues("anthropic-workspace-id").Single());
    }

    private sealed class TestSubclassClient : AnthropicClient
    {
        public TestSubclassClient(ClientOptions options)
            : base(options) { }
    }

    [Fact]
    public async Task Subclass_InheritsAutoResolve()
    {
        // A user subclass that does NOT override ShouldAutoResolveCredentials should
        // inherit auto-resolution. Resolve picks ANTHROPIC_AUTH_TOKEN → Bearer.
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, null),
            (CredentialsConstants.EnvAuthToken, "subclass-auto-token"),
            (CredentialsConstants.EnvProfile, null),
            (CredentialsConstants.EnvFederationRuleId, null),
            (CredentialsConstants.EnvIdentityToken, null),
            (CredentialsConstants.EnvIdentityTokenFile, null)
        );

        var handler = new FakeHandler();
        using var client = new TestSubclassClient(
            new ClientOptions { HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.Equal("Bearer", req.Headers.Authorization!.Scheme);
        Assert.Equal("subclass-auto-token", req.Headers.Authorization.Parameter);
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task Constructor_EnvApiKey_UsesXApiKey()
    {
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, "sk-test"),
            (CredentialsConstants.EnvAuthToken, null),
            (CredentialsConstants.EnvProfile, null)
        );

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions { HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.Equal("sk-test", req.Headers.GetValues("X-Api-Key").Single());
        Assert.Null(req.Headers.Authorization);
    }

    [Fact]
    public async Task Constructor_DiskProfile_UsesBearer()
    {
        var dir = Path.Combine(
            Path.GetTempPath(),
            "anthropic_test_cfg_" + Guid.NewGuid().ToString("N")
        );
        Directory.CreateDirectory(Path.Combine(dir, "configs"));
        Directory.CreateDirectory(Path.Combine(dir, "credentials"));
        File.WriteAllText(
            Path.Combine(dir, "configs", "default.json"),
            "{\"authentication\":{\"type\":\"user_oauth\"}}"
        );
        var credPath = Path.Combine(dir, "credentials", "default.json");
        File.WriteAllText(
            credPath,
            JsonSerializer.Serialize(
                new
                {
                    version = "1.0",
                    type = "oauth_token",
                    access_token = "disk-tok",
                    expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600,
                }
            )
        );
#if NET
        if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
        {
            File.SetUnixFileMode(credPath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
        }
#endif
        try
        {
            using var env = new EnvScope(
                (CredentialsConstants.EnvApiKey, null),
                (CredentialsConstants.EnvAuthToken, null),
                (CredentialsConstants.EnvProfile, null),
                (CredentialsConstants.EnvConfigDir, dir),
                (CredentialsConstants.EnvFederationRuleId, null),
                (CredentialsConstants.EnvIdentityToken, null),
                (CredentialsConstants.EnvIdentityTokenFile, null)
            );

            var handler = new FakeHandler();
            using var client = new AnthropicClient(
                new ClientOptions { HttpClient = new HttpClient(handler) }
            );

            await client.Messages.Create(TestParams());

            var req = handler.LastRequest!;
            Assert.Equal("Bearer", req.Headers.Authorization!.Scheme);
            Assert.Equal("disk-tok", req.Headers.Authorization.Parameter);
            Assert.False(req.Headers.Contains("X-Api-Key"));
        }
        finally
        {
            Directory.Delete(dir, recursive: true);
        }
    }

    [Fact]
    public async Task Constructor_ProfileBaseUrl_UsedWhenNoExplicitOrEnv()
    {
        using var fixture = ProfileBaseUrlFixture.Create("https://staging.test");
        using var env = fixture.Env(envBaseUrl: null);

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions { HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());
        Assert.Equal("staging.test", handler.LastRequest!.RequestUri!.Host);
    }

    [Fact]
    public async Task Constructor_EnvBaseUrl_BeatsProfileBaseUrl()
    {
        using var fixture = ProfileBaseUrlFixture.Create("https://staging.test");
        using var env = fixture.Env(envBaseUrl: "https://env.test");

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions { HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());
        Assert.Equal("env.test", handler.LastRequest!.RequestUri!.Host);
    }

    [Fact]
    public async Task Constructor_ExplicitBaseUrl_BeatsProfileAndEnv()
    {
        using var fixture = ProfileBaseUrlFixture.Create("https://staging.test");
        using var env = fixture.Env(envBaseUrl: "https://env.test");

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                BaseUrl = "https://explicit.test",
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());
        Assert.Equal("explicit.test", handler.LastRequest!.RequestUri!.Host);
    }

    private sealed class ProfileBaseUrlFixture : IDisposable
    {
        public string Dir { get; }

        private ProfileBaseUrlFixture(string dir) => Dir = dir;

        public static ProfileBaseUrlFixture Create(string profileBaseUrl)
        {
            var dir = Path.Combine(
                Path.GetTempPath(),
                "anthropic_test_baseurl_" + Guid.NewGuid().ToString("N")
            );
            Directory.CreateDirectory(Path.Combine(dir, "configs"));
            Directory.CreateDirectory(Path.Combine(dir, "credentials"));
            File.WriteAllText(
                Path.Combine(dir, "configs", "default.json"),
                JsonSerializer.Serialize(
                    new { base_url = profileBaseUrl, authentication = new { type = "user_oauth" } }
                )
            );
            var credPath = Path.Combine(dir, "credentials", "default.json");
            File.WriteAllText(
                credPath,
                JsonSerializer.Serialize(
                    new
                    {
                        version = "1.0",
                        type = "oauth_token",
                        access_token = "disk-tok",
                        expires_at = DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600,
                    }
                )
            );
#if NET
            if (OperatingSystem.IsLinux() || OperatingSystem.IsMacOS())
            {
                File.SetUnixFileMode(credPath, UnixFileMode.UserRead | UnixFileMode.UserWrite);
            }
#endif
            return new ProfileBaseUrlFixture(dir);
        }

        public EnvScope Env(string? envBaseUrl) =>
            new(
                (CredentialsConstants.EnvApiKey, null),
                (CredentialsConstants.EnvAuthToken, null),
                (CredentialsConstants.EnvProfile, null),
                (CredentialsConstants.EnvConfigDir, Dir),
                (CredentialsConstants.EnvFederationRuleId, null),
                (CredentialsConstants.EnvIdentityToken, null),
                (CredentialsConstants.EnvIdentityTokenFile, null),
                ("ANTHROPIC_BASE_URL", envBaseUrl)
            );

        public void Dispose()
        {
            try
            {
                Directory.Delete(Dir, recursive: true);
            }
            catch { }
        }
    }

    /// <summary>
    /// Captures and restores environment variables for the duration of a test.
    /// </summary>
    private sealed class EnvScope : IDisposable
    {
        private readonly List<(string Name, string? Original)> _saved = new();

        public EnvScope(params (string Name, string? Value)[] vars)
        {
            foreach (var (name, value) in vars)
            {
                _saved.Add((name, Environment.GetEnvironmentVariable(name)));
                Environment.SetEnvironmentVariable(name, value);
            }
        }

        public void Dispose()
        {
            foreach (var (name, original) in _saved)
            {
                Environment.SetEnvironmentVariable(name, original);
            }
        }
    }

    [Fact]
    public void CanConstructWithCredentials()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicClient(
            new ClientOptions { Credentials = creds, ApiKey = null }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void CanConstructWithCredentialResultFields()
    {
        var creds = new FakeCredentials();
        var extraHeaders = new Dictionary<string, string>
        {
            ["anthropic-workspace-id"] = "wrkspc_test",
        };
        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = creds,
                ExtraHeaders = extraHeaders,
                ApiKey = null,
            }
        );
        Assert.NotNull(client);
    }

    [Fact]
    public void DisposesCascadesToCredentials()
    {
        var creds = new FakeCredentials();
        var client = new AnthropicClient(new ClientOptions { Credentials = creds, ApiKey = null });
        client.Dispose();
        Assert.True(creds.Disposed);
    }

    [Fact]
    public void WithOptions_DerivedClient_Dispose_DoesNotDisposeSharedCredentials()
    {
        var creds = new FakeCredentials();
        var parent = new AnthropicClient(new ClientOptions { Credentials = creds, ApiKey = null });
        var child = parent.WithOptions(o => o);

        child.Dispose();
        Assert.False(creds.Disposed);

        parent.Dispose();
        Assert.True(creds.Disposed);
    }

    [Fact]
    public void RawResponseClient_DirectConstruction_DisposesOwnedCredentials()
    {
        var fake = new FakeCredentials();
        using (
            var raw = new AnthropicClientWithRawResponse(
                new ClientOptions { Credentials = fake, ApiKey = null }
            )
        ) { }
        Assert.True(fake.Disposed);
    }

    [Fact]
    public void RawResponseClient_ViaWithRawResponse_DoesNotDisposeParentCredentials()
    {
        var fake = new FakeCredentials();
        var parent = new AnthropicClient(new ClientOptions { Credentials = fake, ApiKey = null });

        parent.WithRawResponse.Dispose();
        Assert.False(fake.Disposed);

        parent.Dispose();
        Assert.True(fake.Disposed);
    }

    [Fact]
    public async Task UnauthorizedResponse_StaticToken_DoesNotRetry()
    {
        // StaticTokenCredentials can't change on forceRefresh — the 401-retry path
        // should detect the unchanged token and skip the wasted second round-trip.
        var handler = new FakeHandler(
            (_, _) =>
                new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                }
        );

        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = new StaticTokenCredentials("tok"),
                HttpClient = new HttpClient(handler),
                MaxRetries = 0,
            }
        );

        await Assert.ThrowsAsync<AnthropicUnauthorizedException>(() =>
            client.Messages.Create(TestParams())
        );

        Assert.Single(handler.Requests);
    }

    [Fact]
    public void WithRawResponse_IsNotNull()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicClient(
            new ClientOptions { Credentials = creds, ApiKey = null }
        );
        Assert.NotNull(client.WithRawResponse);
    }

    [Fact]
    public void WithOptions_ReturnsNewClient()
    {
        var creds = new FakeCredentials();
        using var client = new AnthropicClient(
            new ClientOptions { Credentials = creds, ApiKey = null }
        );
        var newClient = client.WithOptions(o =>
        {
            o.BaseUrl = "https://custom.example.com";
            return o;
        });
        Assert.NotNull(newClient);
        Assert.NotSame(client, newClient);
    }

    [Fact]
    public async Task ExplicitApiKey_TakesPriorityOverCredentials()
    {
        var handler = new FakeHandler();
        var creds = new FakeCredentials();

        // When both ApiKey and Credentials are explicitly set, ApiKey wins.
        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = creds,
                ApiKey = "sk-explicit-key",
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;

        // X-Api-Key should be present (API key wins)
        Assert.True(req.Headers.Contains("X-Api-Key"));
        Assert.Equal("sk-explicit-key", req.Headers.GetValues("X-Api-Key").Single());

        // Credentials should NOT have been consulted
        Assert.Equal(0, creds.CallCount);
    }

    [Fact]
    public async Task Credentials_OverrideEnvVarApiKey()
    {
        var handler = new FakeHandler();
        var creds = new FakeCredentials();

        // Credentials is explicitly set, ApiKey is NOT explicitly set
        // (it will default to ANTHROPIC_API_KEY env var).
        // Credentials should win and strip the env-var API key.
        using var client = new AnthropicClient(
            new ClientOptions { Credentials = creds, HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;

        // Client should have set Bearer auth from the provider's token
        Assert.Equal("Bearer", req.Headers.Authorization!.Scheme);
        Assert.Equal("test-token", req.Headers.Authorization.Parameter);

        // OAuth beta header should be appended by the client
        var beta = string.Join(",", req.Headers.GetValues("anthropic-beta"));
        Assert.Contains("oauth-2025-04-20", beta);

        // X-Api-Key should NOT be present
        Assert.False(
            req.Headers.Contains("X-Api-Key"),
            "X-Api-Key from env var should be stripped when Credentials is set"
        );
    }

    [Fact]
    public async Task ProviderIsCached_SingleFetchAcrossRequests()
    {
        // A user-supplied IAccessTokenProvider is wrapped in the internal TokenCache,
        // so two back-to-back requests with a non-expiring token only call the provider once.
        var handler = new FakeHandler();
        var creds = new FakeCredentials((_, _) => new AccessToken("tok", expiresAt: null));

        using var client = new AnthropicClient(
            new ClientOptions { Credentials = creds, HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());
        await client.Messages.Create(TestParams());

        Assert.Equal(2, handler.Requests.Count);
        Assert.Equal(1, creds.CallCount);
    }

    [Fact]
    public async Task UnauthorizedResponse_ForceRefreshesAndRetriesOnce()
    {
        // First call → token-A → server says 401.
        // Client should force-refresh (token-B) and retry once → 200.
        var creds = new FakeCredentials((n, _) => new AccessToken($"token-{(n == 1 ? "A" : "B")}"));

        var handler = new FakeHandler(
            (req, callNumber) =>
                callNumber == 1
                    ? new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                    }
                    : OkMessageResponse()
        );

        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = creds,
                HttpClient = new HttpClient(handler),
                MaxRetries = 0,
            }
        );

        var result = await client.Messages.Create(TestParams());
        Assert.NotNull(result);

        Assert.Equal(2, handler.Requests.Count);
        Assert.Equal("token-A", handler.Requests[0].Headers.Authorization!.Parameter);
        Assert.Equal("token-B", handler.Requests[1].Headers.Authorization!.Parameter);

        // Second attempt carries the retry-count header
        Assert.Equal(
            "1",
            handler.Requests[1].Headers.GetValues("x-stainless-retry-count").Single()
        );

        // Exactly one force-refresh
        Assert.Equal(1, creds.ForceRefreshCount);
    }

    [Fact]
    public async Task UnauthorizedResponse_OnlyRetriesOnce()
    {
        // 401 → refresh+retry → 401 again → surface the 401, do NOT retry a second time.
        var creds = new FakeCredentials((n, _) => new AccessToken($"token-{n}"));

        var handler = new FakeHandler(
            (_, _) =>
                new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                }
        );

        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = creds,
                HttpClient = new HttpClient(handler),
                MaxRetries = 0,
            }
        );

        await Assert.ThrowsAsync<AnthropicUnauthorizedException>(() =>
            client.Messages.Create(TestParams())
        );

        Assert.Equal(2, handler.Requests.Count);
        Assert.Equal(1, creds.ForceRefreshCount);
    }

    [Fact]
    public async Task UnauthorizedWithoutCredentials_DoesNotRetry()
    {
        // No Credentials → 401 should surface immediately, no auth retry.
        var handler = new FakeHandler(
            (_, _) =>
                new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("{}", Encoding.UTF8, "application/json"),
                }
        );

        using var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = "sk-bad-key",
                HttpClient = new HttpClient(handler),
                MaxRetries = 0,
            }
        );

        await Assert.ThrowsAsync<AnthropicUnauthorizedException>(() =>
            client.Messages.Create(TestParams())
        );

        Assert.Single(handler.Requests);
    }
}
