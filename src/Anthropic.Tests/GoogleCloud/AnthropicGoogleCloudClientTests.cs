using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.GoogleCloud;
using Google.Apis.Auth.OAuth2;
using Moq;
using Moq.Protected;

namespace Anthropic.Tests.GoogleCloud;

[Collection("EnvVarMutating")]
public class AnthropicGoogleCloudClientTests : IDisposable
{
    private static readonly string[] s_envVars =
    [
        "ANTHROPIC_GOOGLE_CLOUD_PROJECT",
        "GOOGLE_CLOUD_PROJECT",
        "ANTHROPIC_GOOGLE_CLOUD_LOCATION",
        "ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID",
        "ANTHROPIC_GOOGLE_CLOUD_BASE_URL",
        "ANTHROPIC_API_KEY",
        "ANTHROPIC_AUTH_TOKEN",
        "ANTHROPIC_BASE_URL",
        // Suppress ADC discovery so tests are hermetic.
        "GOOGLE_APPLICATION_CREDENTIALS",
    ];

    private readonly Dictionary<string, string?> _origEnv = new();

    public AnthropicGoogleCloudClientTests()
    {
        foreach (var name in s_envVars)
        {
            _origEnv[name] = Environment.GetEnvironmentVariable(name);
            Environment.SetEnvironmentVariable(name, null);
        }
    }

