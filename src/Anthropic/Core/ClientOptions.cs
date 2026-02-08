using System;
using System.Net.Http;

namespace Anthropic.Core;

/// <summary>
/// A class representing the SDK client configuration.
/// </summary>
public record struct ClientOptions()
{
    /// <summary>
    /// The default value used for <see cref="MaxRetries"/>.
    /// </summary>
    public static readonly int DefaultMaxRetries = 2;

    /// <summary>
    /// The default value used for <see cref="Timeout"/>.
    /// </summary>
    public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMinutes(10);

    /// <summary>
    /// The HTTP client to use for making requests in the SDK.
    /// </summary>
    public HttpClient HttpClient { get; set; } = new();

    Lazy<string> _baseUrl = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_BASE_URL") ?? EnvironmentUrl.Production
    );

    /// <summary>
    /// The base URL to use for every request.
    ///
    /// <para>Defaults to the production environment: <see cref="EnvironmentUrl.Production"/></para>
    /// </summary>
    public string BaseUrl
    {
        readonly get { return _baseUrl.Value; }
        set { _baseUrl = new(() => value); }
    }

    /// <summary>
    /// Whether to validate response bodies before returning them.
    ///
    /// <para>Defaults to false, which means the shape of the response body will not be validated upfront.
    /// Instead, validation will only occur for the parts of the response body that are accessed.</para>
    ///
    /// <para>Note that when set to true, the response body is only validated if the response is
    /// deserialized. Methods that don't eagerly deserialize the response, such as those on
    /// <see cref="IAnthropicClient.WithRawResponse"/>, don't perform validation until deserialization
    /// is triggered.</para>
    /// </summary>
    public bool ResponseValidation { get; set; } = false;

    /// <summary>
    /// The maximum number of times to retry failed requests, with a short exponential backoff between requests.
    ///
    /// <para>
    /// Only the following error types are retried:
    /// <list type="bullet">
    ///   <item>Connection errors (for example, due to a network connectivity problem)</item>
    ///   <item>408 Request Timeout</item>
    ///   <item>409 Conflict</item>
    ///   <item>429 Rate Limit</item>
    ///   <item>5xx Internal</item>
    /// </list>
    /// </para>
    ///
    /// <para>The API may also explicitly instruct the SDK to retry or not retry a request.</para>
    ///
    /// <para>Defaults to 2 when null. Set to 0 to
    /// disable retries, which also ignores API instructions to retry.</para>
    /// </summary>
    public int? MaxRetries { get; set; }

    /// <summary>
    /// Sets the maximum time allowed for a complete HTTP call, not including retries.
    ///
    /// <para>This includes resolving DNS, connecting, writing the request body, server processing, as
    /// well as reading the response body.</para>
    ///
    /// <para>Defaults to <c>TimeSpan.FromMinutes(10)</c> when null.</para>
    /// </summary>
    public TimeSpan? Timeout { get; set; }

    Lazy<string?> _apiKey = new(() => Environment.GetEnvironmentVariable("ANTHROPIC_API_KEY"));
    public string? ApiKey
    {
        readonly get { return _apiKey.Value; }
        set { _apiKey = new(() => value); }
    }

    Lazy<string?> _authToken = new(() =>
        Environment.GetEnvironmentVariable("ANTHROPIC_AUTH_TOKEN")
    );
    public string? AuthToken
    {
        readonly get { return _authToken.Value; }
        set { _authToken = new(() => value); }
    }

    internal static TimeSpan TimeoutFromMaxTokens(
        long maxTokens,
        bool isStreaming,
        string? model = null
    )
    {
        // Check model-specific token limits for non-streaming requests
        long? maxNonStreamingTokens = null;

        if (model != null)
        {
            maxNonStreamingTokens = model switch
            {
                "claude-opus-4-20250514" => 8_192,
                "claude-4-opus-20250514" => 8_192,
                "claude-opus-4-0" => 8_192,
                "anthropic.claude-opus-4-20250514-v1:0" => 8_192,
                "claude-opus-4@20250514" => 8_192,
                "claude-opus-4-1-20250805" => 8_192,
                "anthropic.claude-opus-4-1-20250805-v1:0" => 8_192,
                "claude-opus-4-1@20250805" => 8_192,
                _ => null,
            };
        }
        var exceedsModelLimit = maxNonStreamingTokens != null && maxTokens > maxNonStreamingTokens;

        long timeoutSeconds;
        if (isStreaming)
        {
            timeoutSeconds = Math.Min(
                60 * 60, // 1 hour maximum
                Math.Max(
                    10 * 60, // 10 minute minimum
                    60 * 60 * maxTokens / 128_000
                )
            );
        }
        else
        {
            timeoutSeconds = Math.Min(
                10 * 60, // 10 minute maximum
                Math.Max(
                    30, // 30 second minimum
                    30 * maxTokens / 1000
                )
            );
        }

        if (!isStreaming && (exceedsModelLimit || timeoutSeconds > 10 * 60)) // 10 minutes
        {
            throw new ArgumentOutOfRangeException(
                nameof(maxTokens),
                "Streaming is required for operations that may take longer than 10 minutes. "
                    + "For more information, see https://github.com/anthropics/anthropic-sdk-csharp#streaming"
            );
        }

        return TimeSpan.FromSeconds(timeoutSeconds);
    }
}
