using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeCode;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClaudeCodeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClaudeCodeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClaudeCodeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IManagedSettingService ManagedSettings { get; }
}

/// <summary>
/// A view of <see cref="IClaudeCodeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClaudeCodeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClaudeCodeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IManagedSettingServiceWithRawResponse ManagedSettings { get; }
}
