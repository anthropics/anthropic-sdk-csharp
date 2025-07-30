using Beta = Anthropic.Service.Beta;
using Completions = Anthropic.Service.Completions;
using Http = System.Net.Http;
using Messages = Anthropic.Service.Messages;
using Models = Anthropic.Service.Models;

namespace Anthropic;

public interface IAnthropicClient
{
    Http::HttpClient HttpClient { get; init; }

    global::System.Uri BaseUrl { get; init; }

    string? APIKey { get; init; }

    string? AuthToken { get; init; }

    Completions::ICompletionService Completions { get; }

    Messages::IMessageService Messages { get; }

    Models::IModelService Models { get; }

    Beta::IBetaService Beta { get; }
}
