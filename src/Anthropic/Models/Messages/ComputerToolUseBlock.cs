using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ComputerToolUseBlockConverter))]
public record class ComputerToolUseBlock : ModelBase
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
                ComputerKeyToolUseBlock x => x.ID,
                ComputerHoldKeyToolUseBlock x => x.ID,
                ComputerTypeToolUseBlock x => x.ID,
                ComputerCursorPositionToolUseBlock x => x.ID,
                ComputerMouseMoveToolUseBlock x => x.ID,
                ComputerLeftMouseDownToolUseBlock x => x.ID,
                ComputerLeftMouseUpToolUseBlock x => x.ID,
                ComputerLeftClickToolUseBlock x => x.ID,
                ComputerLeftClickDragToolUseBlock x => x.ID,
                ComputerRightClickToolUseBlock x => x.ID,
                ComputerMiddleClickToolUseBlock x => x.ID,
                ComputerDoubleClickToolUseBlock x => x.ID,
                ComputerTripleClickToolUseBlock x => x.ID,
                ComputerScrollToolUseBlock x => x.ID,
                ComputerWaitToolUseBlock x => x.ID,
                ComputerScreenshotToolUseBlock x => x.ID,
                ComputerZoomToolUseBlock x => x.ID,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<string>(this.Json, "id"),
            };
        }
    }

    public ToolUseCaller Caller
    {
        get
        {
            return this.Value switch
            {
                ComputerKeyToolUseBlock x => x.Caller,
                ComputerHoldKeyToolUseBlock x => x.Caller,
                ComputerTypeToolUseBlock x => x.Caller,
                ComputerCursorPositionToolUseBlock x => x.Caller,
                ComputerMouseMoveToolUseBlock x => x.Caller,
                ComputerLeftMouseDownToolUseBlock x => x.Caller,
                ComputerLeftMouseUpToolUseBlock x => x.Caller,
                ComputerLeftClickToolUseBlock x => x.Caller,
                ComputerLeftClickDragToolUseBlock x => x.Caller,
                ComputerRightClickToolUseBlock x => x.Caller,
                ComputerMiddleClickToolUseBlock x => x.Caller,
                ComputerDoubleClickToolUseBlock x => x.Caller,
                ComputerTripleClickToolUseBlock x => x.Caller,
                ComputerScrollToolUseBlock x => x.Caller,
                ComputerWaitToolUseBlock x => x.Caller,
                ComputerScreenshotToolUseBlock x => x.Caller,
                ComputerZoomToolUseBlock x => x.Caller,
                _ => WrappedJsonSerializer.GetNotNullClassProperty<ToolUseCaller>(
                    this.Json,
                    "caller"
                ),
            };
        }
    }

    public JsonElement Name
    {
        get
        {
            return this.Value switch
            {
                ComputerKeyToolUseBlock x => x.Name,
                ComputerHoldKeyToolUseBlock x => x.Name,
                ComputerTypeToolUseBlock x => x.Name,
                ComputerCursorPositionToolUseBlock x => x.Name,
                ComputerMouseMoveToolUseBlock x => x.Name,
                ComputerLeftMouseDownToolUseBlock x => x.Name,
                ComputerLeftMouseUpToolUseBlock x => x.Name,
                ComputerLeftClickToolUseBlock x => x.Name,
                ComputerLeftClickDragToolUseBlock x => x.Name,
                ComputerRightClickToolUseBlock x => x.Name,
                ComputerMiddleClickToolUseBlock x => x.Name,
                ComputerDoubleClickToolUseBlock x => x.Name,
                ComputerTripleClickToolUseBlock x => x.Name,
                ComputerScrollToolUseBlock x => x.Name,
                ComputerWaitToolUseBlock x => x.Name,
                ComputerScreenshotToolUseBlock x => x.Name,
                ComputerZoomToolUseBlock x => x.Name,
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
                ComputerKeyToolUseBlock x => x.ToolsetName,
                ComputerHoldKeyToolUseBlock x => x.ToolsetName,
                ComputerTypeToolUseBlock x => x.ToolsetName,
                ComputerCursorPositionToolUseBlock x => x.ToolsetName,
                ComputerMouseMoveToolUseBlock x => x.ToolsetName,
                ComputerLeftMouseDownToolUseBlock x => x.ToolsetName,
                ComputerLeftMouseUpToolUseBlock x => x.ToolsetName,
                ComputerLeftClickToolUseBlock x => x.ToolsetName,
                ComputerLeftClickDragToolUseBlock x => x.ToolsetName,
                ComputerRightClickToolUseBlock x => x.ToolsetName,
                ComputerMiddleClickToolUseBlock x => x.ToolsetName,
                ComputerDoubleClickToolUseBlock x => x.ToolsetName,
                ComputerTripleClickToolUseBlock x => x.ToolsetName,
                ComputerScrollToolUseBlock x => x.ToolsetName,
                ComputerWaitToolUseBlock x => x.ToolsetName,
                ComputerScreenshotToolUseBlock x => x.ToolsetName,
                ComputerZoomToolUseBlock x => x.ToolsetName,
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
                ComputerKeyToolUseBlock x => x.Type,
                ComputerHoldKeyToolUseBlock x => x.Type,
                ComputerTypeToolUseBlock x => x.Type,
                ComputerCursorPositionToolUseBlock x => x.Type,
                ComputerMouseMoveToolUseBlock x => x.Type,
                ComputerLeftMouseDownToolUseBlock x => x.Type,
                ComputerLeftMouseUpToolUseBlock x => x.Type,
                ComputerLeftClickToolUseBlock x => x.Type,
                ComputerLeftClickDragToolUseBlock x => x.Type,
                ComputerRightClickToolUseBlock x => x.Type,
                ComputerMiddleClickToolUseBlock x => x.Type,
                ComputerDoubleClickToolUseBlock x => x.Type,
                ComputerTripleClickToolUseBlock x => x.Type,
                ComputerScrollToolUseBlock x => x.Type,
                ComputerWaitToolUseBlock x => x.Type,
                ComputerScreenshotToolUseBlock x => x.Type,
                ComputerZoomToolUseBlock x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ComputerToolUseBlock(ComputerKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerHoldKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerTypeToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(
        ComputerCursorPositionToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerMouseMoveToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(
        ComputerLeftMouseDownToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerLeftMouseUpToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerLeftClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(
        ComputerLeftClickDragToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerRightClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerMiddleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerDoubleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerTripleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerScrollToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerWaitToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerScreenshotToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(ComputerZoomToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ComputerToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickKey(out var value)) {
    ///     // `value` is of type `ComputerKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickKey([NotNullWhen(true)] out ComputerKeyToolUseBlock? value)
    {
        value = this.Value as ComputerKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerHoldKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHoldKey(out var value)) {
    ///     // `value` is of type `ComputerHoldKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHoldKey([NotNullWhen(true)] out ComputerHoldKeyToolUseBlock? value)
    {
        value = this.Value as ComputerHoldKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerTypeToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickType(out var value)) {
    ///     // `value` is of type `ComputerTypeToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickType([NotNullWhen(true)] out ComputerTypeToolUseBlock? value)
    {
        value = this.Value as ComputerTypeToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerCursorPositionToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCursorPosition(out var value)) {
    ///     // `value` is of type `ComputerCursorPositionToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCursorPosition(
        [NotNullWhen(true)] out ComputerCursorPositionToolUseBlock? value
    )
    {
        value = this.Value as ComputerCursorPositionToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerMouseMoveToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMouseMove(out var value)) {
    ///     // `value` is of type `ComputerMouseMoveToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMouseMove([NotNullWhen(true)] out ComputerMouseMoveToolUseBlock? value)
    {
        value = this.Value as ComputerMouseMoveToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerLeftMouseDownToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseDown(out var value)) {
    ///     // `value` is of type `ComputerLeftMouseDownToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseDown(
        [NotNullWhen(true)] out ComputerLeftMouseDownToolUseBlock? value
    )
    {
        value = this.Value as ComputerLeftMouseDownToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerLeftMouseUpToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseUp(out var value)) {
    ///     // `value` is of type `ComputerLeftMouseUpToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseUp([NotNullWhen(true)] out ComputerLeftMouseUpToolUseBlock? value)
    {
        value = this.Value as ComputerLeftMouseUpToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerLeftClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClick(out var value)) {
    ///     // `value` is of type `ComputerLeftClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClick([NotNullWhen(true)] out ComputerLeftClickToolUseBlock? value)
    {
        value = this.Value as ComputerLeftClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerLeftClickDragToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClickDrag(out var value)) {
    ///     // `value` is of type `ComputerLeftClickDragToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClickDrag(
        [NotNullWhen(true)] out ComputerLeftClickDragToolUseBlock? value
    )
    {
        value = this.Value as ComputerLeftClickDragToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerRightClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRightClick(out var value)) {
    ///     // `value` is of type `ComputerRightClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRightClick([NotNullWhen(true)] out ComputerRightClickToolUseBlock? value)
    {
        value = this.Value as ComputerRightClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerMiddleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMiddleClick(out var value)) {
    ///     // `value` is of type `ComputerMiddleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMiddleClick([NotNullWhen(true)] out ComputerMiddleClickToolUseBlock? value)
    {
        value = this.Value as ComputerMiddleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerDoubleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDoubleClick(out var value)) {
    ///     // `value` is of type `ComputerDoubleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDoubleClick([NotNullWhen(true)] out ComputerDoubleClickToolUseBlock? value)
    {
        value = this.Value as ComputerDoubleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerTripleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTripleClick(out var value)) {
    ///     // `value` is of type `ComputerTripleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTripleClick([NotNullWhen(true)] out ComputerTripleClickToolUseBlock? value)
    {
        value = this.Value as ComputerTripleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerScrollToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScroll(out var value)) {
    ///     // `value` is of type `ComputerScrollToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScroll([NotNullWhen(true)] out ComputerScrollToolUseBlock? value)
    {
        value = this.Value as ComputerScrollToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerWaitToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWait(out var value)) {
    ///     // `value` is of type `ComputerWaitToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWait([NotNullWhen(true)] out ComputerWaitToolUseBlock? value)
    {
        value = this.Value as ComputerWaitToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerScreenshotToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScreenshot(out var value)) {
    ///     // `value` is of type `ComputerScreenshotToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScreenshot([NotNullWhen(true)] out ComputerScreenshotToolUseBlock? value)
    {
        value = this.Value as ComputerScreenshotToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ComputerZoomToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickZoom(out var value)) {
    ///     // `value` is of type `ComputerZoomToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickZoom([NotNullWhen(true)] out ComputerZoomToolUseBlock? value)
    {
        value = this.Value as ComputerZoomToolUseBlock;
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
    ///     (ComputerKeyToolUseBlock value) =&gt; {...},
    ///     (ComputerHoldKeyToolUseBlock value) =&gt; {...},
    ///     (ComputerTypeToolUseBlock value) =&gt; {...},
    ///     (ComputerCursorPositionToolUseBlock value) =&gt; {...},
    ///     (ComputerMouseMoveToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftClickToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (ComputerRightClickToolUseBlock value) =&gt; {...},
    ///     (ComputerMiddleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerDoubleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerTripleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerScrollToolUseBlock value) =&gt; {...},
    ///     (ComputerWaitToolUseBlock value) =&gt; {...},
    ///     (ComputerScreenshotToolUseBlock value) =&gt; {...},
    ///     (ComputerZoomToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ComputerKeyToolUseBlock> key,
        System::Action<ComputerHoldKeyToolUseBlock> holdKey,
        System::Action<ComputerTypeToolUseBlock> type,
        System::Action<ComputerCursorPositionToolUseBlock> cursorPosition,
        System::Action<ComputerMouseMoveToolUseBlock> mouseMove,
        System::Action<ComputerLeftMouseDownToolUseBlock> leftMouseDown,
        System::Action<ComputerLeftMouseUpToolUseBlock> leftMouseUp,
        System::Action<ComputerLeftClickToolUseBlock> leftClick,
        System::Action<ComputerLeftClickDragToolUseBlock> leftClickDrag,
        System::Action<ComputerRightClickToolUseBlock> rightClick,
        System::Action<ComputerMiddleClickToolUseBlock> middleClick,
        System::Action<ComputerDoubleClickToolUseBlock> doubleClick,
        System::Action<ComputerTripleClickToolUseBlock> tripleClick,
        System::Action<ComputerScrollToolUseBlock> scroll,
        System::Action<ComputerWaitToolUseBlock> wait,
        System::Action<ComputerScreenshotToolUseBlock> screenshot,
        System::Action<ComputerZoomToolUseBlock> zoom
    )
    {
        switch (this.Value)
        {
            case ComputerKeyToolUseBlock value:
                key(value);
                break;
            case ComputerHoldKeyToolUseBlock value:
                holdKey(value);
                break;
            case ComputerTypeToolUseBlock value:
                type(value);
                break;
            case ComputerCursorPositionToolUseBlock value:
                cursorPosition(value);
                break;
            case ComputerMouseMoveToolUseBlock value:
                mouseMove(value);
                break;
            case ComputerLeftMouseDownToolUseBlock value:
                leftMouseDown(value);
                break;
            case ComputerLeftMouseUpToolUseBlock value:
                leftMouseUp(value);
                break;
            case ComputerLeftClickToolUseBlock value:
                leftClick(value);
                break;
            case ComputerLeftClickDragToolUseBlock value:
                leftClickDrag(value);
                break;
            case ComputerRightClickToolUseBlock value:
                rightClick(value);
                break;
            case ComputerMiddleClickToolUseBlock value:
                middleClick(value);
                break;
            case ComputerDoubleClickToolUseBlock value:
                doubleClick(value);
                break;
            case ComputerTripleClickToolUseBlock value:
                tripleClick(value);
                break;
            case ComputerScrollToolUseBlock value:
                scroll(value);
                break;
            case ComputerWaitToolUseBlock value:
                wait(value);
                break;
            case ComputerScreenshotToolUseBlock value:
                screenshot(value);
                break;
            case ComputerZoomToolUseBlock value:
                zoom(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ComputerToolUseBlock"
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
    ///     (ComputerKeyToolUseBlock value) =&gt; {...},
    ///     (ComputerHoldKeyToolUseBlock value) =&gt; {...},
    ///     (ComputerTypeToolUseBlock value) =&gt; {...},
    ///     (ComputerCursorPositionToolUseBlock value) =&gt; {...},
    ///     (ComputerMouseMoveToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftClickToolUseBlock value) =&gt; {...},
    ///     (ComputerLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (ComputerRightClickToolUseBlock value) =&gt; {...},
    ///     (ComputerMiddleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerDoubleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerTripleClickToolUseBlock value) =&gt; {...},
    ///     (ComputerScrollToolUseBlock value) =&gt; {...},
    ///     (ComputerWaitToolUseBlock value) =&gt; {...},
    ///     (ComputerScreenshotToolUseBlock value) =&gt; {...},
    ///     (ComputerZoomToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ComputerKeyToolUseBlock, T> key,
        System::Func<ComputerHoldKeyToolUseBlock, T> holdKey,
        System::Func<ComputerTypeToolUseBlock, T> type,
        System::Func<ComputerCursorPositionToolUseBlock, T> cursorPosition,
        System::Func<ComputerMouseMoveToolUseBlock, T> mouseMove,
        System::Func<ComputerLeftMouseDownToolUseBlock, T> leftMouseDown,
        System::Func<ComputerLeftMouseUpToolUseBlock, T> leftMouseUp,
        System::Func<ComputerLeftClickToolUseBlock, T> leftClick,
        System::Func<ComputerLeftClickDragToolUseBlock, T> leftClickDrag,
        System::Func<ComputerRightClickToolUseBlock, T> rightClick,
        System::Func<ComputerMiddleClickToolUseBlock, T> middleClick,
        System::Func<ComputerDoubleClickToolUseBlock, T> doubleClick,
        System::Func<ComputerTripleClickToolUseBlock, T> tripleClick,
        System::Func<ComputerScrollToolUseBlock, T> scroll,
        System::Func<ComputerWaitToolUseBlock, T> wait,
        System::Func<ComputerScreenshotToolUseBlock, T> screenshot,
        System::Func<ComputerZoomToolUseBlock, T> zoom
    )
    {
        return this.Value switch
        {
            ComputerKeyToolUseBlock value => key(value),
            ComputerHoldKeyToolUseBlock value => holdKey(value),
            ComputerTypeToolUseBlock value => type(value),
            ComputerCursorPositionToolUseBlock value => cursorPosition(value),
            ComputerMouseMoveToolUseBlock value => mouseMove(value),
            ComputerLeftMouseDownToolUseBlock value => leftMouseDown(value),
            ComputerLeftMouseUpToolUseBlock value => leftMouseUp(value),
            ComputerLeftClickToolUseBlock value => leftClick(value),
            ComputerLeftClickDragToolUseBlock value => leftClickDrag(value),
            ComputerRightClickToolUseBlock value => rightClick(value),
            ComputerMiddleClickToolUseBlock value => middleClick(value),
            ComputerDoubleClickToolUseBlock value => doubleClick(value),
            ComputerTripleClickToolUseBlock value => tripleClick(value),
            ComputerScrollToolUseBlock value => scroll(value),
            ComputerWaitToolUseBlock value => wait(value),
            ComputerScreenshotToolUseBlock value => screenshot(value),
            ComputerZoomToolUseBlock value => zoom(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ComputerToolUseBlock"
            ),
        };
    }

    public static implicit operator ComputerToolUseBlock(ComputerKeyToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerHoldKeyToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerTypeToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(
        ComputerCursorPositionToolUseBlock value
    ) => new(value);

    public static implicit operator ComputerToolUseBlock(ComputerMouseMoveToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerLeftMouseDownToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerLeftMouseUpToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerLeftClickToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerLeftClickDragToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerRightClickToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerMiddleClickToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerDoubleClickToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerTripleClickToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerScrollToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerWaitToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerScreenshotToolUseBlock value) =>
        new(value);

    public static implicit operator ComputerToolUseBlock(ComputerZoomToolUseBlock value) =>
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
                "Data did not match any variant of ComputerToolUseBlock"
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

    public virtual bool Equals(ComputerToolUseBlock? other) =>
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
            ComputerKeyToolUseBlock _ => 0,
            ComputerHoldKeyToolUseBlock _ => 1,
            ComputerTypeToolUseBlock _ => 2,
            ComputerCursorPositionToolUseBlock _ => 3,
            ComputerMouseMoveToolUseBlock _ => 4,
            ComputerLeftMouseDownToolUseBlock _ => 5,
            ComputerLeftMouseUpToolUseBlock _ => 6,
            ComputerLeftClickToolUseBlock _ => 7,
            ComputerLeftClickDragToolUseBlock _ => 8,
            ComputerRightClickToolUseBlock _ => 9,
            ComputerMiddleClickToolUseBlock _ => 10,
            ComputerDoubleClickToolUseBlock _ => 11,
            ComputerTripleClickToolUseBlock _ => 12,
            ComputerScrollToolUseBlock _ => 13,
            ComputerWaitToolUseBlock _ => 14,
            ComputerScreenshotToolUseBlock _ => 15,
            ComputerZoomToolUseBlock _ => 16,
            _ => -1,
        };
    }
}

sealed class ComputerToolUseBlockConverter : JsonConverter<ComputerToolUseBlock>
{
    public override ComputerToolUseBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerHoldKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerTypeToolUseBlock>(
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
                        JsonSerializer.Deserialize<ComputerCursorPositionToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerMouseMoveToolUseBlock>(
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
                        JsonSerializer.Deserialize<ComputerLeftMouseDownToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerLeftMouseUpToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerLeftClickToolUseBlock>(
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
                        JsonSerializer.Deserialize<ComputerLeftClickDragToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerRightClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerMiddleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerDoubleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerTripleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerScrollToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerWaitToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerScreenshotToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<ComputerZoomToolUseBlock>(
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
                return new ComputerToolUseBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ComputerToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
