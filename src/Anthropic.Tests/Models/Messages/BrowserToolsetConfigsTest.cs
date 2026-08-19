using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserToolsetConfigsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserToolsetConfigs
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        BrowserCloseTabConfig expectedCloseTab = new() { DeferLoading = true, Enabled = true };
        BrowserDoubleClickConfig expectedDoubleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserFileUploadConfig expectedFileUpload = new() { DeferLoading = true, Enabled = true };
        BrowserFindConfig expectedFind = new() { DeferLoading = true, Enabled = true };
        BrowserFormInputConfig expectedFormInput = new() { DeferLoading = true, Enabled = true };
        BrowserGetPageTextConfig expectedGetPageText = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserHoldKeyConfig expectedHoldKey = new() { DeferLoading = true, Enabled = true };
        BrowserHoverConfig expectedHover = new() { DeferLoading = true, Enabled = true };
        BrowserJavascriptExecConfig expectedJavascriptExec = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserKeyConfig expectedKey = new() { DeferLoading = true, Enabled = true };
        BrowserLeftClickConfig expectedLeftClick = new() { DeferLoading = true, Enabled = true };
        BrowserLeftClickDragConfig expectedLeftClickDrag = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserLeftMouseDownConfig expectedLeftMouseDown = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserLeftMouseUpConfig expectedLeftMouseUp = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserListTabsConfig expectedListTabs = new() { DeferLoading = true, Enabled = true };
        BrowserMiddleClickConfig expectedMiddleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserMouseMoveConfig expectedMouseMove = new() { DeferLoading = true, Enabled = true };
        BrowserNavigateConfig expectedNavigate = new() { DeferLoading = true, Enabled = true };
        BrowserNewTabConfig expectedNewTab = new() { DeferLoading = true, Enabled = true };
        BrowserReadConsoleConfig expectedReadConsole = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserReadNetworkConfig expectedReadNetwork = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserReadPageConfig expectedReadPage = new() { DeferLoading = true, Enabled = true };
        BrowserRightClickConfig expectedRightClick = new() { DeferLoading = true, Enabled = true };
        BrowserScreenshotConfig expectedScreenshot = new() { DeferLoading = true, Enabled = true };
        BrowserScrollConfig expectedScroll = new() { DeferLoading = true, Enabled = true };
        BrowserScrollToConfig expectedScrollTo = new() { DeferLoading = true, Enabled = true };
        BrowserSwitchTabConfig expectedSwitchTab = new() { DeferLoading = true, Enabled = true };
        BrowserTripleClickConfig expectedTripleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserTypeConfig expectedType = new() { DeferLoading = true, Enabled = true };
        BrowserWaitConfig expectedWait = new() { DeferLoading = true, Enabled = true };
        BrowserZoomConfig expectedZoom = new() { DeferLoading = true, Enabled = true };

        Assert.Equal(expectedCloseTab, model.CloseTab);
        Assert.Equal(expectedDoubleClick, model.DoubleClick);
        Assert.Equal(expectedFileUpload, model.FileUpload);
        Assert.Equal(expectedFind, model.Find);
        Assert.Equal(expectedFormInput, model.FormInput);
        Assert.Equal(expectedGetPageText, model.GetPageText);
        Assert.Equal(expectedHoldKey, model.HoldKey);
        Assert.Equal(expectedHover, model.Hover);
        Assert.Equal(expectedJavascriptExec, model.JavascriptExec);
        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedLeftClick, model.LeftClick);
        Assert.Equal(expectedLeftClickDrag, model.LeftClickDrag);
        Assert.Equal(expectedLeftMouseDown, model.LeftMouseDown);
        Assert.Equal(expectedLeftMouseUp, model.LeftMouseUp);
        Assert.Equal(expectedListTabs, model.ListTabs);
        Assert.Equal(expectedMiddleClick, model.MiddleClick);
        Assert.Equal(expectedMouseMove, model.MouseMove);
        Assert.Equal(expectedNavigate, model.Navigate);
        Assert.Equal(expectedNewTab, model.NewTab);
        Assert.Equal(expectedReadConsole, model.ReadConsole);
        Assert.Equal(expectedReadNetwork, model.ReadNetwork);
        Assert.Equal(expectedReadPage, model.ReadPage);
        Assert.Equal(expectedRightClick, model.RightClick);
        Assert.Equal(expectedScreenshot, model.Screenshot);
        Assert.Equal(expectedScroll, model.Scroll);
        Assert.Equal(expectedScrollTo, model.ScrollTo);
        Assert.Equal(expectedSwitchTab, model.SwitchTab);
        Assert.Equal(expectedTripleClick, model.TripleClick);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWait, model.Wait);
        Assert.Equal(expectedZoom, model.Zoom);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserToolsetConfigs
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolsetConfigs>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserToolsetConfigs
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserToolsetConfigs>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BrowserCloseTabConfig expectedCloseTab = new() { DeferLoading = true, Enabled = true };
        BrowserDoubleClickConfig expectedDoubleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserFileUploadConfig expectedFileUpload = new() { DeferLoading = true, Enabled = true };
        BrowserFindConfig expectedFind = new() { DeferLoading = true, Enabled = true };
        BrowserFormInputConfig expectedFormInput = new() { DeferLoading = true, Enabled = true };
        BrowserGetPageTextConfig expectedGetPageText = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserHoldKeyConfig expectedHoldKey = new() { DeferLoading = true, Enabled = true };
        BrowserHoverConfig expectedHover = new() { DeferLoading = true, Enabled = true };
        BrowserJavascriptExecConfig expectedJavascriptExec = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserKeyConfig expectedKey = new() { DeferLoading = true, Enabled = true };
        BrowserLeftClickConfig expectedLeftClick = new() { DeferLoading = true, Enabled = true };
        BrowserLeftClickDragConfig expectedLeftClickDrag = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserLeftMouseDownConfig expectedLeftMouseDown = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserLeftMouseUpConfig expectedLeftMouseUp = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserListTabsConfig expectedListTabs = new() { DeferLoading = true, Enabled = true };
        BrowserMiddleClickConfig expectedMiddleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserMouseMoveConfig expectedMouseMove = new() { DeferLoading = true, Enabled = true };
        BrowserNavigateConfig expectedNavigate = new() { DeferLoading = true, Enabled = true };
        BrowserNewTabConfig expectedNewTab = new() { DeferLoading = true, Enabled = true };
        BrowserReadConsoleConfig expectedReadConsole = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserReadNetworkConfig expectedReadNetwork = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserReadPageConfig expectedReadPage = new() { DeferLoading = true, Enabled = true };
        BrowserRightClickConfig expectedRightClick = new() { DeferLoading = true, Enabled = true };
        BrowserScreenshotConfig expectedScreenshot = new() { DeferLoading = true, Enabled = true };
        BrowserScrollConfig expectedScroll = new() { DeferLoading = true, Enabled = true };
        BrowserScrollToConfig expectedScrollTo = new() { DeferLoading = true, Enabled = true };
        BrowserSwitchTabConfig expectedSwitchTab = new() { DeferLoading = true, Enabled = true };
        BrowserTripleClickConfig expectedTripleClick = new()
        {
            DeferLoading = true,
            Enabled = true,
        };
        BrowserTypeConfig expectedType = new() { DeferLoading = true, Enabled = true };
        BrowserWaitConfig expectedWait = new() { DeferLoading = true, Enabled = true };
        BrowserZoomConfig expectedZoom = new() { DeferLoading = true, Enabled = true };

        Assert.Equal(expectedCloseTab, deserialized.CloseTab);
        Assert.Equal(expectedDoubleClick, deserialized.DoubleClick);
        Assert.Equal(expectedFileUpload, deserialized.FileUpload);
        Assert.Equal(expectedFind, deserialized.Find);
        Assert.Equal(expectedFormInput, deserialized.FormInput);
        Assert.Equal(expectedGetPageText, deserialized.GetPageText);
        Assert.Equal(expectedHoldKey, deserialized.HoldKey);
        Assert.Equal(expectedHover, deserialized.Hover);
        Assert.Equal(expectedJavascriptExec, deserialized.JavascriptExec);
        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedLeftClick, deserialized.LeftClick);
        Assert.Equal(expectedLeftClickDrag, deserialized.LeftClickDrag);
        Assert.Equal(expectedLeftMouseDown, deserialized.LeftMouseDown);
        Assert.Equal(expectedLeftMouseUp, deserialized.LeftMouseUp);
        Assert.Equal(expectedListTabs, deserialized.ListTabs);
        Assert.Equal(expectedMiddleClick, deserialized.MiddleClick);
        Assert.Equal(expectedMouseMove, deserialized.MouseMove);
        Assert.Equal(expectedNavigate, deserialized.Navigate);
        Assert.Equal(expectedNewTab, deserialized.NewTab);
        Assert.Equal(expectedReadConsole, deserialized.ReadConsole);
        Assert.Equal(expectedReadNetwork, deserialized.ReadNetwork);
        Assert.Equal(expectedReadPage, deserialized.ReadPage);
        Assert.Equal(expectedRightClick, deserialized.RightClick);
        Assert.Equal(expectedScreenshot, deserialized.Screenshot);
        Assert.Equal(expectedScroll, deserialized.Scroll);
        Assert.Equal(expectedScrollTo, deserialized.ScrollTo);
        Assert.Equal(expectedSwitchTab, deserialized.SwitchTab);
        Assert.Equal(expectedTripleClick, deserialized.TripleClick);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWait, deserialized.Wait);
        Assert.Equal(expectedZoom, deserialized.Zoom);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserToolsetConfigs
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
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
        var model = new BrowserToolsetConfigs { };

        Assert.Null(model.CloseTab);
        Assert.False(model.RawData.ContainsKey("close_tab"));
        Assert.Null(model.DoubleClick);
        Assert.False(model.RawData.ContainsKey("double_click"));
        Assert.Null(model.FileUpload);
        Assert.False(model.RawData.ContainsKey("file_upload"));
        Assert.Null(model.Find);
        Assert.False(model.RawData.ContainsKey("find"));
        Assert.Null(model.FormInput);
        Assert.False(model.RawData.ContainsKey("form_input"));
        Assert.Null(model.GetPageText);
        Assert.False(model.RawData.ContainsKey("get_page_text"));
        Assert.Null(model.HoldKey);
        Assert.False(model.RawData.ContainsKey("hold_key"));
        Assert.Null(model.Hover);
        Assert.False(model.RawData.ContainsKey("hover"));
        Assert.Null(model.JavascriptExec);
        Assert.False(model.RawData.ContainsKey("javascript_exec"));
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
        Assert.Null(model.ListTabs);
        Assert.False(model.RawData.ContainsKey("list_tabs"));
        Assert.Null(model.MiddleClick);
        Assert.False(model.RawData.ContainsKey("middle_click"));
        Assert.Null(model.MouseMove);
        Assert.False(model.RawData.ContainsKey("mouse_move"));
        Assert.Null(model.Navigate);
        Assert.False(model.RawData.ContainsKey("navigate"));
        Assert.Null(model.NewTab);
        Assert.False(model.RawData.ContainsKey("new_tab"));
        Assert.Null(model.ReadConsole);
        Assert.False(model.RawData.ContainsKey("read_console"));
        Assert.Null(model.ReadNetwork);
        Assert.False(model.RawData.ContainsKey("read_network"));
        Assert.Null(model.ReadPage);
        Assert.False(model.RawData.ContainsKey("read_page"));
        Assert.Null(model.RightClick);
        Assert.False(model.RawData.ContainsKey("right_click"));
        Assert.Null(model.Screenshot);
        Assert.False(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Scroll);
        Assert.False(model.RawData.ContainsKey("scroll"));
        Assert.Null(model.ScrollTo);
        Assert.False(model.RawData.ContainsKey("scroll_to"));
        Assert.Null(model.SwitchTab);
        Assert.False(model.RawData.ContainsKey("switch_tab"));
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
        var model = new BrowserToolsetConfigs { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrowserToolsetConfigs
        {
            CloseTab = null,
            DoubleClick = null,
            FileUpload = null,
            Find = null,
            FormInput = null,
            GetPageText = null,
            HoldKey = null,
            Hover = null,
            JavascriptExec = null,
            Key = null,
            LeftClick = null,
            LeftClickDrag = null,
            LeftMouseDown = null,
            LeftMouseUp = null,
            ListTabs = null,
            MiddleClick = null,
            MouseMove = null,
            Navigate = null,
            NewTab = null,
            ReadConsole = null,
            ReadNetwork = null,
            ReadPage = null,
            RightClick = null,
            Screenshot = null,
            Scroll = null,
            ScrollTo = null,
            SwitchTab = null,
            TripleClick = null,
            Type = null,
            Wait = null,
            Zoom = null,
        };

        Assert.Null(model.CloseTab);
        Assert.True(model.RawData.ContainsKey("close_tab"));
        Assert.Null(model.DoubleClick);
        Assert.True(model.RawData.ContainsKey("double_click"));
        Assert.Null(model.FileUpload);
        Assert.True(model.RawData.ContainsKey("file_upload"));
        Assert.Null(model.Find);
        Assert.True(model.RawData.ContainsKey("find"));
        Assert.Null(model.FormInput);
        Assert.True(model.RawData.ContainsKey("form_input"));
        Assert.Null(model.GetPageText);
        Assert.True(model.RawData.ContainsKey("get_page_text"));
        Assert.Null(model.HoldKey);
        Assert.True(model.RawData.ContainsKey("hold_key"));
        Assert.Null(model.Hover);
        Assert.True(model.RawData.ContainsKey("hover"));
        Assert.Null(model.JavascriptExec);
        Assert.True(model.RawData.ContainsKey("javascript_exec"));
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
        Assert.Null(model.ListTabs);
        Assert.True(model.RawData.ContainsKey("list_tabs"));
        Assert.Null(model.MiddleClick);
        Assert.True(model.RawData.ContainsKey("middle_click"));
        Assert.Null(model.MouseMove);
        Assert.True(model.RawData.ContainsKey("mouse_move"));
        Assert.Null(model.Navigate);
        Assert.True(model.RawData.ContainsKey("navigate"));
        Assert.Null(model.NewTab);
        Assert.True(model.RawData.ContainsKey("new_tab"));
        Assert.Null(model.ReadConsole);
        Assert.True(model.RawData.ContainsKey("read_console"));
        Assert.Null(model.ReadNetwork);
        Assert.True(model.RawData.ContainsKey("read_network"));
        Assert.Null(model.ReadPage);
        Assert.True(model.RawData.ContainsKey("read_page"));
        Assert.Null(model.RightClick);
        Assert.True(model.RawData.ContainsKey("right_click"));
        Assert.Null(model.Screenshot);
        Assert.True(model.RawData.ContainsKey("screenshot"));
        Assert.Null(model.Scroll);
        Assert.True(model.RawData.ContainsKey("scroll"));
        Assert.Null(model.ScrollTo);
        Assert.True(model.RawData.ContainsKey("scroll_to"));
        Assert.Null(model.SwitchTab);
        Assert.True(model.RawData.ContainsKey("switch_tab"));
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
        var model = new BrowserToolsetConfigs
        {
            CloseTab = null,
            DoubleClick = null,
            FileUpload = null,
            Find = null,
            FormInput = null,
            GetPageText = null,
            HoldKey = null,
            Hover = null,
            JavascriptExec = null,
            Key = null,
            LeftClick = null,
            LeftClickDrag = null,
            LeftMouseDown = null,
            LeftMouseUp = null,
            ListTabs = null,
            MiddleClick = null,
            MouseMove = null,
            Navigate = null,
            NewTab = null,
            ReadConsole = null,
            ReadNetwork = null,
            ReadPage = null,
            RightClick = null,
            Screenshot = null,
            Scroll = null,
            ScrollTo = null,
            SwitchTab = null,
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
        var model = new BrowserToolsetConfigs
        {
            CloseTab = new() { DeferLoading = true, Enabled = true },
            DoubleClick = new() { DeferLoading = true, Enabled = true },
            FileUpload = new() { DeferLoading = true, Enabled = true },
            Find = new() { DeferLoading = true, Enabled = true },
            FormInput = new() { DeferLoading = true, Enabled = true },
            GetPageText = new() { DeferLoading = true, Enabled = true },
            HoldKey = new() { DeferLoading = true, Enabled = true },
            Hover = new() { DeferLoading = true, Enabled = true },
            JavascriptExec = new() { DeferLoading = true, Enabled = true },
            Key = new() { DeferLoading = true, Enabled = true },
            LeftClick = new() { DeferLoading = true, Enabled = true },
            LeftClickDrag = new() { DeferLoading = true, Enabled = true },
            LeftMouseDown = new() { DeferLoading = true, Enabled = true },
            LeftMouseUp = new() { DeferLoading = true, Enabled = true },
            ListTabs = new() { DeferLoading = true, Enabled = true },
            MiddleClick = new() { DeferLoading = true, Enabled = true },
            MouseMove = new() { DeferLoading = true, Enabled = true },
            Navigate = new() { DeferLoading = true, Enabled = true },
            NewTab = new() { DeferLoading = true, Enabled = true },
            ReadConsole = new() { DeferLoading = true, Enabled = true },
            ReadNetwork = new() { DeferLoading = true, Enabled = true },
            ReadPage = new() { DeferLoading = true, Enabled = true },
            RightClick = new() { DeferLoading = true, Enabled = true },
            Screenshot = new() { DeferLoading = true, Enabled = true },
            Scroll = new() { DeferLoading = true, Enabled = true },
            ScrollTo = new() { DeferLoading = true, Enabled = true },
            SwitchTab = new() { DeferLoading = true, Enabled = true },
            TripleClick = new() { DeferLoading = true, Enabled = true },
            Type = new() { DeferLoading = true, Enabled = true },
            Wait = new() { DeferLoading = true, Enabled = true },
            Zoom = new() { DeferLoading = true, Enabled = true },
        };

        BrowserToolsetConfigs copied = new(model);

        Assert.Equal(model, copied);
    }
}
