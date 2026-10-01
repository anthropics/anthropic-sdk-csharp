using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Analytics.Apps.Chat;

namespace Anthropic.Services.Beta.Organization.Analytics.Apps;

/// <inheritdoc/>
public sealed class ChatService : IChatService
{
    readonly Lazy<IChatServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatService(this._client.WithOptions(modifier));
    }

    public ChatService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChatServiceWithRawResponse(client.WithRawResponse));
        _projects = new(() => new ProjectService(client));
    }

    readonly Lazy<IProjectService> _projects;
    public IProjectService Projects
    {
        get { return _projects.Value; }
    }
}

/// <inheritdoc/>
public sealed class ChatServiceWithRawResponse : IChatServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChatServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChatServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _projects = new(() => new ProjectServiceWithRawResponse(client));
    }

    readonly Lazy<IProjectServiceWithRawResponse> _projects;
    public IProjectServiceWithRawResponse Projects
    {
        get { return _projects.Value; }
    }
}
