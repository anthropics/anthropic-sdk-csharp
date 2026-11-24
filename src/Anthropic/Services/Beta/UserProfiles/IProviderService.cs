using System;
using Anthropic.Core;
using Anthropic.Services.Beta.UserProfiles.Providers;

namespace Anthropic.Services.Beta.UserProfiles;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProviderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProviderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProviderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGoogleService Google { get; }
}

/// <summary>
/// A view of <see cref="IProviderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProviderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProviderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGoogleServiceWithRawResponse Google { get; }
}
