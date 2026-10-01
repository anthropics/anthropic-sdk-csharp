using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits;
using Anthropic.Services.Beta.Organization.SpendLimits;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class SpendLimitService : ISpendLimitService
{
    readonly Lazy<ISpendLimitServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISpendLimitServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ISpendLimitService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SpendLimitService(this._client.WithOptions(modifier));
    }

    public SpendLimitService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SpendLimitServiceWithRawResponse(client.WithRawResponse));
        _effective = new(() => new EffectiveService(client));
        _increaseRequests = new(() => new IncreaseRequestService(client));
    }

    readonly Lazy<IEffectiveService> _effective;
    public IEffectiveService Effective
    {
        get { return _effective.Value; }
    }

    readonly Lazy<IIncreaseRequestService> _increaseRequests;
    public IIncreaseRequestService IncreaseRequests
    {
        get { return _increaseRequests.Value; }
    }

    /// <inheritdoc/>
    public async Task<BetaSpendLimit> Retrieve(
        SpendLimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSpendLimit> Retrieve(
        string spendLimitID,
        SpendLimitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SpendLimitID = spendLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SpendLimitListPage> List(
        SpendLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SpendLimitDeleteResponse> Delete(
        SpendLimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SpendLimitDeleteResponse> Delete(
        string spendLimitID,
        SpendLimitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SpendLimitID = spendLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BetaSpendLimit> Set(
        SpendLimitSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Set(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SpendLimitServiceWithRawResponse : ISpendLimitServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISpendLimitServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SpendLimitServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SpendLimitServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _effective = new(() => new EffectiveServiceWithRawResponse(client));
        _increaseRequests = new(() => new IncreaseRequestServiceWithRawResponse(client));
    }

    readonly Lazy<IEffectiveServiceWithRawResponse> _effective;
    public IEffectiveServiceWithRawResponse Effective
    {
        get { return _effective.Value; }
    }

    readonly Lazy<IIncreaseRequestServiceWithRawResponse> _increaseRequests;
    public IIncreaseRequestServiceWithRawResponse IncreaseRequests
    {
        get { return _increaseRequests.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSpendLimit>> Retrieve(
        SpendLimitRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpendLimitID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SpendLimitID' cannot be null");
        }

        HttpRequest<SpendLimitRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSpendLimit = await response
                    .Deserialize<BetaSpendLimit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSpendLimit.Validate();
                }
                return betaSpendLimit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSpendLimit>> Retrieve(
        string spendLimitID,
        SpendLimitRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SpendLimitID = spendLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpendLimitListPage>> List(
        SpendLimitListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SpendLimitListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<SpendLimitListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SpendLimitListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SpendLimitDeleteResponse>> Delete(
        SpendLimitDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpendLimitID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.SpendLimitID' cannot be null");
        }

        HttpRequest<SpendLimitDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var spendLimit = await response
                    .Deserialize<SpendLimitDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    spendLimit.Validate();
                }
                return spendLimit;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SpendLimitDeleteResponse>> Delete(
        string spendLimitID,
        SpendLimitDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SpendLimitID = spendLimitID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSpendLimit>> Set(
        SpendLimitSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SpendLimitSetParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSpendLimit = await response
                    .Deserialize<BetaSpendLimit>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSpendLimit.Validate();
                }
                return betaSpendLimit;
            }
        );
    }
}
