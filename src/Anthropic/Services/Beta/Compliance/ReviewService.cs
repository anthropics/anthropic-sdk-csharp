using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Compliance.Review;

namespace Anthropic.Services.Beta.Compliance;

/// <inheritdoc/>
public sealed class ReviewService : IReviewService
{
    readonly Lazy<IReviewServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IReviewService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewService(this._client.WithOptions(modifier));
    }

    public ReviewService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReviewServiceWithRawResponse(client.WithRawResponse));
        _cases = new(() => new CaseService(client));
        _notices = new(() => new NoticeService(client));
        _items = new(() => new ItemService(client));
    }

    readonly Lazy<ICaseService> _cases;
    public ICaseService Cases
    {
        get { return _cases.Value; }
    }

    readonly Lazy<INoticeService> _notices;
    public INoticeService Notices
    {
        get { return _notices.Value; }
    }

    readonly Lazy<IItemService> _items;
    public IItemService Items
    {
        get { return _items.Value; }
    }
}

/// <inheritdoc/>
public sealed class ReviewServiceWithRawResponse : IReviewServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReviewServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReviewServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReviewServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _cases = new(() => new CaseServiceWithRawResponse(client));
        _notices = new(() => new NoticeServiceWithRawResponse(client));
        _items = new(() => new ItemServiceWithRawResponse(client));
    }

    readonly Lazy<ICaseServiceWithRawResponse> _cases;
    public ICaseServiceWithRawResponse Cases
    {
        get { return _cases.Value; }
    }

    readonly Lazy<INoticeServiceWithRawResponse> _notices;
    public INoticeServiceWithRawResponse Notices
    {
        get { return _notices.Value; }
    }

    readonly Lazy<IItemServiceWithRawResponse> _items;
    public IItemServiceWithRawResponse Items
    {
        get { return _items.Value; }
    }
}