    public void Dispose()
    {
        foreach (var entry in _origEnv)
        {
            Environment.SetEnvironmentVariable(entry.Key, entry.Value);
        }
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Minimal <see cref="ParamsBase"/> targeting the gateway URL so we can exercise the
    /// adaptation handler via <c>WithRawResponse.Execute</c>.
    /// </summary>
    private record class BlankParams : ParamsBase
    {
        public string Path { get; set; } = "/v1/messages";

        public override Uri Url(ClientOptions options) => new($"{options.BaseUrl}{Path}");

        internal override void AddHeadersToRequest(
            HttpRequestMessage request,
            ClientOptions options
        )
        {
            AddDefaultHeaders(request, options);
        }
    }

    /// <summary>
    /// Creates a mock <see cref="HttpMessageHandler"/> that captures every request and
    /// returns a canned 200 OK.
    /// </summary>
    private static (
        HttpClient httpClient,
        List<HttpRequestMessage> captured
    ) CreateCapturingClient()
    {
        var captured = new List<HttpRequestMessage>();
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
                    // Clone what we assert on — the request is disposed after SendAsync.
                    var clone = new HttpRequestMessage(req.Method, req.RequestUri);
                    foreach (var header in req.Headers)
                    {
                        clone.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                    captured.Add(clone);
                }
            )
            .ReturnsAsync(() =>
                new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                }
            );
        return (new HttpClient(handlerMock.Object), captured);
    }

    private static async Task<HttpRequestMessage> SendOneRequest(
        AnthropicGoogleCloudClient client,
        HttpClient? httpClient = null,
        List<HttpRequestMessage>? captured = null
    )
    {
        if (httpClient == null)
        {
            (httpClient, captured) = CreateCapturingClient();
        }
        var injected = httpClient;
        var rawClient = client
            .WithOptions(opts =>
            {
                opts.HttpClient = injected;
                return opts;
            })
            .WithRawResponse;

        await rawClient.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        Assert.NotNull(captured);
        Assert.Single(captured!);
        return captured![0];
    }

    private static AnthropicGoogleCloudClient NewClient(GoogleCloudClientOptions options) =>
        new(options);

    private static Func<CancellationToken, Task<string>> StaticToken(string token) =>
        _ => Task.FromResult(token);

    private const string WorkspaceBaseUrl =
        "https://claude.googleapis.com/v1/projects/my-proj"
        + "/locations/us-central1/workspaces/ws-123/invoke";

    private const string OrganizationBaseUrl =
        "https://claude.googleapis.com/v1/projects/my-proj"
        + "/locations/us-central1/claudeOrganization/invoke";

    private static GoogleCloudClientOptions DerivedOptions(
        HttpClient httpClient,
        string? workspaceId = "ws-123"
    ) =>
        new()
        {
            TokenProvider = StaticToken("tok"),
            Project = "my-proj",
            Location = "us-central1",
            WorkspaceId = workspaceId,
            ClientOptions = new() { HttpClient = httpClient },
        };

    private static async Task SendWorkspaceRequest(IAnthropicClient client)
    {
        using var response = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );
    }

    private static async Task SendOrganizationRequest(IAnthropicClient client)
    {
        await client.Beta.Organization.Workspaces.List(
            cancellationToken: TestContext.Current.CancellationToken
        );
    }

    private static async Task SendUserProfilesRequest(AnthropicGoogleCloudClient client)
    {
        await client.Beta.UserProfiles.List(
            cancellationToken: TestContext.Current.CancellationToken
        );
    }

    #region Validation

    [Fact]
    public void Constructor_WithoutWorkspaceId_DoesNotThrow()
    {
        NewClient(new() { TokenProvider = StaticToken("tok"), BaseUrl = "http://localhost" });
        NewClient(new() { TokenProvider = StaticToken("tok"), Project = "proj" });
        NewClient(new() { SkipAuth = true, Project = "proj" });
    }

    [Fact]
    public void Constructor_WithoutProject_Throws()
    {
        var ex = Assert.Throws<AnthropicException>(() =>
            NewClient(
                new()
                {
                    TokenProvider = StaticToken("tok"),
                    WorkspaceId = "ws",
                    Location = "us-central1",
                }
            )
        );
        Assert.Contains("project", ex.Message);
        Assert.Contains("ANTHROPIC_GOOGLE_CLOUD_PROJECT", ex.Message);
    }

    [Fact]
    public void Constructor_WithoutLocation_DefaultsToGlobal()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "proj",
            }
        );
        Assert.Contains("/locations/global/", client.BaseUrl);
    }

    [Fact]
    public void Constructor_SkipAuthWithCredentials_Throws()
    {
        var ex = Assert.Throws<AnthropicException>(() =>
            NewClient(
                new()
                {
                    SkipAuth = true,
                    TokenProvider = StaticToken("tok"),
                    BaseUrl = "http://localhost",
                }
            )
        );
        Assert.Contains("mutually exclusive", ex.Message);
    }

    #endregion

    #region Precedence — project / location / workspace / base URL

    [Fact]
    public void Project_ArgBeatsEnv()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_PROJECT", "env-proj");
        Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "fallback-proj");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "arg-proj",
                Location = "us-central1",
            }
        );
        Assert.Contains("/projects/arg-proj/", client.BaseUrl);
    }

    [Fact]
    public void Project_EnvBeatsFallbackEnv()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_PROJECT", "env-proj");
        Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "fallback-proj");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Location = "us-central1",
            }
        );
        Assert.Contains("/projects/env-proj/", client.BaseUrl);
    }

    [Fact]
    public void Project_FallbackEnvUsedWhenPrimaryUnset()
    {
        Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "fallback-proj");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Location = "us-central1",
            }
        );
        Assert.Contains("/projects/fallback-proj/", client.BaseUrl);
    }

    [Fact]
    public void Location_ArgBeatsEnv()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_LOCATION", "env-loc");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "p",
                Location = "arg-loc",
            }
        );
        Assert.StartsWith("https://claude.googleapis.com/", client.BaseUrl);
        Assert.Contains("/locations/arg-loc/", client.BaseUrl);
    }

    [Fact]
    public void Location_EnvUsedWhenArgUnset()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_LOCATION", "env-loc");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "p",
            }
        );
        Assert.Contains("/locations/env-loc/", client.BaseUrl);
    }

    [Fact]
    public void WorkspaceId_ArgBeatsEnv()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID", "env-ws");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "arg-ws",
                Project = "p",
            }
        );
        Assert.Contains("/workspaces/arg-ws/", client.BaseUrl);
    }

    [Fact]
    public void WorkspaceId_EnvUsedWhenArgUnset()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID", "env-ws");
        var client = NewClient(new() { TokenProvider = StaticToken("tok"), Project = "p" });
        Assert.Contains("/workspaces/env-ws/", client.BaseUrl);
    }

    [Fact]
    public void BaseUrl_ArgBeatsEnvAndDerived()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_BASE_URL", "http://env-url");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "p",
                Location = "l",
                BaseUrl = "http://arg-url",
            }
        );
        Assert.Equal("http://arg-url", client.BaseUrl);
    }

    [Fact]
    public void BaseUrl_EnvBeatsDerived()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_BASE_URL", "http://env-url");
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                Project = "p",
                Location = "l",
            }
        );
        Assert.Equal("http://env-url", client.BaseUrl);
    }

    [Fact]
    public void BaseUrl_DerivedFromProjectLocationAndWorkspace()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws-123",
                Project = "my-proj",
                Location = "us-central1",
            }
        );
        Assert.Equal(
            "https://claude.googleapis.com/v1/projects/my-proj"
                + "/locations/us-central1/workspaces/ws-123/invoke",
            client.BaseUrl
        );
    }

    [Fact]
    public void BaseUrl_DerivedWithDefaultLocation()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws-123",
                Project = "my-proj",
            }
        );
        Assert.Equal(
            "https://claude.googleapis.com/v1/projects/my-proj"
                + "/locations/global/workspaces/ws-123/invoke",
            client.BaseUrl
        );
    }

    [Fact]
    public void BaseUrl_ExplicitNeedsNoLocationOrProject()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        Assert.Equal("http://localhost", client.BaseUrl);
    }

    #endregion

    #region Credentials

    [Fact]
    public async Task TokenProvider_BeatsCredential()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = _ => Task.FromResult("provider-tok"),
                GoogleCredential = GoogleCredential.FromAccessToken("cred-tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);
        Assert.Equal("Bearer provider-tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task GoogleCredential_UsedWhenNoOverride()
    {
        var client = NewClient(
            new()
            {
                GoogleCredential = GoogleCredential.FromAccessToken("cred-tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);
        Assert.Equal("Bearer cred-tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task TokenProvider_ReceivesCancellationToken()
    {
        CancellationToken seen = default;
        var client = NewClient(
            new()
            {
                TokenProvider = ct =>
                {
                    seen = ct;
                    return Task.FromResult("tok");
                },
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        await SendOneRequest(client);
        Assert.True(seen.CanBeCanceled);
    }

    #endregion

    #region Credential isolation

    /// <summary>
    /// First-party Anthropic env vars must never leak onto the wire — even when set,
    /// no <c>X-Api-Key</c> and no first-party <c>Authorization</c> reach the gateway.
    /// </summary>
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Isolation_FirstPartyEnvVarsNotSent(bool freshOptions)
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", "first-party-api-key");
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");
        Environment.SetEnvironmentVariable("ANTHROPIC_BASE_URL", "http://first-party-base");

        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("google-tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        if (freshOptions)
        {
            client = Assert.IsType<AnthropicGoogleCloudClient>(
                client.WithOptions(opts => new ClientOptions { BaseUrl = opts.BaseUrl })
            );
        }
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("X-Api-Key"));
        var auth = req.Headers.GetValues("Authorization").ToArray();
        Assert.Equal(["Bearer google-tok"], auth);
        Assert.Equal("http://localhost/v1/messages", req.RequestUri!.ToString());
    }

    [Fact]
    public async Task Isolation_FirstPartyEnvVarsNotSent_RawResponseFreshOptions()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", "first-party-api-key");
        Environment.SetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN", "first-party-auth-token");

        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("google-tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var (httpClient, captured) = CreateCapturingClient();
        var raw = client.WithRawResponse.WithOptions(o => new ClientOptions
        {
            HttpClient = httpClient,
            BaseUrl = o.BaseUrl,
        });
        await raw.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        var req = Assert.Single(captured);
        Assert.Equal("Bearer google-tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task Isolation_AdaptationHandlerStripsXApiKey()
    {
        // A user handler (or misconfigured ClientOptions) re-adds X-Api-Key after the
        // ctor cleared it; the adaptation handler removes it before send.
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("google-tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
                ClientOptions = new()
                {
                    Handlers =
                    [
                        Handler.Create(
                            (req, next, ct) =>
                            {
                                req.Headers.TryAddWithoutValidation("X-Api-Key", "leaked");
                                return next(req, ct);
                            }
                        ),
                    ],
                },
            }
        );
        var req = await SendOneRequest(client);
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    #endregion

    #region Workspace id (path-only)

    /// <summary>
    /// The workspace ID travels in the derived base URL path only — the gateway resolves
    /// the workspace from the path and mints the header itself, so the client never sends
    /// <c>anthropic-workspace-id</c>.
    /// </summary>
    [Fact]
    public async Task Workspace_HeaderNotSent()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws-abc",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
        // Default headers are present, so the absence above is a real negative — the
        // header pipeline ran and simply never adds the workspace header.
        Assert.True(req.Headers.Contains("anthropic-version"));
    }

    [Fact]
    public async Task Workspace_ClientDoesNotInjectHeaderOverUserExtraHeaders()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws-dedicated",
                BaseUrl = "http://localhost",
                ClientOptions = new()
                {
                    ExtraHeaders = new Dictionary<string, string>
                    {
                        ["anthropic-workspace-id"] = "ws-from-extra",
                    },
                },
            }
        );
        var req = await SendOneRequest(client);
        // A user-supplied extra header passes through untouched; the client adds nothing.
        Assert.Equal("ws-from-extra", req.Headers.GetValues("anthropic-workspace-id").Single());
    }

    #endregion

    #region SkipAuth

    [Fact]
    public void SkipAuth_WithExplicitBaseUrl_NoWorkspaceOrCredentialsRequired()
    {
        var client = NewClient(new() { SkipAuth = true, BaseUrl = "http://localhost" });
        Assert.NotNull(client);
    }

    [Fact]
    public void SkipAuth_WithoutBaseUrl_DerivesUrlFromWorkspace()
    {
        var client = NewClient(
            new()
            {
                SkipAuth = true,
                Project = "proj",
                WorkspaceId = "ws-123",
            }
        );
        Assert.Equal(
            "https://claude.googleapis.com/v1/projects/proj"
                + "/locations/global/workspaces/ws-123/invoke",
            client.BaseUrl
        );
    }

    [Fact]
    public async Task SkipAuth_NoAuthHeadersOnWire()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_API_KEY", "first-party-api-key");
        var client = NewClient(new() { SkipAuth = true, BaseUrl = "http://localhost" });
        var req = await SendOneRequest(client);

        Assert.False(req.Headers.Contains("Authorization"));
        Assert.False(req.Headers.Contains("X-Api-Key"));
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
    }

    [Fact]
    public async Task SkipAuth_WorkspaceHeaderNotSentEvenWhenProvided()
    {
        var client = NewClient(
            new()
            {
                SkipAuth = true,
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var req = await SendOneRequest(client);
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
    }

    #endregion

    #region Organization routing

    [Fact]
    public async Task OrganizationRoute_SentToOrganizationBase()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        await SendOrganizationRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(
            OrganizationBaseUrl + "/v1/organizations/workspaces",
            req.RequestUri!.AbsoluteUri
        );
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    [Fact]
    public async Task OrganizationRoute_NonBeta_SentToOrganizationBase()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        await client.Organization.Retrieve(
            cancellationToken: TestContext.Current.CancellationToken
        );

        var req = Assert.Single(captured);
        Assert.Equal(OrganizationBaseUrl + "/v1/organizations/me", req.RequestUri!.AbsoluteUri);
    }

    [Fact]
    public async Task UserProfilesRoute_SentToOrganizationBase()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        await SendUserProfilesRequest(client);
        await client.Beta.UserProfiles.Create(
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.UserProfiles.Retrieve(
            "uprof_123",
            cancellationToken: TestContext.Current.CancellationToken
        );
        await client.Beta.UserProfiles.CreateEnrollmentUrl(
            "uprof_123",
            cancellationToken: TestContext.Current.CancellationToken
        );

        Assert.Equal(
            [
                OrganizationBaseUrl + "/v1/user_profiles",
                OrganizationBaseUrl + "/v1/user_profiles",
                OrganizationBaseUrl + "/v1/user_profiles/uprof_123",
                OrganizationBaseUrl + "/v1/user_profiles/uprof_123/enrollment_url",
            ],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
        Assert.All(
            captured,
            req => Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single())
        );
    }

    [Fact]
    public async Task UserProfilesRoute_NeedsNoWorkspaceId()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient, workspaceId: null));

        await SendUserProfilesRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(OrganizationBaseUrl + "/v1/user_profiles", req.RequestUri!.AbsoluteUri);
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
    }

    [Theory]
    [InlineData("/v1/user_profiles", OrganizationBaseUrl)]
    [InlineData("/v1/user_profiles?limit=1", OrganizationBaseUrl)]
    [InlineData("/v1/user_profilesX", WorkspaceBaseUrl)]
    public async Task UserProfilesRoute_MatchesWholePathSegment(string path, string expectedBaseUrl)
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        using var response = await client.WithRawResponse.Execute(
            new HttpRequest<BlankParams>
            {
                Method = HttpMethod.Post,
                Params = new() { Path = path },
            },
            TestContext.Current.CancellationToken
        );

        var req = Assert.Single(captured);
        Assert.Equal(expectedBaseUrl + path, req.RequestUri!.AbsoluteUri);
    }

    [Fact]
    public async Task WorkspaceRoute_SentToWorkspaceBase()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        await SendWorkspaceRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(WorkspaceBaseUrl + "/v1/messages", req.RequestUri!.AbsoluteUri);
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task OrganizationRoute_NeedsNoWorkspaceId()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient, workspaceId: null));

        await SendOrganizationRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(
            OrganizationBaseUrl + "/v1/organizations/workspaces",
            req.RequestUri!.AbsoluteUri
        );
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task OrganizationRoute_UsesResolvedProjectAndLocation()
    {
        Environment.SetEnvironmentVariable("GOOGLE_CLOUD_PROJECT", "fallback-proj");
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_LOCATION", "env-loc");
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                ClientOptions = new() { HttpClient = httpClient },
            }
        );

        await SendOrganizationRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(
            "https://claude.googleapis.com/v1/projects/fallback-proj"
                + "/locations/env-loc/claudeOrganization/invoke"
                + "/v1/organizations/workspaces",
            req.RequestUri!.AbsoluteUri
        );
    }

    [Fact]
    public async Task WorkspaceRoute_WithoutWorkspaceId_ThrowsBeforeSending()
    {
        var tokenRequested = false;
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(
            new()
            {
                TokenProvider = _ =>
                {
                    tokenRequested = true;
                    return Task.FromResult("tok");
                },
                Project = "my-proj",
                Location = "us-central1",
                ClientOptions = new() { HttpClient = httpClient },
            }
        );

        var ex = await Assert.ThrowsAsync<AnthropicException>(() => SendWorkspaceRequest(client));

        Assert.Contains("WorkspaceId", ex.Message);
        Assert.Contains("ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID", ex.Message);
        Assert.Empty(captured);
        Assert.False(tokenRequested);
    }

    [Fact]
    public async Task ExplicitBaseUrl_TakesEveryRoute()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                Project = "my-proj",
                Location = "us-central1",
                WorkspaceId = "ws-123",
                BaseUrl = "http://localhost",
                ClientOptions = new() { HttpClient = httpClient },
            }
        );

        await SendOrganizationRequest(client);
        await SendUserProfilesRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            [
                "http://localhost/v1/organizations/workspaces",
                "http://localhost/v1/user_profiles",
                "http://localhost/v1/messages",
            ],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task EnvBaseUrl_TakesEveryRoute()
    {
        Environment.SetEnvironmentVariable("ANTHROPIC_GOOGLE_CLOUD_BASE_URL", "http://env-url");
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient));

        await SendOrganizationRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            ["http://env-url/v1/organizations/workspaces", "http://env-url/v1/messages"],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task AssignedBaseUrl_TakesEveryRoute()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = new AnthropicGoogleCloudClient(DerivedOptions(httpClient))
        {
            BaseUrl = "http://localhost",
        };

        await SendOrganizationRequest(client);
        await SendOrganizationRequest(client.WithOptions(opts => opts));

        Assert.Equal(
            [
                "http://localhost/v1/organizations/workspaces",
                "http://localhost/v1/organizations/workspaces",
            ],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task WithOptions_AssignedBaseUrl_TakesEveryRoute()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient))
            .WithOptions(opts =>
            {
                opts.BaseUrl = "http://localhost";
                return opts;
            });

        await SendOrganizationRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            ["http://localhost/v1/organizations/workspaces", "http://localhost/v1/messages"],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task WithOptions_DerivedClient_KeepsRouting()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(httpClient))
            .WithOptions(opts =>
            {
                opts.MaxRetries = 0;
                return opts;
            });

        await SendOrganizationRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            [
                OrganizationBaseUrl + "/v1/organizations/workspaces",
                WorkspaceBaseUrl + "/v1/messages",
            ],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task WithOptions_FreshOptions_KeepsRouting()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(DerivedOptions(new HttpClient()))
            .WithOptions(opts => new ClientOptions
            {
                HttpClient = httpClient,
                BaseUrl = opts.BaseUrl,
            });

        await SendOrganizationRequest(client);

        var req = Assert.Single(captured);
        Assert.Equal(
            OrganizationBaseUrl + "/v1/organizations/workspaces",
            req.RequestUri!.AbsoluteUri
        );
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
    }

    [Fact]
    public async Task WithOptions_NoWorkspaceId_ExplicitBaseUrl_TakesEveryRoute()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = NewClient(
                new()
                {
                    TokenProvider = StaticToken("tok"),
                    BaseUrl = "http://localhost",
                    ClientOptions = new() { HttpClient = httpClient },
                }
            )
            .WithOptions(opts =>
            {
                opts.MaxRetries = 0;
                return opts;
            });

        await SendOrganizationRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            ["http://localhost/v1/organizations/workspaces", "http://localhost/v1/messages"],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    [Fact]
    public async Task WithOptions_NoWorkspaceId_AssignedBaseUrl_TakesEveryRoute()
    {
        var (httpClient, captured) = CreateCapturingClient();
        var client = new AnthropicGoogleCloudClient(DerivedOptions(httpClient, workspaceId: null))
        {
            BaseUrl = "http://localhost",
        }.WithOptions(opts =>
        {
            opts.MaxRetries = 0;
            return opts;
        });

        await SendOrganizationRequest(client);
        await SendWorkspaceRequest(client);

        Assert.Equal(
            ["http://localhost/v1/organizations/workspaces", "http://localhost/v1/messages"],
            captured.Select(req => req.RequestUri!.AbsoluteUri)
        );
    }

    #endregion

    #region Surface

    [Fact]
    public void Surface_FullApiAvailable()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        Assert.NotNull(client.Messages);
        Assert.NotNull(client.Models);
        Assert.NotNull(client.Beta);
    }

    [Fact]
    public void WithOptions_ReturnsSameSubclass()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var derived = client.WithOptions(o => o);
        Assert.IsType<AnthropicGoogleCloudClient>(derived);
    }

    [Fact]
    public async Task WithOptions_PreservesAuth()
    {
        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("tok"),
                WorkspaceId = "ws",
                BaseUrl = "http://localhost",
            }
        );
        var (httpClient, captured) = CreateCapturingClient();
        var raw = client
            .WithOptions(o =>
            {
                // Fresh ClientOptions — exercises the private-ctor restore path.
                return new ClientOptions { HttpClient = httpClient, BaseUrl = o.BaseUrl };
            })
            .WithRawResponse;
        await raw.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        var req = Assert.Single(captured);
        Assert.Equal("Bearer tok", req.Headers.GetValues("Authorization").Single());
        Assert.False(req.Headers.Contains("anthropic-workspace-id"));
        Assert.False(req.Headers.Contains("X-Api-Key"));
    }

    #endregion

    #region Cross-origin redirect

    /// <summary>
    /// Verifies the cross-origin-redirect guarantee end to end: the adaptation handler
    /// runs once, outside <see cref="HttpClient"/>; .NET's default
    /// <c>SocketsHttpHandler</c> / <c>HttpClientHandler</c> follows the redirect
    /// internally and strips <c>Authorization</c> when the target authority differs.
    /// Uses two real loopback listeners so the platform's redirect logic is what's
    /// exercised, not a mock.
    /// </summary>
    [Fact]
    public async Task CrossOriginRedirect_BearerNotSentToRedirectedHost()
    {
        var (portA, portB) = (FindFreePort(), FindFreePort());
        using var listenerA = StartListener(portA);
        using var listenerB = StartListener(portB);

        string? authAtA = null;
        string? authAtB = null;
        bool? hadXApiKeyAtB = null;

        var ct = TestContext.Current.CancellationToken;
        var serveA = Task.Run(
            async () =>
            {
                var ctx = await listenerA.GetContextAsync().ConfigureAwait(false);
                authAtA = ctx.Request.Headers["Authorization"];
                ctx.Response.RedirectLocation = $"http://127.0.0.1:{portB}/v1/messages";
                ctx.Response.StatusCode = (int)HttpStatusCode.Redirect;
                ctx.Response.Close();
            },
            ct
        );
        var serveB = Task.Run(
            async () =>
            {
                var ctx = await listenerB.GetContextAsync().ConfigureAwait(false);
                authAtB = ctx.Request.Headers["Authorization"];
                hadXApiKeyAtB = ctx.Request.Headers["X-Api-Key"] != null;
                ctx.Response.StatusCode = 200;
                var body = System.Text.Encoding.UTF8.GetBytes("{}");
                ctx.Response.ContentType = "application/json";
                ctx.Response.OutputStream.Write(body, 0, body.Length);
                ctx.Response.Close();
            },
            ct
        );

        var client = NewClient(
            new()
            {
                TokenProvider = StaticToken("google-tok"),
                WorkspaceId = "ws",
                BaseUrl = $"http://127.0.0.1:{portA}",
            }
        );

        // Default HttpClient — exercises the platform's own redirect handling.
        var rawClient = client
            .WithOptions(opts =>
            {
                opts.HttpClient = new HttpClient();
                opts.MaxRetries = 0;
                return opts;
            })
            .WithRawResponse;

        await rawClient.Execute(
            new HttpRequest<BlankParams> { Method = HttpMethod.Post, Params = new() },
            TestContext.Current.CancellationToken
        );

        await Task.WhenAll(serveA, serveB);

        Assert.Equal("Bearer google-tok", authAtA);
        Assert.Null(authAtB);
        Assert.False(hadXApiKeyAtB);
    }

    private static int FindFreePort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        var port = ((IPEndPoint)listener.LocalEndpoint).Port;
        listener.Stop();
        return port;
    }

    private static HttpListener StartListener(int port)
    {
        var listener = new HttpListener();
        listener.Prefixes.Add($"http://127.0.0.1:{port}/");
        listener.Start();
        return listener;
    }

    #endregion
}
