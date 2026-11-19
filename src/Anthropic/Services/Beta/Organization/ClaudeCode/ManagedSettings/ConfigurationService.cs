using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.Configuration;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <inheritdoc/>
public sealed class ConfigurationService : IConfigurationService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-claude-code-managed-settings-2026-10-06");
    }

    readonly Lazy<IConfigurationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IConfigurationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConfigurationService(this._client.WithOptions(modifier));
    }

    public ConfigurationService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ConfigurationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeManagedSettingsConfiguration> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeManagedSettingsConfiguration> Update(
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ConfigurationServiceWithRawResponse : IConfigurationServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConfigurationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConfigurationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConfigurationServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeManagedSettingsConfiguration>> Retrieve(
        ConfigurationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConfigurationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.configuration.retrieve",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeManagedSettingsConfiguration = await response
                    .Deserialize<BetaClaudeCodeManagedSettingsConfiguration>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeManagedSettingsConfiguration.Validate();
                }
                return betaClaudeCodeManagedSettingsConfiguration;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeManagedSettingsConfiguration>> Update(
        ConfigurationUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConfigurationUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.configuration.update",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeManagedSettingsConfiguration = await response
                    .Deserialize<BetaClaudeCodeManagedSettingsConfiguration>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeManagedSettingsConfiguration.Validate();
                }
                return betaClaudeCodeManagedSettingsConfiguration;
            }
        );
    }
}
