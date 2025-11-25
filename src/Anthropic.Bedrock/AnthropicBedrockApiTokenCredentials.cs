namespace Anthropic.Bedrock;

public class AnthropicBedrockApiTokenCredentials : IAnthropicBedrockCredentials
{
    public AnthropicBedrockApiTokenCredentials(string bearerToken, string region)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(bearerToken, nameof(bearerToken));
        ArgumentException.ThrowIfNullOrWhiteSpace(region, nameof(region));

        BearerToken = bearerToken;
        Region = region;                
    }

    public string BearerToken { get; private set; }

    public string Region { get; private set; }

    public void Apply(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", BearerToken);
    }
}
