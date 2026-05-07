#pragma warning disable xUnit1051
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

[Collection("EnvVarMutating")]
public class AnthropicCredentialsResolveTests : IDisposable
{
    private readonly Dictionary<string, string?> _originalEnvVars = new();
    private readonly string _tempConfigDir;

    private class FakeHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, Task<HttpResponseMessage>> _handler;
        public List<HttpRequestMessage> Requests { get; } = new();

        public FakeHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> handler)
        {
            _handler = handler;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            Requests.Add(request);
            return await _handler(request);
        }
    }

    private static HttpResponseMessage OkTokenResponse()
    {
        var json = JsonSerializer.Serialize(
            new { access_token = "sk-ant-oat01-test", expires_in = 600 }
        );
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json"),
        };
    }

    public AnthropicCredentialsResolveTests()
    {
        _tempConfigDir = Path.Combine(
            Path.GetTempPath(),
            "anthropic_test_config_" + Guid.NewGuid().ToString("N")
        );
        Directory.CreateDirectory(_tempConfigDir);
    }

    private void SetEnv(string name, string? value)
    {
        if (!_originalEnvVars.ContainsKey(name))
        {
            _originalEnvVars[name] = Environment.GetEnvironmentVariable(name);
        }
        Environment.SetEnvironmentVariable(name, value);
    }

    public void Dispose()
    {
        foreach (var kvp in _originalEnvVars)
        {
            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
        }
        try
        {
            Directory.Delete(_tempConfigDir, true);
        }
        catch { }
        GC.SuppressFinalize(this);
    }

    [Fact]
    public void ApiKey_ReturnsNull()
    {
        SetEnv(CredentialsConstants.EnvApiKey, "sk-test-key");
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }

    [Fact]
    public void AuthToken_ReturnsStaticTokenCredentials()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, "bearer-token-123");
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.IsType<StaticTokenCredentials>(result!.Credentials);
    }

    [Fact]
    public void EnvVars_FederationRuleWithIdentityToken_ReturnsWorkloadIdentity()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, "fdrl_01test");
        SetEnv(CredentialsConstants.EnvIdentityToken, "jwt-string");
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvOrganizationId, "org-id");
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);
        result.Credentials.Dispose();
    }

    [Fact]
    public void NoCredentials_ReturnsNull()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }

    [Fact]
    public void Resolve_ExplicitProfile_NotFound_Throws()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, "nonexistent");
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var ex = Assert.Throws<WorkloadIdentityException>(() => AnthropicCredentials.Resolve());
        Assert.Contains("nonexistent", ex.Message);
    }

    [Fact]
    public void FederationRuleWithoutIdentityToken_ReturnsNull()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, "fdrl_01test");
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }

    [Fact]
    public void FederationEnvVars_PreemptActiveConfigPointer()
    {
        // Regression: a leftover active_config pointer (e.g. from a past
        // `ant auth login`) must NOT preempt env-var WIF. A machine with
        // WIF env vars wired up should use WIF regardless of on-disk state.
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "configs"));
        File.WriteAllText(Path.Combine(_tempConfigDir, "active_config"), "myprofile");
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "configs", "myprofile.json"),
            "{\"authentication\":{\"type\":\"user_oauth\"}}"
        );
        // Deliberately DON'T write credentials/myprofile.json — stale pointer.

        var tokenPath = Path.Combine(_tempConfigDir, "jwt");
        File.WriteAllText(tokenPath, "the-jwt");

        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(CredentialsConstants.EnvFederationRuleId, "fdrl_01abc");
        SetEnv(CredentialsConstants.EnvOrganizationId, "org-123");
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, tokenPath);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);
    }

    [Fact]
    public void ActiveConfigPointer_UsedAsFallback_WhenNoWif()
    {
        // Confirms the common `ant auth login` flow still resolves through
        // the fallback path once WIF env vars aren't set.
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "configs"));
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "credentials"));
        File.WriteAllText(Path.Combine(_tempConfigDir, "active_config"), "myprofile");
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "configs", "myprofile.json"),
            "{\"authentication\":{\"type\":\"user_oauth\"}}"
        );
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "credentials", "myprofile.json"),
            "{\"access_token\":\"pointer-token\",\"expires_at\":9999999999}"
        );

        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
    }

    [Fact]
    public void Resolve_UserOAuth_SetsWorkspaceIdHeader()
    {
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "configs"));
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "credentials"));
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "configs", "ws.json"),
            "{\"workspace_id\":\"wrkspc_abc\",\"authentication\":{\"type\":\"user_oauth\"}}"
        );
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "credentials", "ws.json"),
            "{\"type\":\"oauth_token\",\"access_token\":\"tok\",\"expires_at\":9999999999}"
        );

        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvProfile, "ws");
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.True(result!.ExtraHeaders.TryGetValue("anthropic-workspace-id", out var ws));
        Assert.Equal("wrkspc_abc", ws);
        result.Credentials.Dispose();
    }

    [Fact]
    public async Task Resolve_OidcFederation_DoesNotSetWorkspaceIdHeader()
    {
        Directory.CreateDirectory(Path.Combine(_tempConfigDir, "configs"));
        var jwtPath = Path.Combine(_tempConfigDir, "jwt");
        File.WriteAllText(jwtPath, "the-jwt");
        File.WriteAllText(
            Path.Combine(_tempConfigDir, "configs", "wif.json"),
            "{\"workspace_id\":\"wrkspc_abc\",\"authentication\":{"
                + "\"type\":\"oidc_federation\",\"federation_rule_id\":\"fdrl_01x\","
                + "\"identity_token\":{\"source\":\"file\",\"path\":\""
                + jwtPath.Replace("\\", "\\\\")
                + "\"}}}"
        );

        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvProfile, "wif");
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return OkTokenResponse();
        });
        using var httpClient = new HttpClient(handler);

        var result = AnthropicCredentials.Resolve(httpClient: httpClient);
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);
        // For federation profiles workspace_id is sent in the jwt-bearer exchange body,
        // not as a request header.
        Assert.False(result.ExtraHeaders.ContainsKey("anthropic-workspace-id"));

        await result.Credentials.GetTokenAsync();
        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.Equal("wrkspc_abc", doc.RootElement.GetProperty("workspace_id").GetString());
        result.Credentials.Dispose();
    }

    [Fact]
    public async Task EnvVars_WorkspaceId_PassedThroughToExchange()
    {
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, "fdrl_01abc");
        SetEnv(CredentialsConstants.EnvIdentityToken, "literal-jwt");
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvOrganizationId, "org-uuid");
        SetEnv(CredentialsConstants.EnvWorkspaceId, "wrkspc_01abc");
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return OkTokenResponse();
        });
        using var httpClient = new HttpClient(handler);

        var result = AnthropicCredentials.Resolve(httpClient: httpClient);
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);

        await result.Credentials.GetTokenAsync();
        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.Equal("wrkspc_01abc", doc.RootElement.GetProperty("workspace_id").GetString());
        result.Credentials.Dispose();
    }

    [Fact]
    public async Task EnvVars_WorkspaceId_EmptyTreatedAsUnset()
    {
        // ANTHROPIC_WORKSPACE_ID="" (a defaulted-but-empty CI variable) is
        // treated as unset — never put "workspace_id": "" on the wire.
        SetEnv(CredentialsConstants.EnvApiKey, null);
        SetEnv(CredentialsConstants.EnvAuthToken, null);
        SetEnv(CredentialsConstants.EnvFederationRuleId, "fdrl_01abc");
        SetEnv(CredentialsConstants.EnvIdentityToken, "literal-jwt");
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvOrganizationId, "org-uuid");
        SetEnv(CredentialsConstants.EnvWorkspaceId, "");
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        string? capturedBody = null;
        var handler = new FakeHandler(async req =>
        {
            capturedBody = await req.Content!.ReadAsStringAsync();
            return OkTokenResponse();
        });
        using var httpClient = new HttpClient(handler);

        var result = AnthropicCredentials.Resolve(httpClient: httpClient);
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);

        await result.Credentials.GetTokenAsync();
        Assert.NotNull(capturedBody);
        using var doc = JsonDocument.Parse(capturedBody!);
        Assert.False(doc.RootElement.TryGetProperty("workspace_id", out _));
        result.Credentials.Dispose();
    }

    [Fact]
    public void ApiKey_TakesPrecedenceOverAuthToken()
    {
        SetEnv(CredentialsConstants.EnvApiKey, "sk-test-key");
        SetEnv(CredentialsConstants.EnvAuthToken, "bearer-token");
        SetEnv(CredentialsConstants.EnvFederationRuleId, null);
        SetEnv(CredentialsConstants.EnvIdentityToken, null);
        SetEnv(CredentialsConstants.EnvIdentityTokenFile, null);
        SetEnv(CredentialsConstants.EnvWorkspaceId, null);
        SetEnv(CredentialsConstants.EnvProfile, null);
        SetEnv(CredentialsConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }
}
