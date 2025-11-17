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
    IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Beta::IModelService Models { get; }

    Beta::IMessageService Messages { get; }

    Beta::IFileService Files { get; }

    Beta::ISkillService Skills { get; }
}
