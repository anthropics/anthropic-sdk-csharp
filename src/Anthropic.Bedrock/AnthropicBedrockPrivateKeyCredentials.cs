namespace Anthropic.Bedrock;

public class AnthropicBedrockPrivateKeyCredentials : IAnthropicBedrockCredentials
{
    public AnthropicBedrockPrivateKeyCredentials(
        string apiSecret,
        string apiAccessKey,
        string region
    )
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiSecret, nameof(apiSecret));
        ArgumentException.ThrowIfNullOrWhiteSpace(apiAccessKey, nameof(apiAccessKey));
        ArgumentException.ThrowIfNullOrWhiteSpace(region, nameof(region));

        Region = region;
        ApiSecret = apiSecret;
        ApiAccessKey = apiAccessKey;
    }

    public string Region { get; private set; }

    public string ApiSecret { get; private set; }

    public string ApiAccessKey { get; private set; }

    public async Task Apply(HttpRequestMessage requestMessage)
    {
        var now = DateTime.UtcNow;
        var amzDate = AWSSigner.ToAmzDate(now);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-date", amzDate);
        var content = await requestMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
        var payloadHash = AWSSigner.CalculateHash(content);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-content-sha256", payloadHash);

        var authorizationHeader = AWSSigner.GetAuthorizationHeader(
            "bedrock",
            Region,
            requestMessage.Method.ToString(),
            requestMessage.RequestUri,
            now,
            requestMessage.Headers.ToDictionary(
                e => e.Key,
                e => string.Join(" ", e.Value),
                StringComparer.InvariantCultureIgnoreCase
            ),
            payloadHash,
            ApiAccessKey,
            ApiSecret
        );
        // requestMessage.Headers.TryAddWithoutValidation("Host", requestMessage.RequestUri.Host);
        requestMessage.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
    }
}
