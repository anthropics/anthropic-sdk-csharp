using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerToolUseBlockTest : TestBase
{
    [Fact]
    public void KeyValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };
        value.Validate();
    }

    [Fact]
    public void HoldKeyValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void TypeValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerTypeToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("text"),
        };
        value.Validate();
    }

    [Fact]
    public void CursorPositionValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void MouseMoveValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0]),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseDownValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseUpValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickDragValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftClickDragToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Coordinate = [0, 0],
                StartCoordinate = [0, 0],
                Text = "text",
            },
        };
        value.Validate();
    }

    [Fact]
    public void RightClickValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerRightClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void MiddleClickValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void DoubleClickValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void TripleClickValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        value.Validate();
    }

    [Fact]
    public void ScrollValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerScrollToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };
        value.Validate();
    }

    [Fact]
    public void WaitValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerWaitToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(300),
        };
        value.Validate();
    }

    [Fact]
    public void ScreenshotValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void ZoomValidationWorks()
    {
        ComputerToolUseBlock value = new ComputerZoomToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0, 0, 0]),
        };
        value.Validate();
    }

    [Fact]
    public void KeySerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoldKeySerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TypeSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerTypeToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("text"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CursorPositionSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MouseMoveSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseDownSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseUpSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickDragSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftClickDragToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Coordinate = [0, 0],
                StartCoordinate = [0, 0],
                Text = "text",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RightClickSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerRightClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MiddleClickSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleClickSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TripleClickSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerScrollToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WaitSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerWaitToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(300),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScreenshotSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ZoomSerializationRoundtripWorks()
    {
        ComputerToolUseBlock value = new ComputerZoomToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0, 0, 0]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ComputerToolUseBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "caller": {
                    "type": "direct"
                  },
                  "name": "key",
                  "toolset_name": "computer",
                  "type": "tool_use"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        JsonElement expectedName = JsonSerializer.SerializeToElement("key");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCaller, value.Caller);
        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, value.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ComputerToolUseBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Caller);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ToolsetName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        ComputerToolUseBlock mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
    }
}
