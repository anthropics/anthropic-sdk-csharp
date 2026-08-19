using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Per-member configuration for ``computer_toolset_20260801``: one optional field
/// per member tool, keyed by the member name — the same name the member's ``tool_use``
/// blocks carry. Every member is an accepted key, and a member's defaults apply wherever
/// its key is absent. Unknown keys are rejected: the field set is this toolset version's
/// complete member set.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerToolsetConfigs, ComputerToolsetConfigsFromRaw>))]
public sealed record class ComputerToolsetConfigs : JsonModel
{
    /// <summary>
    /// ``cursor_position``'s config overrides.
    /// </summary>
    public ComputerCursorPositionConfig? CursorPosition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerCursorPositionConfig>("cursor_position");
        }
        init { this._rawData.Set("cursor_position", value); }
    }

    /// <summary>
    /// ``double_click``'s config overrides.
    /// </summary>
    public ComputerDoubleClickConfig? DoubleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerDoubleClickConfig>("double_click");
        }
        init { this._rawData.Set("double_click", value); }
    }

    /// <summary>
    /// ``hold_key``'s config overrides.
    /// </summary>
    public ComputerHoldKeyConfig? HoldKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerHoldKeyConfig>("hold_key");
        }
        init { this._rawData.Set("hold_key", value); }
    }

    /// <summary>
    /// ``key``'s config overrides.
    /// </summary>
    public ComputerKeyConfig? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerKeyConfig>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// ``left_click``'s config overrides.
    /// </summary>
    public ComputerLeftClickConfig? LeftClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerLeftClickConfig>("left_click");
        }
        init { this._rawData.Set("left_click", value); }
    }

    /// <summary>
    /// ``left_click_drag``'s config overrides.
    /// </summary>
    public ComputerLeftClickDragConfig? LeftClickDrag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerLeftClickDragConfig>("left_click_drag");
        }
        init { this._rawData.Set("left_click_drag", value); }
    }

    /// <summary>
    /// ``left_mouse_down``'s config overrides.
    /// </summary>
    public ComputerLeftMouseDownConfig? LeftMouseDown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerLeftMouseDownConfig>("left_mouse_down");
        }
        init { this._rawData.Set("left_mouse_down", value); }
    }

    /// <summary>
    /// ``left_mouse_up``'s config overrides.
    /// </summary>
    public ComputerLeftMouseUpConfig? LeftMouseUp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerLeftMouseUpConfig>("left_mouse_up");
        }
        init { this._rawData.Set("left_mouse_up", value); }
    }

    /// <summary>
    /// ``middle_click``'s config overrides.
    /// </summary>
    public ComputerMiddleClickConfig? MiddleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerMiddleClickConfig>("middle_click");
        }
        init { this._rawData.Set("middle_click", value); }
    }

    /// <summary>
    /// ``mouse_move``'s config overrides.
    /// </summary>
    public ComputerMouseMoveConfig? MouseMove
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerMouseMoveConfig>("mouse_move");
        }
        init { this._rawData.Set("mouse_move", value); }
    }

    /// <summary>
    /// ``right_click``'s config overrides.
    /// </summary>
    public ComputerRightClickConfig? RightClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerRightClickConfig>("right_click");
        }
        init { this._rawData.Set("right_click", value); }
    }

    /// <summary>
    /// ``screenshot``'s config overrides.
    /// </summary>
    public ComputerScreenshotConfig? Screenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerScreenshotConfig>("screenshot");
        }
        init { this._rawData.Set("screenshot", value); }
    }

    /// <summary>
    /// ``scroll``'s config overrides.
    /// </summary>
    public ComputerScrollConfig? Scroll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerScrollConfig>("scroll");
        }
        init { this._rawData.Set("scroll", value); }
    }

    /// <summary>
    /// ``triple_click``'s config overrides.
    /// </summary>
    public ComputerTripleClickConfig? TripleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerTripleClickConfig>("triple_click");
        }
        init { this._rawData.Set("triple_click", value); }
    }

    /// <summary>
    /// ``type``'s config overrides.
    /// </summary>
    public ComputerTypeConfig? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerTypeConfig>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ``wait``'s config overrides.
    /// </summary>
    public ComputerWaitConfig? Wait
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerWaitConfig>("wait");
        }
        init { this._rawData.Set("wait", value); }
    }

    /// <summary>
    /// ``zoom``'s config overrides.
    /// </summary>
    public ComputerZoomConfig? Zoom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ComputerZoomConfig>("zoom");
        }
        init { this._rawData.Set("zoom", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CursorPosition?.Validate();
        this.DoubleClick?.Validate();
        this.HoldKey?.Validate();
        this.Key?.Validate();
        this.LeftClick?.Validate();
        this.LeftClickDrag?.Validate();
        this.LeftMouseDown?.Validate();
        this.LeftMouseUp?.Validate();
        this.MiddleClick?.Validate();
        this.MouseMove?.Validate();
        this.RightClick?.Validate();
        this.Screenshot?.Validate();
        this.Scroll?.Validate();
        this.TripleClick?.Validate();
        this.Type?.Validate();
        this.Wait?.Validate();
        this.Zoom?.Validate();
    }

    public ComputerToolsetConfigs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerToolsetConfigs(ComputerToolsetConfigs computerToolsetConfigs)
        : base(computerToolsetConfigs) { }
#pragma warning restore CS8618

    public ComputerToolsetConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerToolsetConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerToolsetConfigsFromRaw.FromRawUnchecked"/>
    public static ComputerToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ComputerToolsetConfigsFromRaw : IFromRawJson<ComputerToolsetConfigs>
{
    /// <inheritdoc/>
    public ComputerToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ComputerToolsetConfigs.FromRawUnchecked(rawData);
}
