using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Organization;
using Anthropic.Models.Beta.Organization.Providers.Google.Projects.DataControls;
using Anthropic.Models.Organization.Workspaces;

namespace Anthropic.Services.Beta.Organization.Providers.Google.Projects;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDataControlService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDataControlServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataControlService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get a Google Cloud project's encryption keys and storage buckets for Claude on
    /// Google Cloud's Agent Platform, with each region's status.
    ///
    /// <para>Your organization must have proved that it owns the project.</para>
    /// </summary>
    Task<BetaGoogleManagedProjectDataControls> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DataControlRetrieveParams, CancellationToken)"/>
    Task<BetaGoogleManagedProjectDataControls> Retrieve(
        string projectNumber,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Turn a control on or off, or change the key or bucket set for a region. Controls
    /// and regions that you leave out stay as they are.
    ///
    /// <para>Your organization must have proved that it owns the project. Only one
    /// organization at a time can have controls turned on for a project.</para>
    ///
    /// <para>**Requires a credential that identifies a user or a service account**: an
    /// OAuth access token with the `org:admin` scope, or an organization-scoped API key
    /// that belongs to a user or service account whose organization role can update
    /// these controls. The `admin`, `owner` and `primary_owner` roles can. An Admin API
    /// key gets a `403` error.</para>
    /// </summary>
    /// <exception cref="AnthropicBetaCmekNotApprovedException"/>
    /// <exception cref="AnthropicBetaExternalKeyNotFoundException"/>
    /// <exception cref="AnthropicBetaExternalKeyProviderMismatchException"/>
    /// <exception cref="AnthropicBetaGcpProjectNotVerifiedException"/>
    /// <exception cref="AnthropicKeyProfileMismatchException"/>
    /// <exception cref="AnthropicBetaOrganizationNotEligibleException"/>
    /// <exception cref="AnthropicBetaRegionNotSupportedException"/>
    /// <exception cref="AnthropicBetaStorageNotApprovedException"/>
    /// <exception cref="AnthropicSandboxEgressRestrictedException"/>
    /// <exception cref="AnthropicBetaGcpProjectControlledByAnotherOrganizationException"/>
    /// <exception cref="AnthropicBetaStorageInUseException"/>
    /// <exception cref="AnthropicBetaAuthorizationCheckUnavailableException"/>
    Task<BetaGoogleManagedProjectDataControls> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataControlUpdateParams, CancellationToken)"/>
    Task<BetaGoogleManagedProjectDataControls> Update(
        string projectNumber,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDataControlService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDataControlServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataControlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/organizations/providers/google/projects/{project_number}/data_controls</c>, but is otherwise the
    /// same as <see cref="IDataControlService.Retrieve(DataControlRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DataControlRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Retrieve(
        string projectNumber,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/organizations/providers/google/projects/{project_number}/data_controls</c>, but is otherwise the
    /// same as <see cref="IDataControlService.Update(DataControlUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataControlUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaGoogleManagedProjectDataControls>> Update(
        string projectNumber,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
