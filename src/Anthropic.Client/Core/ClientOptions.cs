using System;
using System.Net.Http;

namespace Anthropic.Client.Core;

public struct ClientOptions()
{
    public HttpClient HttpClient { get; set; } = new();

    Lazy<Uri> _baseUrl = new(() =>
        new Uri(
            Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL") ?? "https://api.anthropic.com"
        )
    );
    public Uri BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    public bool ResponseValidation { get; set; } = false;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(10);

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"));
    public string? APIKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    Lazy<string?> _authToken = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        readonly get { return _authToken.Value; }
        set { _authToken = new(() => value); }
    }
}
