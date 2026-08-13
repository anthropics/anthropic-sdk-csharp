using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// System instructions that appear mid-conversation.
///
/// <para>Use this block to provide or update system-level instructions at a specific
/// point in the conversation, rather than only via the top-level `system` parameter.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaMidConversationSystemBlockParam,
        BetaMidConversationSystemBlockParamFromRaw
    >)
)]
public sealed record class BetaMidConversationSystemBlockParam : JsonModel
{
    /// <summary>
    /// System instruction text blocks.
    /// </summary>
    public required IReadOnlyList<BetaMidConversationSystemBlockParamContent> Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaMidConversationSystemBlockParamContent>
            >("content");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaMidConversationSystemBlockParamContent>>(
                "content",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Content)
        {
            item.Validate();
        }
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("mid_conv_system"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaMidConversationSystemBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaMidConversationSystemBlockParam(
        BetaMidConversationSystemBlockParam betaMidConversationSystemBlockParam
    )
        : base(betaMidConversationSystemBlockParam) { }
#pragma warning restore CS8618

    public BetaMidConversationSystemBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("mid_conv_system");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMidConversationSystemBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaMidConversationSystemBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaMidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaMidConversationSystemBlockParam(
        IReadOnlyList<BetaMidConversationSystemBlockParamContent> content
    )
        : this()
    {
        this.Content = content;
    }
}

class BetaMidConversationSystemBlockParamFromRaw : IFromRawJson<BetaMidConversationSystemBlockParam>
{
    /// <inheritdoc/>
    public BetaMidConversationSystemBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaMidConversationSystemBlockParam.FromRawUnchecked(rawData);
}

/// <summary>
/// Mid-conversation directive to surface a declared tool.
///
/// <para>``tool`` references a tool (or MCP toolset) by name from the request's
/// ``tools``; it is offered to the model from this point in the conversation onward.</para>
/// </summary>
[JsonConverter(typeof(BetaMidConversationSystemBlockParamContentConverter))]
public record class BetaMidConversationSystemBlockParamContent : ModelBase
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
                betaTextBlockParam: (x) => x.Type,
                betaRequestToolAdditionBlock: (x) => x.Type,
                betaRequestToolRemovalBlock: (x) => x.Type
            );
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return Match<BetaCacheControlEphemeral?>(
                betaTextBlockParam: (x) => x.CacheControl,
                betaRequestToolAdditionBlock: (x) => x.CacheControl,
                betaRequestToolRemovalBlock: (x) => x.CacheControl
            );
        }
    }

    public BetaMidConversationSystemBlockParamContent(
        BetaTextBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMidConversationSystemBlockParamContent(
        BetaRequestToolAdditionBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMidConversationSystemBlockParamContent(
        BetaRequestToolRemovalBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaMidConversationSystemBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextBlockParam(out var value)) {
    ///     // `value` is of type `BetaTextBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextBlockParam([NotNullWhen(true)] out BetaTextBlockParam? value)
    {
        value = this.Value as BetaTextBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRequestToolAdditionBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRequestToolAdditionBlock(out var value)) {
    ///     // `value` is of type `BetaRequestToolAdditionBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRequestToolAdditionBlock(
        [NotNullWhen(true)] out BetaRequestToolAdditionBlock? value
    )
    {
        value = this.Value as BetaRequestToolAdditionBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaRequestToolRemovalBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaRequestToolRemovalBlock(out var value)) {
    ///     // `value` is of type `BetaRequestToolRemovalBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaRequestToolRemovalBlock(
        [NotNullWhen(true)] out BetaRequestToolRemovalBlock? value
    )
    {
        value = this.Value as BetaRequestToolRemovalBlock;
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
    ///     (BetaTextBlockParam value) =&gt; {...},
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextBlockParam> betaTextBlockParam,
        System::Action<BetaRequestToolAdditionBlock> betaRequestToolAdditionBlock,
        System::Action<BetaRequestToolRemovalBlock> betaRequestToolRemovalBlock
    )
    {
        switch (this.Value)
        {
            case BetaTextBlockParam value:
                betaTextBlockParam(value);
                break;
            case BetaRequestToolAdditionBlock value:
                betaRequestToolAdditionBlock(value);
                break;
            case BetaRequestToolRemovalBlock value:
                betaRequestToolRemovalBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaMidConversationSystemBlockParamContent"
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
    ///     (BetaTextBlockParam value) =&gt; {...},
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaTextBlockParam, T> betaTextBlockParam,
        System::Func<BetaRequestToolAdditionBlock, T> betaRequestToolAdditionBlock,
        System::Func<BetaRequestToolRemovalBlock, T> betaRequestToolRemovalBlock
    )
    {
        return this.Value switch
        {
            BetaTextBlockParam value => betaTextBlockParam(value),
            BetaRequestToolAdditionBlock value => betaRequestToolAdditionBlock(value),
            BetaRequestToolRemovalBlock value => betaRequestToolRemovalBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMidConversationSystemBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaMidConversationSystemBlockParamContent(
        BetaTextBlockParam value
    ) => new(value);

    public static implicit operator BetaMidConversationSystemBlockParamContent(
        BetaRequestToolAdditionBlock value
    ) => new(value);

    public static implicit operator BetaMidConversationSystemBlockParamContent(
        BetaRequestToolRemovalBlock value
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
                "Data did not match any variant of BetaMidConversationSystemBlockParamContent"
            );
        }
        this.Switch(
            (betaTextBlockParam) => betaTextBlockParam.Validate(),
            (betaRequestToolAdditionBlock) => betaRequestToolAdditionBlock.Validate(),
            (betaRequestToolRemovalBlock) => betaRequestToolRemovalBlock.Validate()
        );
    }

    public virtual bool Equals(BetaMidConversationSystemBlockParamContent? other) =>
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
            BetaTextBlockParam _ => 0,
            BetaRequestToolAdditionBlock _ => 1,
            BetaRequestToolRemovalBlock _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaMidConversationSystemBlockParamContentConverter
    : JsonConverter<BetaMidConversationSystemBlockParamContent>
{
    public override BetaMidConversationSystemBlockParamContent? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaTextBlockParam>(
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
            case "tool_addition":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
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
            case "tool_removal":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
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
                return new BetaMidConversationSystemBlockParamContent(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaMidConversationSystemBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
