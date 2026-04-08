using Anthropic;
using Anthropic.Core;
using Anthropic.Models.Beta.Agents;
using Anthropic.Models.Beta.Environments;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;
using Anthropic.Models.Beta.Skills;
using Anthropic.Models.Beta.Vaults;
using Anthropic.Models.Beta.Vaults.Credentials;

var mcpServerName = "github";
var mcpServerUrl = "https://api.githubcopilot.com/mcp/";

var prompt =
    "Hi! List every tool and skill you have access to, grouped by where they "
    + "came from (built-in toolset, custom tool, MCP server, skills).";

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

var githubToken =
    Environment.GetEnvironmentVariable("GITHUB_TOKEN")
    ?? throw new InvalidOperationException(
        "GITHUB_TOKEN is required (use a fine-grained PAT with public-repo read only)"
    );

// Create an environment
var environment = await client.Beta.Environments.Create(
    new EnvironmentCreateParams { Name = "comprehensive-example-environment" }
);
Console.WriteLine($"Created environment: {environment.ID}");

// Create a vault and store the MCP server credential in it
var vault = await client.Beta.Vaults.Create(
    new VaultCreateParams { DisplayName = "comprehensive-example-vault" }
);
Console.WriteLine($"Created vault: {vault.ID}");

var credential = await client.Beta.Vaults.Credentials.Create(
    vault.ID,
    new CredentialCreateParams
    {
        Auth = new BetaManagedAgentsStaticBearerCreateParams
        {
            Type = BetaManagedAgentsStaticBearerCreateParamsType.StaticBearer,
            McpServerUrl = mcpServerUrl,
            Token = githubToken,
        },
        DisplayName = "github-mcp",
    }
);
Console.WriteLine($"Created credential: {credential.ID}");

// Upload a custom skill
var skillTitle = $"comprehensive-greeting-{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
using var skillStream = File.OpenRead("greeting-SKILL.md");
var skill = await client.Beta.Skills.Create(
    new SkillCreateParams
    {
        DisplayTitle = skillTitle,
        Files =
        [
            new BinaryContent
            {
                Stream = skillStream,
                FileName = "greeting/SKILL.md",
                ContentType = new("text/markdown"),
            },
        ],
    }
);
Console.WriteLine($"Created skill: {skill.ID}");

// Create v1 of the agent with the built-in toolset, an MCP server, and a custom tool
var agentV1 = await client.Beta.Agents.Create(
    new AgentCreateParams
    {
        Name = "comprehensive-example-agent",
        Model = BetaManagedAgentsModel.ClaudeSonnet4_6,
        System = "You are a helpful assistant.",
        McpServers =
        [
            new BetaManagedAgentsUrlMcpServerParams
            {
                Type = BetaManagedAgentsUrlMcpServerParamsType.Url,
                Name = mcpServerName,
                Url = mcpServerUrl,
            },
        ],
        Tools =
        [
            new BetaManagedAgentsAgentToolset20260401Params
            {
                Type = BetaManagedAgentsAgentToolset20260401ParamsType.AgentToolset20260401,
            },
            new BetaManagedAgentsMcpToolsetParams
            {
                Type = BetaManagedAgentsMcpToolsetParamsType.McpToolset,
                McpServerName = mcpServerName,
            },
            new BetaManagedAgentsCustomToolParams
            {
                Type = BetaManagedAgentsCustomToolParamsType.Custom,
                Name = "get_weather",
                Description = "Look up the current weather for a city.",
                InputSchema = new BetaManagedAgentsCustomToolInputSchema
                {
                    Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
                    Properties = new Dictionary<string, System.Text.Json.JsonElement>
                    {
                        ["city"] = System.Text.Json.JsonSerializer.SerializeToElement(
                            new { type = "string" }
                        ),
                    },
                    Required = ["city"],
                },
            },
        ],
    }
);
Console.WriteLine($"Created agent v1: {agentV1.ID}");

// Patch the agent to v2 by adding skills; each update bumps the version
var agent = await client.Beta.Agents.Update(
    agentV1.ID,
    new AgentUpdateParams
    {
        Version = agentV1.Version,
        Skills =
        [
            new BetaManagedAgentsCustomSkillParams
            {
                Type = BetaManagedAgentsCustomSkillParamsType.Custom,
                SkillID = skill.ID,
            },
            new BetaManagedAgentsAnthropicSkillParams
            {
                Type = BetaManagedAgentsAnthropicSkillParamsType.Anthropic,
                SkillID = "xlsx",
            },
        ],
    }
);
Console.WriteLine($"Patched agent to v2: {agent.ID}");

var versions = await client.Beta.Agents.Versions.List(agentV1.ID);
Console.WriteLine($"Agent versions: [{string.Join(", ", versions.Items.Select(v => v.Version))}]");

// Create a session pinned to v2; the vault supplies the MCP credential
var session = await client.Beta.Sessions.Create(
    new SessionCreateParams
    {
        Agent = new BetaManagedAgentsAgentParams
        {
            Type = global::Anthropic.Models.Beta.Sessions.Type.Agent,
            ID = agent.ID,
            Version = agent.Version,
        },
        EnvironmentID = environment.ID,
        VaultIds = [vault.ID],
    }
);
Console.WriteLine($"Created session: {session.ID}");

// Send a prompt and stream events, answering the custom tool if called
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
                        Text = prompt,
                    },
                ],
            },
        ],
    }
);

Console.WriteLine("Streaming events:");
await foreach (var streamEvent in client.Beta.Sessions.Events.StreamStreaming(session.ID))
{
    Console.WriteLine(streamEvent);

    if (
        streamEvent.TryPickAgentCustomToolUseEvent(out var toolUse)
        && toolUse.Name == "get_weather"
    )
    {
        await client.Beta.Sessions.Events.Send(
            session.ID,
            new EventSendParams
            {
                Events =
                [
                    new BetaManagedAgentsUserCustomToolResultEventParams
                    {
                        Type =
                            BetaManagedAgentsUserCustomToolResultEventParamsType.UserCustomToolResult,
                        CustomToolUseID = toolUse.ID,
                        Content =
                        [
                            new BetaManagedAgentsTextBlock
                            {
                                Type = BetaManagedAgentsTextBlockType.Text,
                                Text = "{\"temperature_c\": 14}",
                            },
                        ],
                    },
                ],
            }
        );
    }

    if (
        streamEvent.TryPickSessionStatusIdleEvent(out var idleEvent)
        && idleEvent.StopReason.TryPickBetaManagedAgentsSessionEndTurn(out var _)
    )
    {
        break;
    }
}
