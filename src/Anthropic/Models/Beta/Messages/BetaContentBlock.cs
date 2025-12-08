using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
[JsonConverter(typeof(BetaContentBlockConverter))]
public record class BetaContentBlock
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
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
                mcpToolUse: (x) => x.Type,
                mcpToolResult: (x) => x.Type,
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
                mcpToolUse: (x) => x.ID,
                mcpToolResult: (_) => null,
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
                mcpToolUse: (_) => null,
                mcpToolResult: (x) => x.ToolUseID,
                containerUpload: (_) => null
            );
        }
    }

    public BetaContentBlock(BetaTextBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaThinkingBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaRedactedThinkingBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaServerToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaWebSearchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaWebFetchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaCodeExecutionToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaBashCodeExecutionToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaToolSearchToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaMCPToolUseBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaMCPToolResultBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(BetaContainerUploadBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaContentBlock(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickText(out var value)) {
    ///     // `value` is of type `BetaTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickText([NotNullWhen(true)] out BetaTextBlock? value)
    {
        value = this.Value as BetaTextBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaThinkingBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickThinking(out var value)) {
    ///     // `value` is of type `BetaThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
    {
        value = this.Value as BetaThinkingBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRedactedThinkingBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickRedactedThinking(out var value)) {
    ///     // `value` is of type `BetaRedactedThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickRedactedThinking([NotNullWhen(true)] out BetaRedactedThinkingBlock? value)
    {
        value = this.Value as BetaRedactedThinkingBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolUse(out var value)) {
    ///     // `value` is of type `BetaToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
    {
        value = this.Value as BetaToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaServerToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickServerToolUse(out var value)) {
    ///     // `value` is of type `BetaServerToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
    {
        value = this.Value as BetaServerToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebSearchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebSearchToolResult(out var value)) {
    ///     // `value` is of type `BetaWebSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebSearchToolResult(
        [NotNullWhen(true)] out BetaWebSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebSearchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickWebFetchToolResult(out var value)) {
    ///     // `value` is of type `BetaWebFetchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickWebFetchToolResult(
        [NotNullWhen(true)] out BetaWebFetchToolResultBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaCodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaCodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaBashCodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaBashCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickTextEditorCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickTextEditorCodeExecutionToolResult(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolResult(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolResult(
        [NotNullWhen(true)] out BetaToolSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaToolSearchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMCPToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMCPToolUse(out var value)) {
    ///     // `value` is of type `BetaMCPToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMCPToolUse([NotNullWhen(true)] out BetaMCPToolUseBlock? value)
    {
        value = this.Value as BetaMCPToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMCPToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickMCPToolResult(out var value)) {
    ///     // `value` is of type `BetaMCPToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickMCPToolResult([NotNullWhen(true)] out BetaMCPToolResultBlock? value)
    {
        value = this.Value as BetaMCPToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaContainerUploadBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickContainerUpload(out var value)) {
    ///     // `value` is of type `BetaContainerUploadBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
    {
        value = this.Value as BetaContainerUploadBlock;
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
    ///     (BetaTextBlock value) => {...},
    ///     (BetaThinkingBlock value) => {...},
    ///     (BetaRedactedThinkingBlock value) => {...},
    ///     (BetaToolUseBlock value) => {...},
    ///     (BetaServerToolUseBlock value) => {...},
    ///     (BetaWebSearchToolResultBlock value) => {...},
    ///     (BetaWebFetchToolResultBlock value) => {...},
    ///     (BetaCodeExecutionToolResultBlock value) => {...},
    ///     (BetaBashCodeExecutionToolResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionToolResultBlock value) => {...},
    ///     (BetaToolSearchToolResultBlock value) => {...},
    ///     (BetaMCPToolUseBlock value) => {...},
    ///     (BetaMCPToolResultBlock value) => {...},
    ///     (BetaContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextBlock> text,
        System::Action<BetaThinkingBlock> thinking,
        System::Action<BetaRedactedThinkingBlock> redactedThinking,
        System::Action<BetaToolUseBlock> toolUse,
        System::Action<BetaServerToolUseBlock> serverToolUse,
        System::Action<BetaWebSearchToolResultBlock> webSearchToolResult,
        System::Action<BetaWebFetchToolResultBlock> webFetchToolResult,
        System::Action<BetaCodeExecutionToolResultBlock> codeExecutionToolResult,
        System::Action<BetaBashCodeExecutionToolResultBlock> bashCodeExecutionToolResult,
        System::Action<BetaTextEditorCodeExecutionToolResultBlock> textEditorCodeExecutionToolResult,
        System::Action<BetaToolSearchToolResultBlock> toolSearchToolResult,
        System::Action<BetaMCPToolUseBlock> mcpToolUse,
        System::Action<BetaMCPToolResultBlock> mcpToolResult,
        System::Action<BetaContainerUploadBlock> containerUpload
    )
    {
        switch (this.Value)
        {
            case BetaTextBlock value:
                text(value);
                break;
            case BetaThinkingBlock value:
                thinking(value);
                break;
            case BetaRedactedThinkingBlock value:
                redactedThinking(value);
                break;
            case BetaToolUseBlock value:
                toolUse(value);
                break;
            case BetaServerToolUseBlock value:
                serverToolUse(value);
                break;
            case BetaWebSearchToolResultBlock value:
                webSearchToolResult(value);
                break;
            case BetaWebFetchToolResultBlock value:
                webFetchToolResult(value);
                break;
            case BetaCodeExecutionToolResultBlock value:
                codeExecutionToolResult(value);
                break;
            case BetaBashCodeExecutionToolResultBlock value:
                bashCodeExecutionToolResult(value);
                break;
            case BetaTextEditorCodeExecutionToolResultBlock value:
                textEditorCodeExecutionToolResult(value);
                break;
            case BetaToolSearchToolResultBlock value:
                toolSearchToolResult(value);
                break;
            case BetaMCPToolUseBlock value:
                mcpToolUse(value);
                break;
            case BetaMCPToolResultBlock value:
                mcpToolResult(value);
                break;
            case BetaContainerUploadBlock value:
                containerUpload(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaContentBlock"
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
    ///     (BetaTextBlock value) => {...},
    ///     (BetaThinkingBlock value) => {...},
    ///     (BetaRedactedThinkingBlock value) => {...},
    ///     (BetaToolUseBlock value) => {...},
    ///     (BetaServerToolUseBlock value) => {...},
    ///     (BetaWebSearchToolResultBlock value) => {...},
    ///     (BetaWebFetchToolResultBlock value) => {...},
    ///     (BetaCodeExecutionToolResultBlock value) => {...},
    ///     (BetaBashCodeExecutionToolResultBlock value) => {...},
    ///     (BetaTextEditorCodeExecutionToolResultBlock value) => {...},
    ///     (BetaToolSearchToolResultBlock value) => {...},
    ///     (BetaMCPToolUseBlock value) => {...},
    ///     (BetaMCPToolResultBlock value) => {...},
    ///     (BetaContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTextBlock, T> text,
        System::Func<BetaThinkingBlock, T> thinking,
        System::Func<BetaRedactedThinkingBlock, T> redactedThinking,
        System::Func<BetaToolUseBlock, T> toolUse,
        System::Func<BetaServerToolUseBlock, T> serverToolUse,
        System::Func<BetaWebSearchToolResultBlock, T> webSearchToolResult,
        System::Func<BetaWebFetchToolResultBlock, T> webFetchToolResult,
        System::Func<BetaCodeExecutionToolResultBlock, T> codeExecutionToolResult,
        System::Func<BetaBashCodeExecutionToolResultBlock, T> bashCodeExecutionToolResult,
        System::Func<
            BetaTextEditorCodeExecutionToolResultBlock,
            T
        > textEditorCodeExecutionToolResult,
        System::Func<BetaToolSearchToolResultBlock, T> toolSearchToolResult,
        System::Func<BetaMCPToolUseBlock, T> mcpToolUse,
        System::Func<BetaMCPToolResultBlock, T> mcpToolResult,
        System::Func<BetaContainerUploadBlock, T> containerUpload
    )
    {
        return this.Value switch
        {
            BetaTextBlock value => text(value),
            BetaThinkingBlock value => thinking(value),
            BetaRedactedThinkingBlock value => redactedThinking(value),
            BetaToolUseBlock value => toolUse(value),
            BetaServerToolUseBlock value => serverToolUse(value),
            BetaWebSearchToolResultBlock value => webSearchToolResult(value),
            BetaWebFetchToolResultBlock value => webFetchToolResult(value),
            BetaCodeExecutionToolResultBlock value => codeExecutionToolResult(value),
            BetaBashCodeExecutionToolResultBlock value => bashCodeExecutionToolResult(value),
            BetaTextEditorCodeExecutionToolResultBlock value => textEditorCodeExecutionToolResult(
                value
            ),
            BetaToolSearchToolResultBlock value => toolSearchToolResult(value),
            BetaMCPToolUseBlock value => mcpToolUse(value),
            BetaMCPToolResultBlock value => mcpToolResult(value),
            BetaContainerUploadBlock value => containerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlock"
            ),
        };
    }

    public static implicit operator BetaContentBlock(BetaTextBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaThinkingBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaRedactedThinkingBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaToolUseBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaServerToolUseBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaWebSearchToolResultBlock value) =>
        new(value);

    public static implicit operator BetaContentBlock(BetaWebFetchToolResultBlock value) =>
        new(value);

    public static implicit operator BetaContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator BetaContentBlock(BetaBashCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator BetaContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value
    ) => new(value);

    public static implicit operator BetaContentBlock(BetaToolSearchToolResultBlock value) =>
        new(value);

    public static implicit operator BetaContentBlock(BetaMCPToolUseBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaMCPToolResultBlock value) => new(value);

    public static implicit operator BetaContentBlock(BetaContainerUploadBlock value) => new(value);

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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaContentBlock"
            );
        }
    }

    public virtual bool Equals(BetaContentBlock? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaContentBlockConverter : JsonConverter<BetaContentBlock>
{
    public override BetaContentBlock? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "redacted_thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "server_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "web_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "web_fetch_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "code_execution_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "bash_code_execution_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "text_editor_code_execution_tool_result":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "tool_search_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "mcp_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolUseBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "mcp_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "container_upload":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new BetaContentBlock(json);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaContentBlock value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
