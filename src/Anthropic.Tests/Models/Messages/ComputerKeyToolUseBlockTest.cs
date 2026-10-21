using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerKeyToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerKeyInput expectedInput = new() { Text = "text", Repeat = 1 };
        JsonElement expectedName = JsonSerializer.SerializeToElement("key");
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
        var model = new ComputerKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerKeyToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerKeyToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerKeyInput expectedInput = new() { Text = "text", Repeat = 1 };
        JsonElement expectedName = JsonSerializer.SerializeToElement("key");
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
        var model = new ComputerKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerKeyToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };

        ComputerKeyToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
