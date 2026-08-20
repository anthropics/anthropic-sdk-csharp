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

IAsyncEnumerable<RawMessageStreamEvent> responseUpdates = client.Messages.CreateStreaming(
    parameters
);

await foreach (RawMessageStreamEvent rawEvent in responseUpdates)
{
    if (rawEvent.TryPickContentBlockDelta(out var delta))
    {
        if (delta.Delta.TryPickThinking(out var thinkingDelta))
        {
            Console.Write(thinkingDelta.Thinking);
        }
        else if (delta.Delta.TryPickText(out var textDelta))
        {
            Console.Write(textDelta.Text);
        }
    }
}
