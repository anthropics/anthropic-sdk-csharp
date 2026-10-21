using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerCursorPositionToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerCursorPositionToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerCursorPositionInput expectedInput = new();
        JsonElement expectedName = JsonSerializer.SerializeToElement("cursor_position");
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
        var model = new ComputerCursorPositionToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerCursorPositionToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerCursorPositionToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerCursorPositionToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerCursorPositionInput expectedInput = new();
        JsonElement expectedName = JsonSerializer.SerializeToElement("cursor_position");
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
        var model = new ComputerCursorPositionToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerCursorPositionToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };

        ComputerCursorPositionToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
