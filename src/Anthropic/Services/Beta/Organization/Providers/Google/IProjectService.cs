using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Providers.Google.Projects;

namespace Anthropic.Services.Beta.Organization.Providers.Google;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IProjectService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IProjectServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDataControlService DataControls { get; }
}

/// <summary>
/// A view of <see cref="IProjectService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IProjectServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IProjectServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDataControlServiceWithRawResponse DataControls { get; }
}
