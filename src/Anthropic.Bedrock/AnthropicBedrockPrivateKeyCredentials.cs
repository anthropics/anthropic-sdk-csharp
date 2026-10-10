using System.Diagnostics.CodeAnalysis;

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
public sealed class AnthropicBedrockPrivateKeyCredentials : IAnthropicBedrockCredentials
{
    /// <summary>
    /// Gets the Aws Region.
    /// </summary>
    public required string Region { get; init; }

    /// <summary>
    /// Gets the ApiSecret.
    /// </summary>
    public required string ApiSecret { get; init; }

    /// <summary>
    /// Gets the ApiKey.
    /// </summary>
    public required string ApiAccessKey { get; init; }

    /// <inheritdoc />
    public async Task Apply(HttpRequestMessage requestMessage)
    {
        var now = DateTime.UtcNow;
        var amzDate = AWSSigner.ToAmzDate(now);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-date", amzDate);
        var content = await requestMessage.Content!.ReadAsStringAsync().ConfigureAwait(false);
        var payloadHash = AWSSigner.CalculateHash(content);
        requestMessage.Headers.TryAddWithoutValidation("x-amz-content-sha256", payloadHash);

        // Collapse any multi-value request headers (e.g. anthropic-beta when several betas are
        // supplied) to a single comma-joined value before signing AND sending. HttpClient
        // serializes multi-value headers with ", " on the wire, which would not match the
        // canonical request and cause a SigV4 signature mismatch. By mutating the message
        // headers here, the signed bytes and the wire bytes agree.
        foreach (var header in requestMessage.Headers.ToList())
        {
            var values = header.Value.ToList();
            if (values.Count > 1)
            {
                requestMessage.Headers.Remove(header.Key);
                requestMessage.Headers.TryAddWithoutValidation(
                    header.Key,
                    string.Join(",", values)
                );
            }
        }

        var authorizationHeader = AWSSigner.GetAuthorizationHeader(
            "bedrock",
            Region,
            requestMessage.Method.ToString(),
            requestMessage.RequestUri!,
            now,
            requestMessage.Headers.ToDictionary(
                e => e.Key,
                e => string.Join(",", e.Value),
                StringComparer.InvariantCultureIgnoreCase
            ),
            payloadHash,
            ApiAccessKey,
            ApiSecret
        );

        requestMessage.Headers.TryAddWithoutValidation("Authorization", authorizationHeader);
    }
}
