using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroupDefault;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <inheritdoc/>
public sealed class RbacGroupDefaultService : IRbacGroupDefaultService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-claude-code-managed-settings-2026-10-06");
    }

    readonly Lazy<IRbacGroupDefaultServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRbacGroupDefaultServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRbacGroupDefaultService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupDefaultService(this._client.WithOptions(modifier));
    }

    public RbacGroupDefaultService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RbacGroupDefaultServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeRbacGroupDefaultManagedSettings> Retrieve(
        RbacGroupDefaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeRbacGroupDefaultManagedSettings> Update(
        RbacGroupDefaultUpdateParams parameters,
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
public sealed class RbacGroupDefaultServiceWithRawResponse : IRbacGroupDefaultServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRbacGroupDefaultServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RbacGroupDefaultServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RbacGroupDefaultServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeRbacGroupDefaultManagedSettings>> Retrieve(
        RbacGroupDefaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RbacGroupDefaultRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName =
                "anthropic.organization.claude_code.managed_settings.rbac_group_default.retrieve",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeRbacGroupDefaultManagedSettings = await response
                    .Deserialize<BetaClaudeCodeRbacGroupDefaultManagedSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeRbacGroupDefaultManagedSettings.Validate();
                }
                return betaClaudeCodeRbacGroupDefaultManagedSettings;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeRbacGroupDefaultManagedSettings>> Update(
        RbacGroupDefaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RbacGroupDefaultUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName =
                "anthropic.organization.claude_code.managed_settings.rbac_group_default.update",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeRbacGroupDefaultManagedSettings = await response
                    .Deserialize<BetaClaudeCodeRbacGroupDefaultManagedSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeRbacGroupDefaultManagedSettings.Validate();
                }
                return betaClaudeCodeRbacGroupDefaultManagedSettings;
            }
        );
    }
}
