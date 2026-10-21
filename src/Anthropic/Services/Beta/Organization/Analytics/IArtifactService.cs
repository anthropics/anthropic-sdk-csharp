using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Artifacts;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IArtifactService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IArtifactServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get artifact-creation activity for a given day, broken out by MIME type.
    ///
    /// <para>Returns the full (`artifact_type`, `is_shared`) cube for the organization;
    /// `next_page` is null except for grouped queries, which paginate. The cube can be
    /// broken out per product, per member, or per RBAC group via `group_by[]`, and
    /// scoped via `filter[]`. Requires an API key with the `read:analytics` scope.</para>
    /// </summary>
    Task<ArtifactListPage> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IArtifactService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IArtifactServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IArtifactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/artifacts?beta=true</c>, but is otherwise the
    /// same as <see cref="IArtifactService.List(ArtifactListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ArtifactListPage>> List(
        ArtifactListParams parameters,
        CancellationToken cancellationToken = default
    );
}
