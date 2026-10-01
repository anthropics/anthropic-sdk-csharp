using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.SpendLimits.IncreaseRequests;

namespace Anthropic.Services.Beta.Organization.SpendLimits;

/// <inheritdoc/>
public sealed class IncreaseRequestService : IIncreaseRequestService
{
    readonly Lazy<IIncreaseRequestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIncreaseRequestServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IIncreaseRequestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IncreaseRequestService(this._client.WithOptions(modifier));
    }

    public IncreaseRequestService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new IncreaseRequestServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<BetaSpendLimitIncreaseRequest> Retrieve(
        IncreaseRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSpendLimitIncreaseRequest> Retrieve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<IncreaseRequestListPage> List(
        IncreaseRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<IncreaseRequestApproveResponse> Approve(
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Approve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<IncreaseRequestApproveResponse> Approve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Approve(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BetaSpendLimitIncreaseRequest> Deny(
        IncreaseRequestDenyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deny(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaSpendLimitIncreaseRequest> Deny(
        string spendLimitIncreaseRequestID,
        IncreaseRequestDenyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deny(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class IncreaseRequestServiceWithRawResponse : IIncreaseRequestServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIncreaseRequestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IncreaseRequestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IncreaseRequestServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Retrieve(
        IncreaseRequestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpendLimitIncreaseRequestID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.SpendLimitIncreaseRequestID' cannot be null"
            );
        }

        HttpRequest<IncreaseRequestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSpendLimitIncreaseRequest = await response
                    .Deserialize<BetaSpendLimitIncreaseRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSpendLimitIncreaseRequest.Validate();
                }
                return betaSpendLimitIncreaseRequest;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Retrieve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IncreaseRequestListPage>> List(
        IncreaseRequestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<IncreaseRequestListParams> request = new()
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
                    .Deserialize<IncreaseRequestListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new IncreaseRequestListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IncreaseRequestApproveResponse>> Approve(
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpendLimitIncreaseRequestID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.SpendLimitIncreaseRequestID' cannot be null"
            );
        }

        HttpRequest<IncreaseRequestApproveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<IncreaseRequestApproveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<IncreaseRequestApproveResponse>> Approve(
        string spendLimitIncreaseRequestID,
        IncreaseRequestApproveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Approve(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Deny(
        IncreaseRequestDenyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SpendLimitIncreaseRequestID == null)
        {
            throw new AnthropicInvalidDataException(
                "'parameters.SpendLimitIncreaseRequestID' cannot be null"
            );
        }

        HttpRequest<IncreaseRequestDenyParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaSpendLimitIncreaseRequest = await response
                    .Deserialize<BetaSpendLimitIncreaseRequest>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaSpendLimitIncreaseRequest.Validate();
                }
                return betaSpendLimitIncreaseRequest;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaSpendLimitIncreaseRequest>> Deny(
        string spendLimitIncreaseRequestID,
        IncreaseRequestDenyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deny(
            parameters with
            {
                SpendLimitIncreaseRequestID = spendLimitIncreaseRequestID,
            },
            cancellationToken
        );
    }
}
