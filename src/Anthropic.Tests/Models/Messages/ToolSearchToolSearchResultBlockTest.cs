using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolSearchResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolSearchToolSearchResultBlock { ToolReferences = [new("tool_name")] };

        List<ToolReferenceBlock> expectedToolReferences = [new("tool_name")];
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_search_result"
        );

        Assert.Equal(expectedToolReferences.Count, model.ToolReferences.Count);
        for (int i = 0; i < expectedToolReferences.Count; i++)
        {
            Assert.Equal(expectedToolReferences[i], model.ToolReferences[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolSearchToolSearchResultBlock { ToolReferences = [new("tool_name")] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolSearchResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolSearchToolSearchResultBlock { ToolReferences = [new("tool_name")] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolSearchResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ToolReferenceBlock> expectedToolReferences = [new("tool_name")];
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "tool_search_tool_search_result"
        );

        Assert.Equal(expectedToolReferences.Count, deserialized.ToolReferences.Count);
        for (int i = 0; i < expectedToolReferences.Count; i++)
        {
            Assert.Equal(expectedToolReferences[i], deserialized.ToolReferences[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolSearchToolSearchResultBlock { ToolReferences = [new("tool_name")] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolSearchToolSearchResultBlock { ToolReferences = [new("tool_name")] };

        ToolSearchToolSearchResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
