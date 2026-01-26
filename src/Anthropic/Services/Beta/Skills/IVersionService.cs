using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Skills.Versions;

namespace Anthropic.Services.Beta.Skills;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVersionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVersionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create Skill Version
    /// </summary>
    Task<VersionCreateResponse> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(VersionCreateParams, CancellationToken)"/>
    Task<VersionCreateResponse> Create(
        string skillID,
        VersionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Skill Version
    /// </summary>
    Task<VersionRetrieveResponse> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<VersionRetrieveResponse> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Skill Versions
    /// </summary>
    Task<VersionListPage> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<VersionListPage> List(
        string skillID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Skill Version
    /// </summary>
    Task<VersionDeleteResponse> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task<VersionDeleteResponse> Delete(
        string version,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVersionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVersionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVersionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /v1/skills/{skill_id}/versions?beta=true`, but is otherwise the
    /// same as <see cref="IVersionService.Create(VersionCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionCreateResponse>> Create(
        VersionCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(VersionCreateParams, CancellationToken)"/>
    Task<HttpResponse<VersionCreateResponse>> Create(
        string skillID,
        VersionCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/skills/{skill_id}/versions/{version}?beta=true`, but is otherwise the
    /// same as <see cref="IVersionService.Retrieve(VersionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VersionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<VersionRetrieveResponse>> Retrieve(
        string version,
        VersionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /v1/skills/{skill_id}/versions?beta=true`, but is otherwise the
    /// same as <see cref="IVersionService.List(VersionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionListPage>> List(
        VersionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(VersionListParams, CancellationToken)"/>
    Task<HttpResponse<VersionListPage>> List(
        string skillID,
        VersionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /v1/skills/{skill_id}/versions/{version}?beta=true`, but is otherwise the
    /// same as <see cref="IVersionService.Delete(VersionDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VersionDeleteResponse>> Delete(
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VersionDeleteParams, CancellationToken)"/>
    Task<HttpResponse<VersionDeleteResponse>> Delete(
        string version,
        VersionDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
