using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

namespace Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

/// <inheritdoc/>
public sealed class RbacGroupService : IRbacGroupService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "ce-claude-code-managed-settings-2026-10-06");
    }

    readonly Lazy<IRbacGroupServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRbacGroupService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupService(this._client.WithOptions(modifier));
    }

    public RbacGroupService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RbacGroupServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeRbacGroupManagedSettings> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeCodeRbacGroupManagedSettings> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RbacGroupListPage> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaDeletedClaudeCodeRbacGroupManagedSettings> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaDeletedClaudeCodeRbacGroupManagedSettings> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeCodeRbacGroupManagedSettings> Set(
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Set(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeCodeRbacGroupManagedSettings> Set(
        string rbacGroupID,
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RbacGroupServiceWithRawResponse : IRbacGroupServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRbacGroupServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RbacGroupServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RbacGroupServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Retrieve(
        RbacGroupRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.rbac_groups.retrieve",
            SpanResourceIds =
            [
                new(
                    "anthropic.organization.claude_code.managed_setting.rbac_group.id",
                    parameters.RbacGroupID
                ),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeRbacGroupManagedSettings = await response
                    .Deserialize<BetaClaudeCodeRbacGroupManagedSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeRbacGroupManagedSettings.Validate();
                }
                return betaClaudeCodeRbacGroupManagedSettings;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Retrieve(
        string rbacGroupID,
        RbacGroupRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RbacGroupListPage>> List(
        RbacGroupListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RbacGroupListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.rbac_groups.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<RbacGroupListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RbacGroupListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaDeletedClaudeCodeRbacGroupManagedSettings>> Delete(
        RbacGroupDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.rbac_groups.delete",
            SpanResourceIds =
            [
                new(
                    "anthropic.organization.claude_code.managed_setting.rbac_group.id",
                    parameters.RbacGroupID
                ),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaDeletedClaudeCodeRbacGroupManagedSettings = await response
                    .Deserialize<BetaDeletedClaudeCodeRbacGroupManagedSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaDeletedClaudeCodeRbacGroupManagedSettings.Validate();
                }
                return betaDeletedClaudeCodeRbacGroupManagedSettings;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaDeletedClaudeCodeRbacGroupManagedSettings>> Delete(
        string rbacGroupID,
        RbacGroupDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Set(
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RbacGroupID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RbacGroupID' cannot be null");
        }

        HttpRequest<RbacGroupSetParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_code.managed_settings.rbac_groups.set",
            SpanResourceIds =
            [
                new(
                    "anthropic.organization.claude_code.managed_setting.rbac_group.id",
                    parameters.RbacGroupID
                ),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeCodeRbacGroupManagedSettings = await response
                    .Deserialize<BetaClaudeCodeRbacGroupManagedSettings>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeCodeRbacGroupManagedSettings.Validate();
                }
                return betaClaudeCodeRbacGroupManagedSettings;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeCodeRbacGroupManagedSettings>> Set(
        string rbacGroupID,
        RbacGroupSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { RbacGroupID = rbacGroupID }, cancellationToken);
    }
}
