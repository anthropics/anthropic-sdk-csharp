using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_use\"");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_use\"");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInput.Count, deserialized.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(deserialized.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Input[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolUseBlock
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        model.Validate();
    }
}
