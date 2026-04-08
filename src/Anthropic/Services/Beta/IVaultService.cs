using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults;
using Anthropic.Services.Beta.Vaults;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IVaultService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IVaultServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVaultService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICredentialService Credentials { get; }

    /// <summary>
    /// Create Vault
    /// </summary>
    Task<BetaManagedAgentsVault> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Vault
    /// </summary>
    Task<BetaManagedAgentsVault> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VaultRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsVault> Retrieve(
        string vaultID,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Vault
    /// </summary>
    Task<BetaManagedAgentsVault> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VaultUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsVault> Update(
        string vaultID,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Vaults
    /// </summary>
    Task<VaultListPage> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Vault
    /// </summary>
    Task<BetaManagedAgentsDeletedVault> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VaultDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeletedVault> Delete(
        string vaultID,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Vault
    /// </summary>
    Task<BetaManagedAgentsVault> Archive(
        VaultArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(VaultArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsVault> Archive(
        string vaultID,
        VaultArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IVaultService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IVaultServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IVaultServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICredentialServiceWithRawResponse Credentials { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.Create(VaultCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsVault>> Create(
        VaultCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/vaults/{vault_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.Retrieve(VaultRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsVault>> Retrieve(
        VaultRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(VaultRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsVault>> Retrieve(
        string vaultID,
        VaultRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults/{vault_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.Update(VaultUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsVault>> Update(
        VaultUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(VaultUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsVault>> Update(
        string vaultID,
        VaultUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/vaults?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.List(VaultListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<VaultListPage>> List(
        VaultListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/vaults/{vault_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.Delete(VaultDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeletedVault>> Delete(
        VaultDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(VaultDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeletedVault>> Delete(
        string vaultID,
        VaultDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults/{vault_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="IVaultService.Archive(VaultArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsVault>> Archive(
        VaultArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(VaultArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsVault>> Archive(
        string vaultID,
        VaultArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
