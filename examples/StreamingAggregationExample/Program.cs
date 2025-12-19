using Anthropic;
using Anthropic.Helpers;
using Anthropic.Models.Messages;
using Anthropic.Services.Messages;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();

MessageCreateParams parameters = new()
{
    MaxTokens = 2048,
    Messages =
    [
        new() { Content = "Tell me a story about building the best SDK!", Role = Role.User },
    ],
    Model = Model.Claude4Sonnet20250514,
    Thinking = new ThinkingConfigEnabled() { BudgetTokens = 1024 },
};

IAsyncEnumerable<RawMessageStreamEvent> responseUpdates = client.Messages.CreateStreaming(
    parameters
);

// some streaming endpoints have build-in aggregators that create logically aggregated objects that represent the full stream as its counterpart single object.
var message = responseUpdates.Aggregate();

// you can also add an aggregator as part of your linq chain to get realtime streaming and aggregation

var aggregator = new MessageContentAggregator();
await foreach (RawMessageStreamEvent rawEvent in responseUpdates.CollectAsync(aggregator))
{
    // do something with the stream events
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

// and then get the full aggregated message
var fullMessage = responseUpdates.Aggregate();
