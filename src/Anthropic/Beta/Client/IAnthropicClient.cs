using System;
using System.Net.Http;
using Anthropic.Beta.Client.Services.Beta;
using Anthropic.Beta.Client.Services.Messages;
using Anthropic.Beta.Client.Services.Models;

namespace Anthropic.Beta.Client;

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
