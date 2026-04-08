using Anthropic;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

// Create an environment
var environment = await client.Beta.Environments.Create(
    new EnvironmentCreateParams { Name = "simple-example-environment" }
);
Console.WriteLine($"Created environment: {environment.ID}");

// Create an agent
var agent = await client.Beta.Agents.Create(
    new AgentCreateParams
    {
        Name = "simple-example-agent",
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
                        Text = "Hello Claude!",
                        Type = BetaManagedAgentsTextBlockType.Text,
                    },
                ],
            },
        ],
    }
);

// Stream events until the session goes idle
Console.WriteLine("Streaming events:");
await foreach (var streamEvent in client.Beta.Sessions.Events.StreamStreaming(session.ID))
{
    Console.WriteLine(streamEvent);
    if (streamEvent.TryPickSessionStatusIdleEvent(out var _))
    {
        break;
    }
}
