using System.Text.Json;
using Anthropic.Core;
using Microsoft.Extensions.AI;

namespace Anthropic.Tests.Core;

public class RedactedThinkingMarkerTest
{
    [Fact]
    public void MarkRedactedSetsTheMarkerAndKeepsOtherProperties()
    {
        var content = new TextReasoningContent(string.Empty)
        {
            AdditionalProperties = new() { ["other"] = 1 },
        };

        var marked = content.MarkRedacted();

        Assert.Same(content, marked);
        Assert.True(marked.IsMarkedRedacted());
        Assert.Equal(1, marked.AdditionalProperties!["other"]);
    }

    [Fact]
    public void IsMarkedRedactedIsFalseWithoutTheMarker()
    {
        Assert.False(new TextReasoningContent(string.Empty).IsMarkedRedacted());
        Assert.False(
            new TextReasoningContent(string.Empty)
            {
                AdditionalProperties = new() { [RedactedThinkingMarker.Key] = false },
            }.IsMarkedRedacted()
        );
        Assert.False(
            new TextReasoningContent(string.Empty)
            {
                AdditionalProperties = new() { [RedactedThinkingMarker.Key] = "true" },
            }.IsMarkedRedacted()
        );
    }

    [Fact]
    public void MarkerSurvivesAJsonRoundTrip()
    {
        var typeInfo = AIJsonUtilities.DefaultOptions.GetTypeInfo(typeof(AIContent));
        AIContent original = new TextReasoningContent(string.Empty)
        {
            ProtectedData = "opaque",
        }.MarkRedacted();

        var restored = (AIContent)
            JsonSerializer.Deserialize(JsonSerializer.Serialize(original, typeInfo), typeInfo)!;

        Assert.IsType<TextReasoningContent>(restored);
        Assert.IsType<JsonElement>(restored.AdditionalProperties![RedactedThinkingMarker.Key]);
        Assert.True(restored.IsMarkedRedacted());
    }
}
