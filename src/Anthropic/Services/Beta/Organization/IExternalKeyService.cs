using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalKeys;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create an external key config owned by the caller's organization.
    /// </summary>
    Task<BetaExternalKey> Create(
        ExternalKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single external key config in the caller's organization by ID.
    /// </summary>
    Task<BetaExternalKey> Retrieve(
        ExternalKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalKeyRetrieveParams, CancellationToken)"/>
    Task<BetaExternalKey> Retrieve(
        string externalKeyID,
        ExternalKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update an external key config. Omitted fields are left unchanged.
    ///
    /// <para>`display_name` is always editable. `geo` and `provider_config` cannot be
    /// changed once any workspace references this config, because previously encrypted
    /// data requires the original key identity to decrypt.</para>
    /// </summary>
    Task<BetaExternalKey> Update(
        ExternalKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalKeyUpdateParams, CancellationToken)"/>
    Task<BetaExternalKey> Update(
        string externalKeyID,
        ExternalKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List external key configs in the caller's organization.
    ///
    /// <para>Results are ordered by creation time (newest first). Use the `next_page`
    /// cursor from the response to fetch subsequent pages.</para>
    /// </summary>
    Task<ExternalKeyListPage> List(
        ExternalKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an external key config.
    ///
    /// <para>The request is rejected if any workspace still references this config.</para>
    /// </summary>
    Task<ExternalKeyDeleteResponse> Delete(
        ExternalKeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExternalKeyDeleteParams, CancellationToken)"/>
    Task<ExternalKeyDeleteResponse> Delete(
        string externalKeyID,
        ExternalKeyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Validate an external key config against the customer's KMS.
    ///
    /// <para>Anthropic performs an encrypt/decrypt roundtrip against the configured KMS
    /// key and waits up to 30 seconds for the result. The response status is `success`
    /// if the roundtrip succeeded, or `failure` with an error message if it failed or
    /// timed out.</para>
    /// </summary>
    Task<ExternalKeyValidateResponse> Validate(
        ExternalKeyValidateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Validate(ExternalKeyValidateParams, CancellationToken)"/>
    Task<ExternalKeyValidateResponse> Validate(
        string externalKeyID,
        ExternalKeyValidateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_keys?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.Create(ExternalKeyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalKey>> Create(
        ExternalKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/external_keys/{external_key_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.Retrieve(ExternalKeyRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalKey>> Retrieve(
        ExternalKeyRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalKeyRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaExternalKey>> Retrieve(
        string externalKeyID,
        ExternalKeyRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_keys/{external_key_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.Update(ExternalKeyUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalKey>> Update(
        ExternalKeyUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalKeyUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaExternalKey>> Update(
        string externalKeyID,
        ExternalKeyUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/external_keys?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.List(ExternalKeyListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalKeyListPage>> List(
        ExternalKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/external_keys/{external_key_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.Delete(ExternalKeyDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalKeyDeleteResponse>> Delete(
        ExternalKeyDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExternalKeyDeleteParams, CancellationToken)"/>
    Task<HttpResponse<ExternalKeyDeleteResponse>> Delete(
        string externalKeyID,
        ExternalKeyDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_keys/{external_key_id}/validate?beta=true</c>, but is otherwise the
    /// same as <see cref="IExternalKeyService.Validate(ExternalKeyValidateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalKeyValidateResponse>> Validate(
        ExternalKeyValidateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Validate(ExternalKeyValidateParams, CancellationToken)"/>
    Task<HttpResponse<ExternalKeyValidateResponse>> Validate(
        string externalKeyID,
        ExternalKeyValidateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
