using Anthropic;
using Microsoft.Extensions.AI;

// Configured using the ANTHROPIC_API_KEY, ANTHROPIC_AUTH_TOKEN and ANTHROPIC_BASE_URL environment variables
IChatClient chatClient = new AnthropicClient()
    .AsIChatClient("claude-haiku-4-5")
    .AsBuilder()
    .UseFunctionInvocation()
    .Build();

ChatOptions options = new()
{
    Tools =
    [
        AIFunctionFactory.Create(
            () => Environment.UserName,
            "get_current_user_name",
            "Gets the current user's name."
        ),
    ],
};

await foreach (
    var update in chatClient.GetStreamingResponseAsync(
        "Write a Haiku about the current user's name",
        options
    )
)
{
    Console.Write(update);
}
Console.WriteLine();
