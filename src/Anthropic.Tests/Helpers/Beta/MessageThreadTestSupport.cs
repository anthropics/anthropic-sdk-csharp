using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Nodes;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;

namespace Anthropic.Tests.Helpers.Beta;

/// <summary>What the tests of the message thread and of the tool runner over one share.</summary>
static class MessageThreadTestSupport
{
    public const string ThreadsBeta = "message-threads-2026-08-12";

    public const string FallbackBeta = "server-side-fallback-2026-07-01";

    public const string FallbackModel = "claude-haiku-4-5";

    public static AnthropicClient Client(FakeTransport transport) =>
        new()
        {
            HttpClient = new HttpClient(transport),
            ApiKey = "test-key",
            BaseUrl = "http://localhost",
            MaxRetries = 0,
        };

    public static IMessageService Messages(FakeTransport transport) =>
        Client(transport).Beta.Messages;

    public static BetaMessageParam User(string text) => new BetaUserMessageParam { Content = text };

    public static MessageCreateParams WithThread(MessageCreateParams parameters, string type) =>
        parameters with
        {
            Thread =
                type == "create"
                    ? new BetaThreadCreateParams()
                    : new BetaThreadContinueParams { PreviousMessageID = "msg_of_the_callers" },
        };

    /// <summary>The <c>usage.iterations</c> of a reply that <see cref="FallbackModel"/> wrote.</summary>
    public static JsonArray FallbackIterations(string requestedModel) =>
        [Iteration("fallback_message", FallbackModel), Iteration("message", requestedModel)];

    public static JsonObject Iteration(string type, string model) =>
        new()
        {
            ["type"] = type,
            ["model"] = model,
            ["input_tokens"] = 1,
            ["output_tokens"] = 1,
            ["cache_creation_input_tokens"] = 0,
            ["cache_read_input_tokens"] = 0,
            ["cache_creation"] = null,
        };

    public static JsonObject FallbackBlock(string requestedModel) =>
        new()
        {
            ["type"] = "fallback",
            ["from"] = new JsonObject { ["model"] = requestedModel },
            ["to"] = new JsonObject { ["model"] = FallbackModel },
            ["trigger"] = new JsonObject { ["type"] = "refusal", ["category"] = null },
        };

    public static string[] Betas(FakeTransport transport, int index) =>
        [
            .. transport
                .BetaHeaderValues(index)
                .SelectMany(value => value.Split(','))
                .Select(token => token.Trim()),
        ];

    public static string Refusal(string fields) =>
        $"Cannot change {fields} on a thread: the server keeps the `System` and `Tools` the "
        + "thread was created with. To change them, start a new thread from `thread.Params`."
        + (
            fields.Contains("`Tools`")
                ? " To add or remove tools on this thread, send `tool_addition` or `tool_removal` "
                    + "blocks in a `system` message."
                : ""
        );

    public static bool IsStreamFailure(Exception e) =>
        e is AnthropicException or IOException or HttpRequestException;

    public static void AssertCreate(JsonObject request) =>
        Assert.Equal("""{"type":"create"}""", request["thread"]!.ToJsonString());

    public static void AssertContinue(JsonObject request, string previousMessageID)
    {
        Assert.Equal("continue", request["thread"]!["type"]!.GetValue<string>());
        Assert.Equal(
            previousMessageID,
            request["thread"]!["previous_message_id"]!.GetValue<string>()
        );
    }
}
