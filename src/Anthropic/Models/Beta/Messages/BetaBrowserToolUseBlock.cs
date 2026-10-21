using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaBrowserToolUseBlockConverter))]
public record class BetaBrowserToolUseBlock : ModelBase
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
                BetaBrowserNavigateToolUseBlock x => x.ID,
                BetaBrowserListTabsToolUseBlock x => x.ID,
                BetaBrowserNewTabToolUseBlock x => x.ID,
                BetaBrowserSwitchTabToolUseBlock x => x.ID,
                BetaBrowserCloseTabToolUseBlock x => x.ID,
                BetaBrowserReadPageToolUseBlock x => x.ID,
                BetaBrowserGetPageTextToolUseBlock x => x.ID,
                BetaBrowserReadConsoleToolUseBlock x => x.ID,
                BetaBrowserReadNetworkToolUseBlock x => x.ID,
                BetaBrowserFindToolUseBlock x => x.ID,
                BetaBrowserFormInputToolUseBlock x => x.ID,
                BetaBrowserFileUploadToolUseBlock x => x.ID,
                BetaBrowserScrollToToolUseBlock x => x.ID,
                BetaBrowserScreenshotToolUseBlock x => x.ID,
                BetaBrowserZoomToolUseBlock x => x.ID,
                BetaBrowserLeftClickToolUseBlock x => x.ID,
                BetaBrowserRightClickToolUseBlock x => x.ID,
                BetaBrowserMiddleClickToolUseBlock x => x.ID,
                BetaBrowserDoubleClickToolUseBlock x => x.ID,
                BetaBrowserTripleClickToolUseBlock x => x.ID,
                BetaBrowserHoverToolUseBlock x => x.ID,
                BetaBrowserLeftClickDragToolUseBlock x => x.ID,
                BetaBrowserLeftMouseDownToolUseBlock x => x.ID,
                BetaBrowserLeftMouseUpToolUseBlock x => x.ID,
                BetaBrowserMouseMoveToolUseBlock x => x.ID,
                BetaBrowserScrollToolUseBlock x => x.ID,
                BetaBrowserTypeToolUseBlock x => x.ID,
                BetaBrowserKeyToolUseBlock x => x.ID,
                BetaBrowserHoldKeyToolUseBlock x => x.ID,
                BetaBrowserWaitToolUseBlock x => x.ID,
                BetaBrowserJavascriptExecToolUseBlock x => x.ID,
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
                BetaBrowserNavigateToolUseBlock x => x.Name,
                BetaBrowserListTabsToolUseBlock x => x.Name,
                BetaBrowserNewTabToolUseBlock x => x.Name,
                BetaBrowserSwitchTabToolUseBlock x => x.Name,
                BetaBrowserCloseTabToolUseBlock x => x.Name,
                BetaBrowserReadPageToolUseBlock x => x.Name,
                BetaBrowserGetPageTextToolUseBlock x => x.Name,
                BetaBrowserReadConsoleToolUseBlock x => x.Name,
                BetaBrowserReadNetworkToolUseBlock x => x.Name,
                BetaBrowserFindToolUseBlock x => x.Name,
                BetaBrowserFormInputToolUseBlock x => x.Name,
                BetaBrowserFileUploadToolUseBlock x => x.Name,
                BetaBrowserScrollToToolUseBlock x => x.Name,
                BetaBrowserScreenshotToolUseBlock x => x.Name,
                BetaBrowserZoomToolUseBlock x => x.Name,
                BetaBrowserLeftClickToolUseBlock x => x.Name,
                BetaBrowserRightClickToolUseBlock x => x.Name,
                BetaBrowserMiddleClickToolUseBlock x => x.Name,
                BetaBrowserDoubleClickToolUseBlock x => x.Name,
                BetaBrowserTripleClickToolUseBlock x => x.Name,
                BetaBrowserHoverToolUseBlock x => x.Name,
                BetaBrowserLeftClickDragToolUseBlock x => x.Name,
                BetaBrowserLeftMouseDownToolUseBlock x => x.Name,
                BetaBrowserLeftMouseUpToolUseBlock x => x.Name,
                BetaBrowserMouseMoveToolUseBlock x => x.Name,
                BetaBrowserScrollToolUseBlock x => x.Name,
                BetaBrowserTypeToolUseBlock x => x.Name,
                BetaBrowserKeyToolUseBlock x => x.Name,
                BetaBrowserHoldKeyToolUseBlock x => x.Name,
                BetaBrowserWaitToolUseBlock x => x.Name,
                BetaBrowserJavascriptExecToolUseBlock x => x.Name,
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
                BetaBrowserNavigateToolUseBlock x => x.ToolsetName,
                BetaBrowserListTabsToolUseBlock x => x.ToolsetName,
                BetaBrowserNewTabToolUseBlock x => x.ToolsetName,
                BetaBrowserSwitchTabToolUseBlock x => x.ToolsetName,
                BetaBrowserCloseTabToolUseBlock x => x.ToolsetName,
                BetaBrowserReadPageToolUseBlock x => x.ToolsetName,
                BetaBrowserGetPageTextToolUseBlock x => x.ToolsetName,
                BetaBrowserReadConsoleToolUseBlock x => x.ToolsetName,
                BetaBrowserReadNetworkToolUseBlock x => x.ToolsetName,
                BetaBrowserFindToolUseBlock x => x.ToolsetName,
                BetaBrowserFormInputToolUseBlock x => x.ToolsetName,
                BetaBrowserFileUploadToolUseBlock x => x.ToolsetName,
                BetaBrowserScrollToToolUseBlock x => x.ToolsetName,
                BetaBrowserScreenshotToolUseBlock x => x.ToolsetName,
                BetaBrowserZoomToolUseBlock x => x.ToolsetName,
                BetaBrowserLeftClickToolUseBlock x => x.ToolsetName,
                BetaBrowserRightClickToolUseBlock x => x.ToolsetName,
                BetaBrowserMiddleClickToolUseBlock x => x.ToolsetName,
                BetaBrowserDoubleClickToolUseBlock x => x.ToolsetName,
                BetaBrowserTripleClickToolUseBlock x => x.ToolsetName,
                BetaBrowserHoverToolUseBlock x => x.ToolsetName,
                BetaBrowserLeftClickDragToolUseBlock x => x.ToolsetName,
                BetaBrowserLeftMouseDownToolUseBlock x => x.ToolsetName,
                BetaBrowserLeftMouseUpToolUseBlock x => x.ToolsetName,
                BetaBrowserMouseMoveToolUseBlock x => x.ToolsetName,
                BetaBrowserScrollToolUseBlock x => x.ToolsetName,
                BetaBrowserTypeToolUseBlock x => x.ToolsetName,
                BetaBrowserKeyToolUseBlock x => x.ToolsetName,
                BetaBrowserHoldKeyToolUseBlock x => x.ToolsetName,
                BetaBrowserWaitToolUseBlock x => x.ToolsetName,
                BetaBrowserJavascriptExecToolUseBlock x => x.ToolsetName,
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
                BetaBrowserNavigateToolUseBlock x => x.Type,
                BetaBrowserListTabsToolUseBlock x => x.Type,
                BetaBrowserNewTabToolUseBlock x => x.Type,
                BetaBrowserSwitchTabToolUseBlock x => x.Type,
                BetaBrowserCloseTabToolUseBlock x => x.Type,
                BetaBrowserReadPageToolUseBlock x => x.Type,
                BetaBrowserGetPageTextToolUseBlock x => x.Type,
                BetaBrowserReadConsoleToolUseBlock x => x.Type,
                BetaBrowserReadNetworkToolUseBlock x => x.Type,
                BetaBrowserFindToolUseBlock x => x.Type,
                BetaBrowserFormInputToolUseBlock x => x.Type,
                BetaBrowserFileUploadToolUseBlock x => x.Type,
                BetaBrowserScrollToToolUseBlock x => x.Type,
                BetaBrowserScreenshotToolUseBlock x => x.Type,
                BetaBrowserZoomToolUseBlock x => x.Type,
                BetaBrowserLeftClickToolUseBlock x => x.Type,
                BetaBrowserRightClickToolUseBlock x => x.Type,
                BetaBrowserMiddleClickToolUseBlock x => x.Type,
                BetaBrowserDoubleClickToolUseBlock x => x.Type,
                BetaBrowserTripleClickToolUseBlock x => x.Type,
                BetaBrowserHoverToolUseBlock x => x.Type,
                BetaBrowserLeftClickDragToolUseBlock x => x.Type,
                BetaBrowserLeftMouseDownToolUseBlock x => x.Type,
                BetaBrowserLeftMouseUpToolUseBlock x => x.Type,
                BetaBrowserMouseMoveToolUseBlock x => x.Type,
                BetaBrowserScrollToolUseBlock x => x.Type,
                BetaBrowserTypeToolUseBlock x => x.Type,
                BetaBrowserKeyToolUseBlock x => x.Type,
                BetaBrowserHoldKeyToolUseBlock x => x.Type,
                BetaBrowserWaitToolUseBlock x => x.Type,
                BetaBrowserJavascriptExecToolUseBlock x => x.Type,
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
                BetaBrowserNavigateToolUseBlock x => x.Caller,
                BetaBrowserListTabsToolUseBlock x => x.Caller,
                BetaBrowserNewTabToolUseBlock x => x.Caller,
                BetaBrowserSwitchTabToolUseBlock x => x.Caller,
                BetaBrowserCloseTabToolUseBlock x => x.Caller,
                BetaBrowserReadPageToolUseBlock x => x.Caller,
                BetaBrowserGetPageTextToolUseBlock x => x.Caller,
                BetaBrowserReadConsoleToolUseBlock x => x.Caller,
                BetaBrowserReadNetworkToolUseBlock x => x.Caller,
                BetaBrowserFindToolUseBlock x => x.Caller,
                BetaBrowserFormInputToolUseBlock x => x.Caller,
                BetaBrowserFileUploadToolUseBlock x => x.Caller,
                BetaBrowserScrollToToolUseBlock x => x.Caller,
                BetaBrowserScreenshotToolUseBlock x => x.Caller,
                BetaBrowserZoomToolUseBlock x => x.Caller,
                BetaBrowserLeftClickToolUseBlock x => x.Caller,
                BetaBrowserRightClickToolUseBlock x => x.Caller,
                BetaBrowserMiddleClickToolUseBlock x => x.Caller,
                BetaBrowserDoubleClickToolUseBlock x => x.Caller,
                BetaBrowserTripleClickToolUseBlock x => x.Caller,
                BetaBrowserHoverToolUseBlock x => x.Caller,
                BetaBrowserLeftClickDragToolUseBlock x => x.Caller,
                BetaBrowserLeftMouseDownToolUseBlock x => x.Caller,
                BetaBrowserLeftMouseUpToolUseBlock x => x.Caller,
                BetaBrowserMouseMoveToolUseBlock x => x.Caller,
                BetaBrowserScrollToolUseBlock x => x.Caller,
                BetaBrowserTypeToolUseBlock x => x.Caller,
                BetaBrowserKeyToolUseBlock x => x.Caller,
                BetaBrowserHoldKeyToolUseBlock x => x.Caller,
                BetaBrowserWaitToolUseBlock x => x.Caller,
                BetaBrowserJavascriptExecToolUseBlock x => x.Caller,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaToolUseCaller>(
                    this.Json,
                    "caller"
                ),
            };
        }
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserNavigateToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserListTabsToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserNewTabToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserSwitchTabToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserCloseTabToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserReadPageToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserGetPageTextToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserReadConsoleToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserReadNetworkToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserFindToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserFormInputToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserFileUploadToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserScrollToToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserScreenshotToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserZoomToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserLeftClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserRightClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserMiddleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserDoubleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserTripleClickToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserHoverToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserLeftClickDragToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserLeftMouseDownToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserLeftMouseUpToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserMouseMoveToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserScrollToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserTypeToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserHoldKeyToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(BetaBrowserWaitToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(
        BetaBrowserJavascriptExecToolUseBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaBrowserToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserNavigateToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNavigate(out var value)) {
    ///     // `value` is of type `BetaBrowserNavigateToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNavigate([NotNullWhen(true)] out BetaBrowserNavigateToolUseBlock? value)
    {
        value = this.Value as BetaBrowserNavigateToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserListTabsToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListTabs(out var value)) {
    ///     // `value` is of type `BetaBrowserListTabsToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListTabs([NotNullWhen(true)] out BetaBrowserListTabsToolUseBlock? value)
    {
        value = this.Value as BetaBrowserListTabsToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserNewTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewTab(out var value)) {
    ///     // `value` is of type `BetaBrowserNewTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewTab([NotNullWhen(true)] out BetaBrowserNewTabToolUseBlock? value)
    {
        value = this.Value as BetaBrowserNewTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserSwitchTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSwitchTab(out var value)) {
    ///     // `value` is of type `BetaBrowserSwitchTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSwitchTab([NotNullWhen(true)] out BetaBrowserSwitchTabToolUseBlock? value)
    {
        value = this.Value as BetaBrowserSwitchTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserCloseTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloseTab(out var value)) {
    ///     // `value` is of type `BetaBrowserCloseTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloseTab([NotNullWhen(true)] out BetaBrowserCloseTabToolUseBlock? value)
    {
        value = this.Value as BetaBrowserCloseTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserReadPageToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadPage(out var value)) {
    ///     // `value` is of type `BetaBrowserReadPageToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadPage([NotNullWhen(true)] out BetaBrowserReadPageToolUseBlock? value)
    {
        value = this.Value as BetaBrowserReadPageToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserGetPageTextToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGetPageText(out var value)) {
    ///     // `value` is of type `BetaBrowserGetPageTextToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGetPageText(
        [NotNullWhen(true)] out BetaBrowserGetPageTextToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserGetPageTextToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserReadConsoleToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadConsole(out var value)) {
    ///     // `value` is of type `BetaBrowserReadConsoleToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadConsole(
        [NotNullWhen(true)] out BetaBrowserReadConsoleToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserReadConsoleToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserReadNetworkToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadNetwork(out var value)) {
    ///     // `value` is of type `BetaBrowserReadNetworkToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadNetwork(
        [NotNullWhen(true)] out BetaBrowserReadNetworkToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserReadNetworkToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserFindToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFind(out var value)) {
    ///     // `value` is of type `BetaBrowserFindToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFind([NotNullWhen(true)] out BetaBrowserFindToolUseBlock? value)
    {
        value = this.Value as BetaBrowserFindToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserFormInputToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormInput(out var value)) {
    ///     // `value` is of type `BetaBrowserFormInputToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormInput([NotNullWhen(true)] out BetaBrowserFormInputToolUseBlock? value)
    {
        value = this.Value as BetaBrowserFormInputToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserFileUploadToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileUpload(out var value)) {
    ///     // `value` is of type `BetaBrowserFileUploadToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileUpload([NotNullWhen(true)] out BetaBrowserFileUploadToolUseBlock? value)
    {
        value = this.Value as BetaBrowserFileUploadToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserScrollToToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScrollTo(out var value)) {
    ///     // `value` is of type `BetaBrowserScrollToToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScrollTo([NotNullWhen(true)] out BetaBrowserScrollToToolUseBlock? value)
    {
        value = this.Value as BetaBrowserScrollToToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserScreenshotToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScreenshot(out var value)) {
    ///     // `value` is of type `BetaBrowserScreenshotToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScreenshot([NotNullWhen(true)] out BetaBrowserScreenshotToolUseBlock? value)
    {
        value = this.Value as BetaBrowserScreenshotToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserZoomToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickZoom(out var value)) {
    ///     // `value` is of type `BetaBrowserZoomToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickZoom([NotNullWhen(true)] out BetaBrowserZoomToolUseBlock? value)
    {
        value = this.Value as BetaBrowserZoomToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserLeftClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClick(out var value)) {
    ///     // `value` is of type `BetaBrowserLeftClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClick([NotNullWhen(true)] out BetaBrowserLeftClickToolUseBlock? value)
    {
        value = this.Value as BetaBrowserLeftClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserRightClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRightClick(out var value)) {
    ///     // `value` is of type `BetaBrowserRightClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRightClick([NotNullWhen(true)] out BetaBrowserRightClickToolUseBlock? value)
    {
        value = this.Value as BetaBrowserRightClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserMiddleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMiddleClick(out var value)) {
    ///     // `value` is of type `BetaBrowserMiddleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMiddleClick(
        [NotNullWhen(true)] out BetaBrowserMiddleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserMiddleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserDoubleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDoubleClick(out var value)) {
    ///     // `value` is of type `BetaBrowserDoubleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDoubleClick(
        [NotNullWhen(true)] out BetaBrowserDoubleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserDoubleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserTripleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTripleClick(out var value)) {
    ///     // `value` is of type `BetaBrowserTripleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTripleClick(
        [NotNullWhen(true)] out BetaBrowserTripleClickToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserTripleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserHoverToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHover(out var value)) {
    ///     // `value` is of type `BetaBrowserHoverToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHover([NotNullWhen(true)] out BetaBrowserHoverToolUseBlock? value)
    {
        value = this.Value as BetaBrowserHoverToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserLeftClickDragToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClickDrag(out var value)) {
    ///     // `value` is of type `BetaBrowserLeftClickDragToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClickDrag(
        [NotNullWhen(true)] out BetaBrowserLeftClickDragToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserLeftClickDragToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserLeftMouseDownToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseDown(out var value)) {
    ///     // `value` is of type `BetaBrowserLeftMouseDownToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseDown(
        [NotNullWhen(true)] out BetaBrowserLeftMouseDownToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserLeftMouseDownToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserLeftMouseUpToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseUp(out var value)) {
    ///     // `value` is of type `BetaBrowserLeftMouseUpToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseUp(
        [NotNullWhen(true)] out BetaBrowserLeftMouseUpToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserLeftMouseUpToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserMouseMoveToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMouseMove(out var value)) {
    ///     // `value` is of type `BetaBrowserMouseMoveToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMouseMove([NotNullWhen(true)] out BetaBrowserMouseMoveToolUseBlock? value)
    {
        value = this.Value as BetaBrowserMouseMoveToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserScrollToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScroll(out var value)) {
    ///     // `value` is of type `BetaBrowserScrollToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScroll([NotNullWhen(true)] out BetaBrowserScrollToolUseBlock? value)
    {
        value = this.Value as BetaBrowserScrollToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserTypeToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickType(out var value)) {
    ///     // `value` is of type `BetaBrowserTypeToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickType([NotNullWhen(true)] out BetaBrowserTypeToolUseBlock? value)
    {
        value = this.Value as BetaBrowserTypeToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickKey(out var value)) {
    ///     // `value` is of type `BetaBrowserKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickKey([NotNullWhen(true)] out BetaBrowserKeyToolUseBlock? value)
    {
        value = this.Value as BetaBrowserKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserHoldKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHoldKey(out var value)) {
    ///     // `value` is of type `BetaBrowserHoldKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHoldKey([NotNullWhen(true)] out BetaBrowserHoldKeyToolUseBlock? value)
    {
        value = this.Value as BetaBrowserHoldKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserWaitToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWait(out var value)) {
    ///     // `value` is of type `BetaBrowserWaitToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWait([NotNullWhen(true)] out BetaBrowserWaitToolUseBlock? value)
    {
        value = this.Value as BetaBrowserWaitToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBrowserJavascriptExecToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJavascriptExec(out var value)) {
    ///     // `value` is of type `BetaBrowserJavascriptExecToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJavascriptExec(
        [NotNullWhen(true)] out BetaBrowserJavascriptExecToolUseBlock? value
    )
    {
        value = this.Value as BetaBrowserJavascriptExecToolUseBlock;
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
    ///     (BetaBrowserNavigateToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserListTabsToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserNewTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserSwitchTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserCloseTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadPageToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserGetPageTextToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadConsoleToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadNetworkToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFindToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFormInputToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFileUploadToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScrollToToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScreenshotToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserZoomToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserRightClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserTripleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserHoverToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScrollToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserTypeToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserKeyToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserWaitToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserJavascriptExecToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaBrowserNavigateToolUseBlock> navigate,
        System::Action<BetaBrowserListTabsToolUseBlock> listTabs,
        System::Action<BetaBrowserNewTabToolUseBlock> newTab,
        System::Action<BetaBrowserSwitchTabToolUseBlock> switchTab,
        System::Action<BetaBrowserCloseTabToolUseBlock> closeTab,
        System::Action<BetaBrowserReadPageToolUseBlock> readPage,
        System::Action<BetaBrowserGetPageTextToolUseBlock> getPageText,
        System::Action<BetaBrowserReadConsoleToolUseBlock> readConsole,
        System::Action<BetaBrowserReadNetworkToolUseBlock> readNetwork,
        System::Action<BetaBrowserFindToolUseBlock> find,
        System::Action<BetaBrowserFormInputToolUseBlock> formInput,
        System::Action<BetaBrowserFileUploadToolUseBlock> fileUpload,
        System::Action<BetaBrowserScrollToToolUseBlock> scrollTo,
        System::Action<BetaBrowserScreenshotToolUseBlock> screenshot,
        System::Action<BetaBrowserZoomToolUseBlock> zoom,
        System::Action<BetaBrowserLeftClickToolUseBlock> leftClick,
        System::Action<BetaBrowserRightClickToolUseBlock> rightClick,
        System::Action<BetaBrowserMiddleClickToolUseBlock> middleClick,
        System::Action<BetaBrowserDoubleClickToolUseBlock> doubleClick,
        System::Action<BetaBrowserTripleClickToolUseBlock> tripleClick,
        System::Action<BetaBrowserHoverToolUseBlock> hover,
        System::Action<BetaBrowserLeftClickDragToolUseBlock> leftClickDrag,
        System::Action<BetaBrowserLeftMouseDownToolUseBlock> leftMouseDown,
        System::Action<BetaBrowserLeftMouseUpToolUseBlock> leftMouseUp,
        System::Action<BetaBrowserMouseMoveToolUseBlock> mouseMove,
        System::Action<BetaBrowserScrollToolUseBlock> scroll,
        System::Action<BetaBrowserTypeToolUseBlock> type,
        System::Action<BetaBrowserKeyToolUseBlock> key,
        System::Action<BetaBrowserHoldKeyToolUseBlock> holdKey,
        System::Action<BetaBrowserWaitToolUseBlock> wait,
        System::Action<BetaBrowserJavascriptExecToolUseBlock> javascriptExec
    )
    {
        switch (this.Value)
        {
            case BetaBrowserNavigateToolUseBlock value:
                navigate(value);
                break;
            case BetaBrowserListTabsToolUseBlock value:
                listTabs(value);
                break;
            case BetaBrowserNewTabToolUseBlock value:
                newTab(value);
                break;
            case BetaBrowserSwitchTabToolUseBlock value:
                switchTab(value);
                break;
            case BetaBrowserCloseTabToolUseBlock value:
                closeTab(value);
                break;
            case BetaBrowserReadPageToolUseBlock value:
                readPage(value);
                break;
            case BetaBrowserGetPageTextToolUseBlock value:
                getPageText(value);
                break;
            case BetaBrowserReadConsoleToolUseBlock value:
                readConsole(value);
                break;
            case BetaBrowserReadNetworkToolUseBlock value:
                readNetwork(value);
                break;
            case BetaBrowserFindToolUseBlock value:
                find(value);
                break;
            case BetaBrowserFormInputToolUseBlock value:
                formInput(value);
                break;
            case BetaBrowserFileUploadToolUseBlock value:
                fileUpload(value);
                break;
            case BetaBrowserScrollToToolUseBlock value:
                scrollTo(value);
                break;
            case BetaBrowserScreenshotToolUseBlock value:
                screenshot(value);
                break;
            case BetaBrowserZoomToolUseBlock value:
                zoom(value);
                break;
            case BetaBrowserLeftClickToolUseBlock value:
                leftClick(value);
                break;
            case BetaBrowserRightClickToolUseBlock value:
                rightClick(value);
                break;
            case BetaBrowserMiddleClickToolUseBlock value:
                middleClick(value);
                break;
            case BetaBrowserDoubleClickToolUseBlock value:
                doubleClick(value);
                break;
            case BetaBrowserTripleClickToolUseBlock value:
                tripleClick(value);
                break;
            case BetaBrowserHoverToolUseBlock value:
                hover(value);
                break;
            case BetaBrowserLeftClickDragToolUseBlock value:
                leftClickDrag(value);
                break;
            case BetaBrowserLeftMouseDownToolUseBlock value:
                leftMouseDown(value);
                break;
            case BetaBrowserLeftMouseUpToolUseBlock value:
                leftMouseUp(value);
                break;
            case BetaBrowserMouseMoveToolUseBlock value:
                mouseMove(value);
                break;
            case BetaBrowserScrollToolUseBlock value:
                scroll(value);
                break;
            case BetaBrowserTypeToolUseBlock value:
                type(value);
                break;
            case BetaBrowserKeyToolUseBlock value:
                key(value);
                break;
            case BetaBrowserHoldKeyToolUseBlock value:
                holdKey(value);
                break;
            case BetaBrowserWaitToolUseBlock value:
                wait(value);
                break;
            case BetaBrowserJavascriptExecToolUseBlock value:
                javascriptExec(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaBrowserToolUseBlock"
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
    ///     (BetaBrowserNavigateToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserListTabsToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserNewTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserSwitchTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserCloseTabToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadPageToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserGetPageTextToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadConsoleToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserReadNetworkToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFindToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFormInputToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserFileUploadToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScrollToToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScreenshotToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserZoomToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserRightClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserTripleClickToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserHoverToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserScrollToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserTypeToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserKeyToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserWaitToolUseBlock value) =&gt; {...},
    ///     (BetaBrowserJavascriptExecToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaBrowserNavigateToolUseBlock, T> navigate,
        System::Func<BetaBrowserListTabsToolUseBlock, T> listTabs,
        System::Func<BetaBrowserNewTabToolUseBlock, T> newTab,
        System::Func<BetaBrowserSwitchTabToolUseBlock, T> switchTab,
        System::Func<BetaBrowserCloseTabToolUseBlock, T> closeTab,
        System::Func<BetaBrowserReadPageToolUseBlock, T> readPage,
        System::Func<BetaBrowserGetPageTextToolUseBlock, T> getPageText,
        System::Func<BetaBrowserReadConsoleToolUseBlock, T> readConsole,
        System::Func<BetaBrowserReadNetworkToolUseBlock, T> readNetwork,
        System::Func<BetaBrowserFindToolUseBlock, T> find,
        System::Func<BetaBrowserFormInputToolUseBlock, T> formInput,
        System::Func<BetaBrowserFileUploadToolUseBlock, T> fileUpload,
        System::Func<BetaBrowserScrollToToolUseBlock, T> scrollTo,
        System::Func<BetaBrowserScreenshotToolUseBlock, T> screenshot,
        System::Func<BetaBrowserZoomToolUseBlock, T> zoom,
        System::Func<BetaBrowserLeftClickToolUseBlock, T> leftClick,
        System::Func<BetaBrowserRightClickToolUseBlock, T> rightClick,
        System::Func<BetaBrowserMiddleClickToolUseBlock, T> middleClick,
        System::Func<BetaBrowserDoubleClickToolUseBlock, T> doubleClick,
        System::Func<BetaBrowserTripleClickToolUseBlock, T> tripleClick,
        System::Func<BetaBrowserHoverToolUseBlock, T> hover,
        System::Func<BetaBrowserLeftClickDragToolUseBlock, T> leftClickDrag,
        System::Func<BetaBrowserLeftMouseDownToolUseBlock, T> leftMouseDown,
        System::Func<BetaBrowserLeftMouseUpToolUseBlock, T> leftMouseUp,
        System::Func<BetaBrowserMouseMoveToolUseBlock, T> mouseMove,
        System::Func<BetaBrowserScrollToolUseBlock, T> scroll,
        System::Func<BetaBrowserTypeToolUseBlock, T> type,
        System::Func<BetaBrowserKeyToolUseBlock, T> key,
        System::Func<BetaBrowserHoldKeyToolUseBlock, T> holdKey,
        System::Func<BetaBrowserWaitToolUseBlock, T> wait,
        System::Func<BetaBrowserJavascriptExecToolUseBlock, T> javascriptExec
    )
    {
        return this.Value switch
        {
            BetaBrowserNavigateToolUseBlock value => navigate(value),
            BetaBrowserListTabsToolUseBlock value => listTabs(value),
            BetaBrowserNewTabToolUseBlock value => newTab(value),
            BetaBrowserSwitchTabToolUseBlock value => switchTab(value),
            BetaBrowserCloseTabToolUseBlock value => closeTab(value),
            BetaBrowserReadPageToolUseBlock value => readPage(value),
            BetaBrowserGetPageTextToolUseBlock value => getPageText(value),
            BetaBrowserReadConsoleToolUseBlock value => readConsole(value),
            BetaBrowserReadNetworkToolUseBlock value => readNetwork(value),
            BetaBrowserFindToolUseBlock value => find(value),
            BetaBrowserFormInputToolUseBlock value => formInput(value),
            BetaBrowserFileUploadToolUseBlock value => fileUpload(value),
            BetaBrowserScrollToToolUseBlock value => scrollTo(value),
            BetaBrowserScreenshotToolUseBlock value => screenshot(value),
            BetaBrowserZoomToolUseBlock value => zoom(value),
            BetaBrowserLeftClickToolUseBlock value => leftClick(value),
            BetaBrowserRightClickToolUseBlock value => rightClick(value),
            BetaBrowserMiddleClickToolUseBlock value => middleClick(value),
            BetaBrowserDoubleClickToolUseBlock value => doubleClick(value),
            BetaBrowserTripleClickToolUseBlock value => tripleClick(value),
            BetaBrowserHoverToolUseBlock value => hover(value),
            BetaBrowserLeftClickDragToolUseBlock value => leftClickDrag(value),
            BetaBrowserLeftMouseDownToolUseBlock value => leftMouseDown(value),
            BetaBrowserLeftMouseUpToolUseBlock value => leftMouseUp(value),
            BetaBrowserMouseMoveToolUseBlock value => mouseMove(value),
            BetaBrowserScrollToolUseBlock value => scroll(value),
            BetaBrowserTypeToolUseBlock value => type(value),
            BetaBrowserKeyToolUseBlock value => key(value),
            BetaBrowserHoldKeyToolUseBlock value => holdKey(value),
            BetaBrowserWaitToolUseBlock value => wait(value),
            BetaBrowserJavascriptExecToolUseBlock value => javascriptExec(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaBrowserToolUseBlock"
            ),
        };
    }

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserNavigateToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserListTabsToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserNewTabToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserSwitchTabToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserCloseTabToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserReadPageToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserGetPageTextToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserReadConsoleToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserReadNetworkToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserFindToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserFormInputToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserFileUploadToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserScrollToToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserScreenshotToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserZoomToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserLeftClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserRightClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserMiddleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserDoubleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserTripleClickToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserHoverToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserLeftClickDragToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserLeftMouseDownToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserLeftMouseUpToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserMouseMoveToolUseBlock value
    ) => new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserScrollToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserTypeToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserKeyToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserHoldKeyToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(BetaBrowserWaitToolUseBlock value) =>
        new(value);

    public static implicit operator BetaBrowserToolUseBlock(
        BetaBrowserJavascriptExecToolUseBlock value
    ) => new(value);

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
                "Data did not match any variant of BetaBrowserToolUseBlock"
            );
        }
        this.Switch(
            (navigate) => navigate.Validate(),
            (listTabs) => listTabs.Validate(),
            (newTab) => newTab.Validate(),
            (switchTab) => switchTab.Validate(),
            (closeTab) => closeTab.Validate(),
            (readPage) => readPage.Validate(),
            (getPageText) => getPageText.Validate(),
            (readConsole) => readConsole.Validate(),
            (readNetwork) => readNetwork.Validate(),
            (find) => find.Validate(),
            (formInput) => formInput.Validate(),
            (fileUpload) => fileUpload.Validate(),
            (scrollTo) => scrollTo.Validate(),
            (screenshot) => screenshot.Validate(),
            (zoom) => zoom.Validate(),
            (leftClick) => leftClick.Validate(),
            (rightClick) => rightClick.Validate(),
            (middleClick) => middleClick.Validate(),
            (doubleClick) => doubleClick.Validate(),
            (tripleClick) => tripleClick.Validate(),
            (hover) => hover.Validate(),
            (leftClickDrag) => leftClickDrag.Validate(),
            (leftMouseDown) => leftMouseDown.Validate(),
            (leftMouseUp) => leftMouseUp.Validate(),
            (mouseMove) => mouseMove.Validate(),
            (scroll) => scroll.Validate(),
            (type) => type.Validate(),
            (key) => key.Validate(),
            (holdKey) => holdKey.Validate(),
            (wait) => wait.Validate(),
            (javascriptExec) => javascriptExec.Validate()
        );
    }

    public virtual bool Equals(BetaBrowserToolUseBlock? other) =>
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
            BetaBrowserNavigateToolUseBlock _ => 0,
            BetaBrowserListTabsToolUseBlock _ => 1,
            BetaBrowserNewTabToolUseBlock _ => 2,
            BetaBrowserSwitchTabToolUseBlock _ => 3,
            BetaBrowserCloseTabToolUseBlock _ => 4,
            BetaBrowserReadPageToolUseBlock _ => 5,
            BetaBrowserGetPageTextToolUseBlock _ => 6,
            BetaBrowserReadConsoleToolUseBlock _ => 7,
            BetaBrowserReadNetworkToolUseBlock _ => 8,
            BetaBrowserFindToolUseBlock _ => 9,
            BetaBrowserFormInputToolUseBlock _ => 10,
            BetaBrowserFileUploadToolUseBlock _ => 11,
            BetaBrowserScrollToToolUseBlock _ => 12,
            BetaBrowserScreenshotToolUseBlock _ => 13,
            BetaBrowserZoomToolUseBlock _ => 14,
            BetaBrowserLeftClickToolUseBlock _ => 15,
            BetaBrowserRightClickToolUseBlock _ => 16,
            BetaBrowserMiddleClickToolUseBlock _ => 17,
            BetaBrowserDoubleClickToolUseBlock _ => 18,
            BetaBrowserTripleClickToolUseBlock _ => 19,
            BetaBrowserHoverToolUseBlock _ => 20,
            BetaBrowserLeftClickDragToolUseBlock _ => 21,
            BetaBrowserLeftMouseDownToolUseBlock _ => 22,
            BetaBrowserLeftMouseUpToolUseBlock _ => 23,
            BetaBrowserMouseMoveToolUseBlock _ => 24,
            BetaBrowserScrollToolUseBlock _ => 25,
            BetaBrowserTypeToolUseBlock _ => 26,
            BetaBrowserKeyToolUseBlock _ => 27,
            BetaBrowserHoldKeyToolUseBlock _ => 28,
            BetaBrowserWaitToolUseBlock _ => 29,
            BetaBrowserJavascriptExecToolUseBlock _ => 30,
            _ => -1,
        };
    }
}

sealed class BetaBrowserToolUseBlockConverter : JsonConverter<BetaBrowserToolUseBlock>
{
    public override BetaBrowserToolUseBlock? Read(
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
            case "navigate":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserNavigateToolUseBlock>(
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
            case "list_tabs":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserListTabsToolUseBlock>(
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
            case "new_tab":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserNewTabToolUseBlock>(
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
            case "switch_tab":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserSwitchTabToolUseBlock>(
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
            case "close_tab":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserCloseTabToolUseBlock>(
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
            case "read_page":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserReadPageToolUseBlock>(
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
            case "get_page_text":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserGetPageTextToolUseBlock>(
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
            case "read_console":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserReadConsoleToolUseBlock>(
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
            case "read_network":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserReadNetworkToolUseBlock>(
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
            case "find":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserFindToolUseBlock>(
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
            case "form_input":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputToolUseBlock>(
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
            case "file_upload":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserFileUploadToolUseBlock>(
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
            case "scroll_to":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserScrollToToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserScreenshotToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserZoomToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserLeftClickToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserRightClickToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserMiddleClickToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserDoubleClickToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserTripleClickToolUseBlock>(
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
            case "hover":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserHoverToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserLeftClickDragToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserLeftMouseDownToolUseBlock>(
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
                        JsonSerializer.Deserialize<BetaBrowserLeftMouseUpToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserMouseMoveToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserScrollToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserTypeToolUseBlock>(
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
            case "key":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserHoldKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaBrowserWaitToolUseBlock>(
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
            case "javascript_exec":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBrowserJavascriptExecToolUseBlock>(
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
                return new BetaBrowserToolUseBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaBrowserToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
