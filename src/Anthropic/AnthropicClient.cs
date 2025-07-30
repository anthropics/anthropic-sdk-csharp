using Beta = Anthropic.Service.Beta;
using Completions = Anthropic.Service.Completions;
using Http = System.Net.Http;
using Messages = Anthropic.Service.Messages;
using Models = Anthropic.Service.Models;

namespace Anthropic;

public sealed class AnthropicClient : IAnthropicClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

    global::System.Lazy<global::System.Uri> _baseUrl = new(() =>
        new global::System.Uri(
            global::System.Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL")
                ?? "https://api.anthropic.com"
        )
    );
    public global::System.Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    global::System.Lazy<string?> _apiKey = new(() =>
        global::System.Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY")
    );
    public string? APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    global::System.Lazy<string?> _authToken = new(() =>
        global::System.Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        get { return _authToken.Value; }
        init { _authToken = new(() => value); }
    }

    readonly global::System.Lazy<Completions::ICompletionService> _completions;
    public Completions::ICompletionService Completions
    {
        get { return _completions.Value; }
    }

    readonly global::System.Lazy<Messages::IMessageService> _messages;
    public Messages::IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly global::System.Lazy<Models::IModelService> _models;
    public Models::IModelService Models
    {
        get { return _models.Value; }
    }

    readonly global::System.Lazy<Beta::IBetaService> _beta;
    public Beta::IBetaService Beta
    {
        get { return _beta.Value; }
    }

    public AnthropicClient()
    {
        _completions = new(() => new Completions::CompletionService(this));
        _messages = new(() => new Messages::MessageService(this));
        _models = new(() => new Models::ModelService(this));
        _beta = new(() => new Beta::BetaService(this));
    }
}
