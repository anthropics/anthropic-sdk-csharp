using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Apps.Chat.Projects;

namespace Anthropic.Services.Beta.Organization.Analytics.Apps.Chat;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get per-project activity for a given day, with cursor-based pagination.
    ///
    /// <para>Returns activity metrics for each project in the organization, sorted by
    /// project ID. Use `group_by[]` to break projects out per member or per RBAC group,
    /// and `filter[]` to scope results; the parameter descriptions list the supported
    /// dimensions. Available to organizations on a Claude Enterprise plan. Requires an
    /// API key with the `read:analytics` scope.</para>
    /// </summary>
    Task<ProjectListPage> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/apps/chat/projects?beta=true</c>, but is otherwise the
    /// same as <see cref="IProjectService.List(ProjectListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ProjectListPage>> List(
        ProjectListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
