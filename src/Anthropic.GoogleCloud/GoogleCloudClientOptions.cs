using Anthropic.Core;
using Google.Apis.Auth.OAuth2;

namespace Anthropic.GoogleCloud;

/// <summary>
/// Configuration options for <see cref="AnthropicGoogleCloudClient"/>.
/// </summary>
/// <remarks>
/// <para>
/// Credential precedence (first match wins; ignored when <see cref="SkipAuth"/> is set):
/// <list type="number">
///   <item><description><see cref="TokenProvider"/> — caller-supplied access-token callback</description></item>
///   <item><description><see cref="GoogleCredential"/> — explicit Google credential</description></item>
///   <item><description>Application Default Credentials (cloud-platform scope)</description></item>
/// </list>
/// </para>
///
/// <para>
/// Project resolution: <see cref="Project"/> → <c>ANTHROPIC_GOOGLE_CLOUD_PROJECT</c> →
/// <c>GOOGLE_CLOUD_PROJECT</c> env vars → project reported by Application Default Credentials
/// (where the credential type carries one).
/// </para>
///
/// <para>
/// Location resolution: <see cref="Location"/> → <c>ANTHROPIC_GOOGLE_CLOUD_LOCATION</c> env var →
/// <c>global</c>.
/// </para>
///
/// <para>
/// Base URL resolution: <see cref="BaseUrl"/> → <c>ANTHROPIC_GOOGLE_CLOUD_BASE_URL</c> env var →
/// derived from project, location, and workspace ID.
/// </para>
///
/// <para>
/// Workspace ID: <see cref="WorkspaceId"/> → <c>ANTHROPIC_GOOGLE_CLOUD_WORKSPACE_ID</c> env var.
/// Required unless <see cref="SkipAuth"/> is set together with an explicit <see cref="BaseUrl"/>.
/// </para>
///
/// <para>
/// First-party Anthropic configuration (<c>ANTHROPIC_API_KEY</c>, <c>ANTHROPIC_AUTH_TOKEN</c>,
/// <c>ANTHROPIC_BASE_URL</c>, the credentials-file chain) is never consulted by this client.
/// Use <see cref="ClientOptions"/> for SDK plumbing only (<c>HttpClient</c>, <c>MaxRetries</c>,
/// <c>Timeout</c>, <c>Handlers</c>, etc.).
/// </para>
/// </remarks>
public sealed class GoogleCloudClientOptions
{
    /// <summary>
    /// GCP consumer project ID.
    /// </summary>
    public string? Project { get; init; }

    /// <summary>
    /// GCP location. Defaults to <c>global</c>.
    /// </summary>
    public string? Location { get; init; }

    /// <summary>
    /// Anthropic workspace ID.
    /// </summary>
    public string? WorkspaceId { get; init; }

    /// <summary>
    /// Override the gateway base URL.
    /// </summary>
    public string? BaseUrl { get; init; }

    /// <summary>
    /// Explicit Google credential. When set, Application Default Credentials are not consulted.
    /// </summary>
    public GoogleCredential? GoogleCredential { get; init; }

    /// <summary>
    /// Caller-supplied access-token callback. Invoked once per request; the caller is
    /// responsible for caching and refresh. Takes precedence over
    /// <see cref="GoogleCredential"/>.
    /// </summary>
    public Func<CancellationToken, Task<string>>? TokenProvider { get; init; }

    /// <summary>
    /// When <c>true</c>, all authentication is disabled — no bearer token is attached.
    /// Use when requests go through a gateway or proxy that handles authentication.
    /// A workspace ID is still required to derive the base URL unless
    /// <see cref="BaseUrl"/> is set explicitly. Mutually exclusive with
    /// <see cref="TokenProvider"/> and <see cref="GoogleCredential"/>.
    /// </summary>
    public bool SkipAuth { get; init; }

    /// <summary>
    /// Additional SDK client options (<c>HttpClient</c>, <c>MaxRetries</c>, <c>Timeout</c>,
    /// <c>Handlers</c>, etc.). <c>ApiKey</c>, <c>AuthToken</c>, and <c>BaseUrl</c> on this
    /// type are ignored — the Google Cloud client never sends first-party Anthropic
    /// credentials.
    /// </summary>
    public ClientOptions ClientOptions { get; init; } = new();
}
