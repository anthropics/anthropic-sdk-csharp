using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Per-member configuration for ``computer_toolset_20260801``: one optional field
/// per member tool, keyed by the member name — the same name the member's ``tool_use``
/// blocks carry. Every member is an accepted key, and a member's defaults apply wherever
/// its key is absent. Unknown keys are rejected: the field set is this toolset version's
/// complete member set.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerToolsetConfigs, BetaComputerToolsetConfigsFromRaw>)
)]
public sealed record class BetaComputerToolsetConfigs : JsonModel
{
    /// <summary>
    /// ``cursor_position``'s config overrides.
    /// </summary>
    public BetaComputerCursorPositionConfig? CursorPosition
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerCursorPositionConfig>(
                "cursor_position"
            );
        }
        init { this._rawData.Set("cursor_position", value); }
    }

    /// <summary>
    /// ``double_click``'s config overrides.
    /// </summary>
    public BetaComputerDoubleClickConfig? DoubleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerDoubleClickConfig>("double_click");
        }
        init { this._rawData.Set("double_click", value); }
    }

    /// <summary>
    /// ``hold_key``'s config overrides.
    /// </summary>
    public BetaComputerHoldKeyConfig? HoldKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerHoldKeyConfig>("hold_key");
        }
        init { this._rawData.Set("hold_key", value); }
    }

    /// <summary>
    /// ``key``'s config overrides.
    /// </summary>
    public BetaComputerKeyConfig? Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerKeyConfig>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <summary>
    /// ``left_click``'s config overrides.
    /// </summary>
    public BetaComputerLeftClickConfig? LeftClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerLeftClickConfig>("left_click");
        }
        init { this._rawData.Set("left_click", value); }
    }

    /// <summary>
    /// ``left_click_drag``'s config overrides.
    /// </summary>
    public BetaComputerLeftClickDragConfig? LeftClickDrag
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerLeftClickDragConfig>(
                "left_click_drag"
            );
        }
        init { this._rawData.Set("left_click_drag", value); }
    }

    /// <summary>
    /// ``left_mouse_down``'s config overrides.
    /// </summary>
    public BetaComputerLeftMouseDownConfig? LeftMouseDown
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerLeftMouseDownConfig>(
                "left_mouse_down"
            );
        }
        init { this._rawData.Set("left_mouse_down", value); }
    }

    /// <summary>
    /// ``left_mouse_up``'s config overrides.
    /// </summary>
    public BetaComputerLeftMouseUpConfig? LeftMouseUp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerLeftMouseUpConfig>("left_mouse_up");
        }
        init { this._rawData.Set("left_mouse_up", value); }
    }

    /// <summary>
    /// ``middle_click``'s config overrides.
    /// </summary>
    public BetaComputerMiddleClickConfig? MiddleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerMiddleClickConfig>("middle_click");
        }
        init { this._rawData.Set("middle_click", value); }
    }

    /// <summary>
    /// ``mouse_move``'s config overrides.
    /// </summary>
    public BetaComputerMouseMoveConfig? MouseMove
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerMouseMoveConfig>("mouse_move");
        }
        init { this._rawData.Set("mouse_move", value); }
    }

    /// <summary>
    /// ``right_click``'s config overrides.
    /// </summary>
    public BetaComputerRightClickConfig? RightClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerRightClickConfig>("right_click");
        }
        init { this._rawData.Set("right_click", value); }
    }

    /// <summary>
    /// ``screenshot``'s config overrides.
    /// </summary>
    public BetaComputerScreenshotConfig? Screenshot
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerScreenshotConfig>("screenshot");
        }
        init { this._rawData.Set("screenshot", value); }
    }

    /// <summary>
    /// ``scroll``'s config overrides.
    /// </summary>
    public BetaComputerScrollConfig? Scroll
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerScrollConfig>("scroll");
        }
        init { this._rawData.Set("scroll", value); }
    }

    /// <summary>
    /// ``triple_click``'s config overrides.
    /// </summary>
    public BetaComputerTripleClickConfig? TripleClick
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerTripleClickConfig>("triple_click");
        }
        init { this._rawData.Set("triple_click", value); }
    }

    /// <summary>
    /// ``type``'s config overrides.
    /// </summary>
    public BetaComputerTypeConfig? Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerTypeConfig>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ``wait``'s config overrides.
    /// </summary>
    public BetaComputerWaitConfig? Wait
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerWaitConfig>("wait");
        }
        init { this._rawData.Set("wait", value); }
    }

    /// <summary>
    /// ``zoom``'s config overrides.
    /// </summary>
    public BetaComputerZoomConfig? Zoom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaComputerZoomConfig>("zoom");
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

    public BetaComputerToolsetConfigs() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerToolsetConfigs(BetaComputerToolsetConfigs betaComputerToolsetConfigs)
        : base(betaComputerToolsetConfigs) { }
#pragma warning restore CS8618

    public BetaComputerToolsetConfigs(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerToolsetConfigs(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerToolsetConfigsFromRaw.FromRawUnchecked"/>
    public static BetaComputerToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerToolsetConfigsFromRaw : IFromRawJson<BetaComputerToolsetConfigs>
{
    /// <inheritdoc/>
    public BetaComputerToolsetConfigs FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerToolsetConfigs.FromRawUnchecked(rawData);
}
