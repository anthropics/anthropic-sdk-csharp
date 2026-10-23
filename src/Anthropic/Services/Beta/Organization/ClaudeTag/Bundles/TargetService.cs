using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

/// <inheritdoc/>
public sealed class TargetService : ITargetService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "experimental-claude-tag-2026-10-21");
    }

    readonly Lazy<ITargetServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITargetServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ITargetService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TargetService(this._client.WithOptions(modifier));
    }

    public TargetService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TargetServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagBundleTarget> Create(
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagBundleTarget> Create(
        string bundleID,
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagBundleTarget> Retrieve(
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagBundleTarget> Retrieve(
        string targetID,
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TargetID = targetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TargetListPage> List(
        TargetListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TargetListPage> List(
        string bundleID,
        TargetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagDeletedBundleTarget> Delete(
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagDeletedBundleTarget> Delete(
        string targetID,
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TargetID = targetID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TargetServiceWithRawResponse : ITargetServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITargetServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TargetServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TargetServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagBundleTarget>> Create(
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BundleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.BundleID' cannot be null");
        }

        HttpRequest<TargetCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.targets.create",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.bundle.id", parameters.BundleID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagBundleTarget = await response
                    .Deserialize<BetaClaudeTagBundleTarget>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagBundleTarget.Validate();
                }
                return betaClaudeTagBundleTarget;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagBundleTarget>> Create(
        string bundleID,
        TargetCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagBundleTarget>> Retrieve(
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TargetID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TargetID' cannot be null");
        }

        HttpRequest<TargetRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.targets.retrieve",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.bundle.id", parameters.BundleID),
                new("anthropic.organization.claude_tag.bundle.target.id", parameters.TargetID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagBundleTarget = await response
                    .Deserialize<BetaClaudeTagBundleTarget>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagBundleTarget.Validate();
                }
                return betaClaudeTagBundleTarget;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagBundleTarget>> Retrieve(
        string targetID,
        TargetRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { TargetID = targetID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TargetListPage>> List(
        TargetListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BundleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.BundleID' cannot be null");
        }

        HttpRequest<TargetListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.targets.list",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.bundle.id", parameters.BundleID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<TargetListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TargetListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TargetListPage>> List(
        string bundleID,
        TargetListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagDeletedBundleTarget>> Delete(
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TargetID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.TargetID' cannot be null");
        }

        HttpRequest<TargetDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.targets.delete",
            SpanResourceIds =
            [
                new("anthropic.organization.claude_tag.bundle.id", parameters.BundleID),
                new("anthropic.organization.claude_tag.bundle.target.id", parameters.TargetID),
            ],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaClaudeTagDeletedBundleTarget = await response
                    .Deserialize<BetaClaudeTagDeletedBundleTarget>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagDeletedBundleTarget.Validate();
                }
                return betaClaudeTagDeletedBundleTarget;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagDeletedBundleTarget>> Delete(
        string targetID,
        TargetDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { TargetID = targetID }, cancellationToken);
    }
}
