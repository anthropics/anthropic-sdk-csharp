using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserToolUseBlockTest : TestBase
{
    [Fact]
    public void NavigateValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNavigateToolUseBlock()
        {
            ID = "id",
            Input = new() { Url = "url", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ListTabsValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserListTabsToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void NewTabValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNewTabToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void SwitchTabValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserSwitchTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void CloseTabValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserCloseTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ReadPageValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadPageToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Depth = 1,
                Filter = BetaBrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void GetPageTextValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserGetPageTextToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ReadConsoleValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadConsoleToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ReadNetworkValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadNetworkToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void FindValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFindToolUseBlock()
        {
            ID = "id",
            Input = new() { Query = "query", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void FormInputValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFormInputToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                Value = "string",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void FileUploadValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFileUploadToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                DocumentIds = ["string"],
                Paths = ["string"],
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ScrollToValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToToolUseBlock()
        {
            ID = "id",
            Input = new() { Target = new("ref"), TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ScreenshotValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ZoomValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserZoomToolUseBlock()
        {
            ID = "id",
            Input = new() { Region = [0, 0, 0, 0], TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void RightClickValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserRightClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void MiddleClickValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void DoubleClickValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void TripleClickValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void HoverValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoverToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickDragValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickDragToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseDownValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseUpValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void MouseMoveValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void ScrollValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                ScrollDirection = BetaBrowserScrollDirection.Up,
                Target = new() { X = 0, Y = 0 },
                ScrollAmount = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void TypeValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTypeToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void KeyValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Text = "text",
                Repeat = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void HoldKeyValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Duration = 0,
                Text = "text",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void WaitValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserWaitToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 0, TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void JavascriptExecValidationWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserJavascriptExecToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        value.Validate();
    }

    [Fact]
    public void NavigateSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNavigateToolUseBlock()
        {
            ID = "id",
            Input = new() { Url = "url", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListTabsSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserListTabsToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewTabSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNewTabToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SwitchTabSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserSwitchTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloseTabSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserCloseTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadPageSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadPageToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Depth = 1,
                Filter = BetaBrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GetPageTextSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserGetPageTextToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadConsoleSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadConsoleToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadNetworkSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadNetworkToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FindSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFindToolUseBlock()
        {
            ID = "id",
            Input = new() { Query = "query", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormInputSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFormInputToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                Value = "string",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileUploadSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFileUploadToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                DocumentIds = ["string"],
                Paths = ["string"],
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollToSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToToolUseBlock()
        {
            ID = "id",
            Input = new() { Target = new("ref"), TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScreenshotSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ZoomSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserZoomToolUseBlock()
        {
            ID = "id",
            Input = new() { Region = [0, 0, 0, 0], TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RightClickSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserRightClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MiddleClickSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleClickSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TripleClickSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoverSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoverToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickDragSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickDragToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseDownSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseUpSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MouseMoveSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                ScrollDirection = BetaBrowserScrollDirection.Up,
                Target = new() { X = 0, Y = 0 },
                ScrollAmount = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TypeSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTypeToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void KeySerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Text = "text",
                Repeat = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoldKeySerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Duration = 0,
                Text = "text",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WaitSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserWaitToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 0, TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JavascriptExecSerializationRoundtripWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserJavascriptExecToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NavigateNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNavigateToolUseBlock()
        {
            ID = "id",
            Input = new() { Url = "url", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Navigate, value.Name.Value());
    }

    [Fact]
    public void ListTabsNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserListTabsToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.ListTabs, value.Name.Value());
    }

    [Fact]
    public void NewTabNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserNewTabToolUseBlock()
        {
            ID = "id",
            Input = new(),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.NewTab, value.Name.Value());
    }

    [Fact]
    public void SwitchTabNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserSwitchTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.SwitchTab, value.Name.Value());
    }

    [Fact]
    public void CloseTabNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserCloseTabToolUseBlock()
        {
            ID = "id",
            Input = new("tab_id"),
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.CloseTab, value.Name.Value());
    }

    [Fact]
    public void ReadPageNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadPageToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Depth = 1,
                Filter = BetaBrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.ReadPage, value.Name.Value());
    }

    [Fact]
    public void GetPageTextNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserGetPageTextToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.GetPageText, value.Name.Value());
    }

    [Fact]
    public void ReadConsoleNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadConsoleToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.ReadConsole, value.Name.Value());
    }

    [Fact]
    public void ReadNetworkNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserReadNetworkToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.ReadNetwork, value.Name.Value());
    }

    [Fact]
    public void FindNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFindToolUseBlock()
        {
            ID = "id",
            Input = new() { Query = "query", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Find, value.Name.Value());
    }

    [Fact]
    public void FormInputNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFormInputToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                Value = "string",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.FormInput, value.Name.Value());
    }

    [Fact]
    public void FileUploadNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserFileUploadToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new("ref"),
                DocumentIds = ["string"],
                Paths = ["string"],
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.FileUpload, value.Name.Value());
    }

    [Fact]
    public void ScrollToNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToToolUseBlock()
        {
            ID = "id",
            Input = new() { Target = new("ref"), TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.ScrollTo, value.Name.Value());
    }

    [Fact]
    public void ScreenshotNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScreenshotToolUseBlock()
        {
            ID = "id",
            Input = new() { TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Screenshot, value.Name.Value());
    }

    [Fact]
    public void ZoomNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserZoomToolUseBlock()
        {
            ID = "id",
            Input = new() { Region = [0, 0, 0, 0], TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Zoom, value.Name.Value());
    }

    [Fact]
    public void LeftClickNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.LeftClick, value.Name.Value());
    }

    [Fact]
    public void RightClickNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserRightClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.RightClick, value.Name.Value());
    }

    [Fact]
    public void MiddleClickNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMiddleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.MiddleClick, value.Name.Value());
    }

    [Fact]
    public void DoubleClickNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserDoubleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.DoubleClick, value.Name.Value());
    }

    [Fact]
    public void TripleClickNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTripleClickToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.TripleClick, value.Name.Value());
    }

    [Fact]
    public void HoverNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoverToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new BetaBrowserCoordinateTarget() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Hover, value.Name.Value());
    }

    [Fact]
    public void LeftClickDragNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftClickDragToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.LeftClickDrag, value.Name.Value());
    }

    [Fact]
    public void LeftMouseDownNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.LeftMouseDown, value.Name.Value());
    }

    [Fact]
    public void LeftMouseUpNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.LeftMouseUp, value.Name.Value());
    }

    [Fact]
    public void MouseMoveNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserMouseMoveToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.MouseMove, value.Name.Value());
    }

    [Fact]
    public void ScrollNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserScrollToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                ScrollDirection = BetaBrowserScrollDirection.Up,
                Target = new() { X = 0, Y = 0 },
                ScrollAmount = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Scroll, value.Name.Value());
    }

    [Fact]
    public void TypeNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserTypeToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Type, value.Name.Value());
    }

    [Fact]
    public void KeyNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Text = "text",
                Repeat = 1,
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Key, value.Name.Value());
    }

    [Fact]
    public void HoldKeyNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserHoldKeyToolUseBlock()
        {
            ID = "id",
            Input = new()
            {
                Duration = 0,
                Text = "text",
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.HoldKey, value.Name.Value());
    }

    [Fact]
    public void WaitNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserWaitToolUseBlock()
        {
            ID = "id",
            Input = new() { Duration = 0, TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.Wait, value.Name.Value());
    }

    [Fact]
    public void JavascriptExecNameWorks()
    {
        BetaBrowserToolUseBlock value = new BetaBrowserJavascriptExecToolUseBlock()
        {
            ID = "id",
            Input = new() { Text = "text", TabID = "tab_id" },
            Caller = new BetaDirectCaller(),
        };
        Assert.Equal(BetaBrowserToolUseBlockName.JavascriptExec, value.Name.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaBrowserToolUseBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "name": "navigate",
                  "toolset_name": "browser",
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
        ApiEnum<string, BetaBrowserToolUseBlockName> expectedName =
            BetaBrowserToolUseBlockName.Navigate;
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        BetaToolUseCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedName, value.Name);
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, value.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedCaller, value.Caller);

        BetaBrowserToolUseBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ToolsetName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.Caller);

        BetaBrowserToolUseBlock mismatchedValue = new(
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

public class BetaBrowserToolUseBlockNameTest : TestBase
{
    [Theory]
    [InlineData(BetaBrowserToolUseBlockName.Navigate)]
    [InlineData(BetaBrowserToolUseBlockName.ListTabs)]
    [InlineData(BetaBrowserToolUseBlockName.NewTab)]
    [InlineData(BetaBrowserToolUseBlockName.SwitchTab)]
    [InlineData(BetaBrowserToolUseBlockName.CloseTab)]
    [InlineData(BetaBrowserToolUseBlockName.ReadPage)]
    [InlineData(BetaBrowserToolUseBlockName.GetPageText)]
    [InlineData(BetaBrowserToolUseBlockName.ReadConsole)]
    [InlineData(BetaBrowserToolUseBlockName.ReadNetwork)]
    [InlineData(BetaBrowserToolUseBlockName.Find)]
    [InlineData(BetaBrowserToolUseBlockName.FormInput)]
    [InlineData(BetaBrowserToolUseBlockName.FileUpload)]
    [InlineData(BetaBrowserToolUseBlockName.ScrollTo)]
    [InlineData(BetaBrowserToolUseBlockName.Screenshot)]
    [InlineData(BetaBrowserToolUseBlockName.Zoom)]
    [InlineData(BetaBrowserToolUseBlockName.LeftClick)]
    [InlineData(BetaBrowserToolUseBlockName.RightClick)]
    [InlineData(BetaBrowserToolUseBlockName.MiddleClick)]
    [InlineData(BetaBrowserToolUseBlockName.DoubleClick)]
    [InlineData(BetaBrowserToolUseBlockName.TripleClick)]
    [InlineData(BetaBrowserToolUseBlockName.Hover)]
    [InlineData(BetaBrowserToolUseBlockName.LeftClickDrag)]
    [InlineData(BetaBrowserToolUseBlockName.LeftMouseDown)]
    [InlineData(BetaBrowserToolUseBlockName.LeftMouseUp)]
    [InlineData(BetaBrowserToolUseBlockName.MouseMove)]
    [InlineData(BetaBrowserToolUseBlockName.Scroll)]
    [InlineData(BetaBrowserToolUseBlockName.Type)]
    [InlineData(BetaBrowserToolUseBlockName.Key)]
    [InlineData(BetaBrowserToolUseBlockName.HoldKey)]
    [InlineData(BetaBrowserToolUseBlockName.Wait)]
    [InlineData(BetaBrowserToolUseBlockName.JavascriptExec)]
    public void Validation_Works(BetaBrowserToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserToolUseBlockName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaBrowserToolUseBlockName.Navigate)]
    [InlineData(BetaBrowserToolUseBlockName.ListTabs)]
    [InlineData(BetaBrowserToolUseBlockName.NewTab)]
    [InlineData(BetaBrowserToolUseBlockName.SwitchTab)]
    [InlineData(BetaBrowserToolUseBlockName.CloseTab)]
    [InlineData(BetaBrowserToolUseBlockName.ReadPage)]
    [InlineData(BetaBrowserToolUseBlockName.GetPageText)]
    [InlineData(BetaBrowserToolUseBlockName.ReadConsole)]
    [InlineData(BetaBrowserToolUseBlockName.ReadNetwork)]
    [InlineData(BetaBrowserToolUseBlockName.Find)]
    [InlineData(BetaBrowserToolUseBlockName.FormInput)]
    [InlineData(BetaBrowserToolUseBlockName.FileUpload)]
    [InlineData(BetaBrowserToolUseBlockName.ScrollTo)]
    [InlineData(BetaBrowserToolUseBlockName.Screenshot)]
    [InlineData(BetaBrowserToolUseBlockName.Zoom)]
    [InlineData(BetaBrowserToolUseBlockName.LeftClick)]
    [InlineData(BetaBrowserToolUseBlockName.RightClick)]
    [InlineData(BetaBrowserToolUseBlockName.MiddleClick)]
    [InlineData(BetaBrowserToolUseBlockName.DoubleClick)]
    [InlineData(BetaBrowserToolUseBlockName.TripleClick)]
    [InlineData(BetaBrowserToolUseBlockName.Hover)]
    [InlineData(BetaBrowserToolUseBlockName.LeftClickDrag)]
    [InlineData(BetaBrowserToolUseBlockName.LeftMouseDown)]
    [InlineData(BetaBrowserToolUseBlockName.LeftMouseUp)]
    [InlineData(BetaBrowserToolUseBlockName.MouseMove)]
    [InlineData(BetaBrowserToolUseBlockName.Scroll)]
    [InlineData(BetaBrowserToolUseBlockName.Type)]
    [InlineData(BetaBrowserToolUseBlockName.Key)]
    [InlineData(BetaBrowserToolUseBlockName.HoldKey)]
    [InlineData(BetaBrowserToolUseBlockName.Wait)]
    [InlineData(BetaBrowserToolUseBlockName.JavascriptExec)]
    public void SerializationRoundtrip_Works(BetaBrowserToolUseBlockName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaBrowserToolUseBlockName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserToolUseBlockName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserToolUseBlockName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BetaBrowserToolUseBlockName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
