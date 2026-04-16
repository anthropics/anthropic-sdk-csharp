using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles;

namespace Anthropic.Services.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUserProfileService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUserProfileServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserProfileService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create User Profile
    /// </summary>
    Task<BetaUserProfile> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get User Profile
    /// </summary>
    Task<BetaUserProfile> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserProfileRetrieveParams, CancellationToken)"/>
    Task<BetaUserProfile> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update User Profile
    /// </summary>
    Task<BetaUserProfile> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserProfileUpdateParams, CancellationToken)"/>
    Task<BetaUserProfile> Update(
        string userProfileID,
        UserProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List User Profiles
    /// </summary>
    Task<UserProfileListPage> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create Enrollment URL
    /// </summary>
    Task<BetaUserProfileEnrollmentUrl> CreateEnrollmentUrl(
        UserProfileCreateEnrollmentUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnrollmentUrl(UserProfileCreateEnrollmentUrlParams, CancellationToken)"/>
    Task<BetaUserProfileEnrollmentUrl> CreateEnrollmentUrl(
        string userProfileID,
        UserProfileCreateEnrollmentUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUserProfileService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUserProfileServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUserProfileServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Create(UserProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaUserProfile>> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user_profiles/{user_profile_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Retrieve(UserProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaUserProfile>> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BetaUserProfile>> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Update(UserProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaUserProfile>> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BetaUserProfile>> Update(
        string userProfileID,
        UserProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user_profiles?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.List(UserProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfileListPage>> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}/enrollment_url?beta=true</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.CreateEnrollmentUrl(UserProfileCreateEnrollmentUrlParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaUserProfileEnrollmentUrl>> CreateEnrollmentUrl(
        UserProfileCreateEnrollmentUrlParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateEnrollmentUrl(UserProfileCreateEnrollmentUrlParams, CancellationToken)"/>
    Task<HttpResponse<BetaUserProfileEnrollmentUrl>> CreateEnrollmentUrl(
        string userProfileID,
        UserProfileCreateEnrollmentUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
