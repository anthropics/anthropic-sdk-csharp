using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.Vaults.Credentials;

namespace Anthropic.Services.Beta.Vaults;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICredentialService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICredentialServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICredentialService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create Credential
    /// </summary>
    Task<BetaManagedAgentsCredential> Create(
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CredentialCreateParams, CancellationToken)"/>
    Task<BetaManagedAgentsCredential> Create(
        string vaultID,
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get Credential
    /// </summary>
    Task<BetaManagedAgentsCredential> Retrieve(
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CredentialRetrieveParams, CancellationToken)"/>
    Task<BetaManagedAgentsCredential> Retrieve(
        string credentialID,
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update Credential
    /// </summary>
    Task<BetaManagedAgentsCredential> Update(
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CredentialUpdateParams, CancellationToken)"/>
    Task<BetaManagedAgentsCredential> Update(
        string credentialID,
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List Credentials
    /// </summary>
    Task<CredentialListPage> List(
        CredentialListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CredentialListParams, CancellationToken)"/>
    Task<CredentialListPage> List(
        string vaultID,
        CredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete Credential
    /// </summary>
    Task<BetaManagedAgentsDeletedCredential> Delete(
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CredentialDeleteParams, CancellationToken)"/>
    Task<BetaManagedAgentsDeletedCredential> Delete(
        string credentialID,
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archive Credential
    /// </summary>
    Task<BetaManagedAgentsCredential> Archive(
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CredentialArchiveParams, CancellationToken)"/>
    Task<BetaManagedAgentsCredential> Archive(
        string credentialID,
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICredentialService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICredentialServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICredentialServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults/{vault_id}/credentials?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.Create(CredentialCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsCredential>> Create(
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(CredentialCreateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsCredential>> Create(
        string vaultID,
        CredentialCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/vaults/{vault_id}/credentials/{credential_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.Retrieve(CredentialRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsCredential>> Retrieve(
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CredentialRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsCredential>> Retrieve(
        string credentialID,
        CredentialRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults/{vault_id}/credentials/{credential_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.Update(CredentialUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsCredential>> Update(
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CredentialUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsCredential>> Update(
        string credentialID,
        CredentialUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/vaults/{vault_id}/credentials?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.List(CredentialListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CredentialListPage>> List(
        CredentialListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(CredentialListParams, CancellationToken)"/>
    Task<HttpResponse<CredentialListPage>> List(
        string vaultID,
        CredentialListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/vaults/{vault_id}/credentials/{credential_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.Delete(CredentialDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsDeletedCredential>> Delete(
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CredentialDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsDeletedCredential>> Delete(
        string credentialID,
        CredentialDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/vaults/{vault_id}/credentials/{credential_id}/archive?beta=true</c>, but is otherwise the
    /// same as <see cref="ICredentialService.Archive(CredentialArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaManagedAgentsCredential>> Archive(
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(CredentialArchiveParams, CancellationToken)"/>
    Task<HttpResponse<BetaManagedAgentsCredential>> Archive(
        string credentialID,
        CredentialArchiveParams parameters,
        CancellationToken cancellationToken = default
    );
}
