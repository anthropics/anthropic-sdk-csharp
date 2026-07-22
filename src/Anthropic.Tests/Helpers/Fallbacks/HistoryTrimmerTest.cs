using System.Text.Json.Nodes;
using Anthropic.Helpers.Fallbacks;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class HistoryTrimmerTest
{
    static JsonObject Body(string assistantContent, string extraTurns = "") =>
        (JsonObject)
            JsonNode.Parse(
                $$$"""
                {
                  "messages": [
                    {"role": "user", "content": "hi"},
                    {"role": "assistant", "content": [{{{assistantContent}}}]}
                    {{{extraTurns}}}
                  ]
                }
                """
            )!;

    static JsonArray AssistantContent(JsonObject body) =>
        (JsonArray)((JsonArray)body["messages"]!)[1]!["content"]!;

    const string Fallback = """
        {"type": "fallback", "from": {"model": "a"}, "to": {"model": "b"},
         "trigger": {"type": "refusal", "category": null}}
        """;

    [Fact]
    public void NoFallbackBlockLeavesTheBodyUntouched()
    {
        var body = Body(
            """{"type": "thinking", "thinking": "..."}, {"type": "text", "text": "ok"}"""
        );

        Assert.False(HistoryTrimmer.TrimFallbackTurns(body));
        Assert.Equal(2, AssistantContent(body).Count);
    }

    [Fact]
    public void TrimsTheFallbackBlockAndTheRefusedAttemptBeforeIt()
    {
        var body = Body(
            $$$"""
            {"type": "thinking", "thinking": "refused model musing"},
            {"type": "tool_use", "id": "toolu_1", "name": "f", "input": {}},
            {{{Fallback}}},
            {"type": "text", "text": "serving model output"}
            """
        );

        Assert.True(HistoryTrimmer.TrimFallbackTurns(body));

        var content = AssistantContent(body);
        var only = Assert.Single(content);
        Assert.Equal("text", (string?)only!["type"]);
        Assert.Equal("serving model output", (string?)only["text"]);
    }

    [Fact]
    public void KeepsTextThatPrecedesTheFallbackBlock()
    {
        var body = Body(
            $$$"""
            {"type": "text", "text": "refusal preamble"},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        var content = AssistantContent(body);
        Assert.Equal(2, content.Count);
        Assert.Equal("refusal preamble", (string?)content[0]!["text"]);
    }

    [Fact]
    public void KeepsAResolvedServerToolUse()
    {
        var body = Body(
            $$$"""
            {"type": "server_tool_use", "id": "srvtoolu_1", "name": "web_search", "input": {}},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """,
            extraTurns: """
            , {"role": "user", "content": [
                {"type": "web_search_tool_result", "tool_use_id": "srvtoolu_1", "content": []}
            ]}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        var content = AssistantContent(body);
        Assert.Equal(2, content.Count);
        Assert.Equal("server_tool_use", (string?)content[0]!["type"]);
    }

    [Fact]
    public void RemovesAnUnresolvedServerToolUse()
    {
        var body = Body(
            $$$"""
            {"type": "server_tool_use", "id": "srvtoolu_9", "name": "web_search", "input": {}},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        var only = Assert.Single(AssistantContent(body));
        Assert.Equal("text", (string?)only!["type"]);
    }

    [Fact]
    public void ClientToolUseIsRemovedEvenWhenAResultExists()
    {
        var body = Body(
            $$$"""
            {"type": "tool_use", "id": "toolu_1", "name": "f", "input": {}},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """,
            extraTurns: """
            , {"role": "user", "content": [
                {"type": "tool_result", "tool_use_id": "toolu_1", "content": "42"}
            ]}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        Assert.Equal("text", (string?)Assert.Single(AssistantContent(body))!["type"]);
    }

    [Fact]
    public void KeepsUnknownBlockTypesBeforeTheFallbackBlock()
    {
        var body = Body(
            $$$"""
            {"type": "novel_block", "data": 1},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        var content = AssistantContent(body);
        Assert.Equal(2, content.Count);
        Assert.Equal("novel_block", (string?)content[0]!["type"]);
    }

    [Fact]
    public void RemovesConnectorText()
    {
        var body = Body(
            $$$"""
            {"type": "connector_text", "text": "refused"},
            {{{Fallback}}},
            {"type": "text", "text": "served"}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        Assert.Equal("text", (string?)Assert.Single(AssistantContent(body))!["type"]);
    }

    [Fact]
    public void DropsATurnLeftEmptyByTheTrim()
    {
        var body = Body(
            $$$"""
            {"type": "thinking", "thinking": "..."},
            {{{Fallback}}}
            """
        );

        HistoryTrimmer.TrimFallbackTurns(body);

        var messages = (JsonArray)body["messages"]!;
        Assert.Single(messages);
        Assert.Equal("user", (string?)messages[0]!["role"]);
    }

    [Fact]
    public void BodyWithoutMessagesIsANoOp()
    {
        var body = (JsonObject)JsonNode.Parse("""{"model": "m"}""")!;

        Assert.False(HistoryTrimmer.TrimFallbackTurns(body));
    }
}
