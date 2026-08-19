using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Per-member configuration for ``browser_toolset_20260801``: one optional field
/// per member tool, keyed by the member name — the same name the member's ``tool_use``
/// blocks carry. Every member is an accepted key, and a member's defaults apply wherever
/// its key is absent. Unknown keys are rejected: the field set is this toolset version's
/// complete member set.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserToolsetConfigs, BetaBrowserToolsetConfigsFromRaw>)
)]
public sealed record class BetaBrowserToolsetConfigs : JsonModel
{
    /// <summary>
    /// ``close_tab``'s config overrides.
    /// </summary>
    public BetaBrowserCloseTabConfig? CloseTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserCloseTabConfig>("close_tab");
        }
        init { this._rawData.Set("close_tab", value); }
    }

    /// <summary>
    /// ``double_click``'s config overrides.
    /// </summary>
    public BetaBrowserDoubleClickConfig? DoubleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserDoubleClickConfig>("double_click");
        }
        init { this._rawData.Set("double_click", value); }
    }

    /// <summary>
    /// ``file_upload``'s config overrides.
    /// </summary>
    public BetaBrowserFileUploadConfig? FileUpload
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserFileUploadConfig>("file_upload");
        }
        init { this._rawData.Set("file_upload", value); }
    }

    /// <summary>
    /// ``find``'s config overrides.
    /// </summary>
    public BetaBrowserFindConfig? Find
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserFindConfig>("find");
        }
        init { this._rawData.Set("find", value); }
    }

    /// <summary>
    /// ``form_input``'s config overrides.
    /// </summary>
    public BetaBrowserFormInputConfig? FormInput
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserFormInputConfig>("form_input");
        }
        init { this._rawData.Set("form_input", value); }
    }

    /// <summary>
    /// ``get_page_text``'s config overrides.
    /// </summary>
    public BetaBrowserGetPageTextConfig? GetPageText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserGetPageTextConfig>("get_page_text");
        }
        init { this._rawData.Set("get_page_text", value); }
    }

    /// <summary>
    /// ``hold_key``'s config overrides.
    /// </summary>
    public BetaBrowserHoldKeyConfig? HoldKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserHoldKeyConfig>("hold_key");
        }
        init { this._rawData.Set("hold_key", value); }
    }

    /// <summary>
    /// ``hover``'s config overrides.
    /// </summary>
    public BetaBrowserHoverConfig? Hover
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserHoverConfig>("hover");
        }
        init { this._rawData.Set("hover", value); }
    }

    /// <summary>
    /// ``javascript_exec``'s config overrides.
    /// </summary>
    public BetaBrowserJavascriptExecConfig? JavascriptExec
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserJavascriptExecConfig>(
                "javascript_exec"
            );
        }
        init { this._rawData.Set("javascript_exec", value); }
    }

    /// <summary>
    /// ``key``'s config overrides.
    /// </summary>
    public BetaBrowserKeyConfig? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserKeyConfig>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// ``left_click``'s config overrides.
    /// </summary>
    public BetaBrowserLeftClickConfig? LeftClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserLeftClickConfig>("left_click");
        }
        init { this._rawData.Set("left_click", value); }
    }

    /// <summary>
    /// ``left_click_drag``'s config overrides.
    /// </summary>
    public BetaBrowserLeftClickDragConfig? LeftClickDrag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserLeftClickDragConfig>(
                "left_click_drag"
            );
        }
        init { this._rawData.Set("left_click_drag", value); }
    }

    /// <summary>
    /// ``left_mouse_down``'s config overrides.
    /// </summary>
    public BetaBrowserLeftMouseDownConfig? LeftMouseDown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserLeftMouseDownConfig>(
                "left_mouse_down"
            );
        }
        init { this._rawData.Set("left_mouse_down", value); }
    }

    /// <summary>
    /// ``left_mouse_up``'s config overrides.
    /// </summary>
    public BetaBrowserLeftMouseUpConfig? LeftMouseUp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserLeftMouseUpConfig>("left_mouse_up");
        }
        init { this._rawData.Set("left_mouse_up", value); }
    }

    /// <summary>
    /// ``list_tabs``'s config overrides.
    /// </summary>
    public BetaBrowserListTabsConfig? ListTabs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserListTabsConfig>("list_tabs");
        }
        init { this._rawData.Set("list_tabs", value); }
    }

    /// <summary>
    /// ``middle_click``'s config overrides.
    /// </summary>
    public BetaBrowserMiddleClickConfig? MiddleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserMiddleClickConfig>("middle_click");
        }
        init { this._rawData.Set("middle_click", value); }
    }

    /// <summary>
    /// ``mouse_move``'s config overrides.
    /// </summary>
    public BetaBrowserMouseMoveConfig? MouseMove
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserMouseMoveConfig>("mouse_move");
        }
        init { this._rawData.Set("mouse_move", value); }
    }

    /// <summary>
    /// ``navigate``'s config overrides.
    /// </summary>
    public BetaBrowserNavigateConfig? Navigate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserNavigateConfig>("navigate");
        }
        init { this._rawData.Set("navigate", value); }
    }

    /// <summary>
    /// ``new_tab``'s config overrides.
    /// </summary>
    public BetaBrowserNewTabConfig? NewTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserNewTabConfig>("new_tab");
        }
        init { this._rawData.Set("new_tab", value); }
    }

    /// <summary>
    /// ``read_console``'s config overrides.
    /// </summary>
    public BetaBrowserReadConsoleConfig? ReadConsole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserReadConsoleConfig>("read_console");
        }
        init { this._rawData.Set("read_console", value); }
    }

    /// <summary>
    /// ``read_network``'s config overrides.
    /// </summary>
    public BetaBrowserReadNetworkConfig? ReadNetwork
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserReadNetworkConfig>("read_network");
        }
        init { this._rawData.Set("read_network", value); }
    }

    /// <summary>
    /// ``read_page``'s config overrides.
    /// </summary>
    public BetaBrowserReadPageConfig? ReadPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserReadPageConfig>("read_page");
        }
        init { this._rawData.Set("read_page", value); }
    }

    /// <summary>
    /// ``right_click``'s config overrides.
    /// </summary>
    public BetaBrowserRightClickConfig? RightClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserRightClickConfig>("right_click");
        }
        init { this._rawData.Set("right_click", value); }
    }

    /// <summary>
    /// ``screenshot``'s config overrides.
    /// </summary>
    public BetaBrowserScreenshotConfig? Screenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserScreenshotConfig>("screenshot");
        }
        init { this._rawData.Set("screenshot", value); }
    }

    /// <summary>
    /// ``scroll``'s config overrides.
    /// </summary>
    public BetaBrowserScrollConfig? Scroll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserScrollConfig>("scroll");
        }
        init { this._rawData.Set("scroll", value); }
    }

    /// <summary>
    /// ``scroll_to``'s config overrides.
    /// </summary>
    public BetaBrowserScrollToConfig? ScrollTo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserScrollToConfig>("scroll_to");
        }
        init { this._rawData.Set("scroll_to", value); }
    }

    /// <summary>
    /// ``switch_tab``'s config overrides.
    /// </summary>
    public BetaBrowserSwitchTabConfig? SwitchTab
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserSwitchTabConfig>("switch_tab");
        }
        init { this._rawData.Set("switch_tab", value); }
    }

    /// <summary>
    /// ``triple_click``'s config overrides.
    /// </summary>
    public BetaBrowserTripleClickConfig? TripleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserTripleClickConfig>("triple_click");
        }
        init { this._rawData.Set("triple_click", value); }
    }

    /// <summary>
    /// ``type``'s config overrides.
    /// </summary>
    public BetaBrowserTypeConfig? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserTypeConfig>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ``wait``'s config overrides.
    /// </summary>
    public BetaBrowserWaitConfig? Wait
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserWaitConfig>("wait");
        }
        init { this._rawData.Set("wait", value); }
    }

    /// <summary>
    /// ``zoom``'s config overrides.
    /// </summary>
    public BetaBrowserZoomConfig? Zoom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaBrowserZoomConfig>("zoom");
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

    public BetaBrowserToolsetConfigs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserToolsetConfigs(BetaBrowserToolsetConfigs betaBrowserToolsetConfigs)
        : base(betaBrowserToolsetConfigs) { }
#pragma warning restore CS8618

    public BetaBrowserToolsetConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserToolsetConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserToolsetConfigsFromRaw.FromRawUnchecked"/>
    public static BetaBrowserToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserToolsetConfigsFromRaw : IFromRawJson<BetaBrowserToolsetConfigs>
{
    /// <inheritdoc/>
    public BetaBrowserToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserToolsetConfigs.FromRawUnchecked(rawData);
}
