using System;
using Anthropic.Client.Services.Beta.Files;
using Anthropic.Client.Services.Beta.Messages;
using Anthropic.Client.Services.Beta.Models;

namespace Anthropic.Client.Services.Beta;

public sealed class BetaService : IBetaService
{
    public BetaService(IAnthropicClient client)
    {
        _models = new(() => new ModelService(client));
        _messages = new(() => new MessageService(client));
        _files = new(() => new FileService(client));
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IFileService> _files;
    public IFileService Files
    {
        get { return _files.Value; }
    }
}
