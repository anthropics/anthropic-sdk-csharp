using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.UserProfiles;
using Anthropic.Services.UserProfiles;

namespace Anthropic.Services;

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

    IActionUrlService ActionUrls { get; }

    /// <summary>
    /// Create User Profile
    /// </summary>
    Task<UserProfile> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get User Profile
    /// </summary>
    Task<UserProfile> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserProfileRetrieveParams, CancellationToken)"/>
    Task<UserProfile> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update User Profile
    /// </summary>
    Task<UserProfile> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserProfileUpdateParams, CancellationToken)"/>
    Task<UserProfile> Update(
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
    /// Delete User Profile
    /// </summary>
    Task<DeletedUserProfile> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserProfileDeleteParams, CancellationToken)"/>
    Task<DeletedUserProfile> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
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

    IActionUrlServiceWithRawResponse ActionUrls { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Create(UserProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfile>> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user_profiles/{user_profile_id}</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Retrieve(UserProfileRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfile>> Retrieve(
        UserProfileRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UserProfileRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UserProfile>> Retrieve(
        string userProfileID,
        UserProfileRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Update(UserProfileUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfile>> Update(
        UserProfileUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(UserProfileUpdateParams, CancellationToken)"/>
    Task<HttpResponse<UserProfile>> Update(
        string userProfileID,
        UserProfileUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user_profiles</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.List(UserProfileListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfileListPage>> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/user_profiles/{user_profile_id}</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Delete(UserProfileDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DeletedUserProfile>> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<DeletedUserProfile>> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
