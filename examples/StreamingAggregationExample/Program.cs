using Anthropic;
using Anthropic.Helpers;
using Anthropic.Models.Messages;
using Anthropic.Services.Messages;

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

// Each CreateStreaming call sends one request. The returned IAsyncEnumerable is lazy: the request
// is sent when it is enumerated, and enumerating it a second time would send a second request.
IAsyncEnumerable<RawMessageStreamEvent> responseUpdates = client.Messages.CreateStreaming(
    parameters
);

// some streaming endpoints have built-in aggregators that create logically aggregated objects.
// these represent the full stream as a single object.
var message = await responseUpdates.Aggregate().ConfigureAwait(false);
Console.WriteLine(message);

// you can also add an aggregator as part of your LINQ chain to get real-time streaming and aggregation.
// This is a separate request, streamed through the aggregator as the events arrive.
var aggregator = new MessageContentAggregator();
IAsyncEnumerable<RawMessageStreamEvent> secondResponseUpdates = client.Messages.CreateStreaming(
    parameters
);
await foreach (RawMessageStreamEvent rawEvent in secondResponseUpdates.CollectAsync(aggregator))
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
Console.WriteLine();

// and then get the full aggregated message
var message2 = aggregator.Message();
Console.WriteLine(message2);
