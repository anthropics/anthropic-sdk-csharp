using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Cases;

namespace Anthropic.Services.Beta.Compliance.Review;

/// <inheritdoc/>
public sealed class CaseService : ICaseService
{
    readonly Lazy<ICaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICaseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public ICaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CaseService(this._client.WithOptions(modifier));
    }

    public CaseService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CaseServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BetaComplianceReviewCase> Retrieve(
        CaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaComplianceReviewCase> Retrieve(
        string caseID,
        CaseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CaseID = caseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CaseListPage> List(
        CaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BetaComplianceReviewCase> Respond(
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Respond(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BetaComplianceReviewCase> Respond(
        string caseID,
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Respond(parameters with { CaseID = caseID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CaseServiceWithRawResponse : ICaseServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICaseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CaseServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaComplianceReviewCase>> Retrieve(
        CaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CaseID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CaseID' cannot be null");
        }

        HttpRequest<CaseRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.compliance.review.cases.retrieve",
            SpanResourceIds = [new("anthropic.compliance.review.case.id", parameters.CaseID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaComplianceReviewCase = await response
                    .Deserialize<BetaComplianceReviewCase>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaComplianceReviewCase.Validate();
                }
                return betaComplianceReviewCase;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaComplianceReviewCase>> Retrieve(
        string caseID,
        CaseRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CaseID = caseID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CaseListPage>> List(
        CaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CaseListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.compliance.review.cases.list",
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<CaseListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CaseListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BetaComplianceReviewCase>> Respond(
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CaseID == null)
        {
            throw new AnthropicInvalidDataException("'parameters.CaseID' cannot be null");
        }

        HttpRequest<CaseRespondParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
            Qualifiers = new Dictionary<string, string>() { ["beta"] = "true" },
            SpanName = "anthropic.compliance.review.cases.respond",
            SpanResourceIds = [new("anthropic.compliance.review.case.id", parameters.CaseID)],
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var betaComplianceReviewCase = await response
                    .Deserialize<BetaComplianceReviewCase>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    betaComplianceReviewCase.Validate();
                }
                return betaComplianceReviewCase;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BetaComplianceReviewCase>> Respond(
        string caseID,
        CaseRespondParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Respond(parameters with { CaseID = caseID }, cancellationToken);
    }
}
