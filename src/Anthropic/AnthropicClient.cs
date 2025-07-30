using Beta = Anthropic.Service.Beta;
using Completions = Anthropic.Service.Completions;
using Http = System.Net.Http;
using Messages = Anthropic.Service.Messages;
using Models = Anthropic.Service.Models;
using System = System;

namespace Anthropic;

public sealed class AnthropicClient : IAnthropicClient
{
    public Http::HttpClient HttpClient { get; init; } = new();

    System::Lazy<System::Uri> _baseUrl = new(() =>
        new System::Uri(
            System::Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL")
                ?? "https://api.anthropic.com"
        )
    );
    public System::Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    System::Lazy<string?> _apiKey = new(() =>
        System::Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY")
    );
    public string? APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    System::Lazy<string?> _authToken = new(() =>
        System::Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        get { return _authToken.Value; }
        init { _authToken = new(() => value); }
    }

    readonly System::Lazy<Completions::ICompletionService> _completions;
    public Completions::ICompletionService Completions
    {
        get { return _completions.Value; }
    }

    readonly System::Lazy<Messages::IMessageService> _messages;
    public Messages::IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly System::Lazy<Models::IModelService> _models;
    public Models::IModelService Models
    {
        get { return _models.Value; }
    }

    readonly System::Lazy<Beta::IBetaService> _beta;
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
