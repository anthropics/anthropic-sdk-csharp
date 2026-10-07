using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.SpendLimits.Effective;

namespace Anthropic.Services.Beta.Organization.SpendLimits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEffectiveService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEffectiveServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEffectiveService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List each member's effective spend limit and period-to-date spend.
    ///
    /// <para>Returns one row per (member, period) the member resolves a spend limit
    /// for, with the `source` scope the spend limit was inherited from. Paginates by
    /// member, so a member's periods never split across pages. Listing Claude Console
    /// limits is in an early access preview. To request access, contact your Anthropic
    /// account team.</para>
    /// </summary>
    Task<EffectiveListPage> List(
        EffectiveListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEffectiveService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEffectiveServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEffectiveServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/spend_limits/effective?beta=true</c>, but is otherwise the
    /// same as <see cref="IEffectiveService.List(EffectiveListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EffectiveListPage>> List(
        EffectiveListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
