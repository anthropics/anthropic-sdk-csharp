using System;
using Anthropic.Core;
using Anthropic.Services.Organization.SpendLimits;

namespace Anthropic.Services.Organization;

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
}
