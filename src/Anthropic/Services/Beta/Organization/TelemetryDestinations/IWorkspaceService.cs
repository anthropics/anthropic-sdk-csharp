using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.TelemetryDestinations.Workspaces;

namespace Anthropic.Services.Beta.Organization.TelemetryDestinations;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWorkspaceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWorkspaceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspaceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List the workspaces on a destination's workspace list, newest entry first.
    ///
    /// <para>A destination whose `workspaces.type` is `all` doesn't have a list, so its
    /// page is empty. The list includes archived workspaces.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#choose-workspaces-for-a-destination)
    /// to learn more about choosing the workspaces of a destination.</para>
    /// </summary>
    Task<WorkspaceListPage> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<WorkspaceListPage> List(
        string destinationID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add one workspace to a destination's workspace list.
    ///
    /// <para>Under `include` the workspace's spans start going to the destination.
    /// Under `exclude` they stop. A list holds at most 1,000 workspaces.</para>
    ///
    /// <para>Adding a workspace that is already on the list changes nothing and returns
    /// the existing entry. An archived workspace that isn't on the list yet can't be
    /// added. A destination whose `workspaces.type` is `all` doesn't have a list, so
    /// the API returns 400. To change which workspaces such a destination covers,
    /// update its `workspaces`.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#choose-workspaces-for-a-destination)
    /// to learn more about choosing the workspaces of a destination.</para>
    /// </summary>
    Task<BetaTelemetryDestinationWorkspace> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<BetaTelemetryDestinationWorkspace> Add(
        string workspaceID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove one workspace from a destination's workspace list.
    ///
    /// <para>Under `include` the workspace's spans stop going to the destination. Under
    /// `exclude` they start. An archived workspace can be removed too.</para>
    ///
    /// <para>The API returns 404 when the workspace isn't on the list. A destination
    /// whose `workspaces.type` is `all` doesn't have a list, so the API returns 400.</para>
    ///
    /// <para>See the [OpenTelemetry export
    /// guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#choose-workspaces-for-a-destination)
    /// to learn more about choosing the workspaces of a destination.</para>
    /// </summary>
    Task<BetaDeletedTelemetryDestinationWorkspace> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(WorkspaceRemoveParams, CancellationToken)"/>
    Task<BetaDeletedTelemetryDestinationWorkspace> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWorkspaceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWorkspaceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWorkspaceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/telemetry_destinations/{destination_id}/workspaces?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.List(WorkspaceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WorkspaceListPage>> List(
        WorkspaceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(WorkspaceListParams, CancellationToken)"/>
    Task<HttpResponse<WorkspaceListPage>> List(
        string destinationID,
        WorkspaceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/telemetry_destinations/{destination_id}/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Add(WorkspaceAddParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaTelemetryDestinationWorkspace>> Add(
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Add(WorkspaceAddParams, CancellationToken)"/>
    Task<HttpResponse<BetaTelemetryDestinationWorkspace>> Add(
        string workspaceID,
        WorkspaceAddParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/telemetry_destinations/{destination_id}/workspaces/{workspace_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IWorkspaceService.Remove(WorkspaceRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedTelemetryDestinationWorkspace>> Remove(
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(WorkspaceRemoveParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedTelemetryDestinationWorkspace>> Remove(
        string workspaceID,
        WorkspaceRemoveParams parameters,
        CancellationToken cancellationToken = default
    );
}
