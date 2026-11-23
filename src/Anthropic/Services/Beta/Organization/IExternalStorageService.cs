using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.ExternalStorage;
using Anthropic.Models.UserProfiles;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExternalStorageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExternalStorageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalStorageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Register a bucket in the organization's own cloud account. It is saved as
    /// `pending_configuration` and verified when activated.
    /// </summary>
    /// <exception cref="AnthropicBetaGrantRequiredException"/>
    /// <exception cref="AnthropicBetaOrganizationNotEligibleException"/>
    /// <exception cref="AnthropicBetaProviderNotAllowedException"/>
    /// <exception cref="AnthropicBetaUnsupportedRegionException"/>
    /// <exception cref="AnthropicUserProfileNotFoundException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    /// <exception cref="AnthropicBetaStorageAlreadyRegisteredException"/>
    /// <exception cref="AnthropicBetaAuthorizationCheckUnavailableException"/>
    Task<BetaExternalStorage> Create(
        ExternalStorageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get one External Storage in the organization.
    /// </summary>
    /// <exception cref="AnthropicBetaInvalidStorageArnException"/>
    Task<BetaExternalStorage> Retrieve(
        ExternalStorageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalStorageRetrieveParams, CancellationToken)"/>
    Task<BetaExternalStorage> Retrieve(
        string externalStorageID,
        ExternalStorageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rename External Storage or clear its name, in any status.
    /// </summary>
    /// <exception cref="AnthropicBetaInvalidStorageArnException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    Task<BetaExternalStorage> Update(
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalStorageUpdateParams, CancellationToken)"/>
    Task<BetaExternalStorage> Update(
        string externalStorageID,
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the organization's External Storage, newest first.
    /// </summary>
    Task<ExternalStorageListPage> List(
        ExternalStorageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete External Storage. Storage that is pending configuration, available, or
    /// active but never attached is deleted at once, unless an Enterprise Frontier
    /// Safeguards workspace policy lists it. Other storage gets a 400 that says what to
    /// do next. On `draining` storage that 400 can mean this delete started a removal
    /// that can't be undone. To check, get the storage: if `status.removal_started` is
    /// true, delete it again later to finish.
    /// </summary>
    /// <exception cref="AnthropicBetaExternalStorageInUseException"/>
    /// <exception cref="AnthropicBetaExternalStorageInWorkspacePolicyException"/>
    /// <exception cref="AnthropicBetaInvalidStorageArnException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    Task<BetaDeletedExternalStorage> Delete(
        ExternalStorageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExternalStorageDeleteParams, CancellationToken)"/>
    Task<BetaDeletedExternalStorage> Delete(
        string externalStorageID,
        ExternalStorageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Verify pending External Storage and make it available. Storage that is already
    /// available, active or draining comes back unchanged, without any check.
    /// </summary>
    /// <exception cref="AnthropicBetaGrantRequiredException"/>
    /// <exception cref="AnthropicBetaInvalidStorageArnException"/>
    /// <exception cref="AnthropicBetaOrganizationNotEligibleException"/>
    /// <exception cref="AnthropicBetaProviderNotAllowedException"/>
    /// <exception cref="AnthropicBetaStorageVerificationFailedException"/>
    /// <exception cref="AnthropicUserProfileNotFoundException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    /// <exception cref="AnthropicBetaAuthorizationCheckUnavailableException"/>
    Task<BetaExternalStorage> Activate(
        ExternalStorageActivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Activate(ExternalStorageActivateParams, CancellationToken)"/>
    Task<BetaExternalStorage> Activate(
        string externalStorageID,
        ExternalStorageActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExternalStorageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExternalStorageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExternalStorageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_storage</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.Create(ExternalStorageCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalStorage>> Create(
        ExternalStorageCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/external_storage/{external_storage_id}</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.Retrieve(ExternalStorageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalStorage>> Retrieve(
        ExternalStorageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExternalStorageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaExternalStorage>> Retrieve(
        string externalStorageID,
        ExternalStorageRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_storage/{external_storage_id}</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.Update(ExternalStorageUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalStorage>> Update(
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ExternalStorageUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaExternalStorage>> Update(
        string externalStorageID,
        ExternalStorageUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/external_storage</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.List(ExternalStorageListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExternalStorageListPage>> List(
        ExternalStorageListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/organizations/external_storage/{external_storage_id}</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.Delete(ExternalStorageDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaDeletedExternalStorage>> Delete(
        ExternalStorageDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ExternalStorageDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedExternalStorage>> Delete(
        string externalStorageID,
        ExternalStorageDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/external_storage/{external_storage_id}/activate</c>, but is otherwise the
    /// same as <see cref="IExternalStorageService.Activate(ExternalStorageActivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaExternalStorage>> Activate(
        ExternalStorageActivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Activate(ExternalStorageActivateParams, CancellationToken)"/>
    Task<HttpResponse<BetaExternalStorage>> Activate(
        string externalStorageID,
        ExternalStorageActivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
