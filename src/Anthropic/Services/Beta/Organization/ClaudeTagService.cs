using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag;

namespace Anthropic.Services.Beta.Organization;

/// <inheritdoc/>
public sealed class ClaudeTagService : IClaudeTagService
{
    readonly Lazy<IClaudeTagServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IClaudeTagServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IAnthropicClient _client;

    /// <inheritdoc/>
    public IClaudeTagService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClaudeTagService(this._client.WithOptions(modifier));
    }

    public ClaudeTagService(IAnthropicClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ClaudeTagServiceWithRawResponse(client.WithRawResponse));
        _slackChannels = new(() => new SlackChannelService(client));
        _slackWorkspaces = new(() => new SlackWorkspaceService(client));
        _bundles = new(() => new BundleService(client));
    }

    readonly Lazy<ISlackChannelService> _slackChannels;
    public ISlackChannelService SlackChannels
    {
        get { return _slackChannels.Value; }
    }

    readonly Lazy<ISlackWorkspaceService> _slackWorkspaces;
    public ISlackWorkspaceService SlackWorkspaces
    {
        get { return _slackWorkspaces.Value; }
    }

    readonly Lazy<IBundleService> _bundles;
    public IBundleService Bundles
    {
        get { return _bundles.Value; }
    }
}

/// <inheritdoc/>
public sealed class ClaudeTagServiceWithRawResponse : IClaudeTagServiceWithRawResponse
{
    readonly IAnthropicClientWithRawResponse _client;

    /// <inheritdoc/>
    public IClaudeTagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ClaudeTagServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ClaudeTagServiceWithRawResponse(IAnthropicClientWithRawResponse client)
    {
        _client = client;

        _slackChannels = new(() => new SlackChannelServiceWithRawResponse(client));
        _slackWorkspaces = new(() => new SlackWorkspaceServiceWithRawResponse(client));
        _bundles = new(() => new BundleServiceWithRawResponse(client));
    }

    readonly Lazy<ISlackChannelServiceWithRawResponse> _slackChannels;
    public ISlackChannelServiceWithRawResponse SlackChannels
    {
        get { return _slackChannels.Value; }
    }

    readonly Lazy<ISlackWorkspaceServiceWithRawResponse> _slackWorkspaces;
    public ISlackWorkspaceServiceWithRawResponse SlackWorkspaces
    {
        get { return _slackWorkspaces.Value; }
    }

    readonly Lazy<IBundleServiceWithRawResponse> _bundles;
    public IBundleServiceWithRawResponse Bundles
    {
        get { return _bundles.Value; }
    }
}
