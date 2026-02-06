using Anthropic.Models.Messages;
using Anthropic.Vertex;
using Google.Apis.Auth.OAuth2;

// The google vertex client needs a Project ID, use the ID from the google cloud dashboard.
// The region parameter is optional.

// By default the Vertex Credential provider tries to load system wide credentials generated via the "gcloud" tool.
// For application wide credentials we recommend using service accounts instead and providing your own GoogleCredentials. Example:
/*
var client = new AnthropicVertexClient(new AnthropicVertexCredentials(null, "YourProjectId", GoogleCredential.FromJson(
"""
{
    ServiceAccount JSON
}
""").CreateScoped("https://www.googleapis.com/auth/cloud-platform")));
*/

// or you can load the credentials from your system after you set it with the necessary environment variables by calling
// var client = new AnthropicVertexClient(await DefaultAnthropicVertexCredentials.FromEnvAsync());

// The main variables you can set are below. There are more options available; consult the method's documentation for more info.
// <code>
// ANTHROPIC_VERTEX_PROJECT_ID=your_project_id
// CLOUD_ML_REGION=region_name
// VERTEX_ACCESS_TOKEN=vertex_access_token
// </code>

var client = new AnthropicVertexClient(new AnthropicVertexCredentials(null, "YourProjectId"));

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "claude-3-7-sonnet@20250219",
};

var response = await client.Messages.Create(parameters);

var message = string.Join(
    "",
    response
        .Content.Select(message => message.Value)
        .OfType<TextBlock>()
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
