namespace Anthropic.Bedrock;

/// <summary>
/// Provides bearer token-based authentication credentials for accessing Amazon Bedrock Anthropic API.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IAnthropicBedrockCredentials"/> interface to support
/// authentication using a bearer token and AWS region for Anthropic API requests through Amazon Bedrock.
/// The bearer token is applied to the Authorization header of HTTP requests.
/// </remarks>
public class AnthropicBedrockApiTokenCredentials : IAnthropicBedrockCredentials
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnthropicBedrockApiTokenCredentials"/> class.
    /// </summary>
    /// <param name="bearerToken">The bearer token used for authentication with the Anthropic Bedrock API.</param>
    /// <param name="region">The AWS region where the Bedrock service is hosted.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="bearerToken"/> or <paramref name="region"/> is null or whitespace.</exception>
    public AnthropicBedrockApiTokenCredentials(string bearerToken, string region)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bearerToken, nameof(bearerToken));
        ArgumentException.ThrowIfNullOrWhiteSpace(region, nameof(region));

        BearerToken = bearerToken;
        Region = region;
    }

    /// <summary>
    /// Gets the bearer token used for authentication with the Anthropic Bedrock API.
    /// </summary>
    /// <value>
    /// A string representing the bearer token. This value is set privately and can only be modified within the class.
    /// </value>
    public string BearerToken { get; private init; }

    /// <summary>
    /// Gets the AWS region.
    /// </summary>
    public string Region { get; private init; }

    // <inheritdoc />
    public Task Apply(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", BearerToken);
        return Task.CompletedTask;
    }
}
