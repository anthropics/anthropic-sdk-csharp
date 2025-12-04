namespace Anthropic.Bedrock;

/// <summary>
/// Provides AWS private key-based credentials for authenticating requests to Amazon Bedrock's Anthropic models.
/// </summary>
/// <remarks>
/// This class implements the AWS Signature Version 4 signing process to authenticate HTTP requests
/// to Amazon Bedrock using AWS access key and secret key credentials. The credentials are applied
/// to each request by adding the necessary AWS authentication headers including the authorization
/// signature, date, and content hash.
/// </remarks>
public class AnthropicBedrockPrivateKeyCredentials : IAnthropicBedrockCredentials
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AnthropicBedrockPrivateKeyCredentials"/> class with the specified AWS credentials and region.
    /// </summary>
    /// <param name="apiSecret">The AWS secret access key used for authentication.</param>
    /// <param name="apiAccessKey">The AWS access key ID used for authentication.</param>
    /// <param name="region">The AWS region where the Bedrock service is hosted (e.g., "us-east-1").</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="apiSecret"/>, <paramref name="apiAccessKey"/>, or <paramref name="region"/> is null, empty, or contains only whitespace.
    /// </exception>
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

    /// <summary>
    /// Gets the Aws Region.
    /// </summary>
    public string Region { get; private init; }

    /// <summary>
    /// Gets the ApiSecret.
    /// </summary>
    public string ApiSecret { get; private init; }

    /// <summary>
    /// Gets the ApiKey.
    /// </summary>
    public string ApiAccessKey { get; private init; }

    // <inheritdoc />
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

        requestMessage.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
    }
}
