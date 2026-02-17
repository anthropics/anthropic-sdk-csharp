using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(ContentBlockConverter))]
public record class ContentBlock : ModelBase
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

    public JsonElement Type
    {
        get
        {
            return Match(
                text: (x) => x.Type,
                thinking: (x) => x.Type,
                redactedThinking: (x) => x.Type,
                toolUse: (x) => x.Type,
                serverToolUse: (x) => x.Type,
                webSearchToolResult: (x) => x.Type,
                webFetchToolResult: (x) => x.Type,
                codeExecutionToolResult: (x) => x.Type,
                bashCodeExecutionToolResult: (x) => x.Type,
                textEditorCodeExecutionToolResult: (x) => x.Type,
                toolSearchToolResult: (x) => x.Type,
                containerUpload: (x) => x.Type
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (x) => x.ID,
                serverToolUse: (x) => x.ID,
                webSearchToolResult: (_) => null,
                webFetchToolResult: (_) => null,
                codeExecutionToolResult: (_) => null,
                bashCodeExecutionToolResult: (_) => null,
                textEditorCodeExecutionToolResult: (_) => null,
                toolSearchToolResult: (_) => null,
                containerUpload: (_) => null
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                text: (_) => null,
                thinking: (_) => null,
                redactedThinking: (_) => null,
                toolUse: (_) => null,
                serverToolUse: (_) => null,
                webSearchToolResult: (x) => x.ToolUseID,
                webFetchToolResult: (x) => x.ToolUseID,
                codeExecutionToolResult: (x) => x.ToolUseID,
                bashCodeExecutionToolResult: (x) => x.ToolUseID,
                textEditorCodeExecutionToolResult: (x) => x.ToolUseID,
                toolSearchToolResult: (x) => x.ToolUseID,
                containerUpload: (_) => null
            );
        }
    }

    public ContentBlock(TextBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(ThinkingBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(RedactedThinkingBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(ToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(ServerToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(WebSearchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(WebFetchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(CodeExecutionToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BashCodeExecutionToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(TextEditorCodeExecutionToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(ToolSearchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(ContainerUploadBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `TextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out TextBlock? value)
    {
        value = this.Value as TextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ThinkingBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinking(out var value)) {
    ///     // `value` is of type `ThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinking([NotNullWhen(true)] out ThinkingBlock? value)
    {
        value = this.Value as ThinkingBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="RedactedThinkingBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRedactedThinking(out var value)) {
    ///     // `value` is of type `RedactedThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRedactedThinking([NotNullWhen(true)] out RedactedThinkingBlock? value)
    {
        value = this.Value as RedactedThinkingBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolUse(out var value)) {
    ///     // `value` is of type `ToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolUse([NotNullWhen(true)] out ToolUseBlock? value)
    {
        value = this.Value as ToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ServerToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerToolUse(out var value)) {
    ///     // `value` is of type `ServerToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerToolUse([NotNullWhen(true)] out ServerToolUseBlock? value)
    {
        value = this.Value as ServerToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebSearchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchToolResult(out var value)) {
    ///     // `value` is of type `WebSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchToolResult([NotNullWhen(true)] out WebSearchToolResultBlock? value)
    {
        value = this.Value as WebSearchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="WebFetchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchToolResult(out var value)) {
    ///     // `value` is of type `WebFetchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchToolResult([NotNullWhen(true)] out WebFetchToolResultBlock? value)
    {
        value = this.Value as WebFetchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="CodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `CodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out CodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as CodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BashCodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BashCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BashCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BashCodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="TextEditorCodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `TextEditorCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out TextEditorCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as TextEditorCodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolResult(out var value)) {
    ///     // `value` is of type `ToolSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolResult(
        [NotNullWhen(true)] out ToolSearchToolResultBlock? value
    )
    {
        value = this.Value as ToolSearchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ContainerUploadBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContainerUpload(out var value)) {
    ///     // `value` is of type `ContainerUploadBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContainerUpload([NotNullWhen(true)] out ContainerUploadBlock? value)
    {
        value = this.Value as ContainerUploadBlock;
        return value != null;
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match">
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
    ///     (TextBlock value) => {...},
    ///     (ThinkingBlock value) => {...},
    ///     (RedactedThinkingBlock value) => {...},
    ///     (ToolUseBlock value) => {...},
    ///     (ServerToolUseBlock value) => {...},
    ///     (WebSearchToolResultBlock value) => {...},
    ///     (WebFetchToolResultBlock value) => {...},
    ///     (CodeExecutionToolResultBlock value) => {...},
    ///     (BashCodeExecutionToolResultBlock value) => {...},
    ///     (TextEditorCodeExecutionToolResultBlock value) => {...},
    ///     (ToolSearchToolResultBlock value) => {...},
    ///     (ContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<TextBlock> text,
        System::Action<ThinkingBlock> thinking,
        System::Action<RedactedThinkingBlock> redactedThinking,
        System::Action<ToolUseBlock> toolUse,
        System::Action<ServerToolUseBlock> serverToolUse,
        System::Action<WebSearchToolResultBlock> webSearchToolResult,
        System::Action<WebFetchToolResultBlock> webFetchToolResult,
        System::Action<CodeExecutionToolResultBlock> codeExecutionToolResult,
        System::Action<BashCodeExecutionToolResultBlock> bashCodeExecutionToolResult,
        System::Action<TextEditorCodeExecutionToolResultBlock> textEditorCodeExecutionToolResult,
        System::Action<ToolSearchToolResultBlock> toolSearchToolResult,
        System::Action<ContainerUploadBlock> containerUpload
    )
    {
        switch (this.Value)
        {
            case TextBlock value:
                text(value);
                break;
            case ThinkingBlock value:
                thinking(value);
                break;
            case RedactedThinkingBlock value:
                redactedThinking(value);
                break;
            case ToolUseBlock value:
                toolUse(value);
                break;
            case ServerToolUseBlock value:
                serverToolUse(value);
                break;
            case WebSearchToolResultBlock value:
                webSearchToolResult(value);
                break;
            case WebFetchToolResultBlock value:
                webFetchToolResult(value);
                break;
            case CodeExecutionToolResultBlock value:
                codeExecutionToolResult(value);
                break;
            case BashCodeExecutionToolResultBlock value:
                bashCodeExecutionToolResult(value);
                break;
            case TextEditorCodeExecutionToolResultBlock value:
                textEditorCodeExecutionToolResult(value);
                break;
            case ToolSearchToolResultBlock value:
                toolSearchToolResult(value);
                break;
            case ContainerUploadBlock value:
                containerUpload(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentBlock"
                );
        }
    }

    /// <summary>
    /// Calls the function parameter corresponding to the variant the instance was constructed with and
    /// returns its result.
    ///
    /// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch">
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
    ///     (TextBlock value) => {...},
    ///     (ThinkingBlock value) => {...},
    ///     (RedactedThinkingBlock value) => {...},
    ///     (ToolUseBlock value) => {...},
    ///     (ServerToolUseBlock value) => {...},
    ///     (WebSearchToolResultBlock value) => {...},
    ///     (WebFetchToolResultBlock value) => {...},
    ///     (CodeExecutionToolResultBlock value) => {...},
    ///     (BashCodeExecutionToolResultBlock value) => {...},
    ///     (TextEditorCodeExecutionToolResultBlock value) => {...},
    ///     (ToolSearchToolResultBlock value) => {...},
    ///     (ContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<TextBlock, T> text,
        System::Func<ThinkingBlock, T> thinking,
        System::Func<RedactedThinkingBlock, T> redactedThinking,
        System::Func<ToolUseBlock, T> toolUse,
        System::Func<ServerToolUseBlock, T> serverToolUse,
        System::Func<WebSearchToolResultBlock, T> webSearchToolResult,
        System::Func<WebFetchToolResultBlock, T> webFetchToolResult,
        System::Func<CodeExecutionToolResultBlock, T> codeExecutionToolResult,
        System::Func<BashCodeExecutionToolResultBlock, T> bashCodeExecutionToolResult,
        System::Func<TextEditorCodeExecutionToolResultBlock, T> textEditorCodeExecutionToolResult,
        System::Func<ToolSearchToolResultBlock, T> toolSearchToolResult,
        System::Func<ContainerUploadBlock, T> containerUpload
    )
    {
        return this.Value switch
        {
            TextBlock value => text(value),
            ThinkingBlock value => thinking(value),
            RedactedThinkingBlock value => redactedThinking(value),
            ToolUseBlock value => toolUse(value),
            ServerToolUseBlock value => serverToolUse(value),
            WebSearchToolResultBlock value => webSearchToolResult(value),
            WebFetchToolResultBlock value => webFetchToolResult(value),
            CodeExecutionToolResultBlock value => codeExecutionToolResult(value),
            BashCodeExecutionToolResultBlock value => bashCodeExecutionToolResult(value),
            TextEditorCodeExecutionToolResultBlock value => textEditorCodeExecutionToolResult(
                value
            ),
            ToolSearchToolResultBlock value => toolSearchToolResult(value),
            ContainerUploadBlock value => containerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            ),
        };
    }

    public static implicit operator ContentBlock(TextBlock value) => new(value);

    public static implicit operator ContentBlock(ThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(RedactedThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(ToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(ServerToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(WebSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(WebFetchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(CodeExecutionToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BashCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(TextEditorCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(ToolSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(ContainerUploadBlock value) => new(value);

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
                "Data did not match any variant of ContentBlock"
            );
        }
        this.Switch(
            (text) => text.Validate(),
            (thinking) => thinking.Validate(),
            (redactedThinking) => redactedThinking.Validate(),
            (toolUse) => toolUse.Validate(),
            (serverToolUse) => serverToolUse.Validate(),
            (webSearchToolResult) => webSearchToolResult.Validate(),
            (webFetchToolResult) => webFetchToolResult.Validate(),
            (codeExecutionToolResult) => codeExecutionToolResult.Validate(),
            (bashCodeExecutionToolResult) => bashCodeExecutionToolResult.Validate(),
            (textEditorCodeExecutionToolResult) => textEditorCodeExecutionToolResult.Validate(),
            (toolSearchToolResult) => toolSearchToolResult.Validate(),
            (containerUpload) => containerUpload.Validate()
        );
    }

    public virtual bool Equals(ContentBlock? other) =>
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
            TextBlock _ => 0,
            ThinkingBlock _ => 1,
            RedactedThinkingBlock _ => 2,
            ToolUseBlock _ => 3,
            ServerToolUseBlock _ => 4,
            WebSearchToolResultBlock _ => 5,
            WebFetchToolResultBlock _ => 6,
            CodeExecutionToolResultBlock _ => 7,
            BashCodeExecutionToolResultBlock _ => 8,
            TextEditorCodeExecutionToolResultBlock _ => 9,
            ToolSearchToolResultBlock _ => 10,
            ContainerUploadBlock _ => 11,
            _ => -1,
        };
    }
}

sealed class ContentBlockConverter : JsonConverter<ContentBlock>
{
    public override ContentBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = element.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "text":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TextBlock>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ThinkingBlock>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "redacted_thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<RedactedThinkingBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolUseBlock>(element, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "server_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ServerToolUseBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "web_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "web_fetch_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "code_execution_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CodeExecutionToolResultBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "bash_code_execution_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "text_editor_code_execution_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<TextEditorCodeExecutionToolResultBlock>(
                            element,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "tool_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            case "container_upload":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ContainerUploadBlock>(
                        element,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, element);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(element);
            }
            default:
            {
                return new ContentBlock(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
