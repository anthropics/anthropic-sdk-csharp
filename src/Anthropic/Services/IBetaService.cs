using System;
using Anthropic.Core;
using Beta = Anthropic.Services.Beta;

namespace Anthropic.Services;

public interface IBetaService
{
    IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Beta::IModelService Models { get; }

    Beta::IMessageService Messages { get; }

    Beta::IFileService Files { get; }

    Beta::ISkillService Skills { get; }
}
