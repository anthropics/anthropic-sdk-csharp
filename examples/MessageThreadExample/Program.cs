using Anthropic;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
var client = new AnthropicClient();

// The thread keeps the history. The first turn creates a message thread, and each later turn
// sends only the messages that are new.
var thread = client.Beta.Messages.Thread(
    new()
    {
        Model = "claude-sonnet-5",
        MaxTokens = 2048,
        System = "You are a concise travel guide.",
        Messages = [],
    }
);

var reply = await thread.Send(
    new BetaUserMessageParam { Content = "Name one sight to see in Paris." }
);
Console.WriteLine(TextOf(reply));
Console.WriteLine($"The next turn continues from {thread.PreviousMessageID}.");

// A streamed turn is recorded on the thread when the stream reaches its end.
await foreach (
    var streamEvent in thread.SendStreaming(
        new BetaUserMessageParam { Content = "And one in Rome?" }
    )
)
{
    if (
        streamEvent.TryPickContentBlockDelta(out var delta) && delta.Delta.TryPickText(out var text)
    )
    {
        Console.Write(text.Text);
    }
}
Console.WriteLine();

// A fork starts a new thread from the same history and leaves this one untouched.
var fork = thread.Fork();
reply = await fork.Send(new BetaUserMessageParam { Content = "Which of the two is older?" });
Console.WriteLine(TextOf(reply));

Console.WriteLine($"The thread holds {thread.Messages.Count} messages.");
Console.WriteLine($"The fork holds {fork.Messages.Count} messages.");

// A thread created with a type asks for output that fits the type on every turn, and returns
// each reply with its text parsed.
var sights = client.Beta.Messages.Thread<Sight>(
    new()
    {
        Model = "claude-sonnet-5",
        MaxTokens = 2048,
        Messages = [],
    }
);
foreach (var city in new[] { "Paris", "Rome" })
{
    var sight = await sights.Send(
        new BetaUserMessageParam { Content = $"Name one sight to see in {city}." }
    );
    foreach (var parsed in sight.Content.Select(block => block.Parsed()).OfType<Sight>())
    {
        Console.WriteLine($"{parsed.Name}, built in {parsed.YearBuilt}");
    }
}

static string TextOf(BetaMessage message) =>
    string.Join(
        "",
        message.Content.Select(block => block.Value).OfType<BetaTextBlock>().Select(b => b.Text)
    );

class Sight
{
    public string Name { get; set; } = "";

    public int YearBuilt { get; set; }
}
