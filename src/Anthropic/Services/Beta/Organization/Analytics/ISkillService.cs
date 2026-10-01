using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics.Skills;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISkillService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISkillServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISkillService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get per-skill usage for a given day, with cursor-based pagination.
    ///
    /// <para>Returns skill usage metrics for the organization, sorted by skill name.
    /// Use `group_by[]` to break usage out per member, per RBAC group, or per product
    /// surface, and `filter[]` to scope results; the parameter descriptions list the
    /// supported dimensions. Available to organizations on a Claude Enterprise plan.
    /// Requires an API key with the `read:analytics` scope.</para>
    /// </summary>
    Task<SkillListPage> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISkillService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISkillServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISkillServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/analytics/skills?beta=true</c>, but is otherwise the
    /// same as <see cref="ISkillService.List(SkillListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SkillListPage>> List(
        SkillListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
