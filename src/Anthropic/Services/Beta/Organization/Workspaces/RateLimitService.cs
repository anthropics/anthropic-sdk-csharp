using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Services.Beta.Organization.Workspaces;

/// <inheritdoc/>
public sealed class RateLimitService : IRateLimitService
{
    readonly Lazy<IRateLimitServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRateLimitServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IRateLimitService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateLimitService(this._client.WithOptions(modifier));
    }

    public RateLimitService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new RateLimitServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaWorkspaceRateLimit> Update(
        RateLimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaWorkspaceRateLimit> Update(
        string rateLimitID,
        RateLimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { RateLimitID = rateLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RateLimitListPage> List(
        RateLimitListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RateLimitListPage> List(
        string workspaceID,
        RateLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class RateLimitServiceWithRawResponse : IRateLimitServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRateLimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RateLimitServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RateLimitServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaWorkspaceRateLimit>> Update(
        RateLimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.RateLimitID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.RateLimitID' cannot be null");
        }

        HttpRequest<RateLimitUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.workspaces.rate_limits.update",
            SpanResourceIds =
            [
                new("anthropic.organization.workspace.id", parameters.WorkspaceID),
                new("anthropic.organization.workspace.rate_limit.id", parameters.RateLimitID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaWorkspaceRateLimit = await response
                    .Deserialize<BetaWorkspaceRateLimit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaWorkspaceRateLimit.Validate();
                }
                return betaWorkspaceRateLimit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaWorkspaceRateLimit>> Update(
        string rateLimitID,
        RateLimitUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { RateLimitID = rateLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RateLimitListPage>> List(
        RateLimitListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.WorkspaceID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.WorkspaceID' cannot be null");
        }

        HttpRequest<RateLimitListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.workspaces.rate_limits.list",
            SpanResourceIds = [new("anthropic.organization.workspace.id", parameters.WorkspaceID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<RateLimitListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RateLimitListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RateLimitListPage>> List(
        string workspaceID,
        RateLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { WorkspaceID = workspaceID }, cancellationToken);
    }
}
