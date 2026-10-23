using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackChannels;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISlackChannelService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISlackChannelServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISlackChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Set a Slack channel up for Claude Tag and return it with its identifier. If the
    /// channel is already set up, whether in claude.ai, by Claude's first use in it or
    /// by an earlier request, the existing channel is returned, so the request can be
    /// repeated. `settings`, when sent, is applied as an update applies it. Before a
    /// channel is set up, Claude's Slack app confirms with Slack that the channel is in
    /// the workspace, is not archived and is visible to the app; a channel that fails
    /// the confirmation returns 404. Setting the channel up and applying `settings` are
    /// two steps: when the second is refused, the response is the refusal, the channel
    /// stays set up with every setting unset, and the error's
    /// `details.slack_channel_id` holds the channel's identifier.
    /// </summary>
    Task<BetaClaudeTagSlackChannel> Create(
        SlackChannelCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get one Slack channel and its settings. By default `settings` holds what the
    /// channel itself stores: a setting that is null there is not set on the channel
    /// and is inherited. With `include_inherited=true`, `settings` holds what applies
    /// in the channel once the settings levels above it are taken into account, and the
    /// request fails with 503 rather than resolve against a settings level that could
    /// not be read. Either way `sources` names the settings level each value comes
    /// from, so a caller tells the channel's own value from an inherited one by its
    /// source, not by whether it is null.
    /// </summary>
    Task<BetaClaudeTagSlackChannel> Retrieve(
        SlackChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SlackChannelRetrieveParams, CancellationToken)"/>
    Task<BetaClaudeTagSlackChannel> Retrieve(
        string id,
        SlackChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change the settings a Slack channel stores. The update is partial: a setting
    /// left out is unchanged, and a setting sent as null is cleared, so the channel
    /// inherits it. If any value is refused, no setting in the request is stored. A
    /// group direct message takes no settings and returns 400.
    /// </summary>
    Task<BetaClaudeTagSlackChannel> Update(
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SlackChannelUpdateParams, CancellationToken)"/>
    Task<BetaClaudeTagSlackChannel> Update(
        string id,
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the set-up Slack channels of one Slack workspace, newest first by
    /// `created_at`. A channel that is not set up is not listed: Slack holds the full
    /// list of a workspace's channels. Pass `slack_channel_id` as well to look one
    /// channel up by its Slack identifiers: `data` then holds that channel, or is empty
    /// when it is not set up, and `limit` and `page` are ignored. A workspace that the
    /// organization owns only through a Slack Enterprise Grid returns 404 until it is
    /// set up. With `include_inherited=true` each channel's `settings` holds what
    /// applies in it, and the request fails with 503 rather than resolve against a
    /// settings level that could not be read. A `page` cursor resumes only a request
    /// with the same `include_inherited`.
    /// </summary>
    Task<SlackChannelListPage> List(
        SlackChannelListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a Slack channel from Claude Tag. This deletes the channel's stored
    /// settings and its Bundle Targets at once, and then, in the background, the
    /// channel's sessions and their transcripts, its memory, its routines and the
    /// artifacts published from it. None of it can be restored. The channel in Slack
    /// and its messages are unchanged. The request is refused with 400 and
    /// `error.details.error_code` `slack_channel_enabled` while `enabled` resolves to
    /// `true` for the channel, as a read with `include_inherited=true` returns it: set
    /// `enabled` to `false` on the channel first. This guards against removing a
    /// channel in use by mistake; it is not a way to keep Claude out, because the
    /// removal deletes the channel's own `enabled: false` with its other settings,
    /// after which the channel inherits again and Claude's next use of it can set it up
    /// anew with a new identifier. The identifier returns 404 as soon as the request
    /// returns, so a repeated removal returns 404. A group direct message returns 400,
    /// and so does a channel that holds configuration this API does not manage.
    /// </summary>
    Task<BetaClaudeTagDeletedSlackChannel> Delete(
        SlackChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SlackChannelDeleteParams, CancellationToken)"/>
    Task<BetaClaudeTagDeletedSlackChannel> Delete(
        string id,
        SlackChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISlackChannelService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISlackChannelServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISlackChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_tag/slack_channels</c>, but is otherwise the
    /// same as <see cref="ISlackChannelService.Create(SlackChannelCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagSlackChannel>> Create(
        SlackChannelCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/slack_channels/{id}</c>, but is otherwise the
    /// same as <see cref="ISlackChannelService.Retrieve(SlackChannelRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagSlackChannel>> Retrieve(
        SlackChannelRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SlackChannelRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagSlackChannel>> Retrieve(
        string id,
        SlackChannelRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_tag/slack_channels/{id}</c>, but is otherwise the
    /// same as <see cref="ISlackChannelService.Update(SlackChannelUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagSlackChannel>> Update(
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SlackChannelUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagSlackChannel>> Update(
        string id,
        SlackChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/slack_channels</c>, but is otherwise the
    /// same as <see cref="ISlackChannelService.List(SlackChannelListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SlackChannelListPage>> List(
        SlackChannelListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/claude_tag/slack_channels/{id}</c>, but is otherwise the
    /// same as <see cref="ISlackChannelService.Delete(SlackChannelDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagDeletedSlackChannel>> Delete(
        SlackChannelDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(SlackChannelDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagDeletedSlackChannel>> Delete(
        string id,
        SlackChannelDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
