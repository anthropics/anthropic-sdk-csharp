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
using Anthropic.Models.Files;
using Anthropic.Models.Messages;
using Anthropic.Tests.Helpers;

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
            Messages = [new UserMessageParam { Content = "hi" }],
        };

    public enum ClientKind
    {
        Client,
        ClientWithRawResponse,
        RawResponseClient,
    }

    /// <summary>
    /// Any kind of client over a fake handler, so that one test covers them all.
    /// </summary>
    private sealed class ClientUnderTest : IDisposable
    {
        private readonly FakeHandler _handler;
        private readonly IAnthropicClient? _client;
        private readonly IAnthropicClientWithRawResponse? _rawResponseClient;

        public ClientUnderTest(ClientOptions options, ClientKind kind)
        {
            _handler = new FakeHandler();
            options.HttpClient = new HttpClient(_handler);
            if (kind == ClientKind.RawResponseClient)
            {
                _rawResponseClient = new AnthropicClientWithRawResponse(options);
                return;
            }

            _client = new AnthropicClient(options);
            if (kind == ClientKind.ClientWithRawResponse)
            {
                _rawResponseClient = _client.WithRawResponse;
            }
        }

        private ClientUnderTest(ClientUnderTest parent, Func<ClientOptions, ClientOptions> modifier)
        {
            _handler = parent._handler;
            if (parent._rawResponseClient != null)
            {
                _rawResponseClient = parent._rawResponseClient.WithOptions(modifier);
            }
            else
            {
                _client = parent._client?.WithOptions(modifier);
            }
        }

        public ClientUnderTest WithOptions(Func<ClientOptions, ClientOptions> modifier) =>
            new(this, modifier);

        public async Task<string> SendAndGetAuthorization() =>
            (await Send()).Headers.GetValues("Authorization").Single();

        public async Task<HttpRequestMessage> Send()
        {
            if (_rawResponseClient != null)
            {
                using var response = await _rawResponseClient.Messages.Create(
                    TestParams(),
                    TestContext.Current.CancellationToken
                );
            }
            else if (_client != null)
            {
                await _client.Messages.Create(TestParams(), TestContext.Current.CancellationToken);
            }
            return _handler.LastRequest!;
        }

        public void Dispose()
        {
            _rawResponseClient?.Dispose();
            _client?.Dispose();
        }
    }

    private static readonly string[] CredentialOptions =
    [
        nameof(ClientOptions.ApiKey),
        nameof(ClientOptions.AuthToken),
        nameof(ClientOptions.Credentials),
    ];

    private static ClientOptions Pass(ClientOptions options, string option, string value) =>
        option switch
        {
            nameof(ClientOptions.ApiKey) => options with { ApiKey = value },
            nameof(ClientOptions.AuthToken) => options with { AuthToken = value },
            nameof(ClientOptions.Credentials) => options with
            {
                Credentials = new StaticTokenCredentials(value),
            },
            _ => throw new ArgumentOutOfRangeException(nameof(option), option, null),
        };

    private static readonly ClientKind[] ClientKinds =
    [
        ClientKind.Client,
        ClientKind.ClientWithRawResponse,
        ClientKind.RawResponseClient,
    ];

    public static TheoryData<string, ClientKind> EachCredentialOption()
    {
        var data = new TheoryData<string, ClientKind>();
        foreach (var option in CredentialOptions)
        {
            foreach (var kind in ClientKinds)
            {
                data.Add(option, kind);
            }
        }
        return data;
    }

    public static TheoryData<string, string, ClientKind> EachTwoCredentialOptions(bool distinct)
    {
        var data = new TheoryData<string, string, ClientKind>();
        foreach (var first in CredentialOptions)
        {
            foreach (var second in CredentialOptions)
            {
                if (distinct && first == second)
                {
                    continue;
                }
                foreach (var kind in ClientKinds)
                {
                    data.Add(first, second, kind);
                }
            }
        }
        return data;
    }

    [Fact]
    public void CredentialOptions_TrackClientOptionsProperties()
    {
        // A new property that supplies a credential has to be stored as a ClientCredential, be
        // named in the message of ClientCredential.Pass, and join CredentialOptions here.
        string[] otherOptions =
        [
            nameof(ClientOptions.HttpClient),
            nameof(ClientOptions.Handlers),
            nameof(ClientOptions.BaseUrl),
            nameof(ClientOptions.ResponseValidation),
            nameof(ClientOptions.MaxRetries),
            nameof(ClientOptions.Timeout),
            nameof(ClientOptions.OpenTelemetry),
            nameof(ClientOptions.OpenTelemetryRequest),
            nameof(ClientOptions.ExtraHeaders),
            nameof(ClientOptions.WebhookKey),
        ];

        Assert.Equal(
            CredentialOptions.Concat(otherOptions).OrderBy(name => name, StringComparer.Ordinal),
            typeof(ClientOptions)
                .GetProperties()
                .Select(property => property.Name)
                .OrderBy(name => name, StringComparer.Ordinal)
        );
    }

    [Theory]
    [InlineData(nameof(ClientOptions.ApiKey), nameof(ClientOptions.AuthToken))]
    [InlineData(nameof(ClientOptions.ApiKey), nameof(ClientOptions.Credentials))]
    [InlineData(nameof(ClientOptions.AuthToken), nameof(ClientOptions.ApiKey))]
    [InlineData(nameof(ClientOptions.AuthToken), nameof(ClientOptions.Credentials))]
    [InlineData(nameof(ClientOptions.Credentials), nameof(ClientOptions.ApiKey))]
    [InlineData(nameof(ClientOptions.Credentials), nameof(ClientOptions.AuthToken))]
    public void TwoCredentialOptions_Throw(string first, string second)
    {
        var exception = Assert.Throws<ArgumentException>(() =>
            Pass(Pass(new ClientOptions(), first, "first-secret"), second, "second-secret")
        );

        Assert.Equal(
            "Pass at most one of ApiKey, AuthToken and Credentials. "
                + $"Both {first} and {second} were passed.",
            exception.Message
        );
    }

    [Fact]
    public void ObjectInitializer_TwoCredentialOptions_Throw()
    {
        Assert.Throws<ArgumentException>(() =>
            new AnthropicClient { ApiKey = "sk-passed", AuthToken = "passed-token" }
        );
        Assert.Throws<ArgumentException>(() =>
            new AnthropicClientWithRawResponse { AuthToken = "passed-token", ApiKey = "sk-passed" }
        );
        Assert.Throws<ArgumentException>(() =>
            new AnthropicClient(new ClientOptions { Credentials = new FakeCredentials() })
            {
                ApiKey = "sk-passed",
            }
        );
    }

    [Theory]
    [MemberData(nameof(EachTwoCredentialOptions), true)]
    public void WithOptions_TwoCredentialOptions_Throw(string first, string second, ClientKind kind)
    {
        using var parent = new ClientUnderTest(new ClientOptions { ApiKey = "sk-parent" }, kind);

        var exception = Assert.Throws<ArgumentException>(() =>
            parent.WithOptions(o => Pass(Pass(o, first, "first-secret"), second, "second-secret"))
        );

        Assert.Equal(
            "Pass at most one of ApiKey, AuthToken and Credentials. "
                + $"Both {first} and {second} were passed.",
            exception.Message
        );
    }

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task OneCredentialOption_IgnoresApiKeyAndAuthTokenEnvVars(
        string option,
        ClientKind kind
    )
    {
        using var env = ApiKeyAndAuthTokenEnvVars();

        using var client = new ClientUnderTest(Pass(new ClientOptions(), option, "passed"), kind);

        Assert.Equal("Bearer passed", await client.SendAndGetAuthorization());
    }

    [Theory]
    [InlineData(nameof(ClientOptions.ApiKey), false, null)]
    [InlineData(nameof(ClientOptions.ApiKey), false, "missing-profile")]
    [InlineData(nameof(ClientOptions.ApiKey), true, null)]
    [InlineData(nameof(ClientOptions.ApiKey), true, "missing-profile")]
    [InlineData(nameof(ClientOptions.AuthToken), false, null)]
    [InlineData(nameof(ClientOptions.AuthToken), false, "missing-profile")]
    [InlineData(nameof(ClientOptions.AuthToken), true, null)]
    [InlineData(nameof(ClientOptions.AuthToken), true, "missing-profile")]
    [InlineData(nameof(ClientOptions.Credentials), false, null)]
    [InlineData(nameof(ClientOptions.Credentials), false, "missing-profile")]
    public async Task OneCredentialOption_IgnoresProfiles(
        string option,
        bool objectInitializer,
        string? envProfile
    )
    {
        using var fixture = ProfileFixture.Create("https://staging.test", "wrkspc_profile");
        using var env = fixture.Env(envBaseUrl: null, envProfile);

        var handler = new FakeHandler();
        using var client = (objectInitializer, option) switch
        {
            (false, _) => new AnthropicClient(Pass(new ClientOptions(), option, "passed"))
            {
                HttpClient = new HttpClient(handler),
            },
            (true, nameof(ClientOptions.ApiKey)) => new AnthropicClient
            {
                ApiKey = "passed",
                HttpClient = new HttpClient(handler),
            },
            _ => new AnthropicClient { AuthToken = "passed", HttpClient = new HttpClient(handler) },
        };

        await client.Messages.Create(TestParams(), TestContext.Current.CancellationToken);

        var req = handler.LastRequest!;
        Assert.Equal("Bearer passed", req.Headers.GetValues("Authorization").Single());
        Assert.Equal("api.anthropic.com", req.RequestUri!.Host);
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
    }

    [Theory]
    [InlineData("sk-env", "env-token", "named", true, "Bearer sk-env")]
    [InlineData(null, "env-token", "named", true, "Bearer env-token")]
    [InlineData(null, null, "named", true, "Bearer named-tok")]
    [InlineData(null, null, null, false, "Bearer disk-tok")]
    public async Task NoCredentialOption_UsesFirstMatchInEnvironment(
        string? envApiKey,
        string? envAuthToken,
        string? envProfile,
        bool envFederation,
        string expectedAuthorization
    )
    {
        using var fixture = ProfileFixture.Create(profileBaseUrl: null);
        fixture.AddProfile("named", "named-tok");
        using var env = fixture.Env(envBaseUrl: null, envProfile);
        using var credentialsEnv = new EnvScope(
            (CredentialsConstants.EnvApiKey, envApiKey),
            (CredentialsConstants.EnvAuthToken, envAuthToken),
            (CredentialsConstants.EnvFederationRuleId, envFederation ? "fdrl_test" : null),
            (CredentialsConstants.EnvIdentityToken, envFederation ? "identity-token" : null)
        );

        using var client = new ClientUnderTest(new ClientOptions(), ClientKind.Client);

        Assert.Equal(expectedAuthorization, await client.SendAndGetAuthorization());
    }

    [Fact]
    public async Task MissingEnvProfile_ThrowsOnFirstUse()
    {
        using var fixture = ProfileFixture.Create(profileBaseUrl: null);
        using var env = fixture.Env(envBaseUrl: null, "missing-profile");

        using var client = new AnthropicClient();

        await Assert.ThrowsAsync<WorkloadIdentityException>(() =>
            client.Messages.Create(TestParams(), TestContext.Current.CancellationToken)
        );
    }

    [Fact]
    public async Task Dispose_DisposesCredentialsResolvedFromEnvironment()
    {
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, null),
            (CredentialsConstants.EnvAuthToken, "env-token"),
            (CredentialsConstants.EnvProfile, null)
        );
        var parent = new AnthropicClient();
        using var child = parent.WithOptions(o =>
            o with
            {
                HttpClient = new HttpClient(new FakeHandler()),
            }
        );

        parent.Dispose();

        // The copy shares its parent's credentials, which refuse to serve a token once disposed.
        await Assert.ThrowsAsync<ObjectDisposedException>(() =>
            child.Messages.Create(TestParams(), TestContext.Current.CancellationToken)
        );
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

    [Fact]
    public async Task PerRequestWorkspaceId_OverridesProfileWorkspaceIdHeader()
    {
        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = new FakeCredentials(),
                ExtraHeaders = new Dictionary<string, string>
                {
                    ["anthropic-workspace-id"] = "wrkspc_profile",
                },
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams() with { WorkspaceID = "wrkspc_request" });

        Assert.Equal(
            "wrkspc_request",
            handler.LastRequest!.Headers.GetValues("anthropic-workspace-id").Single()
        );
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
    public async Task Constructor_EnvApiKey_UsesBearer()
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
        Assert.Equal("Bearer", req.Headers.Authorization!.Scheme);
        Assert.Equal("sk-test", req.Headers.Authorization.Parameter);
        Assert.False(req.Headers.Contains("X-Api-Key"));
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
        using var fixture = ProfileFixture.Create("https://staging.test");
        using var env = fixture.Env(envBaseUrl: null);

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions { HttpClient = new HttpClient(handler) }
        );

        await client.Messages.Create(TestParams());
        Assert.Equal("staging.test", handler.LastRequest!.RequestUri!.Host);
        Assert.Equal("https://staging.test", client.BaseUrl);
    }

    [Fact]
    public async Task Constructor_EnvBaseUrl_BeatsProfileBaseUrl()
    {
        using var fixture = ProfileFixture.Create("https://staging.test");
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
        using var fixture = ProfileFixture.Create("https://staging.test");
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

    private sealed class ProfileFixture : IDisposable
    {
        public string Dir { get; }

        private ProfileFixture(string dir) => Dir = dir;

        public static ProfileFixture Create(string? profileBaseUrl, string? workspaceId = null)
        {
            var dir = Path.Combine(
                Path.GetTempPath(),
                "anthropic_test_baseurl_" + Guid.NewGuid().ToString("N")
            );
            Directory.CreateDirectory(Path.Combine(dir, "configs"));
            Directory.CreateDirectory(Path.Combine(dir, "credentials"));
            var fixture = new ProfileFixture(dir);
            fixture.AddProfile("default", "disk-tok", profileBaseUrl, workspaceId);
            return fixture;
        }

        public void AddProfile(
            string name,
            string accessToken,
            string? baseUrl = null,
            string? workspaceId = null
        )
        {
            File.WriteAllText(
                Path.Combine(Dir, "configs", name + ".json"),
                JsonSerializer.Serialize(
                    new
                    {
                        base_url = baseUrl,
                        workspace_id = workspaceId,
                        authentication = new { type = "user_oauth" },
                    }
                )
            );
            var credPath = Path.Combine(Dir, "credentials", name + ".json");
            File.WriteAllText(
                credPath,
                JsonSerializer.Serialize(
                    new
                    {
                        version = "1.0",
                        type = "oauth_token",
                        access_token = accessToken,
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
        }

        public EnvScope Env(string? envBaseUrl, string? envProfile = null) =>
            new(
                (CredentialsConstants.EnvApiKey, null),
                (CredentialsConstants.EnvAuthToken, null),
                (CredentialsConstants.EnvProfile, envProfile),
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
    public async Task Credentials_OverrideEnvVarApiKey()
    {
        using var env = new EnvScope((CredentialsConstants.EnvApiKey, "sk-env"));

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
    public async Task ExplicitAuthToken_BeatsEnvVarApiKey()
    {
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, "sk-env"),
            (CredentialsConstants.EnvAuthToken, null),
            (CredentialsConstants.EnvProfile, null)
        );

        var handler = new FakeHandler();
        using var client = new AnthropicClient
        {
            AuthToken = "my-token",
            HttpClient = new HttpClient(handler),
        };

        await client.Messages.Create(TestParams());

        Assert.Null(client.ApiKey);
        Assert.Equal(
            "Bearer my-token",
            handler.LastRequest!.Headers.GetValues("Authorization").Single()
        );
    }

    [Theory]
    [InlineData(ClientKind.Client)]
    [InlineData(ClientKind.ClientWithRawResponse)]
    [InlineData(ClientKind.RawResponseClient)]
    public async Task EnvVarApiKeyAndAuthToken_SendsApiKey(ClientKind kind)
    {
        using var env = ApiKeyAndAuthTokenEnvVars();

        Assert.Null(new ClientOptions().AuthToken);

        using var client = new ClientUnderTest(new ClientOptions(), kind);

        Assert.Equal("Bearer sk-env", await client.SendAndGetAuthorization());

        // A copy keeps the credential its parent resolved, whatever the environment holds by then.
        using var laterEnv = new EnvScope((CredentialsConstants.EnvApiKey, null));
        Assert.Equal(
            "Bearer sk-env",
            await client.WithOptions(o => o with { MaxRetries = 0 }).SendAndGetAuthorization()
        );
    }

    private const string ApiKeyAndAuthTokenWarning =
        "Anthropic: ANTHROPIC_API_KEY and ANTHROPIC_AUTH_TOKEN are both set. "
        + "Using ANTHROPIC_API_KEY.";

    private static EnvScope ApiKeyAndAuthTokenEnvVars() =>
        new(
            (CredentialsConstants.EnvApiKey, "sk-env"),
            (CredentialsConstants.EnvAuthToken, "env-token"),
            (CredentialsConstants.EnvProfile, null)
        );

    /// <summary>
    /// Makes the once-per-process warning due again, and once more on the way out.
    /// </summary>
    private sealed class UnwarnedProcessScope : IDisposable
    {
        public UnwarnedProcessScope() => ClientOptions.ResetEnvironmentCredentialsWarningForTests();

        public void Dispose() => ClientOptions.ResetEnvironmentCredentialsWarningForTests();
    }

    [Theory]
    [InlineData(ClientKind.Client)]
    [InlineData(ClientKind.ClientWithRawResponse)]
    [InlineData(ClientKind.RawResponseClient)]
    public async Task EnvVarApiKeyAndAuthToken_WarnsOncePerProcess(ClientKind kind)
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var unwarned = new UnwarnedProcessScope();
        using var first = new ClientUnderTest(new ClientOptions(), kind);
        using var second = new ClientUnderTest(new ClientOptions(), kind);

        string? authorization = null;
        var firstStderr = await FallbackTestSupport.CaptureStderr(async () =>
            authorization = await first.SendAndGetAuthorization()
        );
        var secondStderr = await FallbackTestSupport.CaptureStderr(second.SendAndGetAuthorization);

        Assert.Equal("Bearer sk-env", authorization);
        Assert.Equal(ApiKeyAndAuthTokenWarning + Environment.NewLine, firstStderr);
        Assert.Equal(string.Empty, secondStderr);
    }

    [Theory]
    [InlineData("sk-env", null, ClientKind.Client)]
    [InlineData("sk-env", null, ClientKind.ClientWithRawResponse)]
    [InlineData("sk-env", null, ClientKind.RawResponseClient)]
    [InlineData(null, "env-token", ClientKind.Client)]
    [InlineData(null, "env-token", ClientKind.ClientWithRawResponse)]
    [InlineData(null, "env-token", ClientKind.RawResponseClient)]
    public async Task EnvVarApiKeyOrAuthTokenAlone_DoesNotWarn(
        string? apiKey,
        string? authToken,
        ClientKind kind
    )
    {
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, apiKey),
            (CredentialsConstants.EnvAuthToken, authToken),
            (CredentialsConstants.EnvProfile, null)
        );
        using var unwarned = new UnwarnedProcessScope();
        using var client = new ClientUnderTest(new ClientOptions(), kind);

        var stderr = await FallbackTestSupport.CaptureStderr(client.SendAndGetAuthorization);

        Assert.Equal(string.Empty, stderr);
    }

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task OneCredentialOption_DoesNotWarnAboutEnvVars(string option, ClientKind kind)
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var unwarned = new UnwarnedProcessScope();
        using var client = new ClientUnderTest(Pass(new ClientOptions(), option, "passed"), kind);

        var stderr = await FallbackTestSupport.CaptureStderr(client.SendAndGetAuthorization);

        Assert.Equal(string.Empty, stderr);
    }

    [Theory]
    [InlineData(ClientKind.Client)]
    [InlineData(ClientKind.ClientWithRawResponse)]
    [InlineData(ClientKind.RawResponseClient)]
    public async Task NullApiKeyOrAuthToken_DoesNotWarnAboutEnvVars(ClientKind kind)
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var unwarned = new UnwarnedProcessScope();
        using var noApiKey = new ClientUnderTest(new ClientOptions { ApiKey = null }, kind);
        using var noAuthToken = new ClientUnderTest(new ClientOptions { AuthToken = null }, kind);

        var stderr = await FallbackTestSupport.CaptureStderr(async () =>
        {
            Assert.Equal("Bearer env-token", await noApiKey.SendAndGetAuthorization());
            Assert.Equal("Bearer sk-env", await noAuthToken.SendAndGetAuthorization());
        });

        Assert.Equal(string.Empty, stderr);
    }

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task WithOptions_CredentialOption_DoesNotWarnAboutEnvVars(
        string childOption,
        ClientKind kind
    )
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var unwarned = new UnwarnedProcessScope();
        using var parent = new ClientUnderTest(new ClientOptions(), kind);

        var child = parent.WithOptions(o => Pass(o, childOption, "child"));
        var stderr = await FallbackTestSupport.CaptureStderr(child.SendAndGetAuthorization);

        Assert.Equal(string.Empty, stderr);
    }

    [Theory]
    [InlineData(ClientKind.Client, false)]
    [InlineData(ClientKind.Client, true)]
    [InlineData(ClientKind.ClientWithRawResponse, false)]
    [InlineData(ClientKind.ClientWithRawResponse, true)]
    [InlineData(ClientKind.RawResponseClient, false)]
    [InlineData(ClientKind.RawResponseClient, true)]
    public async Task WithOptions_NoCredentialOption_WarnsAboutInheritedEnvVars(
        ClientKind kind,
        bool freshOptions
    )
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var unwarned = new UnwarnedProcessScope();
        using var parent = new ClientUnderTest(new ClientOptions(), kind);

        var child = parent.WithOptions(o =>
            freshOptions
                ? new ClientOptions { HttpClient = o.HttpClient }
                : o with
                {
                    MaxRetries = 0,
                }
        );
        var stderr = await FallbackTestSupport.CaptureStderr(child.SendAndGetAuthorization);

        Assert.Equal(ApiKeyAndAuthTokenWarning + Environment.NewLine, stderr);
    }

    [Theory]
    [MemberData(nameof(EachTwoCredentialOptions), false)]
    public async Task WithOptions_CredentialOption_ReplacesParentCredential(
        string parentOption,
        string childOption,
        ClientKind kind
    )
    {
        using var parent = new ClientUnderTest(
            Pass(new ClientOptions(), parentOption, "parent"),
            kind
        );

        var child = parent.WithOptions(o => Pass(o, childOption, "child"));

        Assert.Equal("Bearer child", await child.SendAndGetAuthorization());
        Assert.Equal("Bearer parent", await parent.SendAndGetAuthorization());
    }

    [Fact]
    public async Task ObjectInitializer_ApiKey_ReplacesInheritedCredentials()
    {
        var handler = new FakeHandler();
        using var parent = new AnthropicClient(
            new ClientOptions
            {
                Credentials = new FakeCredentials(),
                HttpClient = new HttpClient(handler),
            }
        );
        ClientOptions inherited = default;
        parent.WithOptions(o => inherited = o);

        var client = new AnthropicClientWithRawResponse(inherited) { ApiKey = "sk-passed" };
        using var response = await client.Models.List(
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(
            "Bearer sk-passed",
            handler.LastRequest!.Headers.GetValues("Authorization").Single()
        );
    }

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task WithOptions_NoCredentialOption_InheritsParentCredential(
        string parentOption,
        ClientKind kind
    )
    {
        using var env = ApiKeyAndAuthTokenEnvVars();
        using var parent = new ClientUnderTest(
            Pass(new ClientOptions(), parentOption, "parent"),
            kind
        );

        var child = parent.WithOptions(o => o with { MaxRetries = 0 });
        var freshChild = parent.WithOptions(o => new ClientOptions { HttpClient = o.HttpClient });

        Assert.Equal("Bearer parent", await child.SendAndGetAuthorization());
        Assert.Equal("Bearer parent", await freshChild.SendAndGetAuthorization());
    }

    [Theory]
    [InlineData(ClientKind.Client)]
    [InlineData(ClientKind.ClientWithRawResponse)]
    public async Task WithOptions_FreshOptions_KeepsProfileBaseUrlAndWorkspaceId(ClientKind kind)
    {
        using var fixture = ProfileFixture.Create("https://staging.test", "wrkspc_profile");
        using var env = fixture.Env(envBaseUrl: null);
        using var parent = new ClientUnderTest(new ClientOptions(), kind);

        var child = parent.WithOptions(o => new ClientOptions { HttpClient = o.HttpClient });
        var request = await child.Send();

        Assert.Equal("Bearer disk-tok", request.Headers.GetValues("Authorization").Single());
        Assert.Equal("staging.test", request.RequestUri!.Host);
        Assert.Equal(
            "wrkspc_profile",
            request.Headers.GetValues("anthropic-workspace-id").Single()
        );
    }

    private static ClientOptions WithParentBaseUrlAndWorkspaceId(ClientOptions options) =>
        options with
        {
            BaseUrl = "https://parent.test",
            ExtraHeaders = new Dictionary<string, string>
            {
                ["anthropic-workspace-id"] = "wrkspc_parent",
            },
        };

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task WithOptions_FreshOptions_KeepsParentBaseUrlAndExtraHeaders(
        string parentOption,
        ClientKind kind
    )
    {
        using var env = new EnvScope(("ANTHROPIC_BASE_URL", null));
        using var parent = new ClientUnderTest(
            WithParentBaseUrlAndWorkspaceId(Pass(new ClientOptions(), parentOption, "parent")),
            kind
        );

        var child = parent.WithOptions(o => new ClientOptions { HttpClient = o.HttpClient });
        var request = await child.Send();

        Assert.Equal("Bearer parent", request.Headers.GetValues("Authorization").Single());
        Assert.Equal("parent.test", request.RequestUri!.Host);
        Assert.Equal("wrkspc_parent", request.Headers.GetValues("anthropic-workspace-id").Single());
    }

    [Theory]
    [InlineData(ClientKind.Client)]
    [InlineData(ClientKind.ClientWithRawResponse)]
    [InlineData(ClientKind.RawResponseClient)]
    public async Task WithOptions_FreshOptions_OwnBaseUrlAndExtraHeadersWin(ClientKind kind)
    {
        using var parent = new ClientUnderTest(
            WithParentBaseUrlAndWorkspaceId(new ClientOptions { ApiKey = "parent" }),
            kind
        );

        var child = parent.WithOptions(o => new ClientOptions
        {
            HttpClient = o.HttpClient,
            BaseUrl = "https://child.test",
            ExtraHeaders = new Dictionary<string, string> { ["x-child"] = "yes" },
        });
        var request = await child.Send();

        Assert.Equal("Bearer parent", request.Headers.GetValues("Authorization").Single());
        Assert.Equal("child.test", request.RequestUri!.Host);
        Assert.Equal("yes", request.Headers.GetValues("x-child").Single());
        Assert.False(request.Headers.Contains("anthropic-workspace-id"));
    }

    [Theory]
    [MemberData(nameof(EachCredentialOption))]
    public async Task WithOptions_FreshOptionsWithCredential_DropsParentBaseUrlAndExtraHeaders(
        string childOption,
        ClientKind kind
    )
    {
        using var env = new EnvScope(("ANTHROPIC_BASE_URL", null));
        using var parent = new ClientUnderTest(
            WithParentBaseUrlAndWorkspaceId(new ClientOptions { ApiKey = "parent" }),
            kind
        );

        var child = parent.WithOptions(o =>
            Pass(new ClientOptions { HttpClient = o.HttpClient }, childOption, "child")
        );
        var request = await child.Send();

        Assert.Equal("Bearer child", request.Headers.GetValues("Authorization").Single());
        Assert.Equal(new Uri(EnvironmentUrl.Production).Host, request.RequestUri!.Host);
        Assert.False(request.Headers.Contains("anthropic-workspace-id"));
    }

    [Fact]
    public async Task NullCredentials_WithXApiKeyExtraHeader_SendsOnlyXApiKey()
    {
        // The migration guide's recipe for a proxy or gateway that reads X-Api-Key.
        using var env = ApiKeyAndAuthTokenEnvVars();

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                ApiKey = null,
                AuthToken = null,
                ExtraHeaders = new Dictionary<string, string> { ["X-Api-Key"] = "sk-by-hand" },
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.Equal("sk-by-hand", req.Headers.GetValues("X-Api-Key").Single());
        Assert.False(req.Headers.Contains("Authorization"));
    }

    [Fact]
    public async Task ExtraHeaders_XApiKey_SentAlongsideAuthToken()
    {
        using var env = new EnvScope(
            (CredentialsConstants.EnvApiKey, "sk-env"),
            (CredentialsConstants.EnvAuthToken, null),
            (CredentialsConstants.EnvProfile, null)
        );

        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                AuthToken = "gateway-token",
                ExtraHeaders = new Dictionary<string, string> { ["X-Api-Key"] = "sk-by-hand" },
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Messages.Create(TestParams());

        var req = handler.LastRequest!;
        Assert.Equal("sk-by-hand", req.Headers.GetValues("X-Api-Key").Single());
        Assert.Equal("Bearer gateway-token", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task OAuthBeta_IsJoinedToRequestBetasWithACommaAndNoSpace()
    {
        var handler = new FakeHandler();
        using var client = new AnthropicClient(
            new ClientOptions
            {
                Credentials = new FakeCredentials(),
                HttpClient = new HttpClient(handler),
            }
        );

        await client.Beta.Messages.Create(
            new Anthropic.Models.Beta.Messages.MessageCreateParams()
            {
                MaxTokens = 1,
                Model = "claude-sonnet-4-5",
                Messages = [],
                Betas = ["files-api-2025-04-14"],
            }
        );

        Assert.Equal(
            ["files-api-2025-04-14,oauth-2025-04-20"],
            handler.LastRequest!.Headers.GetValues("anthropic-beta")
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
    public async Task UnauthorizedResponse_StreamUpload_IsSentOnce()
    {
        // The first attempt reads the caller's stream to its end, so a refresh-and-retry would
        // send an upload with nothing in it. The 401 surfaces instead.
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

        var stream = new MemoryStream(Encoding.UTF8.GetBytes("file contents"));
        var exception = await Assert.ThrowsAsync<AnthropicUnauthorizedException>(() =>
            client.Files.Upload(
                new FileUploadParams { File = new BinaryContent { Stream = stream } },
                TestContext.Current.CancellationToken
            )
        );

        Assert.Equal(HttpStatusCode.Unauthorized, exception.StatusCode);
        Assert.Single(handler.Requests);
    }

    [Fact]
    public async Task UnauthorizedResponse_ByteArrayUpload_RetriesOnce()
    {
        // Every attempt can send a byte array again, so this upload keeps the refresh-and-retry.
        var creds = new FakeCredentials((n, _) => new AccessToken($"token-{(n == 1 ? "A" : "B")}"));

        var handler = new FakeHandler(
            (_, callNumber) =>
                new HttpResponseMessage(
                    callNumber == 1 ? HttpStatusCode.Unauthorized : HttpStatusCode.OK
                )
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

        using var response = await client.WithRawResponse.Files.Upload(
            new FileUploadParams { File = Encoding.UTF8.GetBytes("file contents") },
            TestContext.Current.CancellationToken
        );

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(2, handler.Requests.Count);
        Assert.Equal("token-A", handler.Requests[0].Headers.Authorization!.Parameter);
        Assert.Equal("token-B", handler.Requests[1].Headers.Authorization!.Parameter);
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
