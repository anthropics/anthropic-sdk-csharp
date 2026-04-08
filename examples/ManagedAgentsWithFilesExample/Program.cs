using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Files;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

// Create an environment
var environment = await client.Beta.Environments.Create(
    new EnvironmentCreateParams { Name = "files-example-environment" }
);
Console.WriteLine($"Created environment: {environment.ID}");

// Create an agent with the built-in toolset and an always-allow permission policy
var agent = await client.Beta.Agents.Create(
    new AgentCreateParams
    {
        Name = "files-example-agent",
        Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
        Tools =
        [
            new BetaManagedAgentsAgentToolset20260401Params
            {
                Type = BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
                DefaultConfig = new BetaManagedAgentsAgentToolsetDefaultConfigParams
                {
                    Enabled = true,
                    PermissionPolicy = new BetaManagedAgentsAlwaysAllowPolicy
                    {
                        Type = BetaManagedAgentsAlwaysAllowPolicyType.AlwaysAllow,
                    },
                },
            },
        ],
    }
);
Console.WriteLine($"Created agent: {agent.ID}");

// Upload a file using the Files API
using var fileStream = File.OpenRead("data.csv");
var file = await client.Beta.Files.Upload(
    new FileUploadParams
    {
        File = new BinaryContent
        {
            Stream = fileStream,
            FileName = "data.csv",
            ContentType = new("text/csv"),
        },
    }
);
Console.WriteLine($"Uploaded file: {file.ID}");

// Create a session with the file mounted as a resource
var session = await client.Beta.Sessions.Create(
    new SessionCreateParams
    {
        Agent = agent.ID,
        EnvironmentID = environment.ID,
        Resources =
        [
            new BetaManagedAgentsFileResourceParams
            {
                Type = BetaManagedAgentsFileResourceParamsType.File,
                FileID = file.ID,
                MountPath = "data.csv",
            },
        ],
    }
);
Console.WriteLine($"Created session: {session.ID}");

var resources = await client.Beta.Sessions.Resources.List(session.ID);
Console.WriteLine(
    $"Listed session resources: [{string.Join(", ", resources.Items.Select(r => r.ID))}]"
);

// Send a prompt asking the agent to read the mounted file
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
                        Type = BetaManagedAgentsTextBlockType.Text,
                        Text = "Read /uploads/data.csv and tell me the column names.",
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
