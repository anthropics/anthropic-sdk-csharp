using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(BrowserToolUseBlockConverter))]
public record class BrowserToolUseBlock : ModelBase
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
                BrowserNavigateToolUseBlock x => x.ID,
                BrowserListTabsToolUseBlock x => x.ID,
                BrowserNewTabToolUseBlock x => x.ID,
                BrowserSwitchTabToolUseBlock x => x.ID,
                BrowserCloseTabToolUseBlock x => x.ID,
                BrowserReadPageToolUseBlock x => x.ID,
                BrowserGetPageTextToolUseBlock x => x.ID,
                BrowserReadConsoleToolUseBlock x => x.ID,
                BrowserReadNetworkToolUseBlock x => x.ID,
                BrowserFindToolUseBlock x => x.ID,
                BrowserFormInputToolUseBlock x => x.ID,
                BrowserFileUploadToolUseBlock x => x.ID,
                BrowserScrollToToolUseBlock x => x.ID,
                BrowserScreenshotToolUseBlock x => x.ID,
                BrowserZoomToolUseBlock x => x.ID,
                BrowserLeftClickToolUseBlock x => x.ID,
                BrowserRightClickToolUseBlock x => x.ID,
                BrowserMiddleClickToolUseBlock x => x.ID,
                BrowserDoubleClickToolUseBlock x => x.ID,
                BrowserTripleClickToolUseBlock x => x.ID,
                BrowserHoverToolUseBlock x => x.ID,
                BrowserLeftClickDragToolUseBlock x => x.ID,
                BrowserLeftMouseDownToolUseBlock x => x.ID,
                BrowserLeftMouseUpToolUseBlock x => x.ID,
                BrowserMouseMoveToolUseBlock x => x.ID,
                BrowserScrollToolUseBlock x => x.ID,
                BrowserTypeToolUseBlock x => x.ID,
                BrowserKeyToolUseBlock x => x.ID,
                BrowserHoldKeyToolUseBlock x => x.ID,
                BrowserWaitToolUseBlock x => x.ID,
                BrowserJavascriptExecToolUseBlock x => x.ID,
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
                BrowserNavigateToolUseBlock x => x.Caller,
                BrowserListTabsToolUseBlock x => x.Caller,
                BrowserNewTabToolUseBlock x => x.Caller,
                BrowserSwitchTabToolUseBlock x => x.Caller,
                BrowserCloseTabToolUseBlock x => x.Caller,
                BrowserReadPageToolUseBlock x => x.Caller,
                BrowserGetPageTextToolUseBlock x => x.Caller,
                BrowserReadConsoleToolUseBlock x => x.Caller,
                BrowserReadNetworkToolUseBlock x => x.Caller,
                BrowserFindToolUseBlock x => x.Caller,
                BrowserFormInputToolUseBlock x => x.Caller,
                BrowserFileUploadToolUseBlock x => x.Caller,
                BrowserScrollToToolUseBlock x => x.Caller,
                BrowserScreenshotToolUseBlock x => x.Caller,
                BrowserZoomToolUseBlock x => x.Caller,
                BrowserLeftClickToolUseBlock x => x.Caller,
                BrowserRightClickToolUseBlock x => x.Caller,
                BrowserMiddleClickToolUseBlock x => x.Caller,
                BrowserDoubleClickToolUseBlock x => x.Caller,
                BrowserTripleClickToolUseBlock x => x.Caller,
                BrowserHoverToolUseBlock x => x.Caller,
                BrowserLeftClickDragToolUseBlock x => x.Caller,
                BrowserLeftMouseDownToolUseBlock x => x.Caller,
                BrowserLeftMouseUpToolUseBlock x => x.Caller,
                BrowserMouseMoveToolUseBlock x => x.Caller,
                BrowserScrollToolUseBlock x => x.Caller,
                BrowserTypeToolUseBlock x => x.Caller,
                BrowserKeyToolUseBlock x => x.Caller,
                BrowserHoldKeyToolUseBlock x => x.Caller,
                BrowserWaitToolUseBlock x => x.Caller,
                BrowserJavascriptExecToolUseBlock x => x.Caller,
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
                BrowserNavigateToolUseBlock x => x.Name,
                BrowserListTabsToolUseBlock x => x.Name,
                BrowserNewTabToolUseBlock x => x.Name,
                BrowserSwitchTabToolUseBlock x => x.Name,
                BrowserCloseTabToolUseBlock x => x.Name,
                BrowserReadPageToolUseBlock x => x.Name,
                BrowserGetPageTextToolUseBlock x => x.Name,
                BrowserReadConsoleToolUseBlock x => x.Name,
                BrowserReadNetworkToolUseBlock x => x.Name,
                BrowserFindToolUseBlock x => x.Name,
                BrowserFormInputToolUseBlock x => x.Name,
                BrowserFileUploadToolUseBlock x => x.Name,
                BrowserScrollToToolUseBlock x => x.Name,
                BrowserScreenshotToolUseBlock x => x.Name,
                BrowserZoomToolUseBlock x => x.Name,
                BrowserLeftClickToolUseBlock x => x.Name,
                BrowserRightClickToolUseBlock x => x.Name,
                BrowserMiddleClickToolUseBlock x => x.Name,
                BrowserDoubleClickToolUseBlock x => x.Name,
                BrowserTripleClickToolUseBlock x => x.Name,
                BrowserHoverToolUseBlock x => x.Name,
                BrowserLeftClickDragToolUseBlock x => x.Name,
                BrowserLeftMouseDownToolUseBlock x => x.Name,
                BrowserLeftMouseUpToolUseBlock x => x.Name,
                BrowserMouseMoveToolUseBlock x => x.Name,
                BrowserScrollToolUseBlock x => x.Name,
                BrowserTypeToolUseBlock x => x.Name,
                BrowserKeyToolUseBlock x => x.Name,
                BrowserHoldKeyToolUseBlock x => x.Name,
                BrowserWaitToolUseBlock x => x.Name,
                BrowserJavascriptExecToolUseBlock x => x.Name,
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
                BrowserNavigateToolUseBlock x => x.ToolsetName,
                BrowserListTabsToolUseBlock x => x.ToolsetName,
                BrowserNewTabToolUseBlock x => x.ToolsetName,
                BrowserSwitchTabToolUseBlock x => x.ToolsetName,
                BrowserCloseTabToolUseBlock x => x.ToolsetName,
                BrowserReadPageToolUseBlock x => x.ToolsetName,
                BrowserGetPageTextToolUseBlock x => x.ToolsetName,
                BrowserReadConsoleToolUseBlock x => x.ToolsetName,
                BrowserReadNetworkToolUseBlock x => x.ToolsetName,
                BrowserFindToolUseBlock x => x.ToolsetName,
                BrowserFormInputToolUseBlock x => x.ToolsetName,
                BrowserFileUploadToolUseBlock x => x.ToolsetName,
                BrowserScrollToToolUseBlock x => x.ToolsetName,
                BrowserScreenshotToolUseBlock x => x.ToolsetName,
                BrowserZoomToolUseBlock x => x.ToolsetName,
                BrowserLeftClickToolUseBlock x => x.ToolsetName,
                BrowserRightClickToolUseBlock x => x.ToolsetName,
                BrowserMiddleClickToolUseBlock x => x.ToolsetName,
                BrowserDoubleClickToolUseBlock x => x.ToolsetName,
                BrowserTripleClickToolUseBlock x => x.ToolsetName,
                BrowserHoverToolUseBlock x => x.ToolsetName,
                BrowserLeftClickDragToolUseBlock x => x.ToolsetName,
                BrowserLeftMouseDownToolUseBlock x => x.ToolsetName,
                BrowserLeftMouseUpToolUseBlock x => x.ToolsetName,
                BrowserMouseMoveToolUseBlock x => x.ToolsetName,
                BrowserScrollToolUseBlock x => x.ToolsetName,
                BrowserTypeToolUseBlock x => x.ToolsetName,
                BrowserKeyToolUseBlock x => x.ToolsetName,
                BrowserHoldKeyToolUseBlock x => x.ToolsetName,
                BrowserWaitToolUseBlock x => x.ToolsetName,
                BrowserJavascriptExecToolUseBlock x => x.ToolsetName,
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
                BrowserNavigateToolUseBlock x => x.Type,
                BrowserListTabsToolUseBlock x => x.Type,
                BrowserNewTabToolUseBlock x => x.Type,
                BrowserSwitchTabToolUseBlock x => x.Type,
                BrowserCloseTabToolUseBlock x => x.Type,
                BrowserReadPageToolUseBlock x => x.Type,
                BrowserGetPageTextToolUseBlock x => x.Type,
                BrowserReadConsoleToolUseBlock x => x.Type,
                BrowserReadNetworkToolUseBlock x => x.Type,
                BrowserFindToolUseBlock x => x.Type,
                BrowserFormInputToolUseBlock x => x.Type,
                BrowserFileUploadToolUseBlock x => x.Type,
                BrowserScrollToToolUseBlock x => x.Type,
                BrowserScreenshotToolUseBlock x => x.Type,
                BrowserZoomToolUseBlock x => x.Type,
                BrowserLeftClickToolUseBlock x => x.Type,
                BrowserRightClickToolUseBlock x => x.Type,
                BrowserMiddleClickToolUseBlock x => x.Type,
                BrowserDoubleClickToolUseBlock x => x.Type,
                BrowserTripleClickToolUseBlock x => x.Type,
                BrowserHoverToolUseBlock x => x.Type,
                BrowserLeftClickDragToolUseBlock x => x.Type,
                BrowserLeftMouseDownToolUseBlock x => x.Type,
                BrowserLeftMouseUpToolUseBlock x => x.Type,
                BrowserMouseMoveToolUseBlock x => x.Type,
                BrowserScrollToolUseBlock x => x.Type,
                BrowserTypeToolUseBlock x => x.Type,
                BrowserKeyToolUseBlock x => x.Type,
                BrowserHoldKeyToolUseBlock x => x.Type,
                BrowserWaitToolUseBlock x => x.Type,
                BrowserJavascriptExecToolUseBlock x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BrowserToolUseBlock(BrowserNavigateToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserListTabsToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserNewTabToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserSwitchTabToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserCloseTabToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserReadPageToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserGetPageTextToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserReadConsoleToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserReadNetworkToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserFindToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserFormInputToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserFileUploadToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserScrollToToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserScreenshotToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserZoomToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserLeftClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserRightClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserMiddleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserDoubleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserTripleClickToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserHoverToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserLeftClickDragToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserLeftMouseDownToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserLeftMouseUpToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserMouseMoveToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserScrollToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserTypeToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserHoldKeyToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserWaitToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(BrowserJavascriptExecToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BrowserToolUseBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserNavigateToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNavigate(out var value)) {
    ///     // `value` is of type `BrowserNavigateToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNavigate([NotNullWhen(true)] out BrowserNavigateToolUseBlock? value)
    {
        value = this.Value as BrowserNavigateToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserListTabsToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickListTabs(out var value)) {
    ///     // `value` is of type `BrowserListTabsToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickListTabs([NotNullWhen(true)] out BrowserListTabsToolUseBlock? value)
    {
        value = this.Value as BrowserListTabsToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserNewTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickNewTab(out var value)) {
    ///     // `value` is of type `BrowserNewTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickNewTab([NotNullWhen(true)] out BrowserNewTabToolUseBlock? value)
    {
        value = this.Value as BrowserNewTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserSwitchTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickSwitchTab(out var value)) {
    ///     // `value` is of type `BrowserSwitchTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickSwitchTab([NotNullWhen(true)] out BrowserSwitchTabToolUseBlock? value)
    {
        value = this.Value as BrowserSwitchTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserCloseTabToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCloseTab(out var value)) {
    ///     // `value` is of type `BrowserCloseTabToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCloseTab([NotNullWhen(true)] out BrowserCloseTabToolUseBlock? value)
    {
        value = this.Value as BrowserCloseTabToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserReadPageToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadPage(out var value)) {
    ///     // `value` is of type `BrowserReadPageToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadPage([NotNullWhen(true)] out BrowserReadPageToolUseBlock? value)
    {
        value = this.Value as BrowserReadPageToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserGetPageTextToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickGetPageText(out var value)) {
    ///     // `value` is of type `BrowserGetPageTextToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickGetPageText([NotNullWhen(true)] out BrowserGetPageTextToolUseBlock? value)
    {
        value = this.Value as BrowserGetPageTextToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserReadConsoleToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadConsole(out var value)) {
    ///     // `value` is of type `BrowserReadConsoleToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadConsole([NotNullWhen(true)] out BrowserReadConsoleToolUseBlock? value)
    {
        value = this.Value as BrowserReadConsoleToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserReadNetworkToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickReadNetwork(out var value)) {
    ///     // `value` is of type `BrowserReadNetworkToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickReadNetwork([NotNullWhen(true)] out BrowserReadNetworkToolUseBlock? value)
    {
        value = this.Value as BrowserReadNetworkToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserFindToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFind(out var value)) {
    ///     // `value` is of type `BrowserFindToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFind([NotNullWhen(true)] out BrowserFindToolUseBlock? value)
    {
        value = this.Value as BrowserFindToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserFormInputToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFormInput(out var value)) {
    ///     // `value` is of type `BrowserFormInputToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFormInput([NotNullWhen(true)] out BrowserFormInputToolUseBlock? value)
    {
        value = this.Value as BrowserFormInputToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserFileUploadToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickFileUpload(out var value)) {
    ///     // `value` is of type `BrowserFileUploadToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickFileUpload([NotNullWhen(true)] out BrowserFileUploadToolUseBlock? value)
    {
        value = this.Value as BrowserFileUploadToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserScrollToToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScrollTo(out var value)) {
    ///     // `value` is of type `BrowserScrollToToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScrollTo([NotNullWhen(true)] out BrowserScrollToToolUseBlock? value)
    {
        value = this.Value as BrowserScrollToToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserScreenshotToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScreenshot(out var value)) {
    ///     // `value` is of type `BrowserScreenshotToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScreenshot([NotNullWhen(true)] out BrowserScreenshotToolUseBlock? value)
    {
        value = this.Value as BrowserScreenshotToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserZoomToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickZoom(out var value)) {
    ///     // `value` is of type `BrowserZoomToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickZoom([NotNullWhen(true)] out BrowserZoomToolUseBlock? value)
    {
        value = this.Value as BrowserZoomToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserLeftClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClick(out var value)) {
    ///     // `value` is of type `BrowserLeftClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClick([NotNullWhen(true)] out BrowserLeftClickToolUseBlock? value)
    {
        value = this.Value as BrowserLeftClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserRightClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRightClick(out var value)) {
    ///     // `value` is of type `BrowserRightClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRightClick([NotNullWhen(true)] out BrowserRightClickToolUseBlock? value)
    {
        value = this.Value as BrowserRightClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserMiddleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMiddleClick(out var value)) {
    ///     // `value` is of type `BrowserMiddleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMiddleClick([NotNullWhen(true)] out BrowserMiddleClickToolUseBlock? value)
    {
        value = this.Value as BrowserMiddleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserDoubleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickDoubleClick(out var value)) {
    ///     // `value` is of type `BrowserDoubleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickDoubleClick([NotNullWhen(true)] out BrowserDoubleClickToolUseBlock? value)
    {
        value = this.Value as BrowserDoubleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserTripleClickToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTripleClick(out var value)) {
    ///     // `value` is of type `BrowserTripleClickToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTripleClick([NotNullWhen(true)] out BrowserTripleClickToolUseBlock? value)
    {
        value = this.Value as BrowserTripleClickToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserHoverToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHover(out var value)) {
    ///     // `value` is of type `BrowserHoverToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHover([NotNullWhen(true)] out BrowserHoverToolUseBlock? value)
    {
        value = this.Value as BrowserHoverToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserLeftClickDragToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftClickDrag(out var value)) {
    ///     // `value` is of type `BrowserLeftClickDragToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftClickDrag(
        [NotNullWhen(true)] out BrowserLeftClickDragToolUseBlock? value
    )
    {
        value = this.Value as BrowserLeftClickDragToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserLeftMouseDownToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseDown(out var value)) {
    ///     // `value` is of type `BrowserLeftMouseDownToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseDown(
        [NotNullWhen(true)] out BrowserLeftMouseDownToolUseBlock? value
    )
    {
        value = this.Value as BrowserLeftMouseDownToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserLeftMouseUpToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickLeftMouseUp(out var value)) {
    ///     // `value` is of type `BrowserLeftMouseUpToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickLeftMouseUp([NotNullWhen(true)] out BrowserLeftMouseUpToolUseBlock? value)
    {
        value = this.Value as BrowserLeftMouseUpToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserMouseMoveToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMouseMove(out var value)) {
    ///     // `value` is of type `BrowserMouseMoveToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMouseMove([NotNullWhen(true)] out BrowserMouseMoveToolUseBlock? value)
    {
        value = this.Value as BrowserMouseMoveToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserScrollToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickScroll(out var value)) {
    ///     // `value` is of type `BrowserScrollToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickScroll([NotNullWhen(true)] out BrowserScrollToolUseBlock? value)
    {
        value = this.Value as BrowserScrollToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserTypeToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickType(out var value)) {
    ///     // `value` is of type `BrowserTypeToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickType([NotNullWhen(true)] out BrowserTypeToolUseBlock? value)
    {
        value = this.Value as BrowserTypeToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickKey(out var value)) {
    ///     // `value` is of type `BrowserKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickKey([NotNullWhen(true)] out BrowserKeyToolUseBlock? value)
    {
        value = this.Value as BrowserKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserHoldKeyToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickHoldKey(out var value)) {
    ///     // `value` is of type `BrowserHoldKeyToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickHoldKey([NotNullWhen(true)] out BrowserHoldKeyToolUseBlock? value)
    {
        value = this.Value as BrowserHoldKeyToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserWaitToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWait(out var value)) {
    ///     // `value` is of type `BrowserWaitToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWait([NotNullWhen(true)] out BrowserWaitToolUseBlock? value)
    {
        value = this.Value as BrowserWaitToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BrowserJavascriptExecToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickJavascriptExec(out var value)) {
    ///     // `value` is of type `BrowserJavascriptExecToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickJavascriptExec(
        [NotNullWhen(true)] out BrowserJavascriptExecToolUseBlock? value
    )
    {
        value = this.Value as BrowserJavascriptExecToolUseBlock;
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
    ///     (BrowserNavigateToolUseBlock value) =&gt; {...},
    ///     (BrowserListTabsToolUseBlock value) =&gt; {...},
    ///     (BrowserNewTabToolUseBlock value) =&gt; {...},
    ///     (BrowserSwitchTabToolUseBlock value) =&gt; {...},
    ///     (BrowserCloseTabToolUseBlock value) =&gt; {...},
    ///     (BrowserReadPageToolUseBlock value) =&gt; {...},
    ///     (BrowserGetPageTextToolUseBlock value) =&gt; {...},
    ///     (BrowserReadConsoleToolUseBlock value) =&gt; {...},
    ///     (BrowserReadNetworkToolUseBlock value) =&gt; {...},
    ///     (BrowserFindToolUseBlock value) =&gt; {...},
    ///     (BrowserFormInputToolUseBlock value) =&gt; {...},
    ///     (BrowserFileUploadToolUseBlock value) =&gt; {...},
    ///     (BrowserScrollToToolUseBlock value) =&gt; {...},
    ///     (BrowserScreenshotToolUseBlock value) =&gt; {...},
    ///     (BrowserZoomToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftClickToolUseBlock value) =&gt; {...},
    ///     (BrowserRightClickToolUseBlock value) =&gt; {...},
    ///     (BrowserMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserTripleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserHoverToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BrowserMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BrowserScrollToolUseBlock value) =&gt; {...},
    ///     (BrowserTypeToolUseBlock value) =&gt; {...},
    ///     (BrowserKeyToolUseBlock value) =&gt; {...},
    ///     (BrowserHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BrowserWaitToolUseBlock value) =&gt; {...},
    ///     (BrowserJavascriptExecToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BrowserNavigateToolUseBlock> navigate,
        System::Action<BrowserListTabsToolUseBlock> listTabs,
        System::Action<BrowserNewTabToolUseBlock> newTab,
        System::Action<BrowserSwitchTabToolUseBlock> switchTab,
        System::Action<BrowserCloseTabToolUseBlock> closeTab,
        System::Action<BrowserReadPageToolUseBlock> readPage,
        System::Action<BrowserGetPageTextToolUseBlock> getPageText,
        System::Action<BrowserReadConsoleToolUseBlock> readConsole,
        System::Action<BrowserReadNetworkToolUseBlock> readNetwork,
        System::Action<BrowserFindToolUseBlock> find,
        System::Action<BrowserFormInputToolUseBlock> formInput,
        System::Action<BrowserFileUploadToolUseBlock> fileUpload,
        System::Action<BrowserScrollToToolUseBlock> scrollTo,
        System::Action<BrowserScreenshotToolUseBlock> screenshot,
        System::Action<BrowserZoomToolUseBlock> zoom,
        System::Action<BrowserLeftClickToolUseBlock> leftClick,
        System::Action<BrowserRightClickToolUseBlock> rightClick,
        System::Action<BrowserMiddleClickToolUseBlock> middleClick,
        System::Action<BrowserDoubleClickToolUseBlock> doubleClick,
        System::Action<BrowserTripleClickToolUseBlock> tripleClick,
        System::Action<BrowserHoverToolUseBlock> hover,
        System::Action<BrowserLeftClickDragToolUseBlock> leftClickDrag,
        System::Action<BrowserLeftMouseDownToolUseBlock> leftMouseDown,
        System::Action<BrowserLeftMouseUpToolUseBlock> leftMouseUp,
        System::Action<BrowserMouseMoveToolUseBlock> mouseMove,
        System::Action<BrowserScrollToolUseBlock> scroll,
        System::Action<BrowserTypeToolUseBlock> type,
        System::Action<BrowserKeyToolUseBlock> key,
        System::Action<BrowserHoldKeyToolUseBlock> holdKey,
        System::Action<BrowserWaitToolUseBlock> wait,
        System::Action<BrowserJavascriptExecToolUseBlock> javascriptExec
    )
    {
        switch (this.Value)
        {
            case BrowserNavigateToolUseBlock value:
                navigate(value);
                break;
            case BrowserListTabsToolUseBlock value:
                listTabs(value);
                break;
            case BrowserNewTabToolUseBlock value:
                newTab(value);
                break;
            case BrowserSwitchTabToolUseBlock value:
                switchTab(value);
                break;
            case BrowserCloseTabToolUseBlock value:
                closeTab(value);
                break;
            case BrowserReadPageToolUseBlock value:
                readPage(value);
                break;
            case BrowserGetPageTextToolUseBlock value:
                getPageText(value);
                break;
            case BrowserReadConsoleToolUseBlock value:
                readConsole(value);
                break;
            case BrowserReadNetworkToolUseBlock value:
                readNetwork(value);
                break;
            case BrowserFindToolUseBlock value:
                find(value);
                break;
            case BrowserFormInputToolUseBlock value:
                formInput(value);
                break;
            case BrowserFileUploadToolUseBlock value:
                fileUpload(value);
                break;
            case BrowserScrollToToolUseBlock value:
                scrollTo(value);
                break;
            case BrowserScreenshotToolUseBlock value:
                screenshot(value);
                break;
            case BrowserZoomToolUseBlock value:
                zoom(value);
                break;
            case BrowserLeftClickToolUseBlock value:
                leftClick(value);
                break;
            case BrowserRightClickToolUseBlock value:
                rightClick(value);
                break;
            case BrowserMiddleClickToolUseBlock value:
                middleClick(value);
                break;
            case BrowserDoubleClickToolUseBlock value:
                doubleClick(value);
                break;
            case BrowserTripleClickToolUseBlock value:
                tripleClick(value);
                break;
            case BrowserHoverToolUseBlock value:
                hover(value);
                break;
            case BrowserLeftClickDragToolUseBlock value:
                leftClickDrag(value);
                break;
            case BrowserLeftMouseDownToolUseBlock value:
                leftMouseDown(value);
                break;
            case BrowserLeftMouseUpToolUseBlock value:
                leftMouseUp(value);
                break;
            case BrowserMouseMoveToolUseBlock value:
                mouseMove(value);
                break;
            case BrowserScrollToolUseBlock value:
                scroll(value);
                break;
            case BrowserTypeToolUseBlock value:
                type(value);
                break;
            case BrowserKeyToolUseBlock value:
                key(value);
                break;
            case BrowserHoldKeyToolUseBlock value:
                holdKey(value);
                break;
            case BrowserWaitToolUseBlock value:
                wait(value);
                break;
            case BrowserJavascriptExecToolUseBlock value:
                javascriptExec(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BrowserToolUseBlock"
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
    ///     (BrowserNavigateToolUseBlock value) =&gt; {...},
    ///     (BrowserListTabsToolUseBlock value) =&gt; {...},
    ///     (BrowserNewTabToolUseBlock value) =&gt; {...},
    ///     (BrowserSwitchTabToolUseBlock value) =&gt; {...},
    ///     (BrowserCloseTabToolUseBlock value) =&gt; {...},
    ///     (BrowserReadPageToolUseBlock value) =&gt; {...},
    ///     (BrowserGetPageTextToolUseBlock value) =&gt; {...},
    ///     (BrowserReadConsoleToolUseBlock value) =&gt; {...},
    ///     (BrowserReadNetworkToolUseBlock value) =&gt; {...},
    ///     (BrowserFindToolUseBlock value) =&gt; {...},
    ///     (BrowserFormInputToolUseBlock value) =&gt; {...},
    ///     (BrowserFileUploadToolUseBlock value) =&gt; {...},
    ///     (BrowserScrollToToolUseBlock value) =&gt; {...},
    ///     (BrowserScreenshotToolUseBlock value) =&gt; {...},
    ///     (BrowserZoomToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftClickToolUseBlock value) =&gt; {...},
    ///     (BrowserRightClickToolUseBlock value) =&gt; {...},
    ///     (BrowserMiddleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserDoubleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserTripleClickToolUseBlock value) =&gt; {...},
    ///     (BrowserHoverToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftClickDragToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftMouseDownToolUseBlock value) =&gt; {...},
    ///     (BrowserLeftMouseUpToolUseBlock value) =&gt; {...},
    ///     (BrowserMouseMoveToolUseBlock value) =&gt; {...},
    ///     (BrowserScrollToolUseBlock value) =&gt; {...},
    ///     (BrowserTypeToolUseBlock value) =&gt; {...},
    ///     (BrowserKeyToolUseBlock value) =&gt; {...},
    ///     (BrowserHoldKeyToolUseBlock value) =&gt; {...},
    ///     (BrowserWaitToolUseBlock value) =&gt; {...},
    ///     (BrowserJavascriptExecToolUseBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BrowserNavigateToolUseBlock, T> navigate,
        System::Func<BrowserListTabsToolUseBlock, T> listTabs,
        System::Func<BrowserNewTabToolUseBlock, T> newTab,
        System::Func<BrowserSwitchTabToolUseBlock, T> switchTab,
        System::Func<BrowserCloseTabToolUseBlock, T> closeTab,
        System::Func<BrowserReadPageToolUseBlock, T> readPage,
        System::Func<BrowserGetPageTextToolUseBlock, T> getPageText,
        System::Func<BrowserReadConsoleToolUseBlock, T> readConsole,
        System::Func<BrowserReadNetworkToolUseBlock, T> readNetwork,
        System::Func<BrowserFindToolUseBlock, T> find,
        System::Func<BrowserFormInputToolUseBlock, T> formInput,
        System::Func<BrowserFileUploadToolUseBlock, T> fileUpload,
        System::Func<BrowserScrollToToolUseBlock, T> scrollTo,
        System::Func<BrowserScreenshotToolUseBlock, T> screenshot,
        System::Func<BrowserZoomToolUseBlock, T> zoom,
        System::Func<BrowserLeftClickToolUseBlock, T> leftClick,
        System::Func<BrowserRightClickToolUseBlock, T> rightClick,
        System::Func<BrowserMiddleClickToolUseBlock, T> middleClick,
        System::Func<BrowserDoubleClickToolUseBlock, T> doubleClick,
        System::Func<BrowserTripleClickToolUseBlock, T> tripleClick,
        System::Func<BrowserHoverToolUseBlock, T> hover,
        System::Func<BrowserLeftClickDragToolUseBlock, T> leftClickDrag,
        System::Func<BrowserLeftMouseDownToolUseBlock, T> leftMouseDown,
        System::Func<BrowserLeftMouseUpToolUseBlock, T> leftMouseUp,
        System::Func<BrowserMouseMoveToolUseBlock, T> mouseMove,
        System::Func<BrowserScrollToolUseBlock, T> scroll,
        System::Func<BrowserTypeToolUseBlock, T> type,
        System::Func<BrowserKeyToolUseBlock, T> key,
        System::Func<BrowserHoldKeyToolUseBlock, T> holdKey,
        System::Func<BrowserWaitToolUseBlock, T> wait,
        System::Func<BrowserJavascriptExecToolUseBlock, T> javascriptExec
    )
    {
        return this.Value switch
        {
            BrowserNavigateToolUseBlock value => navigate(value),
            BrowserListTabsToolUseBlock value => listTabs(value),
            BrowserNewTabToolUseBlock value => newTab(value),
            BrowserSwitchTabToolUseBlock value => switchTab(value),
            BrowserCloseTabToolUseBlock value => closeTab(value),
            BrowserReadPageToolUseBlock value => readPage(value),
            BrowserGetPageTextToolUseBlock value => getPageText(value),
            BrowserReadConsoleToolUseBlock value => readConsole(value),
            BrowserReadNetworkToolUseBlock value => readNetwork(value),
            BrowserFindToolUseBlock value => find(value),
            BrowserFormInputToolUseBlock value => formInput(value),
            BrowserFileUploadToolUseBlock value => fileUpload(value),
            BrowserScrollToToolUseBlock value => scrollTo(value),
            BrowserScreenshotToolUseBlock value => screenshot(value),
            BrowserZoomToolUseBlock value => zoom(value),
            BrowserLeftClickToolUseBlock value => leftClick(value),
            BrowserRightClickToolUseBlock value => rightClick(value),
            BrowserMiddleClickToolUseBlock value => middleClick(value),
            BrowserDoubleClickToolUseBlock value => doubleClick(value),
            BrowserTripleClickToolUseBlock value => tripleClick(value),
            BrowserHoverToolUseBlock value => hover(value),
            BrowserLeftClickDragToolUseBlock value => leftClickDrag(value),
            BrowserLeftMouseDownToolUseBlock value => leftMouseDown(value),
            BrowserLeftMouseUpToolUseBlock value => leftMouseUp(value),
            BrowserMouseMoveToolUseBlock value => mouseMove(value),
            BrowserScrollToolUseBlock value => scroll(value),
            BrowserTypeToolUseBlock value => type(value),
            BrowserKeyToolUseBlock value => key(value),
            BrowserHoldKeyToolUseBlock value => holdKey(value),
            BrowserWaitToolUseBlock value => wait(value),
            BrowserJavascriptExecToolUseBlock value => javascriptExec(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BrowserToolUseBlock"
            ),
        };
    }

    public static implicit operator BrowserToolUseBlock(BrowserNavigateToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserListTabsToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserNewTabToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserSwitchTabToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserCloseTabToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserReadPageToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserGetPageTextToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserReadConsoleToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserReadNetworkToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserFindToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserFormInputToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserFileUploadToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserScrollToToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserScreenshotToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserZoomToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserLeftClickToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserRightClickToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserMiddleClickToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserDoubleClickToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserTripleClickToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserHoverToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserLeftClickDragToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserLeftMouseDownToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserLeftMouseUpToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserMouseMoveToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserScrollToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserTypeToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserKeyToolUseBlock value) => new(value);

    public static implicit operator BrowserToolUseBlock(BrowserHoldKeyToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserWaitToolUseBlock value) =>
        new(value);

    public static implicit operator BrowserToolUseBlock(BrowserJavascriptExecToolUseBlock value) =>
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
                "Data did not match any variant of BrowserToolUseBlock"
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

    public virtual bool Equals(BrowserToolUseBlock? other) =>
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
            BrowserNavigateToolUseBlock _ => 0,
            BrowserListTabsToolUseBlock _ => 1,
            BrowserNewTabToolUseBlock _ => 2,
            BrowserSwitchTabToolUseBlock _ => 3,
            BrowserCloseTabToolUseBlock _ => 4,
            BrowserReadPageToolUseBlock _ => 5,
            BrowserGetPageTextToolUseBlock _ => 6,
            BrowserReadConsoleToolUseBlock _ => 7,
            BrowserReadNetworkToolUseBlock _ => 8,
            BrowserFindToolUseBlock _ => 9,
            BrowserFormInputToolUseBlock _ => 10,
            BrowserFileUploadToolUseBlock _ => 11,
            BrowserScrollToToolUseBlock _ => 12,
            BrowserScreenshotToolUseBlock _ => 13,
            BrowserZoomToolUseBlock _ => 14,
            BrowserLeftClickToolUseBlock _ => 15,
            BrowserRightClickToolUseBlock _ => 16,
            BrowserMiddleClickToolUseBlock _ => 17,
            BrowserDoubleClickToolUseBlock _ => 18,
            BrowserTripleClickToolUseBlock _ => 19,
            BrowserHoverToolUseBlock _ => 20,
            BrowserLeftClickDragToolUseBlock _ => 21,
            BrowserLeftMouseDownToolUseBlock _ => 22,
            BrowserLeftMouseUpToolUseBlock _ => 23,
            BrowserMouseMoveToolUseBlock _ => 24,
            BrowserScrollToolUseBlock _ => 25,
            BrowserTypeToolUseBlock _ => 26,
            BrowserKeyToolUseBlock _ => 27,
            BrowserHoldKeyToolUseBlock _ => 28,
            BrowserWaitToolUseBlock _ => 29,
            BrowserJavascriptExecToolUseBlock _ => 30,
            _ => -1,
        };
    }
}

sealed class BrowserToolUseBlockConverter : JsonConverter<BrowserToolUseBlock>
{
    public override BrowserToolUseBlock? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserNavigateToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserListTabsToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserNewTabToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserSwitchTabToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserCloseTabToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserReadPageToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserGetPageTextToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserReadConsoleToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserReadNetworkToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserFindToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserFormInputToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserFileUploadToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserScrollToToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserScreenshotToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserZoomToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserLeftClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserRightClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserMiddleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserDoubleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserTripleClickToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserHoverToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserLeftClickDragToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserLeftMouseDownToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserLeftMouseUpToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserMouseMoveToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserScrollToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserTypeToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserHoldKeyToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BrowserWaitToolUseBlock>(
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
                        JsonSerializer.Deserialize<BrowserJavascriptExecToolUseBlock>(
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
                return new BrowserToolUseBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrowserToolUseBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
