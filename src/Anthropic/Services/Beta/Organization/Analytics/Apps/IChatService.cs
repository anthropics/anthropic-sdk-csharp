using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Analytics.Apps.Chat;

namespace Anthropic.Services.Beta.Organization.Analytics.Apps;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IChatService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IChatServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IProjectService Projects { get; }
}

/// <summary>
/// A view of <see cref="IChatService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IChatServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IChatServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IProjectServiceWithRawResponse Projects { get; }
}
