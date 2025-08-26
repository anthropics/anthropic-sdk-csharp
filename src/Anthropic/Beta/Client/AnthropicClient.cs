using System;
using System.Net.Http;
using Anthropic.Beta.Client.Services.Beta;
using Anthropic.Beta.Client.Services.Messages;
using Anthropic.Beta.Client.Services.Models;

namespace Anthropic.Beta.Client;

public sealed class AnthropicClient : IAnthropicClient
{
    public HttpClient HttpClient { get; init; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL") ?? "https://api.anthropic.com"
        )
    );
    public Uri BaseUrl
    {
        get { return _baseUrl.Value; }
        init { _baseUrl = new(() => value); }
    }

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"));
    public string? APIKey
    {
        get { return _apiKey.Value; }
        init { _apiKey = new(() => value); }
    }

    Lazy<string?> _authToken = new(() => Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        get { return _authToken.Value; }
        init { _authToken = new(() => value); }
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<IModelService> _models;
    public IModelService Models
    {
        get { return _models.Value; }
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }

    public AnthropicClient()
    {
        _messages = new(() => new MessageService(this));
        _models = new(() => new ModelService(this));
        _beta = new(() => new BetaService(this));
    }
}
