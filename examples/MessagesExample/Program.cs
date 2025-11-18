using System;
using Anthropic;
using Anthropic.Models.Messages;
using Anthropic.Foundry;


// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
IAnthropicClient client = new AnthropicClient();

// For using the Foundry client, use this instead
// AnthropicFoundryClient client = new(new AnthropicFoundryApiKeyCredentials("API-TOKEN", "RESOURCE-NAME"));

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = "claude-sonnet-45-2",
};

var response = await client.Messages.Create(parameters);

var message = String.Join(
    "",
    response
        .Content
        .Where(message => message.Value is TextBlock)
        .Select(message => message.Value as TextBlock)
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
