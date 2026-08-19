using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Per-member configuration for ``browser_toolset_20260801``: one optional field
/// per member tool, keyed by the member name — the same name the member's ``tool_use``
/// blocks carry. Every member is an accepted key, and a member's defaults apply wherever
/// its key is absent. Unknown keys are rejected: the field set is this toolset version's
/// complete member set.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserToolsetConfigs, BrowserToolsetConfigsFromRaw>))]
public sealed record class BrowserToolsetConfigs : JsonModel
{
    /// <summary>
    /// ``close_tab``'s config overrides.
    /// </summary>
    public BrowserCloseTabConfig? CloseTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserCloseTabConfig>("close_tab");
        }
        init { this._rawData.Set("close_tab", value); }
    }

    /// <summary>
    /// ``double_click``'s config overrides.
    /// </summary>
    public BrowserDoubleClickConfig? DoubleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserDoubleClickConfig>("double_click");
        }
        init { this._rawData.Set("double_click", value); }
    }

    /// <summary>
    /// ``file_upload``'s config overrides.
    /// </summary>
    public BrowserFileUploadConfig? FileUpload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserFileUploadConfig>("file_upload");
        }
        init { this._rawData.Set("file_upload", value); }
    }

    /// <summary>
    /// ``find``'s config overrides.
    /// </summary>
    public BrowserFindConfig? Find
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserFindConfig>("find");
        }
        init { this._rawData.Set("find", value); }
    }

    /// <summary>
    /// ``form_input``'s config overrides.
    /// </summary>
    public BrowserFormInputConfig? FormInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserFormInputConfig>("form_input");
        }
        init { this._rawData.Set("form_input", value); }
    }

    /// <summary>
    /// ``get_page_text``'s config overrides.
    /// </summary>
    public BrowserGetPageTextConfig? GetPageText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserGetPageTextConfig>("get_page_text");
        }
        init { this._rawData.Set("get_page_text", value); }
    }

    /// <summary>
    /// ``hold_key``'s config overrides.
    /// </summary>
    public BrowserHoldKeyConfig? HoldKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserHoldKeyConfig>("hold_key");
        }
        init { this._rawData.Set("hold_key", value); }
    }

    /// <summary>
    /// ``hover``'s config overrides.
    /// </summary>
    public BrowserHoverConfig? Hover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserHoverConfig>("hover");
        }
        init { this._rawData.Set("hover", value); }
    }

    /// <summary>
    /// ``javascript_exec``'s config overrides.
    /// </summary>
    public BrowserJavascriptExecConfig? JavascriptExec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserJavascriptExecConfig>("javascript_exec");
        }
        init { this._rawData.Set("javascript_exec", value); }
    }

    /// <summary>
    /// ``key``'s config overrides.
    /// </summary>
    public BrowserKeyConfig? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserKeyConfig>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// ``left_click``'s config overrides.
    /// </summary>
    public BrowserLeftClickConfig? LeftClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserLeftClickConfig>("left_click");
        }
        init { this._rawData.Set("left_click", value); }
    }

    /// <summary>
    /// ``left_click_drag``'s config overrides.
    /// </summary>
    public BrowserLeftClickDragConfig? LeftClickDrag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserLeftClickDragConfig>("left_click_drag");
        }
        init { this._rawData.Set("left_click_drag", value); }
    }

    /// <summary>
    /// ``left_mouse_down``'s config overrides.
    /// </summary>
    public BrowserLeftMouseDownConfig? LeftMouseDown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserLeftMouseDownConfig>("left_mouse_down");
        }
        init { this._rawData.Set("left_mouse_down", value); }
    }

    /// <summary>
    /// ``left_mouse_up``'s config overrides.
    /// </summary>
    public BrowserLeftMouseUpConfig? LeftMouseUp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserLeftMouseUpConfig>("left_mouse_up");
        }
        init { this._rawData.Set("left_mouse_up", value); }
    }

    /// <summary>
    /// ``list_tabs``'s config overrides.
    /// </summary>
    public BrowserListTabsConfig? ListTabs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserListTabsConfig>("list_tabs");
        }
        init { this._rawData.Set("list_tabs", value); }
    }

    /// <summary>
    /// ``middle_click``'s config overrides.
    /// </summary>
    public BrowserMiddleClickConfig? MiddleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserMiddleClickConfig>("middle_click");
        }
        init { this._rawData.Set("middle_click", value); }
    }

    /// <summary>
    /// ``mouse_move``'s config overrides.
    /// </summary>
    public BrowserMouseMoveConfig? MouseMove
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserMouseMoveConfig>("mouse_move");
        }
        init { this._rawData.Set("mouse_move", value); }
    }

    /// <summary>
    /// ``navigate``'s config overrides.
    /// </summary>
    public BrowserNavigateConfig? Navigate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserNavigateConfig>("navigate");
        }
        init { this._rawData.Set("navigate", value); }
    }

    /// <summary>
    /// ``new_tab``'s config overrides.
    /// </summary>
    public BrowserNewTabConfig? NewTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserNewTabConfig>("new_tab");
        }
        init { this._rawData.Set("new_tab", value); }
    }

    /// <summary>
    /// ``read_console``'s config overrides.
    /// </summary>
    public BrowserReadConsoleConfig? ReadConsole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserReadConsoleConfig>("read_console");
        }
        init { this._rawData.Set("read_console", value); }
    }

    /// <summary>
    /// ``read_network``'s config overrides.
    /// </summary>
    public BrowserReadNetworkConfig? ReadNetwork
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserReadNetworkConfig>("read_network");
        }
        init { this._rawData.Set("read_network", value); }
    }

    /// <summary>
    /// ``read_page``'s config overrides.
    /// </summary>
    public BrowserReadPageConfig? ReadPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserReadPageConfig>("read_page");
        }
        init { this._rawData.Set("read_page", value); }
    }

    /// <summary>
    /// ``right_click``'s config overrides.
    /// </summary>
    public BrowserRightClickConfig? RightClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserRightClickConfig>("right_click");
        }
        init { this._rawData.Set("right_click", value); }
    }

    /// <summary>
    /// ``screenshot``'s config overrides.
    /// </summary>
    public BrowserScreenshotConfig? Screenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserScreenshotConfig>("screenshot");
        }
        init { this._rawData.Set("screenshot", value); }
    }

    /// <summary>
    /// ``scroll``'s config overrides.
    /// </summary>
    public BrowserScrollConfig? Scroll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserScrollConfig>("scroll");
        }
        init { this._rawData.Set("scroll", value); }
    }

    /// <summary>
    /// ``scroll_to``'s config overrides.
    /// </summary>
    public BrowserScrollToConfig? ScrollTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserScrollToConfig>("scroll_to");
        }
        init { this._rawData.Set("scroll_to", value); }
    }

    /// <summary>
    /// ``switch_tab``'s config overrides.
    /// </summary>
    public BrowserSwitchTabConfig? SwitchTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserSwitchTabConfig>("switch_tab");
        }
        init { this._rawData.Set("switch_tab", value); }
    }

    /// <summary>
    /// ``triple_click``'s config overrides.
    /// </summary>
    public BrowserTripleClickConfig? TripleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserTripleClickConfig>("triple_click");
        }
        init { this._rawData.Set("triple_click", value); }
    }

    /// <summary>
    /// ``type``'s config overrides.
    /// </summary>
    public BrowserTypeConfig? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserTypeConfig>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ``wait``'s config overrides.
    /// </summary>
    public BrowserWaitConfig? Wait
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserWaitConfig>("wait");
        }
        init { this._rawData.Set("wait", value); }
    }

    /// <summary>
    /// ``zoom``'s config overrides.
    /// </summary>
    public BrowserZoomConfig? Zoom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BrowserZoomConfig>("zoom");
        }
        init { this._rawData.Set("zoom", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CloseTab?.Validate();
        this.DoubleClick?.Validate();
        this.FileUpload?.Validate();
        this.Find?.Validate();
        this.FormInput?.Validate();
        this.GetPageText?.Validate();
        this.HoldKey?.Validate();
        this.Hover?.Validate();
        this.JavascriptExec?.Validate();
        this.Key?.Validate();
        this.LeftClick?.Validate();
        this.LeftClickDrag?.Validate();
        this.LeftMouseDown?.Validate();
        this.LeftMouseUp?.Validate();
        this.ListTabs?.Validate();
        this.MiddleClick?.Validate();
        this.MouseMove?.Validate();
        this.Navigate?.Validate();
        this.NewTab?.Validate();
        this.ReadConsole?.Validate();
        this.ReadNetwork?.Validate();
        this.ReadPage?.Validate();
        this.RightClick?.Validate();
        this.Screenshot?.Validate();
        this.Scroll?.Validate();
        this.ScrollTo?.Validate();
        this.SwitchTab?.Validate();
        this.TripleClick?.Validate();
        this.Type?.Validate();
        this.Wait?.Validate();
        this.Zoom?.Validate();
    }

    public BrowserToolsetConfigs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserToolsetConfigs(BrowserToolsetConfigs browserToolsetConfigs)
        : base(browserToolsetConfigs) { }
#pragma warning restore CS8618

    public BrowserToolsetConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserToolsetConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserToolsetConfigsFromRaw.FromRawUnchecked"/>
    public static BrowserToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserToolsetConfigsFromRaw : IFromRawJson<BrowserToolsetConfigs>
{
    /// <inheritdoc/>
    public BrowserToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserToolsetConfigs.FromRawUnchecked(rawData);
}
