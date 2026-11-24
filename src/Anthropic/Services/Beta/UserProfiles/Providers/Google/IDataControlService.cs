using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles.Providers.Google.DataControls;

namespace Anthropic.Services.Beta.UserProfiles.Providers.Google;

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
    /// Get the profile's encryption keys and storage buckets for Claude on Google
    /// Cloud's Agent Platform, with each region's status.
    /// </summary>
    Task<BetaGoogleManagedDataControls> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DataControlRetrieveParams, CancellationToken)"/>
    Task<BetaGoogleManagedDataControls> Retrieve(
        string userProfileID,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Turn a control on or off, or change the key or bucket set for a region. Controls
    /// and regions that you leave out stay as they are.
    /// </summary>
    Task<BetaGoogleManagedDataControls> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataControlUpdateParams, CancellationToken)"/>
    Task<BetaGoogleManagedDataControls> Update(
        string userProfileID,
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
    /// Returns a raw HTTP response for <c>get /v1/user_profiles/{user_profile_id}/providers/google/data_controls</c>, but is otherwise the
    /// same as <see cref="IDataControlService.Retrieve(DataControlRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaGoogleManagedDataControls>> Retrieve(
        DataControlRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(DataControlRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaGoogleManagedDataControls>> Retrieve(
        string userProfileID,
        DataControlRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}/providers/google/data_controls</c>, but is otherwise the
    /// same as <see cref="IDataControlService.Update(DataControlUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaGoogleManagedDataControls>> Update(
        DataControlUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(DataControlUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaGoogleManagedDataControls>> Update(
        string userProfileID,
        DataControlUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
