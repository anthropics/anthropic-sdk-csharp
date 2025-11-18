using Azure.Identity;

namespace Anthropic.Foundry;

public interface IAnthropicFoundryCredentials
{
    string ResourceName { get; }

    void Apply(HttpRequestMessage requestMessage);
#if NET8_0_OR_GREATER
    public static async ValueTask<IAnthropicFoundryCredentials?> FromEnv()
    {
        return await DefaultAnthropicFoundryCredentials.FromEnv().ConfigureAwait(false);
    }
#endif
}

public class DefaultAnthropicFoundryCredentials
{
    /// <summary>
    /// Creates a new instance of <see cref="IAnthropicFoundryCredentials"/> from environment variables.
    /// </summary>
    /// <remarks>
    /// Set the following environment variables:
    /// <code>
    /// ANTHROPIC_FOUNDRY_RESOURCE=your_resource_name
    /// ANTHROPIC_FOUNDRY_API_KEY=your_api_key
    /// </code>
    /// or use Azure Identity to provide a token.
    /// 
    /// If both are set, the API key environment variable will take precedence.
    /// 
    /// </remarks>
    /// <param name="resourceName">The resource name or if null loaded from the environment variable <c>ANTHROPIC_FOUNDRY_RESOURCE</c></param>
    /// <returns></returns>
    public static async ValueTask<IAnthropicFoundryCredentials?> FromEnv(string? resourceName = null)
    {
        if(Environment.GetEnvironmentVariable("ANTHROPIC_FOUNDRY_RESOURCE") is not string envResourceName 
            || (string.IsNullOrWhiteSpace(resourceName) && string.IsNullOrWhiteSpace(envResourceName)))
        {
            return null;
        }

        if (Environment.GetEnvironmentVariable("ANTHROPIC_FOUNDRY_API_KEY") is string apiKey && !string.IsNullOrWhiteSpace(apiKey))
        {
            return new AnthropicFoundryApiKeyCredentials(apiKey, resourceName ?? envResourceName);
        }

        var defaultCredentialsProvider = new DefaultAzureCredential();

        var azureToken = await defaultCredentialsProvider.GetTokenAsync(new()
        {

        }).ConfigureAwait(false);
        if (!azureToken.Equals(default))
        {
            return new AnthropicFoundryIdentityTokenCredentials(azureToken, resourceName ?? envResourceName);
        }

        return null;
    }
}
