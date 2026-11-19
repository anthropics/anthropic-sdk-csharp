using System;
using System.Net.Http;
using Anthropic.Core;
using ManagedSettings = Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Services.Beta.Organization.ClaudeCode;

/// <inheritdoc/>
public sealed class ManagedSettingService : IManagedSettingService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-claude-code-managed-settings-2026-10-06");
    }

    readonly Lazy<IManagedSettingServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IManagedSettingServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IManagedSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ManagedSettingService(this._client.WithOptions(modifier));
    }

    public ManagedSettingService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ManagedSettingServiceWithRawResponse(client.WithRawResponse)
        );
        _configuration = new(() => new ManagedSettings::ConfigurationService(client));
        _rbacGroups = new(() => new ManagedSettings::RbacGroupService(client));
        _rbacGroupDefault = new(() => new ManagedSettings::RbacGroupDefaultService(client));
    }

    readonly Lazy<ManagedSettings::IConfigurationService> _configuration;
    public ManagedSettings::IConfigurationService Configuration
    {
        get { return _configuration.Value; }
    }

    readonly Lazy<ManagedSettings::IRbacGroupService> _rbacGroups;
    public ManagedSettings::IRbacGroupService RbacGroups
    {
        get { return _rbacGroups.Value; }
    }

    readonly Lazy<ManagedSettings::IRbacGroupDefaultService> _rbacGroupDefault;
    public ManagedSettings::IRbacGroupDefaultService RbacGroupDefault
    {
        get { return _rbacGroupDefault.Value; }
    }
}

/// <inheritdoc/>
public sealed class ManagedSettingServiceWithRawResponse : IManagedSettingServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IManagedSettingServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ManagedSettingServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ManagedSettingServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _configuration = new(() =>
            new ManagedSettings::ConfigurationServiceWithRawResponse(client)
        );
        _rbacGroups = new(() => new ManagedSettings::RbacGroupServiceWithRawResponse(client));
        _rbacGroupDefault = new(() =>
            new ManagedSettings::RbacGroupDefaultServiceWithRawResponse(client)
        );
    }

    readonly Lazy<ManagedSettings::IConfigurationServiceWithRawResponse> _configuration;
    public ManagedSettings::IConfigurationServiceWithRawResponse Configuration
    {
        get { return _configuration.Value; }
    }

    readonly Lazy<ManagedSettings::IRbacGroupServiceWithRawResponse> _rbacGroups;
    public ManagedSettings::IRbacGroupServiceWithRawResponse RbacGroups
    {
        get { return _rbacGroups.Value; }
    }

    readonly Lazy<ManagedSettings::IRbacGroupDefaultServiceWithRawResponse> _rbacGroupDefault;
    public ManagedSettings::IRbacGroupDefaultServiceWithRawResponse RbacGroupDefault
    {
        get { return _rbacGroupDefault.Value; }
    }
}
