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
    public void KeyNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", Repeat = 1 },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.Key, value.Name.Value());
    }

    [Fact]
    public void HoldKeyNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 300, Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.HoldKey, value.Name.Value());
    }

    [Fact]
    public void TypeNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTypeToolUseBlock()
        {
            ID = "id",
            Input = new("text"),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.Type, value.Name.Value());
    }

    [Fact]
    public void CursorPositionNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerCursorPositionToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.CursorPosition, value.Name.Value());
    }

    [Fact]
    public void MouseMoveNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.MouseMove, value.Name.Value());
    }

    [Fact]
    public void LeftMouseDownNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.LeftMouseDown, value.Name.Value());
    }

    [Fact]
    public void LeftMouseUpNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.LeftMouseUp, value.Name.Value());
    }

    [Fact]
    public void LeftClickNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.LeftClick, value.Name.Value());
    }

    [Fact]
    public void LeftClickDragNameWorks()
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
        Assert.Equal(BetaComputerToolUseBlockName.LeftClickDrag, value.Name.Value());
    }

    [Fact]
    public void RightClickNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerRightClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.RightClick, value.Name.Value());
    }

    [Fact]
    public void MiddleClickNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.MiddleClick, value.Name.Value());
    }

    [Fact]
    public void DoubleClickNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.DoubleClick, value.Name.Value());
    }

    [Fact]
    public void TripleClickNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new() { Coordinate = [0, 0], Text = "text" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.TripleClick, value.Name.Value());
    }

    [Fact]
    public void ScrollNameWorks()
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
        Assert.Equal(BetaComputerToolUseBlockName.Scroll, value.Name.Value());
    }

    [Fact]
    public void WaitNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerWaitToolUseBlock()
        {
            ID = "id",
            Input = new(300),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.Wait, value.Name.Value());
    }

    [Fact]
    public void ScreenshotNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.Screenshot, value.Name.Value());
    }

    [Fact]
    public void ZoomNameWorks()
    {
        BetaComputerToolUseBlock value = new BetaComputerZoomToolUseBlock()
        {
            ID = "id",
            Input = new([0, 0, 0, 0]),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaComputerToolUseBlockName.Zoom, value.Name.Value());
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
        ApiEnum<string, BetaComputerToolUseBlockName> expectedName =
            BetaComputerToolUseBlockName.Key;
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        BetaToolUseCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedName, value.Name);
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

public class BetaComputerToolUseBlockNameTest : TestBase
{
    [Theory]
    [InlineData(BetaComputerToolUseBlockName.Key)]
    [InlineData(BetaComputerToolUseBlockName.HoldKey)]
    [InlineData(BetaComputerToolUseBlockName.Type)]
    [InlineData(BetaComputerToolUseBlockName.CursorPosition)]
    [InlineData(BetaComputerToolUseBlockName.MouseMove)]
    [InlineData(BetaComputerToolUseBlockName.LeftMouseDown)]
    [InlineData(BetaComputerToolUseBlockName.LeftMouseUp)]
    [InlineData(BetaComputerToolUseBlockName.LeftClick)]
    [InlineData(BetaComputerToolUseBlockName.LeftClickDrag)]
    [InlineData(BetaComputerToolUseBlockName.RightClick)]
    [InlineData(BetaComputerToolUseBlockName.MiddleClick)]
    [InlineData(BetaComputerToolUseBlockName.DoubleClick)]
    [InlineData(BetaComputerToolUseBlockName.TripleClick)]
    [InlineData(BetaComputerToolUseBlockName.Scroll)]
    [InlineData(BetaComputerToolUseBlockName.Wait)]
    [InlineData(BetaComputerToolUseBlockName.Screenshot)]
    [InlineData(BetaComputerToolUseBlockName.Zoom)]
    public void Validation_Works(BetaComputerToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComputerToolUseBlockName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaComputerToolUseBlockName.Key)]
    [InlineData(BetaComputerToolUseBlockName.HoldKey)]
    [InlineData(BetaComputerToolUseBlockName.Type)]
    [InlineData(BetaComputerToolUseBlockName.CursorPosition)]
    [InlineData(BetaComputerToolUseBlockName.MouseMove)]
    [InlineData(BetaComputerToolUseBlockName.LeftMouseDown)]
    [InlineData(BetaComputerToolUseBlockName.LeftMouseUp)]
    [InlineData(BetaComputerToolUseBlockName.LeftClick)]
    [InlineData(BetaComputerToolUseBlockName.LeftClickDrag)]
    [InlineData(BetaComputerToolUseBlockName.RightClick)]
    [InlineData(BetaComputerToolUseBlockName.MiddleClick)]
    [InlineData(BetaComputerToolUseBlockName.DoubleClick)]
    [InlineData(BetaComputerToolUseBlockName.TripleClick)]
    [InlineData(BetaComputerToolUseBlockName.Scroll)]
    [InlineData(BetaComputerToolUseBlockName.Wait)]
    [InlineData(BetaComputerToolUseBlockName.Screenshot)]
    [InlineData(BetaComputerToolUseBlockName.Zoom)]
    public void SerializationRoundtrip_Works(BetaComputerToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaComputerToolUseBlockName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComputerToolUseBlockName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaComputerToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaComputerToolUseBlockName>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
