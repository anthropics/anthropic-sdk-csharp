using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Analytics.Apps;

namespace Anthropic.Services.Beta.Organization.Analytics;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAppService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAppServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAppService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IChatService Chat { get; }
}

/// <summary>
/// A view of <see cref="IAppService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAppServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAppServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IChatServiceWithRawResponse Chat { get; }
}
