using System;
using Anthropic = Anthropic;
using Files = Anthropic.Services.Beta.Files;
using Messages = Anthropic.Services.Beta.Messages;
using Models = Anthropic.Services.Beta.Models;

namespace Anthropic.Services.Beta;

public sealed class BetaService : IBetaService
{
    public BetaService(Anthropic::IAnthropicClient client)
    {
        _models = new(() => new Models::ModelService(client));
        _messages = new(() => new Messages::MessageService(client));
        _files = new(() => new Files::FileService(client));
    }

    readonly Lazy<Models::IModelService> _models;
    public Models::IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<Messages::IMessageService> _messages;
    public Messages::IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<Files::IFileService> _files;
    public Files::IFileService Files
    {
        get { return _files.Value; }
    }
}
