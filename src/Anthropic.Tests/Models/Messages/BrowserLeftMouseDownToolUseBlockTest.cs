using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserLeftMouseDownToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserLeftMouseDownToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        BrowserLeftMouseDownInput expectedInput = new()
        {
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("left_mouse_down");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
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
        var model = new BrowserLeftMouseDownToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserLeftMouseDownToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserLeftMouseDownToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserLeftMouseDownToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        BrowserLeftMouseDownInput expectedInput = new()
        {
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("left_mouse_down");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
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
        var model = new BrowserLeftMouseDownToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserLeftMouseDownToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        BrowserLeftMouseDownToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
