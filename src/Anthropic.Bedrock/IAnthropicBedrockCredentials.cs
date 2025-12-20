using Amazon.Runtime;
using Amazon.Runtime.Credentials;

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

/// <summary>
/// Helper utilities for resolving Anthropic Bedrock credentials from environment and default AWS credential sources.
/// </summary>
/// <remarks>
/// This static helper centralizes discovery logic used to create an <c>IAnthropicBedrockCredentials</c> implementation
/// based on environment configuration and the AWS default credential resolution chain. It follows a prioritized lookup:
/// 1. Read the Bedrock region from the <c>AWS_REGION</c> environment variable. If unset, falls back to <c>FallbackRegionFactory</c>.
/// 2. If an environment bearer token is present in <c>AWS_BEARER_TOKEN_BEDROCK</c>, returns an <c>AnthropicBedrockApiTokenCredentials</c>.
/// 3. Otherwise, attempts to resolve the default AWS credentials using <c>DefaultAWSCredentialsIdentityResolver</c>:
///    - If the resolved credentials contain a session token, returns <c>AnthropicBedrockApiTokenCredentials</c>.
///    - Otherwise returns <c>AnthropicBedrockPrivateKeyCredentials</c> with the resolved access key and secret key.
/// If the region cannot be determined or no credentials can be resolved, the helper returns <c>null</c>.
/// </remarks>
/// <threadsafety>Safe for concurrent use.</threadsafety>
/// <seealso cref="AnthropicBedrockApiTokenCredentials"/>
/// <seealso cref="AnthropicBedrockPrivateKeyCredentials"/>
///
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
