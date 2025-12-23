namespace Anthropic.Foundry;

/// <summary>
/// Defines a new credential set using an <c>x-api-key: </c> token.
/// </summary>
public class AnthropicFoundryApiKeyCredentials : IAnthropicFoundryCredentials
{
    private readonly string _apiKey;

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicFoundryApiKeyCredentials"/> class.
    /// </summary>
    /// <param name="apiKey">The <c>x-api-key</c> api key.</param>
    /// <param name="resourceName">The resource name as part of the base url for the api.</param>
    public AnthropicFoundryApiKeyCredentials(string apiKey, string resourceName)
    {
        _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        ResourceName = resourceName ?? throw new ArgumentNullException(nameof(resourceName));
    }

    public string ResourceName { get; }

    public void Apply(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.TryAddWithoutValidation("x-api-key", _apiKey);
    }
}
