using System;
using System.Collections.Generic;
using System.IO;
using Anthropic.Oidc;

namespace Anthropic.Tests.Oidc;

public class AnthropicCredentialsResolveTests : IDisposable
{
    private readonly Dictionary<string, string?> _originalEnvVars = new();
    private readonly string _tempConfigDir;

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
        SetEnv(OidcConstants.EnvApiKey, "sk-test-key");
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvFederationRuleId, null);
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }

    [Fact]
    public void AuthToken_ReturnsStaticTokenCredentials()
    {
        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, "bearer-token-123");
        SetEnv(OidcConstants.EnvFederationRuleId, null);
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.IsType<StaticTokenCredentials>(result!.Credentials);
    }

    [Fact]
    public void EnvVars_FederationRuleWithIdentityToken_ReturnsWorkloadIdentity()
    {
        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvFederationRuleId, "fdrl_01test");
        SetEnv(OidcConstants.EnvIdentityToken, "jwt-string");
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvOrganizationId, "org-id");
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
        Assert.IsType<WorkloadIdentityCredentials>(result!.Credentials);
        result.Credentials.Dispose();
    }

    [Fact]
    public void NoCredentials_ReturnsNull()
    {
        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvFederationRuleId, null);
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }

    [Fact]
    public void FederationRuleWithoutIdentityToken_ReturnsNull()
    {
        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvFederationRuleId, "fdrl_01test");
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

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

        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(OidcConstants.EnvFederationRuleId, "fdrl_01abc");
        SetEnv(OidcConstants.EnvOrganizationId, "org-123");
        SetEnv(OidcConstants.EnvIdentityTokenFile, tokenPath);

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

        SetEnv(OidcConstants.EnvApiKey, null);
        SetEnv(OidcConstants.EnvAuthToken, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);
        SetEnv(OidcConstants.EnvFederationRuleId, null);
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);

        var result = AnthropicCredentials.Resolve();
        Assert.NotNull(result);
    }

    [Fact]
    public void ApiKey_TakesPrecedenceOverAuthToken()
    {
        SetEnv(OidcConstants.EnvApiKey, "sk-test-key");
        SetEnv(OidcConstants.EnvAuthToken, "bearer-token");
        SetEnv(OidcConstants.EnvFederationRuleId, null);
        SetEnv(OidcConstants.EnvIdentityToken, null);
        SetEnv(OidcConstants.EnvIdentityTokenFile, null);
        SetEnv(OidcConstants.EnvProfile, null);
        SetEnv(OidcConstants.EnvConfigDir, _tempConfigDir);

        var result = AnthropicCredentials.Resolve();
        Assert.Null(result);
    }
}
