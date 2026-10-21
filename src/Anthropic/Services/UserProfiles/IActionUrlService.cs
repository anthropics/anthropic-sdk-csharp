using System;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Core;
using Anthropic.Models.UserProfiles.ActionUrls;

namespace Anthropic.Services.UserProfiles;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IActionUrlService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IActionUrlServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create Action URL
    /// </summary>
    Task<UserProfileActionUrl> Create(
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ActionUrlCreateParams, CancellationToken)"/>
    Task<UserProfileActionUrl> Create(
        string userProfileID,
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IActionUrlService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IActionUrlServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IActionUrlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/user_profiles/{user_profile_id}/action_urls</c>, but is otherwise the
    /// same as <see cref="IActionUrlService.Create(ActionUrlCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UserProfileActionUrl>> Create(
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ActionUrlCreateParams, CancellationToken)"/>
    Task<HttpResponse<UserProfileActionUrl>> Create(
        string userProfileID,
        ActionUrlCreateParams parameters,
        CancellationToken cancellationToken = default
    );
}
