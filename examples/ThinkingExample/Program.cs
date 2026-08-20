using Anthropic;
using Anthropic.Models.Messages;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();

MessageCreateParams parameters = new()
{
    MaxTokens = 16000,
    Messages =
    [
        new()
        {
            Content =
                "Create a haiku about Anthropic. Think carefully about syllable counts before answering.",
            Role = Role.User,
        },
    ],
    Model = Model.ClaudeSonnet5,
    Thinking = new ThinkingConfigAdaptive() { Display = Display.Summarized },
    OutputConfig = new OutputConfig() { Effort = Effort.High },
};

var response = await client.Messages.Create(parameters);

foreach (ContentBlock block in response.Content)
{
    if (block.TryPickThinking(out ThinkingBlock? thinking))
    {
        Console.WriteLine($"Thinking: {thinking.Thinking}");
    }
    else if (block.TryPickText(out TextBlock? text))
    {
        Console.WriteLine($"Text: {text.Text}");
    }
}

var message = string.Join(
    "",
    response.Content.Select(e => e.Value).OfType<TextBlock>().Select((textBlock) => textBlock.Text)
);

Console.WriteLine(message);
