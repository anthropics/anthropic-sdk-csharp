namespace Anthropic.Bedrock;

/// <summary>
/// Provides bearer token-based authentication credentials for accessing Amazon Bedrock Anthropic API.
/// </summary>
/// <remarks>
/// This class implements the <see cref="IAnthropicBedrockCredentials"/> interface to support
/// authentication using a bearer token and AWS region for Anthropic API requests through Amazon Bedrock.
/// The bearer token is applied to the Authorization header of HTTP requests.
/// </remarks>
public sealed class AnthropicBedrockApiTokenCredentials : IAnthropicBedrockCredentials
{
    /// <summary>
    /// Gets the bearer token used for authentication with the Anthropic Bedrock API.
    /// </summary>
    /// <value>
    /// A string representing the bearer token. This value is set privately and can only be modified within the class.
    /// </value>
    public required string BearerToken { get; init; }

    /// <summary>
    /// Gets the AWS region.
    /// </summary>
    public required string Region { get; init; }

    /// <inheritdoc />
    public Task Apply(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", BearerToken);
        return Task.CompletedTask;
    }
}
