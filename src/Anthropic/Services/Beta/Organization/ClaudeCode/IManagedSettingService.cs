using System;
using Anthropic.Core;
using ManagedSettings = Anthropic.Services.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Services.Beta.Organization.ClaudeCode;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IManagedSettingService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IManagedSettingServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IManagedSettingService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ManagedSettings::IConfigurationService Configuration { get; }

    ManagedSettings::IRbacGroupService RbacGroups { get; }

    ManagedSettings::IRbacGroupDefaultService RbacGroupDefault { get; }
}

/// <summary>
/// A view of <see cref="IManagedSettingService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IManagedSettingServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IManagedSettingServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ManagedSettings::IConfigurationServiceWithRawResponse Configuration { get; }

    ManagedSettings::IRbacGroupServiceWithRawResponse RbacGroups { get; }

    ManagedSettings::IRbacGroupDefaultServiceWithRawResponse RbacGroupDefault { get; }
}
