using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolReferenceBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolReferenceBlock { ToolName = "tool_name" };

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");

        Assert.Equal(expectedToolName, model.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolReferenceBlock { ToolName = "tool_name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolReferenceBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolReferenceBlock { ToolName = "tool_name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolReferenceBlock>(json);
        Assert.NotNull(deserialized);

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_reference\"");

        Assert.Equal(expectedToolName, deserialized.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolReferenceBlock { ToolName = "tool_name" };

        model.Validate();
    }
}
