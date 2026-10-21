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
/// A compaction block returned when autocompact is triggered.
///
/// <para>When content is None, it indicates the compaction failed to produce a valid
/// summary (e.g., malformed output from the model). Clients may round-trip compaction
/// blocks with null content; the server treats them as no-ops.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaCompactionBlock, BetaCompactionBlockFromRaw>))]
public sealed record class BetaCompactionBlock : JsonModel
{
    /// <summary>
    /// Summary of compacted content, or null if compaction failed
    /// </summary>
    public required string? Content
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
    public required string? EncryptedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("encrypted_content");
        }
        init { this._rawData.Set("encrypted_content", value); }
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
    /// Signature over the summary, to be sent back with the block verbatim
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
    /// The tool changes of the compacted range: the `tool_addition` and `tool_removal`
    /// blocks that take the request's `tools` to the tool set in effect at the end
    /// of the range, or `[]` when the range changed no tool. Absent when the server
    /// did not compute them. Send the block back unchanged.
    /// </summary>
    public IReadOnlyList<ToolChange>? ToolChanges
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ToolChange>>("tool_changes");
        }
        init
        {
            this._rawData.Set<ImmutableArray<ToolChange>?>(
                "tool_changes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.EncryptedContent;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("compaction")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Signature;
        foreach (var item in this.ToolChanges ?? [])
        {
            item.Validate();
        }
    }

    public BetaCompactionBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaCompactionBlock(BetaCompactionBlock betaCompactionBlock)
        : base(betaCompactionBlock) { }
#pragma warning restore CS8618

    public BetaCompactionBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("compaction");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaCompactionBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaCompactionBlockFromRaw.FromRawUnchecked"/>
    public static BetaCompactionBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaCompactionBlockFromRaw : IFromRawJson<BetaCompactionBlock>
{
    /// <inheritdoc/>
    public BetaCompactionBlock FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaCompactionBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolChangeConverter))]
public record class ToolChange : ModelBase
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
                BetaResponseToolAdditionBlock x => x.Type,
                BetaResponseToolRemovalBlock x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public ToolChange(BetaResponseToolAdditionBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChange(BetaResponseToolRemovalBlock value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public ToolChange(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaResponseToolAdditionBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaResponseToolAdditionBlock(out var value)) {
    ///     // `value` is of type `BetaResponseToolAdditionBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaResponseToolAdditionBlock(
        [NotNullWhen(true)] out BetaResponseToolAdditionBlock? value
    )
    {
        value = this.Value as BetaResponseToolAdditionBlock;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaResponseToolRemovalBlock"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaResponseToolRemovalBlock(out var value)) {
    ///     // `value` is of type `BetaResponseToolRemovalBlock`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaResponseToolRemovalBlock(
        [NotNullWhen(true)] out BetaResponseToolRemovalBlock? value
    )
    {
        value = this.Value as BetaResponseToolRemovalBlock;
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
    ///     (BetaResponseToolAdditionBlock value) =&gt; {...},
    ///     (BetaResponseToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaResponseToolAdditionBlock> betaResponseToolAdditionBlock,
        System::Action<BetaResponseToolRemovalBlock> betaResponseToolRemovalBlock
    )
    {
        switch (this.Value)
        {
            case BetaResponseToolAdditionBlock value:
                betaResponseToolAdditionBlock(value);
                break;
            case BetaResponseToolRemovalBlock value:
                betaResponseToolRemovalBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolChange"
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
    ///     (BetaResponseToolAdditionBlock value) =&gt; {...},
    ///     (BetaResponseToolRemovalBlock value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaResponseToolAdditionBlock, T> betaResponseToolAdditionBlock,
        System::Func<BetaResponseToolRemovalBlock, T> betaResponseToolRemovalBlock
    )
    {
        return this.Value switch
        {
            BetaResponseToolAdditionBlock value => betaResponseToolAdditionBlock(value),
            BetaResponseToolRemovalBlock value => betaResponseToolRemovalBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolChange"
            ),
        };
    }

    public static implicit operator ToolChange(BetaResponseToolAdditionBlock value) => new(value);

    public static implicit operator ToolChange(BetaResponseToolRemovalBlock value) => new(value);

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
            throw new AnthropicInvalidDataException("Data did not match any variant of ToolChange");
        }
        this.Switch(
            (betaResponseToolAdditionBlock) => betaResponseToolAdditionBlock.Validate(),
            (betaResponseToolRemovalBlock) => betaResponseToolRemovalBlock.Validate()
        );
    }

    public virtual bool Equals(ToolChange? other) =>
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
            BetaResponseToolAdditionBlock _ => 0,
            BetaResponseToolRemovalBlock _ => 1,
            _ => -1,
        };
    }
}

sealed class ToolChangeConverter : JsonConverter<ToolChange>
{
    public override ToolChange? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaResponseToolAdditionBlock>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaResponseToolRemovalBlock>(
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
                return new ToolChange(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolChange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
