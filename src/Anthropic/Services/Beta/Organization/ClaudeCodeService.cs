using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeCode;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ClaudeCodeService : IClaudeCodeService
{
    readonly Lazy<IClaudeCodeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClaudeCodeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IClaudeCodeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClaudeCodeService(this._client.WithOptions(modifier));
    }

    public ClaudeCodeService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ClaudeCodeServiceWithRawResponse(client.WithRawResponse));
        _managedSettings = new(() => new ManagedSettingService(client));
    }

    readonly Lazy<IManagedSettingService> _managedSettings;
    public IManagedSettingService ManagedSettings
    {
        get { return _managedSettings.Value; }
    }
}

/// <inheritdoc/>
public sealed class ClaudeCodeServiceWithRawResponse : IClaudeCodeServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClaudeCodeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ClaudeCodeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClaudeCodeServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _managedSettings = new(() => new ManagedSettingServiceWithRawResponse(client));
    }

    readonly Lazy<IManagedSettingServiceWithRawResponse> _managedSettings;
    public IManagedSettingServiceWithRawResponse ManagedSettings
    {
        get { return _managedSettings.Value; }
    }
}
