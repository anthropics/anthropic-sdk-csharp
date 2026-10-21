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
/// A compaction block containing summary of previous context.
///
/// <para>Users should round-trip these blocks from responses to subsequent requests
/// to maintain context across compaction boundaries.</para>
///
/// <para>When content is None, the block represents a failed compaction. The server
/// treats these as no-ops. Empty string content is not allowed.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaCompactionBlockParam, BetaCompactionBlockParamFromRaw>)
)]
public sealed record class BetaCompactionBlockParam : JsonModel
{
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

    /// <summary>
    /// Summary of previously compacted content, or null if compaction failed
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Opaque metadata from prior compaction, to be round-tripped verbatim
    /// </summary>
    public string? EncryptedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("encrypted_content");
        }
        init { this._rawData.Set("encrypted_content", value); }
    }

    /// <summary>
    /// The block's signature as returned, to be sent back verbatim
    /// </summary>
    public string? Signature
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("signature");
        }
        init { this._rawData.Set("signature", value); }
    }

    /// <summary>
    /// The tool changes of the compacted range, as the server returned them on this
    /// block: the `tool_addition` and `tool_removal` entries that take the request's
    /// `tools` to the tool set in effect at the end of the range. Send them back
    /// unchanged with the block.
    /// </summary>
    public IReadOnlyList<BetaCompactionBlockParamToolChange>? ToolChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<BetaCompactionBlockParamToolChange>
            >("tool_changes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaCompactionBlockParamToolChange>?>(
                "tool_changes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("compaction")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        _ = this.Content;
        _ = this.EncryptedContent;
        _ = this.Signature;
        foreach (var item in this.ToolChanges ?? [])
        {
            item.Validate();
        }
    }

    public BetaCompactionBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionBlockParam(BetaCompactionBlockParam betaCompactionBlockParam)
        : base(betaCompactionBlockParam) { }
#pragma warning restore CS8618

    public BetaCompactionBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaCompactionBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCompactionBlockParamFromRaw : IFromRawJson<BetaCompactionBlockParam>
{
    /// <inheritdoc/>
    public BetaCompactionBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaCompactionBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaCompactionBlockParamToolChangeConverter))]
public record class BetaCompactionBlockParamToolChange : ModelBase
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
            return this.Value switch
            {
                BetaRequestToolAdditionBlock x => x.Type,
                BetaRequestToolRemovalBlock x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return this.Value switch
            {
                BetaRequestToolAdditionBlock x => x.CacheControl,
                BetaRequestToolRemovalBlock x => x.CacheControl,
                _ => WrappedJsonSerializer.GetNullableClassProperty<BetaCacheControlEphemeral>(
                    this.Json,
                    "cache_control"
                ),
            };
        }
    }

    public BetaCompactionBlockParamToolChange(
        BetaRequestToolAdditionBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCompactionBlockParamToolChange(
        BetaRequestToolRemovalBlock value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaCompactionBlockParamToolChange(JsonElement element)
    {
        this._element = element;
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
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaRequestToolAdditionBlock> betaRequestToolAdditionBlock,
        System::Action<BetaRequestToolRemovalBlock> betaRequestToolRemovalBlock
    )
    {
        switch (this.Value)
        {
            case BetaRequestToolAdditionBlock value:
                betaRequestToolAdditionBlock(value);
                break;
            case BetaRequestToolRemovalBlock value:
                betaRequestToolRemovalBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCompactionBlockParamToolChange"
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
    ///     (BetaRequestToolAdditionBlock value) =&gt; {...},
    ///     (BetaRequestToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaRequestToolAdditionBlock, T> betaRequestToolAdditionBlock,
        System::Func<BetaRequestToolRemovalBlock, T> betaRequestToolRemovalBlock
    )
    {
        return this.Value switch
        {
            BetaRequestToolAdditionBlock value => betaRequestToolAdditionBlock(value),
            BetaRequestToolRemovalBlock value => betaRequestToolRemovalBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCompactionBlockParamToolChange"
            ),
        };
    }

    public static implicit operator BetaCompactionBlockParamToolChange(
        BetaRequestToolAdditionBlock value
    ) => new(value);

    public static implicit operator BetaCompactionBlockParamToolChange(
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
                "Data did not match any variant of BetaCompactionBlockParamToolChange"
            );
        }
        this.Switch(
            (betaRequestToolAdditionBlock) => betaRequestToolAdditionBlock.Validate(),
            (betaRequestToolRemovalBlock) => betaRequestToolRemovalBlock.Validate()
        );
    }

    public virtual bool Equals(BetaCompactionBlockParamToolChange? other) =>
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
            BetaRequestToolAdditionBlock _ => 0,
            BetaRequestToolRemovalBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaCompactionBlockParamToolChangeConverter
    : JsonConverter<BetaCompactionBlockParamToolChange>
{
    public override BetaCompactionBlockParamToolChange? Read(
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
                return new BetaCompactionBlockParamToolChange(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaCompactionBlockParamToolChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
