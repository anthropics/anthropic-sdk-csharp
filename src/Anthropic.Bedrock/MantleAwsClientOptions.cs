using Anthropic.Core;

namespace Anthropic.Bedrock;

/// <summary>
/// Configuration options for <see cref="AnthropicBedrockMantleClient"/>.
/// </summary>
/// <remarks>
/// <para>
/// Auth precedence (first match wins):
/// <list type="number">
///   <item><description><see cref="ApiKey"/> — Anthropic API key (<c>x-api-key</c> header)</description></item>
///   <item><description><see cref="AwsAccessKey"/> + <see cref="AwsSecretAccessKey"/> — explicit AWS SigV4 credentials</description></item>
///   <item><description><see cref="AwsProfile"/> — named AWS profile from credential store</description></item>
///   <item><description><c>AWS_BEARER_TOKEN_BEDROCK</c> env var (falls back to <c>ANTHROPIC_AWS_API_KEY</c>) — Anthropic API key</description></item>
///   <item><description>Default AWS credential chain (respects <c>AWS_PROFILE</c>, instance metadata, etc.) — SigV4</description></item>
/// </list>
/// </para>
///
/// <para>
/// Region resolution: <see cref="AwsRegion"/> → <c>AWS_REGION</c> → <c>AWS_DEFAULT_REGION</c> env vars.
/// </para>
///
/// <para>
/// Base URL resolution: <see cref="BaseUrl"/> → <c>ANTHROPIC_BEDROCK_MANTLE_BASE_URL</c> env var → <c>https://bedrock-mantle.{region}.api.aws/anthropic</c>.
/// </para>
///
/// <para>
/// <see cref="ApiKey"/> and <see cref="BaseUrl"/> overlap with properties on
/// <see cref="ClientOptions"/>. The mantle-level properties take precedence — they
/// feed into the resolution chains above and the constructor always overwrites the
/// corresponding <see cref="ClientOptions"/> values. Use <see cref="ClientOptions"/>
/// for SDK plumbing (<c>HttpClient</c>, <c>MaxRetries</c>, <c>Timeout</c>, etc.)
/// and set <see cref="ApiKey"/>/<see cref="BaseUrl"/> here for Bedrock Mantle configuration.
/// </para>
/// </remarks>
public sealed class MantleAwsClientOptions
{
    /// <summary>
    /// Anthropic API key. When set, bypasses SigV4 and uses the <c>x-api-key</c> header.
    /// Takes precedence over <see cref="ClientOptions"/>.<see cref="Core.ClientOptions.ApiKey"/>.
    /// </summary>
    public string? ApiKey { get; init; }

    /// <summary>
    /// AWS access key ID for explicit SigV4 credentials.
    /// </summary>
    public string? AwsAccessKey { get; init; }

    /// <summary>
    /// AWS secret access key for explicit SigV4 credentials.
    /// </summary>
    public string? AwsSecretAccessKey { get; init; }

    /// <summary>
    /// Optional AWS session token for temporary SigV4 credentials.
    /// </summary>
    public string? AwsSessionToken { get; init; }

    /// <summary>
    /// Named AWS profile from AWS credentials/config files.
    /// </summary>
    public string? AwsProfile { get; init; }

    /// <summary>
    /// AWS region (e.g. <c>us-east-1</c>). Falls back to <c>AWS_REGION</c> then <c>AWS_DEFAULT_REGION</c> env vars.
    /// </summary>
    public string? AwsRegion { get; init; }

    /// <summary>
    /// When <c>true</c>, all authentication is disabled. Use when requests go through
    /// a gateway or proxy that handles authentication.
    /// </summary>
    public bool SkipAuth { get; init; }

    /// <summary>
    /// Override the base URL. Falls back to <c>ANTHROPIC_BEDROCK_MANTLE_BASE_URL</c> env var,
    /// then derived from <see cref="AwsRegion"/>.
    /// Takes precedence over <see cref="ClientOptions"/>.<see cref="Core.ClientOptions.BaseUrl"/>.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Additional SDK client options (<c>HttpClient</c>, <c>MaxRetries</c>, <c>Timeout</c>, etc.).
    /// <see cref="ApiKey"/> and <see cref="BaseUrl"/> on this type take precedence over
    /// the corresponding properties on <see cref="Core.ClientOptions"/>.
    /// </summary>
    public ClientOptions ClientOptions { get; init; } = new();

    // Internally resolved — not user-facing.
    internal string ServiceName { get; init; } = "bedrock-mantle";
    internal bool UseSigV4 { get; init; }

    /// <summary>
    /// The resolved API key for Bearer token authentication. Set internally when
    /// API key mode is active (not SigV4). Sent as <c>Authorization: Bearer</c>.
    /// </summary>
    internal string? ResolvedApiKey { get; init; }
}
