using Anthropic.Foundry;
using Anthropic.Models.Messages;

// Create a new AnthropicFoundryClient.
// The constructor accepts any IAnthropicFoundryCredentials implementation:
// - AnthropicFoundryApiKeyCredentials(apiKey, resourceName): adds an x-api-key header.
// - AnthropicFoundryBearerTokenCredentials(token, resourceName): sets Authorization: bearer token.
// - AnthropicFoundryIdentityTokenCredentials(AccessToken, resourceName): uses an Azure Identity access token.
// You can also obtain credentials from environment/Azure via DefaultAnthropicFoundryCredentials.FromEnv().
AnthropicFoundryClient client = new(
    new AnthropicFoundryApiKeyCredentials("API-TOKEN", "RESOURCE-NAME")
);

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "claude-sonnet-4-5",
};

var response = await client.Messages.Create(parameters);

var message = string.Join(
    "",
    response
        .Content.Where(message => message.Value is TextBlock)
        .Select(message => message.Value as TextBlock)
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
