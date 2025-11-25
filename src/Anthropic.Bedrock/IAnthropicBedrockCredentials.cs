namespace Anthropic.Bedrock;

public interface IAnthropicBedrockCredentials
{
    public string Region { get; }
    public void Apply(HttpRequestMessage requestMessage);

    public static IAnthropicBedrockCredentials? FromEnv()
    {
        const string ENV_API_KEY = "AWS_BEARER_TOKEN_BEDROCK";
        const string ENV_REGION = "AWS_REGION";

        var region = Environment.GetEnvironmentVariable(ENV_REGION); 
        // TODO according to the java sdk that uses the DefaultAwsRegionProviderChain there are a lot more possible ways to determine this
        // https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/regions/providers/DefaultAwsRegionProviderChain.html
        // Check if there is a simple C# alternative for this
        if (region is null)
        {
            return null;
        }

        var token = Environment.GetEnvironmentVariable(ENV_API_KEY);
        if (!string.IsNullOrWhiteSpace(token))
        {
            return new AnthropicBedrockApiTokenCredentials(token, region);
        }

        // TODO use DefaultCredentialsProvider from the C# SDK to get public/private keypair

        return null;
    }
}
