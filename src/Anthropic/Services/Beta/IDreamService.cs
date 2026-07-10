using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDreamService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDreamServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDreamService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a Dream
    /// </summary>
    Task<BetaDream> Create(
        DreamCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a Dream
    /// </summary>
    Task<BetaDream> Retrieve(
        DreamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DreamRetrieveParams, CancellationToken)"/>
    Task<BetaDream> Retrieve(
        string dreamID,
        DreamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Dreams
    /// </summary>
    Task<DreamListPage> List(
        DreamListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive a Dream
    /// </summary>
    Task<BetaDream> Archive(
        DreamArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DreamArchiveParams, CancellationToken)"/>
    Task<BetaDream> Archive(
        string dreamID,
        DreamArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Cancel a Dream
    /// </summary>
    Task<BetaDream> Cancel(
        DreamCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(DreamCancelParams, CancellationToken)"/>
    Task<BetaDream> Cancel(
        string dreamID,
        DreamCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDreamService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDreamServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDreamServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/dreams?beta=true</c>, but is otherwise the
    /// same as <see cref="IDreamService.Create(DreamCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDream>> Create(
        DreamCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/dreams/{dream_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IDreamService.Retrieve(DreamRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDream>> Retrieve(
        DreamRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DreamRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaDream>> Retrieve(
        string dreamID,
        DreamRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/dreams?beta=true</c>, but is otherwise the
    /// same as <see cref="IDreamService.List(DreamListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DreamListPage>> List(
        DreamListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/dreams/{dream_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IDreamService.Archive(DreamArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDream>> Archive(
        DreamArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(DreamArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaDream>> Archive(
        string dreamID,
        DreamArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/dreams/{dream_id}/cancel?beta=true</c>, but is otherwise the
    /// same as <see cref="IDreamService.Cancel(DreamCancelParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDream>> Cancel(
        DreamCancelParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Cancel(DreamCancelParams, CancellationToken)"/>
    Task<HttpResponse<BetaDream>> Cancel(
        string dreamID,
        DreamCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
