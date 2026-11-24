using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Compliance;

namespace Anthropic.Services.Beta;

/// <inheritdoc/>
public sealed class ComplianceService : IComplianceService
{
    readonly Lazy<IComplianceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IComplianceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IComplianceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ComplianceService(this._client.WithOptions(modifier));
    }

    public ComplianceService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ComplianceServiceWithRawResponse(client.WithRawResponse));
        _review = new(() => new ReviewService(client));
    }

    readonly Lazy<IReviewService> _review;
    public IReviewService Review
    {
        get { return _review.Value; }
    }
}

/// <inheritdoc/>
public sealed class ComplianceServiceWithRawResponse : IComplianceServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IComplianceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ComplianceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ComplianceServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _review = new(() => new ReviewServiceWithRawResponse(client));
    }

    readonly Lazy<IReviewServiceWithRawResponse> _review;
    public IReviewServiceWithRawResponse Review
    {
        get { return _review.Value; }
    }
}
