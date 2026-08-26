using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.Federation;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFederationService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFederationServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFederationService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IIssuerService Issuers { get; }

    IRuleService Rules { get; }
}

/// <summary>
/// A view of <see cref="IFederationService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFederationServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFederationServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IIssuerServiceWithRawResponse Issuers { get; }

    IRuleServiceWithRawResponse Rules { get; }
}
