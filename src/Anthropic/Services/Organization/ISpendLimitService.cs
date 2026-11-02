using System;
using Anthropic.Core;
using Anthropic.Services.Organization.SpendLimits;

namespace Anthropic.Services.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISpendLimitService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISpendLimitServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpendLimitService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEffectiveService Effective { get; }

    IIncreaseRequestService IncreaseRequests { get; }
}

/// <summary>
/// A view of <see cref="ISpendLimitService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISpendLimitServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISpendLimitServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IEffectiveServiceWithRawResponse Effective { get; }

    IIncreaseRequestServiceWithRawResponse IncreaseRequests { get; }
}
