using Anthropic;
using Anthropic.Helpers;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

// Streams a session with `event_deltas` enabled and folds the `event_start` /
// `event_delta` previews into agent.message snapshots with
// BetaManagedAgentsEventAggregator, printing the text as it arrives.

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

// Create an environment
var environment = await client.Beta.Environments.Create(
    new EnvironmentCreateParams { Name = "streaming-deltas-example-environment" }
);
Console.WriteLine($"Created environment: {environment.ID}");

// Create an agent
var agent = await client.Beta.Agents.Create(
    new AgentCreateParams
    {
        Name = "streaming-deltas-example-agent",
        Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
    }
);
Console.WriteLine($"Created agent: {agent.ID}");

// Create a session pinned to the agent
var session = await client.Beta.Sessions.Create(
    new SessionCreateParams { EnvironmentID = environment.ID, Agent = agent.ID }
);
Console.WriteLine($"Created session: {session.ID}");

// Send a user message
await client.Beta.Sessions.Events.Send(
    session.ID,
    new EventSendParams
    {
        Events =
        [
            new BetaManagedAgentsUserMessageEventParams
            {
                Type = BetaManagedAgentsUserMessageEventParamsType.UserMessage,
                Content =
                [
                    new BetaManagedAgentsTextBlock
                    {
                        Text = "Write a short haiku about the ocean.",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
            },
        ],
    }
);

// Open the event stream with `event_deltas` enabled so agent.message text
// arrives incrementally as `event_start` / `event_delta` previews before the
// buffered final event. CollectAsync feeds each event into the aggregator
// while mirroring the stream back to the loop.
Console.WriteLine("Streaming:");
var aggregator = new BetaManagedAgentsEventAggregator();
var stream = client.Beta.Sessions.Events.StreamStreaming(
    session.ID,
    new EventStreamParams { EventDeltas = [BetaManagedAgentsDeltaType.AgentMessage] }
);
await foreach (var events in stream.CollectAsync(aggregator))
{
    if (events.TryPickDeltaEvent(out var delta))
    {
        // Redraw the in-progress preview text as each fragment arrives.
        Console.Write($"\r{aggregator.TryGetAgentMessageText(delta.EventID) ?? ""}");
    }
    else if (events.TryPickAgentMessageEvent(out var message))
    {
        // The canonical event replaced the lossy preview in the aggregator.
        Console.WriteLine();
        Console.WriteLine($"[final] {aggregator.GetAgentMessageText(message.ID)}");
    }
    else if (events.TryPickSessionStatusIdleEvent(out _))
    {
        // The session is no longer doing work and the stream stays open, so
        // stop reading.
        break;
    }
    else if (events.TryPickSessionErrorEvent(out var error))
    {
        Console.Error.WriteLine($"[error] {error.Error}");
        break;
    }
}
