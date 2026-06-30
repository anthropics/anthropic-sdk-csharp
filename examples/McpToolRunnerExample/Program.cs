using Anthropic;
using Anthropic.Helpers.Beta;
using Anthropic.Helpers.Beta.Mcp;
using Anthropic.Models.Beta.Messages;
using ModelContextProtocol.Client;
using Messages = Anthropic.Models.Messages;

// Example showing how to use MCP helpers with the tool runner.
//
// Connects to the remote GitHub MCP server over streamable HTTP, converts its tools to
// Anthropic-compatible runnable tools using BetaMcp.ListToolsAsync, and runs them in a
// BetaToolRunner loop.
//
// Prerequisites:
//   - Set the ANTHROPIC_API_KEY environment variable.
//   - Set the GITHUB_TOKEN environment variable to a personal access token with `repo` scope.

var anthropic = new AnthropicClient();

var githubToken =
    Environment.GetEnvironmentVariable("GITHUB_TOKEN")
    ?? throw new InvalidOperationException("GITHUB_TOKEN environment variable is required.");

await using var mcpClient = await McpClient.CreateAsync(
    new HttpClientTransport(
        new HttpClientTransportOptions
        {
            Endpoint = new Uri("https://api.githubcopilot.com/mcp/"),
            Name = "github",
            AdditionalHeaders = new Dictionary<string, string>
            {
                ["Authorization"] = $"Bearer {githubToken}",
            },
        }
    )
);

// Convert MCP tools into Anthropic-compatible runnable tools.
var tools = await BetaMcp.ListToolsAsync(mcpClient);

Console.WriteLine($"Connected to MCP server with {tools.Count} tools:");
foreach (var tool in tools)
{
    Console.WriteLine($"  - {tool.Name}");
}
Console.WriteLine();

var runner = anthropic.Beta.Messages.ToolRunner(
    new MessageCreateParams
    {
        Model = Messages::Model.ClaudeSonnet5,
        MaxTokens = 1024,
        Messages =
        [
            new BetaMessageParam
            {
                Role = Role.User,
                Content =
                    "List the 5 most recently opened issues in the github/github-mcp-server "
                    + "repository. For each, include the issue number, title, and who opened it.",
            },
        ],
    },
    tools
);

await foreach (var message in runner)
{
    Console.WriteLine(message);
}
