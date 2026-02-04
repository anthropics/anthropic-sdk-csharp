using Amazon.Runtime;
using Amazon.Runtime.Credentials;

namespace Anthropic.Bedrock;

//// <summary>
/// Asynchronously creates an <c>IAnthropicBedrockCredentials</c> instance by inspecting environment variables
/// and falling back to the AWS default credential resolution chain.
/// </summary>
/// <returns>
/// A <see cref="ValueTask{TResult}"/> that resolves to an <c>IAnthropicBedrockCredentials</c> when credentials
/// are successfully discovered; otherwise <c>null</c>.
/// </returns>
/// <remarks>
/// Behavior details:
/// - Environment variables:
///   - <c>AWS_BEARER_TOKEN_BEDROCK</c>: when present and non-empty, used to construct <c>AnthropicBedrockApiTokenCredentials</c>.
///   - <c>AWS_REGION</c>: used as the Bedrock region. If not set, this method consults <c>FallbackRegionFactory</c>.
/// - If no bearer token is found, the method queries <c>DefaultAWSCredentialsIdentityResolver</c> for credentials.
///   - If the returned credentials indicate <c>UseToken</c>, the session token is used to create
///     <c>AnthropicBedrockApiTokenCredentials</c>.
///   - Otherwise the access key and secret key are used to create <c>AnthropicBedrockPrivateKeyCredentials</c>.
/// - The method returns <c>null</c> in scenarios where the region cannot be determined or no credentials are available.
/// - The method performs asynchronous credential resolution and should be awaited.
/// </remarks>
/// <example>
/// // Example usage:
/// // var creds = await AnthropicBedrockCredentialsHelper.FromEnv();
/// // if (creds == null) { /* handle missing credentials */ }
/// </example>
public static class AnthropicBedrockCredentialsHelper
{
    public static async ValueTask<IAnthropicBedrockCredentials?> FromEnv()
    {
        const string ENV_API_KEY = "AWS_BEARER_TOKEN_BEDROCK";
        const string ENV_REGION = "AWS_REGION";

        var region = Environment.GetEnvironmentVariable(ENV_REGION);
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
            return new AnthropicBedrockApiTokenCredentials()
            {
                BearerToken = token,
                Region = region,
            };
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
            return new AnthropicBedrockApiTokenCredentials()
            {
                BearerToken = defaultCreds.Token,
                Region = region,
            };
        }

        return new AnthropicBedrockPrivateKeyCredentials
        {
            ApiAccessKey = defaultCreds.AccessKey,
            ApiSecret = defaultCreds.SecretKey,
            Region = region,
        };
    }
}
