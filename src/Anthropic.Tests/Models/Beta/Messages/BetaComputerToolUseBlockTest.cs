using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerToolUseBlockTest : TestBase
{
    [Fact]
    public void KeyValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", Repeat = 1 },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void HoldKeyValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 300, Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void TypeValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTypeToolUseBlock()
        {
            ID = "id",
            Input = new("text"),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void CursorPositionValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void MouseMoveValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseDownValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseUpValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickDragValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftClickDragToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Coordinate = [0, 0],
                StartCoordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void RightClickValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerRightClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void MiddleClickValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void DoubleClickValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void TripleClickValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ScrollValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerScrollToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WaitValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerWaitToolUseBlock()
        {
            ID = "id",
            Input = new(300),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ScreenshotValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ZoomValidationWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerZoomToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0, 0, 0]),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void KeySerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", Repeat = 1 },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoldKeySerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 300, Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TypeSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTypeToolUseBlock()
        {
            ID = "id",
            Input = new("text"),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CursorPositionSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MouseMoveSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseDownSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseUpSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickDragSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftClickDragToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Coordinate = [0, 0],
                StartCoordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RightClickSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerRightClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MiddleClickSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleClickSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TripleClickSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerScrollToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WaitSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerWaitToolUseBlock()
        {
            ID = "id",
            Input = new(300),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScreenshotSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ZoomSerializationRoundtripWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerZoomToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0, 0, 0]),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaComputerToolUseBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "name": "key",
                  "toolset_name": "computer",
                  "type": "tool_use",
                  "caller": {
                    "type": "direct"
                  }
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        JsonElement expectedName = JsonSerializer.SerializeToElement("key");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        BetaToolUseCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, value.ID);
        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, value.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedCaller, value.Caller);

        BetaComputerToolUseBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ToolsetName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Caller);

        BetaComputerToolUseBlock mismatchedValue = new(
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
