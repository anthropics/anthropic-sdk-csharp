using Anthropic.Beta.Client.Services.Beta.Files;
using Anthropic.Beta.Client.Services.Beta.Messages;
using Anthropic.Beta.Client.Services.Beta.Models;

namespace Anthropic.Beta.Client.Services.Beta;

public interface IBetaService
{
    IModelService Models { get; }

    IMessageService Messages { get; }

    IFileService Files { get; }
}
