using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        ToolSearchToolResultBlockParam,
        ToolSearchToolResultBlockParamFromRaw
    >)
)]
public sealed record class ToolSearchToolResultBlockParam : JsonModel
{
    public required ToolSearchToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ToolSearchToolResultBlockParamContent>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required string ToolUseID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tool_use_id");
        }
        init { this._rawData.Set("tool_use_id", value); }
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
    public CacheControlEphemeral? CacheControl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CacheControlEphemeral>("cache_control");
        }
        init { this._rawData.Set("cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("tool_search_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public ToolSearchToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolSearchToolResultBlockParam(
        ToolSearchToolResultBlockParam toolSearchToolResultBlockParam
    )
        : base(toolSearchToolResultBlockParam) { }
#pragma warning restore CS8618

    public ToolSearchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_search_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolSearchToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolSearchToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static ToolSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolSearchToolResultBlockParamFromRaw : IFromRawJson<ToolSearchToolResultBlockParam>
{
    /// <inheritdoc/>
    public ToolSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolSearchToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolSearchToolResultBlockParamContentConverter))]
public record class ToolSearchToolResultBlockParamContent : ModelBase
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
                toolSearchToolResultErrorParam: (x) => x.Type,
                toolSearchToolSearchResultBlockParam: (x) => x.Type
            );
        }
    }

    public ToolSearchToolResultBlockParamContent(
        ToolSearchToolResultErrorParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ToolSearchToolResultBlockParamContent(
        ToolSearchToolSearchResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ToolSearchToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolResultErrorParam(out var value)) {
    ///     // `value` is of type `ToolSearchToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolResultErrorParam(
        [NotNullWhen(true)] out ToolSearchToolResultErrorParam? value
    )
    {
        value = this.Value as ToolSearchToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="ToolSearchToolSearchResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickToolSearchToolSearchResultBlockParam(out var value)) {
    ///     // `value` is of type `ToolSearchToolSearchResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickToolSearchToolSearchResultBlockParam(
        [NotNullWhen(true)] out ToolSearchToolSearchResultBlockParam? value
    )
    {
        value = this.Value as ToolSearchToolSearchResultBlockParam;
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
    ///     (ToolSearchToolResultErrorParam value) => {...},
    ///     (ToolSearchToolSearchResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<ToolSearchToolResultErrorParam> toolSearchToolResultErrorParam,
        System::Action<ToolSearchToolSearchResultBlockParam> toolSearchToolSearchResultBlockParam
    )
    {
        switch (this.Value)
        {
            case ToolSearchToolResultErrorParam value:
                toolSearchToolResultErrorParam(value);
                break;
            case ToolSearchToolSearchResultBlockParam value:
                toolSearchToolSearchResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ToolSearchToolResultBlockParamContent"
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
    ///     (ToolSearchToolResultErrorParam value) => {...},
    ///     (ToolSearchToolSearchResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<ToolSearchToolResultErrorParam, T> toolSearchToolResultErrorParam,
        System::Func<ToolSearchToolSearchResultBlockParam, T> toolSearchToolSearchResultBlockParam
    )
    {
        return this.Value switch
        {
            ToolSearchToolResultErrorParam value => toolSearchToolResultErrorParam(value),
            ToolSearchToolSearchResultBlockParam value => toolSearchToolSearchResultBlockParam(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ToolSearchToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator ToolSearchToolResultBlockParamContent(
        ToolSearchToolResultErrorParam value
    ) => new(value);

    public static implicit operator ToolSearchToolResultBlockParamContent(
        ToolSearchToolSearchResultBlockParam value
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
                "Data did not match any variant of ToolSearchToolResultBlockParamContent"
            );
        }
        this.Switch(
            (toolSearchToolResultErrorParam) => toolSearchToolResultErrorParam.Validate(),
            (toolSearchToolSearchResultBlockParam) =>
                toolSearchToolSearchResultBlockParam.Validate()
        );
    }

    public virtual bool Equals(ToolSearchToolResultBlockParamContent? other) =>
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
            ToolSearchToolResultErrorParam _ => 0,
            ToolSearchToolSearchResultBlockParam _ => 1,
            _ => -1,
        };
    }
}

sealed class ToolSearchToolResultBlockParamContentConverter
    : JsonConverter<ToolSearchToolResultBlockParamContent>
{
    public override ToolSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultErrorParam>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<ToolSearchToolSearchResultBlockParam>(
                element,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ToolSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
