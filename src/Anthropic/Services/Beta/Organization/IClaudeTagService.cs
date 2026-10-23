using System;
using Anthropic.Core;
using Anthropic.Services.Beta.Organization.ClaudeTag;

namespace Anthropic.Services.Beta.Organization;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IClaudeTagService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IClaudeTagServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClaudeTagService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISlackChannelService SlackChannels { get; }

    ISlackWorkspaceService SlackWorkspaces { get; }

    IBundleService Bundles { get; }
}

/// <summary>
/// A view of <see cref="IClaudeTagService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IClaudeTagServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IClaudeTagServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ISlackChannelServiceWithRawResponse SlackChannels { get; }

    ISlackWorkspaceServiceWithRawResponse SlackWorkspaces { get; }

    IBundleServiceWithRawResponse Bundles { get; }
}
