namespace Anthropic.Bedrock;

/// <summary>
/// Provides methods for authenticating a request for the AWS servers.
/// </summary>
public interface IAnthropicBedrockCredentials
{
    /// <summary>
    /// Gets the Region a request should target.
    /// </summary>
    public string Region { get; }

    /// <summary>
    /// Modifies a <see cref="HttpRequestMessage"/> to contain authentication necessary.
    /// </summary>
    /// <param name="requestMessage">The <see cref="HttpRequestMessage"/> to authenticate.</param>
    /// <returns>A task that resolves once the request has been modified.</returns>
    public Task Apply(HttpRequestMessage requestMessage);

#if NET
    public static async ValueTask<IAnthropicBedrockCredentials?> FromEnv()
    {
        return await AnthropicBedrockCredentialsHelper.FromEnv().ConfigureAwait(false);
    }
#endif
}
