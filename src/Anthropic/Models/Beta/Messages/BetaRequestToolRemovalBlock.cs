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
/// Mid-conversation directive to withdraw a tool.
///
/// <para>``tool`` references a tool (or MCP toolset) by name from the request's
/// ``tools``; it is no longer offered to the model from this point in the conversation onward.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaRequestToolRemovalBlock, BetaRequestToolRemovalBlockFromRaw>)
)]
public sealed record class BetaRequestToolRemovalBlock : JsonModel
{
    /// <summary>
    /// Reference to a single tool the caller declared directly in ``tools[]``. Does
    /// not accept the composed ``{server}_{name}`` form the server assigns to MCP-resolved
    /// tools — use ``mcp_tool_reference`` or ``mcp_toolset_reference`` for those.
    /// </summary>
    public required BetaRequestToolRemovalBlockTool Tool
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaRequestToolRemovalBlockTool>("tool");
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
        this.Tool.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_removal")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaRequestToolRemovalBlock()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_removal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRequestToolRemovalBlock(BetaRequestToolRemovalBlock betaRequestToolRemovalBlock)
        : base(betaRequestToolRemovalBlock) { }
#pragma warning restore CS8618

    public BetaRequestToolRemovalBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_removal");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestToolRemovalBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestToolRemovalBlockFromRaw.FromRawUnchecked"/>
    public static BetaRequestToolRemovalBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaRequestToolRemovalBlock(BetaRequestToolRemovalBlockTool tool)
        : this()
    {
        this.Tool = tool;
    }
}

class BetaRequestToolRemovalBlockFromRaw : IFromRawJson<BetaRequestToolRemovalBlock>
{
    /// <inheritdoc/>
    public BetaRequestToolRemovalBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestToolRemovalBlock.FromRawUnchecked(rawData);
}

/// <summary>
/// Reference to a single tool the caller declared directly in ``tools[]``. Does
/// not accept the composed ``{server}_{name}`` form the server assigns to MCP-resolved
/// tools — use ``mcp_tool_reference`` or ``mcp_toolset_reference`` for those.
/// </summary>
[JsonConverter(typeof(BetaRequestToolRemovalBlockToolConverter))]
public record class BetaRequestToolRemovalBlockTool : ModelBase
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
            return Match<string?>(
                betaToolChangeToolReference: (x) => x.Name,
                betaToolChangeMcpToolReference: (x) => x.Name,
                betaToolChangeMcpToolsetReference: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaToolChangeToolReference: (x) => x.Type,
                betaToolChangeMcpToolReference: (x) => x.Type,
                betaToolChangeMcpToolsetReference: (x) => x.Type
            );
        }
    }

    public string? ServerName
    {
        get
        {
            return Match<string?>(
                betaToolChangeToolReference: (_) => null,
                betaToolChangeMcpToolReference: (x) => x.ServerName,
                betaToolChangeMcpToolsetReference: (x) => x.ServerName
            );
        }
    }

    public BetaRequestToolRemovalBlockTool(
        BetaToolChangeToolReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRequestToolRemovalBlockTool(
        BetaToolChangeMcpToolReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRequestToolRemovalBlockTool(
        BetaToolChangeMcpToolsetReference value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaRequestToolRemovalBlockTool(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChangeToolReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolChangeToolReference(out var value)) {
    ///     // `value` is of type `BetaToolChangeToolReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolChangeToolReference(
        [NotNullWhen(true)] out BetaToolChangeToolReference? value
    )
    {
        value = this.Value as BetaToolChangeToolReference;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChangeMcpToolReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolChangeMcpToolReference(out var value)) {
    ///     // `value` is of type `BetaToolChangeMcpToolReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolChangeMcpToolReference(
        [NotNullWhen(true)] out BetaToolChangeMcpToolReference? value
    )
    {
        value = this.Value as BetaToolChangeMcpToolReference;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolChangeMcpToolsetReference"/>.
    ///
    /// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolChangeMcpToolsetReference(out var value)) {
    ///     // `value` is of type `BetaToolChangeMcpToolsetReference`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolChangeMcpToolsetReference(
        [NotNullWhen(true)] out BetaToolChangeMcpToolsetReference? value
    )
    {
        value = this.Value as BetaToolChangeMcpToolsetReference;
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
    ///     (BetaToolChangeToolReference value) =&gt; {...},
    ///     (BetaToolChangeMcpToolReference value) =&gt; {...},
    ///     (BetaToolChangeMcpToolsetReference value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaToolChangeToolReference> betaToolChangeToolReference,
        System::Action<BetaToolChangeMcpToolReference> betaToolChangeMcpToolReference,
        System::Action<BetaToolChangeMcpToolsetReference> betaToolChangeMcpToolsetReference
    )
    {
        switch (this.Value)
        {
            case BetaToolChangeToolReference value:
                betaToolChangeToolReference(value);
                break;
            case BetaToolChangeMcpToolReference value:
                betaToolChangeMcpToolReference(value);
                break;
            case BetaToolChangeMcpToolsetReference value:
                betaToolChangeMcpToolsetReference(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaRequestToolRemovalBlockTool"
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
    ///     (BetaToolChangeToolReference value) =&gt; {...},
    ///     (BetaToolChangeMcpToolReference value) =&gt; {...},
    ///     (BetaToolChangeMcpToolsetReference value) =&gt; {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaToolChangeToolReference, T> betaToolChangeToolReference,
        System::Func<BetaToolChangeMcpToolReference, T> betaToolChangeMcpToolReference,
        System::Func<BetaToolChangeMcpToolsetReference, T> betaToolChangeMcpToolsetReference
    )
    {
        return this.Value switch
        {
            BetaToolChangeToolReference value => betaToolChangeToolReference(value),
            BetaToolChangeMcpToolReference value => betaToolChangeMcpToolReference(value),
            BetaToolChangeMcpToolsetReference value => betaToolChangeMcpToolsetReference(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaRequestToolRemovalBlockTool"
            ),
        };
    }

    public static implicit operator BetaRequestToolRemovalBlockTool(
        BetaToolChangeToolReference value
    ) => new(value);

    public static implicit operator BetaRequestToolRemovalBlockTool(
        BetaToolChangeMcpToolReference value
    ) => new(value);

    public static implicit operator BetaRequestToolRemovalBlockTool(
        BetaToolChangeMcpToolsetReference value
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
                "Data did not match any variant of BetaRequestToolRemovalBlockTool"
            );
        }
        this.Switch(
            (betaToolChangeToolReference) => betaToolChangeToolReference.Validate(),
            (betaToolChangeMcpToolReference) => betaToolChangeMcpToolReference.Validate(),
            (betaToolChangeMcpToolsetReference) => betaToolChangeMcpToolsetReference.Validate()
        );
    }

    public virtual bool Equals(BetaRequestToolRemovalBlockTool? other) =>
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
            BetaToolChangeToolReference _ => 0,
            BetaToolChangeMcpToolReference _ => 1,
            BetaToolChangeMcpToolsetReference _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaRequestToolRemovalBlockToolConverter
    : JsonConverter<BetaRequestToolRemovalBlockTool>
{
    public override BetaRequestToolRemovalBlockTool? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChangeToolReference>(
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
                    var deserialized = JsonSerializer.Deserialize<BetaToolChangeMcpToolReference>(
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
                        JsonSerializer.Deserialize<BetaToolChangeMcpToolsetReference>(
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
                return new BetaRequestToolRemovalBlockTool(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaRequestToolRemovalBlockTool value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
