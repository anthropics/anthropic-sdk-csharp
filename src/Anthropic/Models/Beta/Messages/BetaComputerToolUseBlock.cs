using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaComputerToolUseBlockConverter))]
public record class BetaComputerToolUseBlock : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json
    {
        get
        {
            return this._element ??= JsonSerializer.SerializeToElement(
                this.Value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string ID
    {
        get
        {
            return this.Value switch
            {
                BetaComputerKeyToolUseBlock x => x.ID,
                BetaComputerHoldKeyToolUseBlock x => x.ID,
                BetaComputerTypeToolUseBlock x => x.ID,
                BetaComputerCursorPositionToolUseBlock x => x.ID,
                BetaComputerMouseMoveToolUseBlock x => x.ID,
                BetaComputerLeftMouseDownToolUseBlock x => x.ID,
                BetaComputerLeftMouseUpToolUseBlock x => x.ID,
                BetaComputerLeftClickToolUseBlock x => x.ID,
                BetaComputerLeftClickDragToolUseBlock x => x.ID,
                BetaComputerRightClickToolUseBlock x => x.ID,
                BetaComputerMiddleClickToolUseBlock x => x.ID,
                BetaComputerDoubleClickToolUseBlock x => x.ID,
                BetaComputerTripleClickToolUseBlock x => x.ID,
                BetaComputerScrollToolUseBlock x => x.ID,
                BetaComputerWaitToolUseBlock x => x.ID,
                BetaComputerScreenshotToolUseBlock x => x.ID,
                BetaComputerZoomToolUseBlock x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public JsonElement Name
    {
        get
        {
            return this.Value switch
            {
                BetaComputerKeyToolUseBlock x => x.Name,
                BetaComputerHoldKeyToolUseBlock x => x.Name,
                BetaComputerTypeToolUseBlock x => x.Name,
                BetaComputerCursorPositionToolUseBlock x => x.Name,
                BetaComputerMouseMoveToolUseBlock x => x.Name,
                BetaComputerLeftMouseDownToolUseBlock x => x.Name,
                BetaComputerLeftMouseUpToolUseBlock x => x.Name,
                BetaComputerLeftClickToolUseBlock x => x.Name,
                BetaComputerLeftClickDragToolUseBlock x => x.Name,
                BetaComputerRightClickToolUseBlock x => x.Name,
                BetaComputerMiddleClickToolUseBlock x => x.Name,
                BetaComputerDoubleClickToolUseBlock x => x.Name,
                BetaComputerTripleClickToolUseBlock x => x.Name,
                BetaComputerScrollToolUseBlock x => x.Name,
                BetaComputerWaitToolUseBlock x => x.Name,
                BetaComputerScreenshotToolUseBlock x => x.Name,
                BetaComputerZoomToolUseBlock x => x.Name,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "name"),
            };
        }
    }

    public JsonElement ToolsetName
    {
        get
        {
            return this.Value switch
            {
                BetaComputerKeyToolUseBlock x => x.ToolsetName,
                BetaComputerHoldKeyToolUseBlock x => x.ToolsetName,
                BetaComputerTypeToolUseBlock x => x.ToolsetName,
                BetaComputerCursorPositionToolUseBlock x => x.ToolsetName,
                BetaComputerMouseMoveToolUseBlock x => x.ToolsetName,
                BetaComputerLeftMouseDownToolUseBlock x => x.ToolsetName,
                BetaComputerLeftMouseUpToolUseBlock x => x.ToolsetName,
                BetaComputerLeftClickToolUseBlock x => x.ToolsetName,
                BetaComputerLeftClickDragToolUseBlock x => x.ToolsetName,
                BetaComputerRightClickToolUseBlock x => x.ToolsetName,
                BetaComputerMiddleClickToolUseBlock x => x.ToolsetName,
                BetaComputerDoubleClickToolUseBlock x => x.ToolsetName,
                BetaComputerTripleClickToolUseBlock x => x.ToolsetName,
                BetaComputerScrollToolUseBlock x => x.ToolsetName,
                BetaComputerWaitToolUseBlock x => x.ToolsetName,
                BetaComputerScreenshotToolUseBlock x => x.ToolsetName,
                BetaComputerZoomToolUseBlock x => x.ToolsetName,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(
                    this.Json,
                    "toolset_name"
                ),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaComputerKeyToolUseBlock x => x.Type,
                BetaComputerHoldKeyToolUseBlock x => x.Type,
                BetaComputerTypeToolUseBlock x => x.Type,
                BetaComputerCursorPositionToolUseBlock x => x.Type,
                BetaComputerMouseMoveToolUseBlock x => x.Type,
                BetaComputerLeftMouseDownToolUseBlock x => x.Type,
                BetaComputerLeftMouseUpToolUseBlock x => x.Type,
                BetaComputerLeftClickToolUseBlock x => x.Type,
                BetaComputerLeftClickDragToolUseBlock x => x.Type,
                BetaComputerRightClickToolUseBlock x => x.Type,
                BetaComputerMiddleClickToolUseBlock x => x.Type,
                BetaComputerDoubleClickToolUseBlock x => x.Type,
                BetaComputerTripleClickToolUseBlock x => x.Type,
                BetaComputerScrollToolUseBlock x => x.Type,
                BetaComputerWaitToolUseBlock x => x.Type,
                BetaComputerScreenshotToolUseBlock x => x.Type,
                BetaComputerZoomToolUseBlock x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaToolUseCaller? Caller
    {
        get
        {
            return this.Value switch
            {
                BetaComputerKeyToolUseBlock x => x.Caller,
                BetaComputerHoldKeyToolUseBlock x => x.Caller,
                BetaComputerTypeToolUseBlock x => x.Caller,
                BetaComputerCursorPositionToolUseBlock x => x.Caller,
                BetaComputerMouseMoveToolUseBlock x => x.Caller,
                BetaComputerLeftMouseDownToolUseBlock x => x.Caller,
                BetaComputerLeftMouseUpToolUseBlock x => x.Caller,
                BetaComputerLeftClickToolUseBlock x => x.Caller,
                BetaComputerLeftClickDragToolUseBlock x => x.Caller,
                BetaComputerRightClickToolUseBlock x => x.Caller,
                BetaComputerMiddleClickToolUseBlock x => x.Caller,
                BetaComputerDoubleClickToolUseBlock x => x.Caller,
                BetaComputerTripleClickToolUseBlock x => x.Caller,
                BetaComputerScrollToolUseBlock x => x.Caller,
                BetaComputerWaitToolUseBlock x => x.Caller,
                BetaComputerScreenshotToolUseBlock x => x.Caller,
                BetaComputerZoomToolUseBlock x => x.Caller,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaToolUseCaller>(
                    this.Json,
                    "caller"
                ),
            };
        }
    }

    public BetaComputerToolUseBlock(BetaComputerKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerHoldKeyToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(BetaComputerTypeToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerCursorPositionToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerMouseMoveToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerLeftMouseDownToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerLeftMouseUpToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerLeftClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerLeftClickDragToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerRightClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerMiddleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerDoubleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerTripleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerScrollToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(BetaComputerWaitToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(
        BetaComputerScreenshotToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(BetaComputerZoomToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaComputerToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickKey(out var value)) {
    ///     // `value` is of type `BetaComputerKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickKey([NotNullWhen(true)] out BetaComputerKeyToolUseBlock? value)
    {
        value = this.Value as BetaComputerKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerHoldKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHoldKey(out var value)) {
    ///     // `value` is of type `BetaComputerHoldKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHoldKey([NotNullWhen(true)] out BetaComputerHoldKeyToolUseBlock? value)
    {
        value = this.Value as BetaComputerHoldKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerTypeToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickType(out var value)) {
    ///     // `value` is of type `BetaComputerTypeToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickType([NotNullWhen(true)] out BetaComputerTypeToolUseBlock? value)
    {
        value = this.Value as BetaComputerTypeToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerCursorPositionToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCursorPosition(out var value)) {
    ///     // `value` is of type `BetaComputerCursorPositionToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCursorPosition(
        [NotNullWhen(true)] out BetaComputerCursorPositionToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerCursorPositionToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerMouseMoveToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMouseMove(out var value)) {
    ///     // `value` is of type `BetaComputerMouseMoveToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMouseMove([NotNullWhen(true)] out BetaComputerMouseMoveToolUseBlock? value)
    {
        value = this.Value as BetaComputerMouseMoveToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerLeftMouseDownToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseDown(out var value)) {
    ///     // `value` is of type `BetaComputerLeftMouseDownToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseDown(
        [NotNullWhen(true)] out BetaComputerLeftMouseDownToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerLeftMouseDownToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerLeftMouseUpToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseUp(out var value)) {
    ///     // `value` is of type `BetaComputerLeftMouseUpToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseUp(
        [NotNullWhen(true)] out BetaComputerLeftMouseUpToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerLeftMouseUpToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerLeftClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClick(out var value)) {
    ///     // `value` is of type `BetaComputerLeftClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClick([NotNullWhen(true)] out BetaComputerLeftClickToolUseBlock? value)
    {
        value = this.Value as BetaComputerLeftClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerLeftClickDragToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClickDrag(out var value)) {
    ///     // `value` is of type `BetaComputerLeftClickDragToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClickDrag(
        [NotNullWhen(true)] out BetaComputerLeftClickDragToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerLeftClickDragToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerRightClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRightClick(out var value)) {
    ///     // `value` is of type `BetaComputerRightClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRightClick([NotNullWhen(true)] out BetaComputerRightClickToolUseBlock? value)
    {
        value = this.Value as BetaComputerRightClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerMiddleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMiddleClick(out var value)) {
    ///     // `value` is of type `BetaComputerMiddleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMiddleClick(
        [NotNullWhen(true)] out BetaComputerMiddleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerMiddleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerDoubleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDoubleClick(out var value)) {
    ///     // `value` is of type `BetaComputerDoubleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDoubleClick(
        [NotNullWhen(true)] out BetaComputerDoubleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerDoubleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerTripleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTripleClick(out var value)) {
    ///     // `value` is of type `BetaComputerTripleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTripleClick(
        [NotNullWhen(true)] out BetaComputerTripleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaComputerTripleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerScrollToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScroll(out var value)) {
    ///     // `value` is of type `BetaComputerScrollToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScroll([NotNullWhen(true)] out BetaComputerScrollToolUseBlock? value)
    {
        value = this.Value as BetaComputerScrollToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerWaitToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWait(out var value)) {
    ///     // `value` is of type `BetaComputerWaitToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWait([NotNullWhen(true)] out BetaComputerWaitToolUseBlock? value)
    {
        value = this.Value as BetaComputerWaitToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerScreenshotToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScreenshot(out var value)) {
    ///     // `value` is of type `BetaComputerScreenshotToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScreenshot([NotNullWhen(true)] out BetaComputerScreenshotToolUseBlock? value)
    {
        value = this.Value as BetaComputerScreenshotToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaComputerZoomToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickZoom(out var value)) {
    ///     // `value` is of type `BetaComputerZoomToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickZoom([NotNullWhen(true)] out BetaComputerZoomToolUseBlock? value)
    {
        value = this.Value as BetaComputerZoomToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
    /// if you need your function parameters to return something.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// instance.Switch(
    ///     (BetaComputerKeyToolUseBlock value) =&gt; {...},
    ///     (BetaComputerHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BetaComputerTypeToolUseBlock value) =&gt; {...},
    ///     (BetaComputerCursorPositionToolUseBlock value) =&gt; {...},
    ///     (BetaComputerMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BetaComputerRightClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerTripleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerScrollToolUseBlock value) =&gt; {...},
    ///     (BetaComputerWaitToolUseBlock value) =&gt; {...},
    ///     (BetaComputerScreenshotToolUseBlock value) =&gt; {...},
    ///     (BetaComputerZoomToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaComputerKeyToolUseBlock> key,
        System::Action<BetaComputerHoldKeyToolUseBlock> holdKey,
        System::Action<BetaComputerTypeToolUseBlock> type,
        System::Action<BetaComputerCursorPositionToolUseBlock> cursorPosition,
        System::Action<BetaComputerMouseMoveToolUseBlock> mouseMove,
        System::Action<BetaComputerLeftMouseDownToolUseBlock> leftMouseDown,
        System::Action<BetaComputerLeftMouseUpToolUseBlock> leftMouseUp,
        System::Action<BetaComputerLeftClickToolUseBlock> leftClick,
        System::Action<BetaComputerLeftClickDragToolUseBlock> leftClickDrag,
        System::Action<BetaComputerRightClickToolUseBlock> rightClick,
        System::Action<BetaComputerMiddleClickToolUseBlock> middleClick,
        System::Action<BetaComputerDoubleClickToolUseBlock> doubleClick,
        System::Action<BetaComputerTripleClickToolUseBlock> tripleClick,
        System::Action<BetaComputerScrollToolUseBlock> scroll,
        System::Action<BetaComputerWaitToolUseBlock> wait,
        System::Action<BetaComputerScreenshotToolUseBlock> screenshot,
        System::Action<BetaComputerZoomToolUseBlock> zoom
    )
    {
        switch (this.Value)
        {
            case BetaComputerKeyToolUseBlock value:
                key(value);
                break;
            case BetaComputerHoldKeyToolUseBlock value:
                holdKey(value);
                break;
            case BetaComputerTypeToolUseBlock value:
                type(value);
                break;
            case BetaComputerCursorPositionToolUseBlock value:
                cursorPosition(value);
                break;
            case BetaComputerMouseMoveToolUseBlock value:
                mouseMove(value);
                break;
            case BetaComputerLeftMouseDownToolUseBlock value:
                leftMouseDown(value);
                break;
            case BetaComputerLeftMouseUpToolUseBlock value:
                leftMouseUp(value);
                break;
            case BetaComputerLeftClickToolUseBlock value:
                leftClick(value);
                break;
            case BetaComputerLeftClickDragToolUseBlock value:
                leftClickDrag(value);
                break;
            case BetaComputerRightClickToolUseBlock value:
                rightClick(value);
                break;
            case BetaComputerMiddleClickToolUseBlock value:
                middleClick(value);
                break;
            case BetaComputerDoubleClickToolUseBlock value:
                doubleClick(value);
                break;
            case BetaComputerTripleClickToolUseBlock value:
                tripleClick(value);
                break;
            case BetaComputerScrollToolUseBlock value:
                scroll(value);
                break;
            case BetaComputerWaitToolUseBlock value:
                wait(value);
                break;
            case BetaComputerScreenshotToolUseBlock value:
                screenshot(value);
                break;
            case BetaComputerZoomToolUseBlock value:
                zoom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaComputerToolUseBlock"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
    /// if you don't need your function parameters to return a value.</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
    /// that doesn't match any variant's expected shape).
    /// </exception>
    ///
    /// <example>
    /// <code>
    /// var result = instance.Match(
    ///     (BetaComputerKeyToolUseBlock value) =&gt; {...},
    ///     (BetaComputerHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BetaComputerTypeToolUseBlock value) =&gt; {...},
    ///     (BetaComputerCursorPositionToolUseBlock value) =&gt; {...},
    ///     (BetaComputerMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BetaComputerRightClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerTripleClickToolUseBlock value) =&gt; {...},
    ///     (BetaComputerScrollToolUseBlock value) =&gt; {...},
    ///     (BetaComputerWaitToolUseBlock value) =&gt; {...},
    ///     (BetaComputerScreenshotToolUseBlock value) =&gt; {...},
    ///     (BetaComputerZoomToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaComputerKeyToolUseBlock, T> key,
        System::Func<BetaComputerHoldKeyToolUseBlock, T> holdKey,
        System::Func<BetaComputerTypeToolUseBlock, T> type,
        System::Func<BetaComputerCursorPositionToolUseBlock, T> cursorPosition,
        System::Func<BetaComputerMouseMoveToolUseBlock, T> mouseMove,
        System::Func<BetaComputerLeftMouseDownToolUseBlock, T> leftMouseDown,
        System::Func<BetaComputerLeftMouseUpToolUseBlock, T> leftMouseUp,
        System::Func<BetaComputerLeftClickToolUseBlock, T> leftClick,
        System::Func<BetaComputerLeftClickDragToolUseBlock, T> leftClickDrag,
        System::Func<BetaComputerRightClickToolUseBlock, T> rightClick,
        System::Func<BetaComputerMiddleClickToolUseBlock, T> middleClick,
        System::Func<BetaComputerDoubleClickToolUseBlock, T> doubleClick,
        System::Func<BetaComputerTripleClickToolUseBlock, T> tripleClick,
        System::Func<BetaComputerScrollToolUseBlock, T> scroll,
        System::Func<BetaComputerWaitToolUseBlock, T> wait,
        System::Func<BetaComputerScreenshotToolUseBlock, T> screenshot,
        System::Func<BetaComputerZoomToolUseBlock, T> zoom
    )
    {
        return this.Value switch
        {
            BetaComputerKeyToolUseBlock value => key(value),
            BetaComputerHoldKeyToolUseBlock value => holdKey(value),
            BetaComputerTypeToolUseBlock value => type(value),
            BetaComputerCursorPositionToolUseBlock value => cursorPosition(value),
            BetaComputerMouseMoveToolUseBlock value => mouseMove(value),
            BetaComputerLeftMouseDownToolUseBlock value => leftMouseDown(value),
            BetaComputerLeftMouseUpToolUseBlock value => leftMouseUp(value),
            BetaComputerLeftClickToolUseBlock value => leftClick(value),
            BetaComputerLeftClickDragToolUseBlock value => leftClickDrag(value),
            BetaComputerRightClickToolUseBlock value => rightClick(value),
            BetaComputerMiddleClickToolUseBlock value => middleClick(value),
            BetaComputerDoubleClickToolUseBlock value => doubleClick(value),
            BetaComputerTripleClickToolUseBlock value => tripleClick(value),
            BetaComputerScrollToolUseBlock value => scroll(value),
            BetaComputerWaitToolUseBlock value => wait(value),
            BetaComputerScreenshotToolUseBlock value => screenshot(value),
            BetaComputerZoomToolUseBlock value => zoom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComputerToolUseBlock"
            ),
        };
    }

    public static implicit operator BetaComputerToolUseBlock(BetaComputerKeyToolUseBlock value) =>
        new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerHoldKeyToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(BetaComputerTypeToolUseBlock value) =>
        new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerCursorPositionToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerMouseMoveToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerLeftMouseDownToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerLeftMouseUpToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerLeftClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerLeftClickDragToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerRightClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerMiddleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerDoubleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerTripleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerScrollToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(BetaComputerWaitToolUseBlock value) =>
        new(value);

    public static implicit operator BetaComputerToolUseBlock(
        BetaComputerScreenshotToolUseBlock value
    ) => new(value);

    public static implicit operator BetaComputerToolUseBlock(BetaComputerZoomToolUseBlock value) =>
        new(value);

    /// <summary>
    /// Validates that the instance was constructed with a known variant and that this variant is valid
    /// (based on its own <c>Validate</c> method).
    ///
    /// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaComputerToolUseBlock"
            );
        }
        this.Switch(
            (key) => key.Validate(),
            (holdKey) => holdKey.Validate(),
            (type) => type.Validate(),
            (cursorPosition) => cursorPosition.Validate(),
            (mouseMove) => mouseMove.Validate(),
            (leftMouseDown) => leftMouseDown.Validate(),
            (leftMouseUp) => leftMouseUp.Validate(),
            (leftClick) => leftClick.Validate(),
            (leftClickDrag) => leftClickDrag.Validate(),
            (rightClick) => rightClick.Validate(),
            (middleClick) => middleClick.Validate(),
            (doubleClick) => doubleClick.Validate(),
            (tripleClick) => tripleClick.Validate(),
            (scroll) => scroll.Validate(),
            (wait) => wait.Validate(),
            (screenshot) => screenshot.Validate(),
            (zoom) => zoom.Validate()
        );
    }

    public virtual bool Equals(BetaComputerToolUseBlock? other) =>
        other != null
        && this.VariantIndex() == other.VariantIndex()
        && JsonElement.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(this.Json),
            ModelBase.ToStringSerializerOptions
        );

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaComputerKeyToolUseBlock _ => 0,
            BetaComputerHoldKeyToolUseBlock _ => 1,
            BetaComputerTypeToolUseBlock _ => 2,
            BetaComputerCursorPositionToolUseBlock _ => 3,
            BetaComputerMouseMoveToolUseBlock _ => 4,
            BetaComputerLeftMouseDownToolUseBlock _ => 5,
            BetaComputerLeftMouseUpToolUseBlock _ => 6,
            BetaComputerLeftClickToolUseBlock _ => 7,
            BetaComputerLeftClickDragToolUseBlock _ => 8,
            BetaComputerRightClickToolUseBlock _ => 9,
            BetaComputerMiddleClickToolUseBlock _ => 10,
            BetaComputerDoubleClickToolUseBlock _ => 11,
            BetaComputerTripleClickToolUseBlock _ => 12,
            BetaComputerScrollToolUseBlock _ => 13,
            BetaComputerWaitToolUseBlock _ => 14,
            BetaComputerScreenshotToolUseBlock _ => 15,
            BetaComputerZoomToolUseBlock _ => 16,
            _ => -1,
        };
    }
}

sealed class BetaComputerToolUseBlockConverter : JsonConverter<BetaComputerToolUseBlock>
{
    public override BetaComputerToolUseBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? name;
        try
        {
            name = element.GetProperty("name").GetString();
        }
        catch
        {
            name = null;
        }

        switch (name)
        {
            case "key":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerKeyToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "hold_key":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerHoldKeyToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "type":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerTypeToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "cursor_position":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerCursorPositionToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "mouse_move":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerMouseMoveToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "left_mouse_down":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerLeftMouseDownToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "left_mouse_up":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerLeftMouseUpToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "left_click":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerLeftClickToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "left_click_drag":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerLeftClickDragToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "right_click":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerRightClickToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "middle_click":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerMiddleClickToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "double_click":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerDoubleClickToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "triple_click":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerTripleClickToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "scroll":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerScrollToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "wait":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerWaitToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "screenshot":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaComputerScreenshotToolUseBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            case "zoom":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaComputerZoomToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new(deserialized, element);
                    }
                }
                catch (JsonException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new BetaComputerToolUseBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaComputerToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
