using Anthropic.Bedrock;
using Anthropic.Models.Messages;

// Create a new AnthropicBedrockClient
// Options for the AnthropicBedrockClient constructor parameter (implements IAnthropicBedrockCredentials):

// - AnthropicBedrockApiTokenCredentials — bearer-token auth (sets Authorization: bearer <token>) plus Region.
// - AnthropicBedrockPrivateKeyCredentials — access-key/secret-key auth (for AWS-signed requests) plus Region.
// - AnthropicBedrockCredentialsHelper.FromEnv() — helper that returns either of the above by reading AWS env vars / default credential chain.
// - Any custom type that implements IAnthropicBedrockCredentials — implement Region and Apply(HttpRequestMessage) for custom auth.
AnthropicBedrockClient client = new(
    new AnthropicBedrockApiTokenCredentials() { BearerToken = "API-TOKEN", Region = "REGION-NAME" }
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
