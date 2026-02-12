using Google.Apis.Auth.OAuth2;

namespace Anthropic.Vertex;

/// <summary>
/// Defines methods for authenticating requests to the vertex api.
/// </summary>
public interface IAnthropicVertexCredentials
{
    /// <summary>
    /// Gets the Region on the Project.
    /// </summary>
    string Region { get; }

    /// <summary>
    /// Gets the Project name.
    /// </summary>
    string Project { get; }

    /// <summary>
    /// Applies the authentication method to the request.
    /// </summary>
    /// <param name="requestMessage">The http Request message object.</param>
    /// <returns>A value task that is resolved when the authentication has been applied to the request message.</returns>
    ValueTask ApplyAsync(HttpRequestMessage requestMessage);

#if NET8_0_OR_GREATER
    public static async Task<IAnthropicVertexCredentials?> FromEnvAsync()
    {
        return await DefaultAnthropicVertexCredentials.FromEnvAsync().ConfigureAwait(false);
    }
#endif
}

public static class DefaultAnthropicVertexCredentials
{
    /// <summary>
    /// Creates a new instance of <see cref="IAnthropicVertexCredentials"/> from environment variables.
    /// </summary>
    /// <remarks>
    /// Set the following environment variables:
    /// <code>
    /// ANTHROPIC_VERTEX_PROJECT_ID=your_project_id
    /// CLOUD_ML_REGION=region_name
    /// VERTEX_ACCESS_TOKEN=vertex_access_token
    /// </code>
    /// The <c>CLOUD_ML_REGION</c> environment variable is optional and if not set will fallback to <c>global</c>.
    /// The <c>VERTEX_ACCESS_TOKEN</c> environment variable is optional and if unset the google system checks will be performed to obtain a valid set of credentials. See: https://docs.cloud.google.com/docs/authentication/application-default-credentials
    /// </remarks>
    /// <returns>A new instance of an <see cref="IAnthropicVertexCredentials"/> or <c>null</c> if it cannot be loaded from environment variables</returns>
    public static async ValueTask<IAnthropicVertexCredentials?> FromEnvAsync()
    {
        var projId = Environment.GetEnvironmentVariable("ANTHROPIC_VERTEX_PROJECT_ID");
        var region = Environment.GetEnvironmentVariable("CLOUD_ML_REGION");
        var accessToken = Environment.GetEnvironmentVariable("VERTEX_ACCESS_TOKEN");

        if (projId is null)
        {
            return null;
        }

        region ??= "global";

        var credentials = accessToken is null
            ? GoogleCredential.FromAccessToken(accessToken)
            : await GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);

        if (credentials.UnderlyingCredential is null)
        {
            return null;
        }

        return new AnthropicVertexCredentials(region, projId, credentials);
    }
}
