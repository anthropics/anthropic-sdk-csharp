using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles;
using Anthropic.Services.Beta.Organization.ClaudeTag.Bundles;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <inheritdoc/>
public sealed class BundleService : IBundleService
{
    internal static void AddDefaultHeaders(HttpRequestMessage request)
    {
        request.Headers.Add("anthropic-beta", "experimental-claude-tag-2026-10-21");
    }

    readonly Lazy<IBundleServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBundleServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IBundleService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BundleService(this._client.WithOptions(modifier));
    }

    public BundleService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BundleServiceWithRawResponse(client.WithRawResponse));
        _targets = new(() => new TargetService(client));
    }

    readonly Lazy<ITargetService> _targets;
    public ITargetService Targets
    {
        get { return _targets.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaClaudeTagBundle> Retrieve(
        BundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaClaudeTagBundle> Retrieve(
        string bundleID,
        BundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BundleListPage> List(
        BundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class BundleServiceWithRawResponse : IBundleServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBundleServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BundleServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BundleServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _targets = new(() => new TargetServiceWithRawResponse(client));
    }

    readonly Lazy<ITargetServiceWithRawResponse> _targets;
    public ITargetServiceWithRawResponse Targets
    {
        get { return _targets.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaClaudeTagBundle>> Retrieve(
        BundleRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BundleID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.BundleID' cannot be null");
        }

        HttpRequest<BundleRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.retrieve",
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
                var betaClaudeTagBundle = await response
                    .Deserialize<BetaClaudeTagBundle>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaClaudeTagBundle.Validate();
                }
                return betaClaudeTagBundle;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaClaudeTagBundle>> Retrieve(
        string bundleID,
        BundleRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BundleID = bundleID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BundleListPage>> List(
        BundleListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BundleListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.organization.claude_tag.bundles.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<BundleListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BundleListPage(this, parameters, page);
            }
        );
    }
}
