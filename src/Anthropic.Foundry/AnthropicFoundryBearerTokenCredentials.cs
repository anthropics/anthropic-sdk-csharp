using System;
using System.Net.Http;

namespace Anthropic.Foundry;

/// <summary>
/// Defines a new credential set using an <c>Authorization: bearer</c> token.
/// </summary>
public class AnthropicFoundryBearerTokenCredentials : IAnthropicFoundryCredentials
{
    private readonly string _apiKey;

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicFoundryBearerTokenCredentials"/> class.
    /// </summary>
    /// <param name="apiKey">The bearer token.</param>
    public AnthropicFoundryBearerTokenCredentials(string apiKey, string resourceName)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        ResourceName = resourceName ?? throw new ArgumentNullException(nameof(resourceName));
    }

    public string ResourceName { get; }

    public void Apply(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", _apiKey);
    }
}
