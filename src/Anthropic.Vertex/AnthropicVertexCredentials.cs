using Google.Apis.Auth.OAuth2;

namespace Anthropic.Vertex;

/// <summary>
/// Defines methods to authenticate with vertex services using the <see cref="GoogleCredential"/> api.
/// </summary>
public class AnthropicVertexCredentials : IAnthropicVertexCredentials
{
    private readonly GoogleCredential _googleCredentials;

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicVertexCredentials"/> using the environment provided google authentication methods.
    /// </summary>
    /// <param name="region">The region string for the project or <c>null</c> for global.</param>
    /// <param name="project">The project string.</param>
    public AnthropicVertexCredentials(string? region, string project)
        : this(region, project, GoogleCredential.GetApplicationDefault()) { }

    /// <summary>
    /// Creates a new instance of the <see cref="AnthropicVertexCredentials"/>.
    /// </summary>
    /// <param name="region">The region string for the project or <c>null</c> for global.</param>
    /// <param name="project">The project string.</param>
    /// <param name="googleCredential">The authentication method.</param>
    public AnthropicVertexCredentials(
        string? region,
        string project,
        GoogleCredential googleCredential
    )
    {
        Region = region ?? "global";
        Project = project;
        _googleCredentials = googleCredential;
    }

    /// <inheritdoc/>
    public string Region { get; }

    /// <inheritdoc/>
    public string Project { get; }

    /// <inheritdoc/>
    public async ValueTask ApplyAsync(HttpRequestMessage requestMessage)
    {
        var token = await _googleCredentials
            .UnderlyingCredential.GetAccessTokenForRequestAsync()
            .ConfigureAwait(false);
        requestMessage.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    }
}
