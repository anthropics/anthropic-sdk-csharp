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
    public void KeyNameWorks()
    {
        ComputerToolUseBlock value = new ComputerKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", Repeat = 1 },
        };
        Assert.Equal(ComputerToolUseBlockName.Key, value.Name.Value());
    }

    [Fact]
    public void HoldKeyNameWorks()
    {
        ComputerToolUseBlock value = new ComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 300, Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.HoldKey, value.Name.Value());
    }

    [Fact]
    public void TypeNameWorks()
    {
        ComputerToolUseBlock value = new ComputerTypeToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("text"),
        };
        Assert.Equal(ComputerToolUseBlockName.Type, value.Name.Value());
    }

    [Fact]
    public void CursorPositionNameWorks()
    {
        ComputerToolUseBlock value = new ComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        Assert.Equal(ComputerToolUseBlockName.CursorPosition, value.Name.Value());
    }

    [Fact]
    public void MouseMoveNameWorks()
    {
        ComputerToolUseBlock value = new ComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0]),
        };
        Assert.Equal(ComputerToolUseBlockName.MouseMove, value.Name.Value());
    }

    [Fact]
    public void LeftMouseDownNameWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        Assert.Equal(ComputerToolUseBlockName.LeftMouseDown, value.Name.Value());
    }

    [Fact]
    public void LeftMouseUpNameWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        Assert.Equal(ComputerToolUseBlockName.LeftMouseUp, value.Name.Value());
    }

    [Fact]
    public void LeftClickNameWorks()
    {
        ComputerToolUseBlock value = new ComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.LeftClick, value.Name.Value());
    }

    [Fact]
    public void LeftClickDragNameWorks()
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
        Assert.Equal(ComputerToolUseBlockName.LeftClickDrag, value.Name.Value());
    }

    [Fact]
    public void RightClickNameWorks()
    {
        ComputerToolUseBlock value = new ComputerRightClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.RightClick, value.Name.Value());
    }

    [Fact]
    public void MiddleClickNameWorks()
    {
        ComputerToolUseBlock value = new ComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.MiddleClick, value.Name.Value());
    }

    [Fact]
    public void DoubleClickNameWorks()
    {
        ComputerToolUseBlock value = new ComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.DoubleClick, value.Name.Value());
    }

    [Fact]
    public void TripleClickNameWorks()
    {
        ComputerToolUseBlock value = new ComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Coordinate = [0, 0], Text = "text" },
        };
        Assert.Equal(ComputerToolUseBlockName.TripleClick, value.Name.Value());
    }

    [Fact]
    public void ScrollNameWorks()
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
        Assert.Equal(ComputerToolUseBlockName.Scroll, value.Name.Value());
    }

    [Fact]
    public void WaitNameWorks()
    {
        ComputerToolUseBlock value = new ComputerWaitToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(300),
        };
        Assert.Equal(ComputerToolUseBlockName.Wait, value.Name.Value());
    }

    [Fact]
    public void ScreenshotNameWorks()
    {
        ComputerToolUseBlock value = new ComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        Assert.Equal(ComputerToolUseBlockName.Screenshot, value.Name.Value());
    }

    [Fact]
    public void ZoomNameWorks()
    {
        ComputerToolUseBlock value = new ComputerZoomToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new([0, 0, 0, 0]),
        };
        Assert.Equal(ComputerToolUseBlockName.Zoom, value.Name.Value());
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
        ApiEnum<string, ComputerToolUseBlockName> expectedName = ComputerToolUseBlockName.Key;
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCaller, value.Caller);
        Assert.Equal(expectedName, value.Name);
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

public class ComputerToolUseBlockNameTest : TestBase
{
    [Theory]
    [InlineData(ComputerToolUseBlockName.Key)]
    [InlineData(ComputerToolUseBlockName.HoldKey)]
    [InlineData(ComputerToolUseBlockName.Type)]
    [InlineData(ComputerToolUseBlockName.CursorPosition)]
    [InlineData(ComputerToolUseBlockName.MouseMove)]
    [InlineData(ComputerToolUseBlockName.LeftMouseDown)]
    [InlineData(ComputerToolUseBlockName.LeftMouseUp)]
    [InlineData(ComputerToolUseBlockName.LeftClick)]
    [InlineData(ComputerToolUseBlockName.LeftClickDrag)]
    [InlineData(ComputerToolUseBlockName.RightClick)]
    [InlineData(ComputerToolUseBlockName.MiddleClick)]
    [InlineData(ComputerToolUseBlockName.DoubleClick)]
    [InlineData(ComputerToolUseBlockName.TripleClick)]
    [InlineData(ComputerToolUseBlockName.Scroll)]
    [InlineData(ComputerToolUseBlockName.Wait)]
    [InlineData(ComputerToolUseBlockName.Screenshot)]
    [InlineData(ComputerToolUseBlockName.Zoom)]
    public void Validation_Works(ComputerToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComputerToolUseBlockName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComputerToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ComputerToolUseBlockName.Key)]
    [InlineData(ComputerToolUseBlockName.HoldKey)]
    [InlineData(ComputerToolUseBlockName.Type)]
    [InlineData(ComputerToolUseBlockName.CursorPosition)]
    [InlineData(ComputerToolUseBlockName.MouseMove)]
    [InlineData(ComputerToolUseBlockName.LeftMouseDown)]
    [InlineData(ComputerToolUseBlockName.LeftMouseUp)]
    [InlineData(ComputerToolUseBlockName.LeftClick)]
    [InlineData(ComputerToolUseBlockName.LeftClickDrag)]
    [InlineData(ComputerToolUseBlockName.RightClick)]
    [InlineData(ComputerToolUseBlockName.MiddleClick)]
    [InlineData(ComputerToolUseBlockName.DoubleClick)]
    [InlineData(ComputerToolUseBlockName.TripleClick)]
    [InlineData(ComputerToolUseBlockName.Scroll)]
    [InlineData(ComputerToolUseBlockName.Wait)]
    [InlineData(ComputerToolUseBlockName.Screenshot)]
    [InlineData(ComputerToolUseBlockName.Zoom)]
    public void SerializationRoundtrip_Works(ComputerToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ComputerToolUseBlockName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComputerToolUseBlockName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ComputerToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ComputerToolUseBlockName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
