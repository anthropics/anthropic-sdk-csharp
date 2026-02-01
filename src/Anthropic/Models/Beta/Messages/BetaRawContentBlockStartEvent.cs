using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<BetaRawContentBlockStartEvent, BetaRawContentBlockStartEventFromRaw>)
)]
public sealed record class BetaRawContentBlockStartEvent : JsonModel
{
    /// <summary>
    /// Response model for a file uploaded to the container.
    /// </summary>
    public required ContentBlock ContentBlock
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ContentBlock>("content_block");
        }
        init { this._rawData.Set("content_block", value); }
    }

    public required long Index
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("index");
        }
        init { this._rawData.Set("index", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentBlock.Validate();
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("content_block_start")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawContentBlockStartEvent()
    {
        this.Type = JsonSerializer.SerializeToElement("content_block_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRawContentBlockStartEvent(
        BetaRawContentBlockStartEvent betaRawContentBlockStartEvent
    )
        : base(betaRawContentBlockStartEvent) { }
#pragma warning restore CS8618

    public BetaRawContentBlockStartEvent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("content_block_start");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockStartEvent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRawContentBlockStartEventFromRaw.FromRawUnchecked"/>
    public static BetaRawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRawContentBlockStartEventFromRaw : IFromRawJson<BetaRawContentBlockStartEvent>
{
    /// <inheritdoc/>
    public BetaRawContentBlockStartEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRawContentBlockStartEvent.FromRawUnchecked(rawData);
}

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
                betaText: (x) => x.Type,
                betaThinking: (x) => x.Type,
                betaRedactedThinking: (x) => x.Type,
                betaToolUse: (x) => x.Type,
                betaServerToolUse: (x) => x.Type,
                betaWebSearchToolResult: (x) => x.Type,
                betaWebFetchToolResult: (x) => x.Type,
                betaCodeExecutionToolResult: (x) => x.Type,
                betaBashCodeExecutionToolResult: (x) => x.Type,
                betaTextEditorCodeExecutionToolResult: (x) => x.Type,
                betaToolSearchToolResult: (x) => x.Type,
                betaMcpToolUse: (x) => x.Type,
                betaMcpToolResult: (x) => x.Type,
                betaContainerUpload: (x) => x.Type
            );
        }
    }

    public string? ID
    {
        get
        {
            return Match<string?>(
                betaText: (_) => null,
                betaThinking: (_) => null,
                betaRedactedThinking: (_) => null,
                betaToolUse: (x) => x.ID,
                betaServerToolUse: (x) => x.ID,
                betaWebSearchToolResult: (_) => null,
                betaWebFetchToolResult: (_) => null,
                betaCodeExecutionToolResult: (_) => null,
                betaBashCodeExecutionToolResult: (_) => null,
                betaTextEditorCodeExecutionToolResult: (_) => null,
                betaToolSearchToolResult: (_) => null,
                betaMcpToolUse: (x) => x.ID,
                betaMcpToolResult: (_) => null,
                betaContainerUpload: (_) => null
            );
        }
    }

    public string? ToolUseID
    {
        get
        {
            return Match<string?>(
                betaText: (_) => null,
                betaThinking: (_) => null,
                betaRedactedThinking: (_) => null,
                betaToolUse: (_) => null,
                betaServerToolUse: (_) => null,
                betaWebSearchToolResult: (x) => x.ToolUseID,
                betaWebFetchToolResult: (x) => x.ToolUseID,
                betaCodeExecutionToolResult: (x) => x.ToolUseID,
                betaBashCodeExecutionToolResult: (x) => x.ToolUseID,
                betaTextEditorCodeExecutionToolResult: (x) => x.ToolUseID,
                betaToolSearchToolResult: (x) => x.ToolUseID,
                betaMcpToolUse: (_) => null,
                betaMcpToolResult: (x) => x.ToolUseID,
                betaContainerUpload: (_) => null
            );
        }
    }

    public ContentBlock(BetaTextBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaThinkingBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaRedactedThinkingBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaServerToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaWebSearchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaWebFetchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaCodeExecutionToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaBashCodeExecutionToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaToolSearchToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaMcpToolUseBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaMcpToolResultBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ContentBlock(BetaContainerUploadBlock value, JsonElement? element = null)
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
    /// type <see cref="BetaTextBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaText(out var value)) {
    ///     // `value` is of type `BetaTextBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaText([NotNullWhen(true)] out BetaTextBlock? value)
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
    /// if (instance.TryPickBetaThinking(out var value)) {
    ///     // `value` is of type `BetaThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaThinking([NotNullWhen(true)] out BetaThinkingBlock? value)
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
    /// if (instance.TryPickBetaRedactedThinking(out var value)) {
    ///     // `value` is of type `BetaRedactedThinkingBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRedactedThinking(
        [NotNullWhen(true)] out BetaRedactedThinkingBlock? value
    )
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
    /// if (instance.TryPickBetaToolUse(out var value)) {
    ///     // `value` is of type `BetaToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolUse([NotNullWhen(true)] out BetaToolUseBlock? value)
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
    /// if (instance.TryPickBetaServerToolUse(out var value)) {
    ///     // `value` is of type `BetaServerToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaServerToolUse([NotNullWhen(true)] out BetaServerToolUseBlock? value)
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
    /// if (instance.TryPickBetaWebSearchToolResult(out var value)) {
    ///     // `value` is of type `BetaWebSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebSearchToolResult(
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
    /// if (instance.TryPickBetaWebFetchToolResult(out var value)) {
    ///     // `value` is of type `BetaWebFetchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchToolResult(
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
    /// if (instance.TryPickBetaCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaCodeExecutionToolResult(
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
    /// if (instance.TryPickBetaBashCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaBashCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaBashCodeExecutionToolResult(
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
    /// if (instance.TryPickBetaTextEditorCodeExecutionToolResult(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionToolResult(
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
    /// if (instance.TryPickBetaToolSearchToolResult(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolResult(
        [NotNullWhen(true)] out BetaToolSearchToolResultBlock? value
    )
    {
        value = this.Value as BetaToolSearchToolResultBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMcpToolUseBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMcpToolUse(out var value)) {
    ///     // `value` is of type `BetaMcpToolUseBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMcpToolUse([NotNullWhen(true)] out BetaMcpToolUseBlock? value)
    {
        value = this.Value as BetaMcpToolUseBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaMcpToolResultBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaMcpToolResult(out var value)) {
    ///     // `value` is of type `BetaMcpToolResultBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaMcpToolResult([NotNullWhen(true)] out BetaMcpToolResultBlock? value)
    {
        value = this.Value as BetaMcpToolResultBlock;
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
    /// if (instance.TryPickBetaContainerUpload(out var value)) {
    ///     // `value` is of type `BetaContainerUploadBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaContainerUpload([NotNullWhen(true)] out BetaContainerUploadBlock? value)
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
    ///     (BetaMcpToolUseBlock value) => {...},
    ///     (BetaMcpToolResultBlock value) => {...},
    ///     (BetaContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextBlock> betaText,
        System::Action<BetaThinkingBlock> betaThinking,
        System::Action<BetaRedactedThinkingBlock> betaRedactedThinking,
        System::Action<BetaToolUseBlock> betaToolUse,
        System::Action<BetaServerToolUseBlock> betaServerToolUse,
        System::Action<BetaWebSearchToolResultBlock> betaWebSearchToolResult,
        System::Action<BetaWebFetchToolResultBlock> betaWebFetchToolResult,
        System::Action<BetaCodeExecutionToolResultBlock> betaCodeExecutionToolResult,
        System::Action<BetaBashCodeExecutionToolResultBlock> betaBashCodeExecutionToolResult,
        System::Action<BetaTextEditorCodeExecutionToolResultBlock> betaTextEditorCodeExecutionToolResult,
        System::Action<BetaToolSearchToolResultBlock> betaToolSearchToolResult,
        System::Action<BetaMcpToolUseBlock> betaMcpToolUse,
        System::Action<BetaMcpToolResultBlock> betaMcpToolResult,
        System::Action<BetaContainerUploadBlock> betaContainerUpload
    )
    {
        switch (this.Value)
        {
            case BetaTextBlock value:
                betaText(value);
                break;
            case BetaThinkingBlock value:
                betaThinking(value);
                break;
            case BetaRedactedThinkingBlock value:
                betaRedactedThinking(value);
                break;
            case BetaToolUseBlock value:
                betaToolUse(value);
                break;
            case BetaServerToolUseBlock value:
                betaServerToolUse(value);
                break;
            case BetaWebSearchToolResultBlock value:
                betaWebSearchToolResult(value);
                break;
            case BetaWebFetchToolResultBlock value:
                betaWebFetchToolResult(value);
                break;
            case BetaCodeExecutionToolResultBlock value:
                betaCodeExecutionToolResult(value);
                break;
            case BetaBashCodeExecutionToolResultBlock value:
                betaBashCodeExecutionToolResult(value);
                break;
            case BetaTextEditorCodeExecutionToolResultBlock value:
                betaTextEditorCodeExecutionToolResult(value);
                break;
            case BetaToolSearchToolResultBlock value:
                betaToolSearchToolResult(value);
                break;
            case BetaMcpToolUseBlock value:
                betaMcpToolUse(value);
                break;
            case BetaMcpToolResultBlock value:
                betaMcpToolResult(value);
                break;
            case BetaContainerUploadBlock value:
                betaContainerUpload(value);
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
    ///     (BetaMcpToolUseBlock value) => {...},
    ///     (BetaMcpToolResultBlock value) => {...},
    ///     (BetaContainerUploadBlock value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTextBlock, T> betaText,
        System::Func<BetaThinkingBlock, T> betaThinking,
        System::Func<BetaRedactedThinkingBlock, T> betaRedactedThinking,
        System::Func<BetaToolUseBlock, T> betaToolUse,
        System::Func<BetaServerToolUseBlock, T> betaServerToolUse,
        System::Func<BetaWebSearchToolResultBlock, T> betaWebSearchToolResult,
        System::Func<BetaWebFetchToolResultBlock, T> betaWebFetchToolResult,
        System::Func<BetaCodeExecutionToolResultBlock, T> betaCodeExecutionToolResult,
        System::Func<BetaBashCodeExecutionToolResultBlock, T> betaBashCodeExecutionToolResult,
        System::Func<
            BetaTextEditorCodeExecutionToolResultBlock,
            T
        > betaTextEditorCodeExecutionToolResult,
        System::Func<BetaToolSearchToolResultBlock, T> betaToolSearchToolResult,
        System::Func<BetaMcpToolUseBlock, T> betaMcpToolUse,
        System::Func<BetaMcpToolResultBlock, T> betaMcpToolResult,
        System::Func<BetaContainerUploadBlock, T> betaContainerUpload
    )
    {
        return this.Value switch
        {
            BetaTextBlock value => betaText(value),
            BetaThinkingBlock value => betaThinking(value),
            BetaRedactedThinkingBlock value => betaRedactedThinking(value),
            BetaToolUseBlock value => betaToolUse(value),
            BetaServerToolUseBlock value => betaServerToolUse(value),
            BetaWebSearchToolResultBlock value => betaWebSearchToolResult(value),
            BetaWebFetchToolResultBlock value => betaWebFetchToolResult(value),
            BetaCodeExecutionToolResultBlock value => betaCodeExecutionToolResult(value),
            BetaBashCodeExecutionToolResultBlock value => betaBashCodeExecutionToolResult(value),
            BetaTextEditorCodeExecutionToolResultBlock value =>
                betaTextEditorCodeExecutionToolResult(value),
            BetaToolSearchToolResultBlock value => betaToolSearchToolResult(value),
            BetaMcpToolUseBlock value => betaMcpToolUse(value),
            BetaMcpToolResultBlock value => betaMcpToolResult(value),
            BetaContainerUploadBlock value => betaContainerUpload(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentBlock"
            ),
        };
    }

    public static implicit operator ContentBlock(BetaTextBlock value) => new(value);

    public static implicit operator ContentBlock(BetaThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(BetaRedactedThinkingBlock value) => new(value);

    public static implicit operator ContentBlock(BetaToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaServerToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaWebSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaWebFetchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(BetaBashCodeExecutionToolResultBlock value) =>
        new(value);

    public static implicit operator ContentBlock(
        BetaTextEditorCodeExecutionToolResultBlock value
    ) => new(value);

    public static implicit operator ContentBlock(BetaToolSearchToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaMcpToolUseBlock value) => new(value);

    public static implicit operator ContentBlock(BetaMcpToolResultBlock value) => new(value);

    public static implicit operator ContentBlock(BetaContainerUploadBlock value) => new(value);

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
            (betaText) => betaText.Validate(),
            (betaThinking) => betaThinking.Validate(),
            (betaRedactedThinking) => betaRedactedThinking.Validate(),
            (betaToolUse) => betaToolUse.Validate(),
            (betaServerToolUse) => betaServerToolUse.Validate(),
            (betaWebSearchToolResult) => betaWebSearchToolResult.Validate(),
            (betaWebFetchToolResult) => betaWebFetchToolResult.Validate(),
            (betaCodeExecutionToolResult) => betaCodeExecutionToolResult.Validate(),
            (betaBashCodeExecutionToolResult) => betaBashCodeExecutionToolResult.Validate(),
            (betaTextEditorCodeExecutionToolResult) =>
                betaTextEditorCodeExecutionToolResult.Validate(),
            (betaToolSearchToolResult) => betaToolSearchToolResult.Validate(),
            (betaMcpToolUse) => betaMcpToolUse.Validate(),
            (betaMcpToolResult) => betaMcpToolResult.Validate(),
            (betaContainerUpload) => betaContainerUpload.Validate()
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
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        {
            BetaTextBlock _ => 0,
            BetaThinkingBlock _ => 1,
            BetaRedactedThinkingBlock _ => 2,
            BetaToolUseBlock _ => 3,
            BetaServerToolUseBlock _ => 4,
            BetaWebSearchToolResultBlock _ => 5,
            BetaWebFetchToolResultBlock _ => 6,
            BetaCodeExecutionToolResultBlock _ => 7,
            BetaBashCodeExecutionToolResultBlock _ => 8,
            BetaTextEditorCodeExecutionToolResultBlock _ => 9,
            BetaToolSearchToolResultBlock _ => 10,
            BetaMcpToolUseBlock _ => 11,
            BetaMcpToolResultBlock _ => 12,
            BetaContainerUploadBlock _ => 13,
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlock>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<BetaThinkingBlock>(
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
            case "redacted_thinking":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRedactedThinkingBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolUseBlock>(
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
            case "server_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolUseBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultBlock>(
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
                    var deserialized =
                        JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultBlock>(
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
                        JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlock>(
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
            case "mcp_tool_use":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMcpToolUseBlock>(
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
            case "mcp_tool_result":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaMcpToolResultBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaContainerUploadBlock>(
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
