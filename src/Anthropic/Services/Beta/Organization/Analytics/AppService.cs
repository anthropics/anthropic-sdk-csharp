using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Analytics.Apps;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <inheritdoc/>
public sealed class AppService : IAppService
{
    readonly Lazy<IAppServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAppServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IAppService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AppService(this._client.WithOptions(modifier));
    }

    public AppService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AppServiceWithRawResponse(client.WithRawResponse));
        _chat = new(() => new ChatService(client));
    }

    readonly Lazy<IChatService> _chat;
    public IChatService Chat
    {
        get { return _chat.Value; }
    }
}

/// <inheritdoc/>
public sealed class AppServiceWithRawResponse : IAppServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAppServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AppServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AppServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _chat = new(() => new ChatServiceWithRawResponse(client));
    }

    readonly Lazy<IChatServiceWithRawResponse> _chat;
    public IChatServiceWithRawResponse Chat
    {
        get { return _chat.Value; }
    }
}
