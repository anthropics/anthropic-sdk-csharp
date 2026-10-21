using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserToolUseBlockTest : TestBase
{
    [Fact]
    public void NavigateValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserNavigateToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Url = "url", TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void ListTabsValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserListTabsToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void NewTabValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserNewTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        value.Validate();
    }

    [Fact]
    public void SwitchTabValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserSwitchTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("tab_id"),
        };
        value.Validate();
    }

    [Fact]
    public void CloseTabValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserCloseTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("tab_id"),
        };
        value.Validate();
    }

    [Fact]
    public void ReadPageValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserReadPageToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void GetPageTextValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserGetPageTextToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void ReadConsoleValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserReadConsoleToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void ReadNetworkValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserReadNetworkToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void FindValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserFindToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Query = "query", TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void FormInputValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserFormInputToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new("ref"),
                Value = "string",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void FileUploadValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserFileUploadToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new("ref"),
                DocumentIds = ["string"],
                Paths = ["string"],
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void ScrollToValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserScrollToToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Target = new("ref"), TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void ScreenshotValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserScreenshotToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void ZoomValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserZoomToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Region = [0, 0, 0, 0], TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void RightClickValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserRightClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void MiddleClickValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserMiddleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void DoubleClickValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserDoubleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void TripleClickValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserTripleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void HoverValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserHoverToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void LeftClickDragValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftClickDragToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseDownValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void LeftMouseUpValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void MouseMoveValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserMouseMoveToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void ScrollValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserScrollToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollDirection = BrowserScrollDirection.Up,
                Target = new() { X = 0, Y = 0 },
                ScrollAmount = 1,
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void TypeValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserTypeToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void KeyValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Text = "text",
                Repeat = 1,
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void HoldKeyValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserHoldKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Duration = 0,
                Text = "text",
                TabID = "tab_id",
            },
        };
        value.Validate();
    }

    [Fact]
    public void WaitValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserWaitToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 0, TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void JavascriptExecValidationWorks()
    {
        BrowserToolUseBlock value = new BrowserJavascriptExecToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", TabID = "tab_id" },
        };
        value.Validate();
    }

    [Fact]
    public void NavigateSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserNavigateToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Url = "url", TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ListTabsSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserListTabsToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NewTabSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserNewTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new(),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SwitchTabSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserSwitchTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("tab_id"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CloseTabSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserCloseTabToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new("tab_id"),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadPageSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserReadPageToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GetPageTextSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserGetPageTextToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadConsoleSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserReadConsoleToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ReadNetworkSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserReadNetworkToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FindSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserFindToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Query = "query", TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FormInputSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserFormInputToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new("ref"),
                Value = "string",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FileUploadSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserFileUploadToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new("ref"),
                DocumentIds = ["string"],
                Paths = ["string"],
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollToSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserScrollToToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Target = new("ref"), TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScreenshotSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserScreenshotToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ZoomSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserZoomToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Region = [0, 0, 0, 0], TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RightClickSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserRightClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MiddleClickSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserMiddleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleClickSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserDoubleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TripleClickSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserTripleClickToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                Modifiers = "modifiers",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoverSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserHoverToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new BrowserCoordinateTarget() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftClickDragSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftClickDragToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseDownSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftMouseDownToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LeftMouseUpSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserLeftMouseUpToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MouseMoveSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserMouseMoveToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ScrollSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserScrollToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollDirection = BrowserScrollDirection.Up,
                Target = new() { X = 0, Y = 0 },
                ScrollAmount = 1,
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TypeSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserTypeToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void KeySerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Text = "text",
                Repeat = 1,
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HoldKeySerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserHoldKeyToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Duration = 0,
                Text = "text",
                TabID = "tab_id",
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WaitSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserWaitToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Duration = 0, TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void JavascriptExecSerializationRoundtripWorks()
    {
        BrowserToolUseBlock value = new BrowserJavascriptExecToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new() { Text = "text", TabID = "tab_id" },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BrowserToolUseBlock value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "caller": {
                    "type": "direct"
                  },
                  "name": "navigate",
                  "toolset_name": "browser",
                  "type": "tool_use"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        JsonElement expectedName = JsonSerializer.SerializeToElement("navigate");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCaller, value.Caller);
        Assert.True(JsonElement.DeepEquals(expectedName, value.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, value.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        BrowserToolUseBlock emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Caller);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Name);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ToolsetName);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BrowserToolUseBlock mismatchedValue = new(
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
