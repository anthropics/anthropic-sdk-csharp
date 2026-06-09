// An example of falling back to substitute models when a request is refused: server-side
// `fallbacks` (preferred) and the client-side BetaRefusalFallbackHandler for providers that
// don't support them.

using Anthropic;
using Anthropic.Helpers;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Messages;
using Messages = Anthropic.Models.Messages;

// 1. Server-side fallbacks (preferred): the API retries a refusal itself — one request, a
// plain client, no client-side logic. Use this when talking to the API directly.
//
// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
AnthropicClient client = new();
BetaMessage served = await client.Beta.Messages.Create(
    new()
    {
        Model = Messages::Model.ClaudeFable5,
        MaxTokens = 1024,
        Messages = [new() { Content = "Some prompt that triggers a refusal", Role = Role.User }],
        Fallbacks = [new(Messages::Model.ClaudeOpus4_8)],
        Betas = [AnthropicBeta.ServerSideFallback2026_06_01],
    }
);
Console.WriteLine($"server-side, served by: {served.Model.Raw()}");

// If your provider doesn't support server-side fallbacks, register the client-side handler
// instead:
AnthropicClient fallbackClient = new()
{
    Handlers =
    [
        new BetaRefusalFallbackHandler { Fallbacks = [new(Messages::Model.ClaudeOpus4_8)] },
    ],
};

// Pins follow-ups to the model that accepted.
BetaFallbackState fallbackState = BetaFallbackState.Create();

// 2. Streaming: on a refusal the handler retries and splices the fallback's events onto the
// open stream — one continuous message, with a `fallback` content block marking the model
// boundary.
BetaMessageContentAggregator aggregator = new();
using (fallbackState.Use())
{
    var responseUpdates = fallbackClient.Beta.Messages.CreateStreaming(
        new()
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 1024,
            Messages =
            [
                new() { Content = "Some prompt that triggers a refusal", Role = Role.User },
            ],
        }
    );
    await foreach (BetaRawMessageStreamEvent rawEvent in responseUpdates.CollectAsync(aggregator))
    {
        // Text streams continuously across the model boundary.
        if (
            rawEvent.TryPickContentBlockDelta(out var deltaEvent)
            && deltaEvent.Delta.TryPickText(out var textDelta)
        )
        {
            Console.Write(textDelta.Text);
        }
        if (
            rawEvent.TryPickContentBlockStart(out var startEvent)
            && startEvent.ContentBlock.TryPickBetaFallback(out var fallback)
        )
        {
            Console.WriteLine(
                $"\n--- fell back: {fallback.From.Model.Raw()} -> {fallback.To.Model.Raw()} ---"
            );
        }
    }
}
Console.WriteLine($"\nstreaming, served by: {aggregator.Message().Model.Raw()}");

// 3. Non-streaming: same handler, the retry just happens before you get the message back.
BetaMessage message;

// Reusing the state keeps the conversation pinned.
using (fallbackState.Use())
{
    message = await fallbackClient.Beta.Messages.Create(
        new()
        {
            Model = Messages::Model.ClaudeFable5,
            MaxTokens = 1024,
            Messages =
            [
                new() { Content = "Some prompt that triggers a refusal", Role = Role.User },
            ],
        }
    );
}
Console.WriteLine($"non-streaming, served by: {message.Model.Raw()}");
