using Anthropic.Client.Services.Beta.Files;
using Anthropic.Client.Services.Beta.Messages;
using Anthropic.Client.Services.Beta.Models;

namespace Anthropic.Client.Services.Beta;

public interface IBetaService
{
    IModelService Models { get; }

    IMessageService Messages { get; }

    IFileService Files { get; }
}
