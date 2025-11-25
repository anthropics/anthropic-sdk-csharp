namespace Anthropic.Bedrock;

public class AnthropicBedrockPrivateKeyCredentials : IAnthropicBedrockCredentials
{
    public AnthropicBedrockPrivateKeyCredentials(string apiKey, string apiAccessKey, string region)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey, nameof(apiKey));
        ArgumentException.ThrowIfNullOrWhiteSpace(apiAccessKey, nameof(apiAccessKey));
        ArgumentException.ThrowIfNullOrWhiteSpace(region, nameof(region));

        Region = region;
        ApiKey = apiKey;
        ApiAccessKey = apiAccessKey;
    }

    public string Region { get; private set; }

    public string ApiKey { get; private set; }

    public string ApiAccessKey { get; private set; }

    public void Apply(HttpRequestMessage requestMessage)
    {
        var now = DateTime.UtcNow;
        var amzDate = AWSSigner.ToAmzDate(now);
        var authorizationHeader = AWSSigner.GetAuthorizationHeader("bedrock", Region, "GET", requestMessage.RequestUri, now, ApiKey, ApiAccessKey);
        requestMessage.Headers.TryAddWithoutValidation("Host", requestMessage.RequestUri.Host);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-date", amzDate);
        requestMessage.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
    }
}
