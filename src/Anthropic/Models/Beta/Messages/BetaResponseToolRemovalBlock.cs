using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// An entry of a `compaction` block's `tool_changes`: a tool of the request's `tools`
/// (or an MCP tool or toolset) that the compacted range withdrew. Send it back unchanged.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaResponseToolRemovalBlock, BetaResponseToolRemovalBlockFromRaw>)
)]
public sealed record class BetaResponseToolRemovalBlock : JsonModel
{
    /// <summary>
    /// A reference to the withdrawn `tools` entry, MCP tool or MCP toolset.
    /// </summary>
    public required BetaResponseToolRemovalBlockTool Tool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaResponseToolRemovalBlockTool>("tool");
        }
        init { this._rawData.Set("tool", value); }
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
        this.Tool.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_removal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaResponseToolRemovalBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_removal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseToolRemovalBlock(BetaResponseToolRemovalBlock betaResponseToolRemovalBlock)
        : base(betaResponseToolRemovalBlock) { }
#pragma warning restore CS8618

    public BetaResponseToolRemovalBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_removal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseToolRemovalBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolRemovalBlockFromRaw.FromRawUnchecked"/>
    public static BetaResponseToolRemovalBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaResponseToolRemovalBlock(BetaResponseToolRemovalBlockTool tool)
        : this()
    {
        this.Tool = tool;
    }
}

class BetaResponseToolRemovalBlockFromRaw : IFromRawJson<BetaResponseToolRemovalBlock>
{
    /// <inheritdoc/>
    public BetaResponseToolRemovalBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaResponseToolRemovalBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// A reference to the withdrawn `tools` entry, MCP tool or MCP toolset.
/// </summary>
[JsonConverter(typeof(BetaResponseToolRemovalBlockToolConverter))]
public record class BetaResponseToolRemovalBlockTool : ModelBase
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

    public string? Name
    {
        get
        {
            return this.Value switch
            {
                BetaResponseToolChangeToolReference x => x.Name,
                BetaResponseToolChangeMcpToolReference x => x.Name,
                BetaResponseToolChangeMcpToolsetReference _ => null,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(this.Json, "name"),
            };
        }
    }

    public JsonElement Type
    {
        get
        {
            return this.Value switch
            {
                BetaResponseToolChangeToolReference x => x.Type,
                BetaResponseToolChangeMcpToolReference x => x.Type,
                BetaResponseToolChangeMcpToolsetReference x => x.Type,
                _ => WrappedJsonSerializer.GetNotNullStructProperty<JsonElement>(this.Json, "type"),
            };
        }
    }

    public string? ServerName
    {
        get
        {
            return this.Value switch
            {
                BetaResponseToolChangeToolReference _ => null,
                BetaResponseToolChangeMcpToolReference x => x.ServerName,
                BetaResponseToolChangeMcpToolsetReference x => x.ServerName,
                _ => WrappedJsonSerializer.GetNullableClassProperty<string>(
                    this.Json,
                    "server_name"
                ),
            };
        }
    }

