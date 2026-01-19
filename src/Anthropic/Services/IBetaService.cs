using System;
using Anthropic.Core;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBetaService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBetaServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Beta::IModelService Models { get; }

    Beta::IMessageService Messages { get; }

    Beta::IFileService Files { get; }

    Beta::ISkillService Skills { get; }
}

/// <summary>
/// A view of <see cref="IBetaService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBetaServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Beta::IModelServiceWithRawResponse Models { get; }

    Beta::IMessageServiceWithRawResponse Messages { get; }

    Beta::IFileServiceWithRawResponse Files { get; }

    Beta::ISkillServiceWithRawResponse Skills { get; }
}
