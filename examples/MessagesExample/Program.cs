using Anthropic;
using Anthropic.Models.Messages;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
var client = new AnthropicClient();

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
        .Content.Select(message => message.Value)
        .OfType<TextBlock>()
        .Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
