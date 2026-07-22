using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using Anthropic.Helpers.Fallbacks;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class WireShapeTest
{
    static JsonObject Parse(string json) => (JsonObject)JsonNode.Parse(json)!;

    [Fact]
    public void TransitionBlockCarriesFromToAndCategory()
    {
        var block = WireShape.TransitionBlock("model-a", "model-b", "safety");
        var json = JsonNode.Parse(JsonSerializer.Serialize(block))!;

        Assert.Equal("fallback", (string?)json["type"]);
        Assert.Equal("model-a", (string?)json["from"]!["model"]);
        Assert.Equal("model-b", (string?)json["to"]!["model"]);
        Assert.Equal("refusal", (string?)json["trigger"]!["type"]);
        Assert.Equal("safety", (string?)json["trigger"]!["category"]);
    }

    [Fact]
    public void TransitionBlockNullCategoryStaysExplicitNull()
    {
        var block = WireShape.TransitionBlock("model-a", "model-b", null);
        var trigger = (JsonObject)JsonNode.Parse(JsonSerializer.Serialize(block))!["trigger"]!;

        Assert.True(trigger.ContainsKey("category"));
        Assert.Null(trigger["category"]);
    }

    [Fact]
    public void BackfillFillsMissingFieldsFromTheStartUsage()
    {
        var merged = WireShape.Backfill(
            primary: Parse("""{"output_tokens": 7}"""),
            fallback: Parse("""{"input_tokens": 12, "output_tokens": 1}""")
        );

        Assert.Equal(12, (int)merged["input_tokens"]!);
        Assert.Equal(7, (int)merged["output_tokens"]!);
    }

    [Fact]
    public void BackfillExplicitNullNeverErasesAStartValue()
    {
        var merged = WireShape.Backfill(
            primary: Parse("""{"cache_read_input_tokens": null}"""),
            fallback: Parse("""{"cache_read_input_tokens": 5}""")
        );

        Assert.Equal(5, (int)merged["cache_read_input_tokens"]!);
    }

    [Fact]
    public void BackfillKeepsNullFieldAbsentFromTheStart()
    {
        var merged = WireShape.Backfill(
            primary: Parse("""{"service_tier": null}"""),
            fallback: Parse("""{"input_tokens": 1}""")
        );

        Assert.True(merged.ContainsKey("service_tier"));
        Assert.Null(merged["service_tier"]);
    }

    [Fact]
    public void BackfillWithNothingReturnsEmpty()
    {
        Assert.Empty(WireShape.Backfill(primary: null, fallback: null));
    }

    [Fact]
    public void MessageIterationStampsTypeAndModelAndKeepsUnknownFields()
    {
        var entry = WireShape.MessageIteration(
            "model-a",
            Parse("""{"input_tokens": 3, "output_tokens": 4, "service_tier": "standard"}""")
        );

        Assert.Equal("message", (string?)entry["type"]);
        Assert.Equal("model-a", (string?)entry["model"]);
        Assert.Equal("standard", (string?)entry["service_tier"]);
    }

    [Fact]
    public void MessageIterationRemovesNestedIterations()
    {
        var entry = WireShape.MessageIteration("m", Parse("""{"iterations": [{"a": 1}]}"""));

        Assert.False(entry.ContainsKey("iterations"));
    }

    [Fact]
    public void MessageIterationCoercesMissingAndNonIntegerTokenCountsToZero()
    {
        var entry = WireShape.MessageIteration(
            "m",
            Parse("""{"input_tokens": null, "output_tokens": "12"}""")
        );

        Assert.Equal(0, (int)entry["input_tokens"]!);
        Assert.Equal(0, (int)entry["output_tokens"]!);
        Assert.Equal(0, (int)entry["cache_read_input_tokens"]!);
        Assert.Equal(0, (int)entry["cache_creation_input_tokens"]!);
    }

    [Fact]
    public void FallbackIterationDiffersFromMessageOnlyByType()
    {
        var usage = Parse("""{"input_tokens": 1, "output_tokens": 2}""");
        var message = WireShape.MessageIteration("m", usage);
        var fallback = WireShape.FallbackIteration("m", usage);

        Assert.Equal("fallback_message", (string?)fallback["type"]);
        fallback["type"] = "message";
        Assert.Equal(message.ToJsonString(), fallback.ToJsonString());
    }

    [Fact]
    public void RewriteTerminalUsageReplacesTheSelfReportedChain()
    {
        var terminalDelta = Parse(
            """{"type": "message_delta", "usage": {"output_tokens": 9, "iterations": [{"type": "message"}]}}"""
        );
        var prior = WireShape.MessageIteration("refused", Parse("""{"input_tokens": 5}"""));

        WireShape.RewriteTerminalUsage(
            terminalDelta,
            startUsage: Parse("""{"input_tokens": 20}"""),
            priorIterations: [prior],
            model: "serving",
            refused: false
        );

        var iterations = (JsonArray)terminalDelta["usage"]!["iterations"]!;
        Assert.Equal(2, iterations.Count);
        Assert.Equal("message", (string?)iterations[0]!["type"]);
        Assert.Equal("refused", (string?)iterations[0]!["model"]);
        Assert.Equal("fallback_message", (string?)iterations[1]!["type"]);
        Assert.Equal("serving", (string?)iterations[1]!["model"]);
        // The terminal hop's usage is backfilled from its message_start.
        Assert.Equal(20, (int)iterations[1]!["input_tokens"]!);
        Assert.Equal(9, (int)iterations[1]!["output_tokens"]!);
    }

    [Fact]
    public void RewriteTerminalUsageMarksARefusingTerminalHopAsMessage()
    {
        var terminalDelta = Parse("""{"type": "message_delta", "usage": {}}""");

        WireShape.RewriteTerminalUsage(
            terminalDelta,
            startUsage: null,
            priorIterations: [],
            model: "last",
            refused: true
        );

        var iterations = (JsonArray)terminalDelta["usage"]!["iterations"]!;
        Assert.Equal("message", (string?)Assert.Single(iterations)!["type"]);
    }

    [Fact]
    public void HeldRefusalDeltaKeepsUnknownFieldsAndPointsAtRecommendedModel()
    {
        var heldEvent = Parse(
            """
            {
              "type": "message_delta",
              "delta": {"stop_reason": "refusal", "stop_details": {"type": "refusal"}},
              "context_management": {"applied_edits": []},
              "usage": {"output_tokens": 1}
            }
            """
        );
        var iteration = WireShape.MessageIteration("m", Parse("""{"input_tokens": 2}"""));

        var bytes = WireShape.HeldRefusalDelta(
            heldEvent,
            refusalUsage: Parse("""{"output_tokens": 1}"""),
            recommendedModel: "next-model",
            iterations: [iteration]
        );

        var text = Encoding.UTF8.GetString(bytes);
        Assert.StartsWith("event: message_delta\ndata: ", text);
        var payload = Parse(text.Substring("event: message_delta\ndata: ".Length).TrimEnd('\n'));
        Assert.Equal(
            "next-model",
            (string?)payload["delta"]!["stop_details"]!["recommended_model"]
        );
        Assert.NotNull(payload["context_management"]);
        Assert.Single((JsonArray)payload["usage"]!["iterations"]!);
        // The captured event is not mutated.
        Assert.False(
            ((JsonObject)heldEvent["delta"]!["stop_details"]!).ContainsKey("recommended_model")
        );
    }

    [Fact]
    public void FallbackBlockStartEmitsAnIndexedFallbackBlock()
    {
        var bytes = WireShape.FallbackBlockStart(
            3,
            new WireShape.ModelTransition("from-model", "to-model", "cyber")
        );

        var text = Encoding.UTF8.GetString(bytes);
        Assert.StartsWith("event: content_block_start\ndata: ", text);
        Assert.EndsWith("\n\n", text);
        var payload = Parse(
            text.Substring("event: content_block_start\ndata: ".Length).TrimEnd('\n')
        );
        Assert.Equal(3, (int)payload["index"]!);
        Assert.Equal("fallback", (string?)payload["content_block"]!["type"]);
        Assert.Equal("cyber", (string?)payload["content_block"]!["trigger"]!["category"]);
    }

    [Fact]
    public void ContentBlockStopAndMessageStopSerializeToTheirEvents()
    {
        Assert.Equal(
            "event: content_block_stop\ndata: {\"type\":\"content_block_stop\",\"index\":4}\n\n",
            Encoding.UTF8.GetString(WireShape.ContentBlockStop(4))
        );
        Assert.Equal(
            "event: message_stop\ndata: {\"type\":\"message_stop\"}\n\n",
            Encoding.UTF8.GetString(WireShape.MessageStop())
        );
    }

    [Fact]
    public void EmitDerivesTheEventNameFromTheType()
    {
        Assert.Equal(
            "event: ping\ndata: {\"type\":\"ping\"}\n\n",
            Encoding.UTF8.GetString(WireShape.Emit(Parse("""{"type": "ping"}""")))
        );
    }
}
