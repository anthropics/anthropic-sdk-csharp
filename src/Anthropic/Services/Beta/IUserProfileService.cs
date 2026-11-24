using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.Beta.UserProfiles;
using Anthropic.Services.Beta.UserProfiles;

namespace Anthropic.Services.Beta;

/// <summary>
/// Register the end customers that your platform serves, so each request can name
/// who it's for. To get started, see the [User profiles guide](https://platform.claude.com/docs/en/manage-claude/user-profiles).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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

    IProviderService Providers { get; }

    /// <summary>
    /// Register one of your end customers and get the ID to send on the requests you
    /// make for them.
    ///
    /// <para>See the [User profiles
    /// guide](https://platform.claude.com/docs/en/manage-claude/user-profiles#create-a-profile-for-each-end-customer)
    /// for what to send.</para>
    /// </summary>
    Task<BetaUserProfile> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a user profile by ID to check the details stored for it.
    ///
    /// <para>See the [User profiles
    /// guide](https://platform.claude.com/docs/en/manage-claude/user-profiles) for how
    /// to set up and manage profiles.</para>
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
    /// Change the details of a user profile, leaving the fields that you don't send as
    /// they are.
    ///
    /// <para>See the [User profiles
    /// guide](https://platform.claude.com/docs/en/manage-claude/user-profiles#update-a-profile)
    /// for how each field is updated.</para>
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
    /// List the user profiles in your organization, newest first by default.
    ///
    /// <para>See the [User profiles
    /// guide](https://platform.claude.com/docs/en/manage-claude/user-profiles) for how
    /// to set up and manage profiles.</para>
    /// </summary>
    Task<UserProfileListPage> List(
        UserProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a user profile, for example when the end customer closes their account.
    ///
    /// <para>Stop sending the profile's ID first. See the [User profiles
    /// guide](https://platform.claude.com/docs/en/manage-claude/user-profiles#delete-a-profile)
    /// for what happens after a delete.</para>
    /// </summary>
    Task<BetaDeletedUserProfile> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserProfileDeleteParams, CancellationToken)"/>
    Task<BetaDeletedUserProfile> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a link that sends the profile's end customer to the Verification Portal
    /// from Claude Platform on AWS.
    ///
    /// <para>On the Claude API, create an action URL instead. See [Send an end customer
    /// a link to the Verification
    /// Portal](https://platform.claude.com/docs/en/manage-claude/user-profiles-verification-portal)
    /// for when to create the link and what the end customer sees.</para>
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

    IActionUrlServiceWithRawResponse ActionUrls { get; }

    IProviderServiceWithRawResponse Providers { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles</c>, but is otherwise the
    /// same as <see cref="IUserProfileService.Create(UserProfileCreateParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BetaUserProfile>> Create(
        UserProfileCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/user_profiles/{user_profile_id}</c>, but is otherwise the
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
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}</c>, but is otherwise the
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
    Task<HttpResponse<BetaDeletedUserProfile>> Delete(
        UserProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(UserProfileDeleteParams, CancellationToken)"/>
    Task<HttpResponse<BetaDeletedUserProfile>> Delete(
        string userProfileID,
        UserProfileDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}/enrollment_url</c>, but is otherwise the
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