    public BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeToolReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeMcpToolReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeMcpToolsetReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaResponseToolRemovalBlockTool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaResponseToolChangeToolReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaResponseToolChangeToolReference(out var value)) {
    ///     // `value` is of type `BetaResponseToolChangeToolReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaResponseToolChangeToolReference(
        [NotNullWhen(true)] out BetaResponseToolChangeToolReference? value
    )
    {
        value = this.Value as BetaResponseToolChangeToolReference;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaResponseToolChangeMcpToolReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaResponseToolChangeMcpToolReference(out var value)) {
    ///     // `value` is of type `BetaResponseToolChangeMcpToolReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaResponseToolChangeMcpToolReference(
        [NotNullWhen(true)] out BetaResponseToolChangeMcpToolReference? value
    )
    {
        value = this.Value as BetaResponseToolChangeMcpToolReference;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaResponseToolChangeMcpToolsetReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaResponseToolChangeMcpToolsetReference(out var value)) {
    ///     // `value` is of type `BetaResponseToolChangeMcpToolsetReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaResponseToolChangeMcpToolsetReference(
        [NotNullWhen(true)] out BetaResponseToolChangeMcpToolsetReference? value
    )
    {
        value = this.Value as BetaResponseToolChangeMcpToolsetReference;
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
    ///     (BetaResponseToolChangeToolReference value) =&gt; {...},
    ///     (BetaResponseToolChangeMcpToolReference value) =&gt; {...},
    ///     (BetaResponseToolChangeMcpToolsetReference value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaResponseToolChangeToolReference> betaResponseToolChangeToolReference,
        System::Action<BetaResponseToolChangeMcpToolReference> betaResponseToolChangeMcpToolReference,
        System::Action<BetaResponseToolChangeMcpToolsetReference> betaResponseToolChangeMcpToolsetReference
    )
    {
        switch (this.Value)
        {
            case BetaResponseToolChangeToolReference value:
                betaResponseToolChangeToolReference(value);
                break;
            case BetaResponseToolChangeMcpToolReference value:
                betaResponseToolChangeMcpToolReference(value);
                break;
            case BetaResponseToolChangeMcpToolsetReference value:
                betaResponseToolChangeMcpToolsetReference(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaResponseToolRemovalBlockTool"
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
    ///     (BetaResponseToolChangeToolReference value) =&gt; {...},
    ///     (BetaResponseToolChangeMcpToolReference value) =&gt; {...},
    ///     (BetaResponseToolChangeMcpToolsetReference value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaResponseToolChangeToolReference, T> betaResponseToolChangeToolReference,
        System::Func<
            BetaResponseToolChangeMcpToolReference,
            T
        > betaResponseToolChangeMcpToolReference,
        System::Func<
            BetaResponseToolChangeMcpToolsetReference,
            T
        > betaResponseToolChangeMcpToolsetReference
    )
    {
        return this.Value switch
        {
            BetaResponseToolChangeToolReference value => betaResponseToolChangeToolReference(value),
            BetaResponseToolChangeMcpToolReference value => betaResponseToolChangeMcpToolReference(
                value
            ),
            BetaResponseToolChangeMcpToolsetReference value =>
                betaResponseToolChangeMcpToolsetReference(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaResponseToolRemovalBlockTool"
            ),
        };
    }

    public static implicit operator BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeToolReference value
    ) => new(value);

    public static implicit operator BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeMcpToolReference value
    ) => new(value);

    public static implicit operator BetaResponseToolRemovalBlockTool(
        BetaResponseToolChangeMcpToolsetReference value
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
                "Data did not match any variant of BetaResponseToolRemovalBlockTool"
            );
        }
        this.Switch(
            (betaResponseToolChangeToolReference) => betaResponseToolChangeToolReference.Validate(),
            (betaResponseToolChangeMcpToolReference) =>
                betaResponseToolChangeMcpToolReference.Validate(),
            (betaResponseToolChangeMcpToolsetReference) =>
                betaResponseToolChangeMcpToolsetReference.Validate()
        );
    }

    public virtual bool Equals(BetaResponseToolRemovalBlockTool? other) =>
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
            BetaResponseToolChangeToolReference _ => 0,
            BetaResponseToolChangeMcpToolReference _ => 1,
            BetaResponseToolChangeMcpToolsetReference _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaResponseToolRemovalBlockToolConverter
    : JsonConverter<BetaResponseToolRemovalBlockTool>
{
    public override BetaResponseToolRemovalBlockTool? Read(
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
            case "tool_reference":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaResponseToolChangeToolReference>(
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
            case "mcp_tool_reference":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaResponseToolChangeMcpToolReference>(
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
            case "mcp_toolset_reference":
            {
                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaResponseToolChangeMcpToolsetReference>(
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
                return new BetaResponseToolRemovalBlockTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaResponseToolRemovalBlockTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
