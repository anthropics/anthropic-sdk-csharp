using Amazon.Runtime;
using Amazon.Runtime.Credentials;

namespace Anthropic.Bedrock;

public interface IAnthropicBedrockCredentials
{
    public string Region { get; }
    public void Apply(HttpRequestMessage requestMessage);

    public static async ValueTask<IAnthropicBedrockCredentials?> FromEnv()
    {
        const string ENV_API_KEY = "AWS_BEARER_TOKEN_BEDROCK";
        const string ENV_REGION = "AWS_REGION";

        var region = Environment.GetEnvironmentVariable(ENV_REGION); // this is a bit redundant as FallbackRegionFactory checks for the same value too, but its aligned with the behavior of the java sdk
        if (region is null)
        {
            var defaultRegion = FallbackRegionFactory.GetRegionEndpoint(false);
            if (defaultRegion is null)
            {
                return null;
            }
            region = defaultRegion.HostnameTemplate;
        }

        var token = Environment.GetEnvironmentVariable(ENV_API_KEY);
        if (!string.IsNullOrWhiteSpace(token))
        {
            return new AnthropicBedrockApiTokenCredentials(token, region);
        }
        
        var defaultIdentity = DefaultAWSCredentialsIdentityResolver.GetCredentials();
        if (defaultIdentity is null)
        {
            return null;
        }

        var defaultCreds = await defaultIdentity.GetCredentialsAsync().ConfigureAwait(false);
        if (defaultCreds is null)
        {
            return null;
        }

        if (defaultCreds.UseToken)
        {
            return new AnthropicBedrockApiTokenCredentials(defaultCreds.Token, region);
        }

        return new AnthropicBedrockPrivateKeyCredentials(defaultCreds.SecretKey, defaultCreds.AccessKey, region);
    }
}
