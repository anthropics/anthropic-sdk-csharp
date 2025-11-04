using System;
using Anthropic.Client.Core;
using Anthropic.Client.Services.Beta.Files;
using Anthropic.Client.Services.Beta.Messages;
using Anthropic.Client.Services.Beta.Models;
using Anthropic.Client.Services.Beta.Skills;

namespace Anthropic.Client.Services.Beta;

public interface IBetaService
{
    IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IModelService Models { get; }

    IMessageService Messages { get; }

    IFileService Files { get; }

    ISkillService Skills { get; }
}
