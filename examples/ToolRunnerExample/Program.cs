using System.Text.Json;
using Anthropic;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

Console.WriteLine("=== Tool Runner Example ===\n");
Console.WriteLine("Ask: What's the weather in Paris right now, and how much is €100 in USD?\n");

// Define tool implementations using simple in-memory stubs.
var weatherTool = new BetaRunnableTool
{
    Name = "get_weather",
    Definition = new BetaTool
    {
        Name = "get_weather",
        Description = "Returns the current weather for a city.",
        InputSchema = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>
            {
                ["city"] = JsonSerializer.SerializeToElement(
                    new { type = "string", description = "City name" }
                ),
            },
            Required = ["city"],
        },
    },
    Run = (toolUse, _) =>
    {
        var city = toolUse.Input.TryGetValue("city", out var c) ? c.GetString() ?? "" : "";
        Console.WriteLine($"  [tool] get_weather(city={city})");
        var result = city.Equals("Paris", StringComparison.OrdinalIgnoreCase)
            ? "Partly cloudy, 18°C (64°F), light breeze from the west."
            : $"No weather data available for {city}.";
        return Task.FromResult<BetaToolResultBlockParamContent>(result);
    },
};

var currencyTool = new BetaRunnableTool
{
    Name = "convert_currency",
    Definition = new BetaTool
    {
        Name = "convert_currency",
        Description = "Converts an amount from one currency to another.",
        InputSchema = new InputSchema
        {
            Properties = new Dictionary<string, JsonElement>
            {
                ["amount"] = JsonSerializer.SerializeToElement(
                    new { type = "number", description = "Amount to convert" }
                ),
                ["from"] = JsonSerializer.SerializeToElement(
                    new { type = "string", description = "Source currency code, e.g. EUR" }
                ),
                ["to"] = JsonSerializer.SerializeToElement(
                    new { type = "string", description = "Target currency code, e.g. USD" }
                ),
            },
            Required = ["amount", "from", "to"],
        },
    },
    Run = (toolUse, _) =>
    {
        var amount = toolUse.Input.TryGetValue("amount", out var a) ? a.GetDouble() : 0;
        var from = toolUse.Input.TryGetValue("from", out var f) ? f.GetString() ?? "" : "";
        var to = toolUse.Input.TryGetValue("to", out var t) ? t.GetString() ?? "" : "";
        Console.WriteLine($"  [tool] convert_currency(amount={amount}, from={from}, to={to})");

        // Stub exchange rates
        var rates = new Dictionary<string, double> { ["EUR_USD"] = 1.08, ["USD_EUR"] = 0.93 };
        var key = $"{from}_{to}".ToUpperInvariant();
        var result = rates.TryGetValue(key, out var rate)
            ? $"{amount:F2} {from} = {amount * rate:F2} {to} (rate: {rate})"
            : $"No exchange rate available for {from} → {to}.";
        return Task.FromResult<BetaToolResultBlockParamContent>(result);
    },
};

// Create the tool runner. The runner handles the full conversation loop:
// model response → tool calls → tool results → model response → …
var runner = client.Beta.Messages.ToolRunner(
    new MessageCreateParams
    {
        Model = Anthropic.Models.Messages.Model.ClaudeSonnet4_5,
        MaxTokens = 1024,
        Messages =
        [
            new()
            {
                Role = Role.User,
                Content =
                    "What's the current weather in Paris, and how much is €100 in USD? "
                    + "Please use both tools to answer.",
            },
        ],
    },
    [weatherTool, currencyTool]
);

// Iterate over each turn. The runner yields one BetaMessage per API call so you
// can observe intermediate tool-use turns as well as the final response.
var turnIndex = 0;
await foreach (var message in runner)
{
    turnIndex++;
    Console.WriteLine($"\n--- Turn {turnIndex} (stop_reason: {message.StopReason}) ---");

    foreach (var block in message.Content)
    {
        if (block.TryPickText(out var text))
        {
            Console.WriteLine(text.Text);
        }
        else if (block.TryPickToolUse(out var toolUse))
        {
            Console.WriteLine(
                $"  → calling tool '{toolUse.Name}' with input: {JsonSerializer.Serialize(toolUse.Input)}"
            );
        }
    }
}

Console.WriteLine("\n=== Done ===");
