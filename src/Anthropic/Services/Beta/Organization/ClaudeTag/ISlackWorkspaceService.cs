using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag.SlackWorkspaces;

namespace Anthropic.Services.Beta.Organization.ClaudeTag;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISlackWorkspaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISlackWorkspaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISlackWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get one Slack workspace and its settings. By default `settings` holds what the
    /// workspace itself stores: a setting that is null there is not set on the
    /// workspace and is inherited. With `include_inherited=true`, `settings` holds what
    /// applies in the workspace once the organization's Slack defaults are taken into
    /// account, and the request fails with 503 rather than resolve against a settings
    /// level that could not be read. Either way `sources` names the settings level each
    /// value comes from.
    /// </summary>
    Task<BetaClaudeTagSlackWorkspace> Retrieve(
        SlackWorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SlackWorkspaceRetrieveParams, CancellationToken)"/>
    Task<BetaClaudeTagSlackWorkspace> Retrieve(
        string id,
        SlackWorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Change the settings a Slack workspace stores. The update is partial: a setting
    /// left out is unchanged, and a setting sent as null is cleared, so the workspace
    /// inherits it. If any value is refused, no setting in the request is stored.
    /// </summary>
    Task<BetaClaudeTagSlackWorkspace> Update(
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SlackWorkspaceUpdateParams, CancellationToken)"/>
    Task<BetaClaudeTagSlackWorkspace> Update(
        string id,
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the set-up Slack workspaces the organization owns, newest first by
    /// `created_at`. Pass `slack_workspace_id` to look one workspace up by its Slack
    /// identifier: `data` then holds that workspace, or is empty when it is not set up.
    /// A workspace of a Slack Enterprise Grid the organization has connected returns
    /// 404 until it is set up. With `include_inherited=true` each workspace's
    /// `settings` holds what applies in it, and the request fails with 503 rather than
    /// resolve against a settings level that could not be read. A `page` cursor resumes
    /// only a request with the same `include_inherited`.
    /// </summary>
    Task<SlackWorkspaceListPage> List(
        SlackWorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISlackWorkspaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISlackWorkspaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISlackWorkspaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/slack_workspaces/{id}</c>, but is otherwise the
    /// same as <see cref="ISlackWorkspaceService.Retrieve(SlackWorkspaceRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Retrieve(
        SlackWorkspaceRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SlackWorkspaceRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Retrieve(
        string id,
        SlackWorkspaceRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/claude_tag/slack_workspaces/{id}</c>, but is otherwise the
    /// same as <see cref="ISlackWorkspaceService.Update(SlackWorkspaceUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Update(
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SlackWorkspaceUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaClaudeTagSlackWorkspace>> Update(
        string id,
        SlackWorkspaceUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/claude_tag/slack_workspaces</c>, but is otherwise the
    /// same as <see cref="ISlackWorkspaceService.List(SlackWorkspaceListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SlackWorkspaceListPage>> List(
        SlackWorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
