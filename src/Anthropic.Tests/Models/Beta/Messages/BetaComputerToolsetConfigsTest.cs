using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerToolsetConfigsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        BetaComputerCursorPositionConfig expectedCursorPosition = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerDoubleClickConfig expectedDoubleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerHoldKeyConfig expectedHoldKey = new() { DeferLoading = true, Enabled = true };
        BetaComputerKeyConfig expectedKey = new() { DeferLoading = true, Enabled = true };
        BetaComputerLeftClickConfig expectedLeftClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftClickDragConfig expectedLeftClickDrag = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftMouseDownConfig expectedLeftMouseDown = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftMouseUpConfig expectedLeftMouseUp = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerMiddleClickConfig expectedMiddleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerMouseMoveConfig expectedMouseMove = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerRightClickConfig expectedRightClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerScreenshotConfig expectedScreenshot = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerScrollConfig expectedScroll = new() { DeferLoading = true, Enabled = true };
        BetaComputerTripleClickConfig expectedTripleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerTypeConfig expectedType = new() { DeferLoading = true, Enabled = true };
        BetaComputerWaitConfig expectedWait = new() { DeferLoading = true, Enabled = true };
        BetaComputerZoomConfig expectedZoom = new() { DeferLoading = true, Enabled = true };

        Assert.Equal(expectedCursorPosition, model.CursorPosition);
        Assert.Equal(expectedDoubleClick, model.DoubleClick);
        Assert.Equal(expectedHoldKey, model.HoldKey);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLeftClick, model.LeftClick);
        Assert.Equal(expectedLeftClickDrag, model.LeftClickDrag);
        Assert.Equal(expectedLeftMouseDown, model.LeftMouseDown);
        Assert.Equal(expectedLeftMouseUp, model.LeftMouseUp);
        Assert.Equal(expectedMiddleClick, model.MiddleClick);
        Assert.Equal(expectedMouseMove, model.MouseMove);
        Assert.Equal(expectedRightClick, model.RightClick);
        Assert.Equal(expectedScreenshot, model.Screenshot);
        Assert.Equal(expectedScroll, model.Scroll);
        Assert.Equal(expectedTripleClick, model.TripleClick);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWait, model.Wait);
        Assert.Equal(expectedZoom, model.Zoom);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolsetConfigs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerToolsetConfigs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaComputerCursorPositionConfig expectedCursorPosition = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerDoubleClickConfig expectedDoubleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerHoldKeyConfig expectedHoldKey = new() { DeferLoading = true, Enabled = true };
        BetaComputerKeyConfig expectedKey = new() { DeferLoading = true, Enabled = true };
        BetaComputerLeftClickConfig expectedLeftClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftClickDragConfig expectedLeftClickDrag = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftMouseDownConfig expectedLeftMouseDown = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerLeftMouseUpConfig expectedLeftMouseUp = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerMiddleClickConfig expectedMiddleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerMouseMoveConfig expectedMouseMove = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerRightClickConfig expectedRightClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerScreenshotConfig expectedScreenshot = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerScrollConfig expectedScroll = new() { DeferLoading = true, Enabled = true };
        BetaComputerTripleClickConfig expectedTripleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BetaComputerTypeConfig expectedType = new() { DeferLoading = true, Enabled = true };
        BetaComputerWaitConfig expectedWait = new() { DeferLoading = true, Enabled = true };
        BetaComputerZoomConfig expectedZoom = new() { DeferLoading = true, Enabled = true };

        Assert.Equal(expectedCursorPosition, deserialized.CursorPosition);
        Assert.Equal(expectedDoubleClick, deserialized.DoubleClick);
        Assert.Equal(expectedHoldKey, deserialized.HoldKey);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLeftClick, deserialized.LeftClick);
        Assert.Equal(expectedLeftClickDrag, deserialized.LeftClickDrag);
        Assert.Equal(expectedLeftMouseDown, deserialized.LeftMouseDown);
        Assert.Equal(expectedLeftMouseUp, deserialized.LeftMouseUp);
        Assert.Equal(expectedMiddleClick, deserialized.MiddleClick);
        Assert.Equal(expectedMouseMove, deserialized.MouseMove);
        Assert.Equal(expectedRightClick, deserialized.RightClick);
        Assert.Equal(expectedScreenshot, deserialized.Screenshot);
        Assert.Equal(expectedScroll, deserialized.Scroll);
        Assert.Equal(expectedTripleClick, deserialized.TripleClick);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWait, deserialized.Wait);
        Assert.Equal(expectedZoom, deserialized.Zoom);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerToolsetConfigs { };

        Assert.Null(model.CursorPosition);
        Assert.False(model.RawData.ContainsKey("cursor_position"));
        Assert.Null(model.DoubleClick);
        Assert.False(model.RawData.ContainsKey("double_click"));
        Assert.Null(model.HoldKey);
        Assert.False(model.RawData.ContainsKey("hold_key"));
        Assert.Null(model.Key);
        Assert.False(model.RawData.ContainsKey("key"));
        Assert.Null(model.LeftClick);
        Assert.False(model.RawData.ContainsKey("left_click"));
        Assert.Null(model.LeftClickDrag);
        Assert.False(model.RawData.ContainsKey("left_click_drag"));
        Assert.Null(model.LeftMouseDown);
        Assert.False(model.RawData.ContainsKey("left_mouse_down"));
        Assert.Null(model.LeftMouseUp);
        Assert.False(model.RawData.ContainsKey("left_mouse_up"));
        Assert.Null(model.MiddleClick);
        Assert.False(model.RawData.ContainsKey("middle_click"));
        Assert.Null(model.MouseMove);
        Assert.False(model.RawData.ContainsKey("mouse_move"));
        Assert.Null(model.RightClick);
        Assert.False(model.RawData.ContainsKey("right_click"));
        Assert.Null(model.Screenshot);
        Assert.False(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Scroll);
        Assert.False(model.RawData.ContainsKey("scroll"));
        Assert.Null(model.TripleClick);
        Assert.False(model.RawData.ContainsKey("triple_click"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
        Assert.Null(model.Wait);
        Assert.False(model.RawData.ContainsKey("wait"));
        Assert.Null(model.Zoom);
        Assert.False(model.RawData.ContainsKey("zoom"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerToolsetConfigs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = null,
            DoubleClick = null,
            HoldKey = null,
            Key = null,
            LeftClick = null,
            LeftClickDrag = null,
            LeftMouseDown = null,
            LeftMouseUp = null,
            MiddleClick = null,
            MouseMove = null,
            RightClick = null,
            Screenshot = null,
            Scroll = null,
            TripleClick = null,
            Type = null,
            Wait = null,
            Zoom = null,
        };

        Assert.Null(model.CursorPosition);
        Assert.True(model.RawData.ContainsKey("cursor_position"));
        Assert.Null(model.DoubleClick);
        Assert.True(model.RawData.ContainsKey("double_click"));
        Assert.Null(model.HoldKey);
        Assert.True(model.RawData.ContainsKey("hold_key"));
        Assert.Null(model.Key);
        Assert.True(model.RawData.ContainsKey("key"));
        Assert.Null(model.LeftClick);
        Assert.True(model.RawData.ContainsKey("left_click"));
        Assert.Null(model.LeftClickDrag);
        Assert.True(model.RawData.ContainsKey("left_click_drag"));
        Assert.Null(model.LeftMouseDown);
        Assert.True(model.RawData.ContainsKey("left_mouse_down"));
        Assert.Null(model.LeftMouseUp);
        Assert.True(model.RawData.ContainsKey("left_mouse_up"));
        Assert.Null(model.MiddleClick);
        Assert.True(model.RawData.ContainsKey("middle_click"));
        Assert.Null(model.MouseMove);
        Assert.True(model.RawData.ContainsKey("mouse_move"));
        Assert.Null(model.RightClick);
        Assert.True(model.RawData.ContainsKey("right_click"));
        Assert.Null(model.Screenshot);
        Assert.True(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Scroll);
        Assert.True(model.RawData.ContainsKey("scroll"));
        Assert.Null(model.TripleClick);
        Assert.True(model.RawData.ContainsKey("triple_click"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
        Assert.Null(model.Wait);
        Assert.True(model.RawData.ContainsKey("wait"));
        Assert.Null(model.Zoom);
        Assert.True(model.RawData.ContainsKey("zoom"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = null,
            DoubleClick = null,
            HoldKey = null,
            Key = null,
            LeftClick = null,
            LeftClickDrag = null,
            LeftMouseDown = null,
            LeftMouseUp = null,
            MiddleClick = null,
            MouseMove = null,
            RightClick = null,
            Screenshot = null,
            Scroll = null,
            TripleClick = null,
            Type = null,
            Wait = null,
            Zoom = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerToolsetConfigs
        {
            CursorPosition = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        BetaComputerToolsetConfigs copied = new(model);

        Assert.Equal(model, copied);
    }
}
