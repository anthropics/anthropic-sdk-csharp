using Amazon.Runtime.Credentials.Internal;
using Anthropic.Bedrock;
using Anthropic.Models.Messages;

// Create a new AnthropicBedrockClient
// Options for the AnthropicBedrockClient constructor parameter (implements IAnthropicBedrockCredentials):

// - AnthropicBedrockApiTokenCredentials — bearer-token auth (sets Authorization: bearer <token>) plus Region.
// - AnthropicBedrockPrivateKeyCredentials — access-key/secret-key auth (for AWS-signed requests) plus Region.
// - AnthropicBedrockCredentialsHelper.FromEnv() — helper that returns either of the above by reading AWS env vars / default credential chain.
//      The CredentialsHelper tries to get the region and token from two enviorment variables:
//   - "AWS_BEARER_TOKEN_BEDROCK"
//   - "AWS_REGION"
//      if both of those are not set, it uses the Azure SDK to load system configuration as described here: https://learn.microsoft.com/en-us/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
// - Any custom type that implements IAnthropicBedrockCredentials — implement Region and Apply(HttpRequestMessage) for custom auth.
AnthropicBedrockClient client = new(
    await AnthropicBedrockCredentialsHelper.FromEnv().ConfigureAwait(false)
        ?? throw new InvalidOperationException("Your system is not properly configured.")
);
MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "global.anthropic.claude-haiku-4-5-20251001-v1:0",
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
