using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerHoldKeyToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerHoldKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerHoldKeyInput expectedInput = new() { Duration = 300, Text = "text" };
        JsonElement expectedName = JsonSerializer.SerializeToElement("hold_key");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedInput, model.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, model.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ComputerHoldKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerHoldKeyToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerHoldKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerHoldKeyToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerHoldKeyInput expectedInput = new() { Duration = 300, Text = "text" };
        JsonElement expectedName = JsonSerializer.SerializeToElement("hold_key");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, deserialized.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ComputerHoldKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerHoldKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };

        ComputerHoldKeyToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
