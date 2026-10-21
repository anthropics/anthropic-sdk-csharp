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
    /// Start an asynchronous job that uses past sessions to produce a reorganized
    /// version of a memory store and get back the dream to poll for the result.
    ///
    /// <para>By default the dream writes its result to a new memory store and doesn't
    /// change the input memory store. The response has `status` set to `pending` and an
    /// empty `outputs` array. Poll the dream until `status` is `completed`, `failed`,
    /// or `canceled`.</para>
    ///
    /// <para>See the [Dreams
    /// guide](https://platform.claude.com/docs/en/managed-agents/dreams#create-a-dream)
    /// to learn more about creating dreams.</para>
    /// </summary>
    Task<BetaDream> Create(
        DreamCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a dream by ID to check its status, output memory store, and token usage.
    ///
    /// <para>Archived dreams are returned too.</para>
    ///
    /// <para>See the [Dreams
    /// guide](https://platform.claude.com/docs/en/managed-agents/dreams#track-progress)
    /// for how to poll a dream and what each status means.</para>
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
    /// List the dreams in the workspace, newest first.
    ///
    /// <para>Archived dreams are left out unless `include_archived` is `true`.</para>
    ///
    /// <para>See the [Dreams
    /// guide](https://platform.claude.com/docs/en/managed-agents/dreams#list-dreams)
    /// for how to page through dreams.</para>
    /// </summary>
    Task<DreamListPage> List(
        DreamListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Hide a `completed`, `failed`, or `canceled` dream from the default list of
    /// dreams.
    ///
    /// <para>Archiving a `pending` or `running` dream returns a 400 error, so cancel it
    /// first. Archiving an archived dream returns it unchanged. An archived dream can
    /// still be fetched by ID. Archiving can't be undone.</para>
    ///
    /// <para>See the [Dreams
    /// guide](https://platform.claude.com/docs/en/managed-agents/dreams#archive-a-dream)
    /// to learn more about archiving dreams.</para>
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
    /// Stop a `pending` or `running` dream.
    ///
    /// <para>The response shows `status` as `canceled`, unless the dream reached
    /// `completed` or `failed` first. `usage` can keep changing after the response.
    /// Canceling a `canceled` dream returns it unchanged. Canceling a `completed` or
    /// `failed` dream returns a 400 error.</para>
    ///
    /// <para>See the [Dreams
    /// guide](https://platform.claude.com/docs/en/managed-agents/dreams#cancel-a-dream)
    /// to learn more about canceling dreams.</para>
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
