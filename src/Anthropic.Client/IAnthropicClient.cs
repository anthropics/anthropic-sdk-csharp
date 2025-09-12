using System;
using System.Net.Http;
using Anthropic.Client.Services.Beta;
using Anthropic.Client.Services.Messages;
using Anthropic.Client.Services.Models;

namespace Anthropic.Client;

public interface IAnthropicClient
{
    HttpClient HttpClient { get; init; }

    Uri BaseUrl { get; init; }

    string? APIKey { get; init; }

    string? AuthToken { get; init; }

    IMessageService Messages { get; }

    IModelService Models { get; }

    IBetaService Beta { get; }
}
