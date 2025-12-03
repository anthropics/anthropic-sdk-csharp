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
    typeof(ModelConverter<
        BetaToolSearchToolResultBlockParam,
        BetaToolSearchToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaToolSearchToolResultBlockParam : ModelBase
{
    public required BetaToolSearchToolResultBlockParamContent Content
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaToolSearchToolResultBlockParamContent>(
                this.RawData,
                "content"
            );
        }
        init { ModelBase.Set(this._rawData, "content", value); }
    }

    public required string ToolUseID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "tool_use_id"); }
        init { ModelBase.Set(this._rawData, "tool_use_id", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            return ModelBase.GetNullableClass<BetaCacheControlEphemeral>(
                this.RawData,
                "cache_control"
            );
        }
        init { ModelBase.Set(this._rawData, "cache_control", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaToolSearchToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

    public BetaToolSearchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolSearchToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaToolSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultBlockParamFromRaw : IFromRaw<BetaToolSearchToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaToolSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolResultBlockParamContentConverter))]
public record class BetaToolSearchToolResultBlockParamContent
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
                betaToolSearchToolResultErrorParam: (x) => x.Type,
                betaToolSearchToolSearchResultBlockParam: (x) => x.Type
            );
        }
    }

    public BetaToolSearchToolResultBlockParamContent(
        BetaToolSearchToolResultErrorParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockParamContent(
        BetaToolSearchToolSearchResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolResultErrorParam(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolResultErrorParam(
        [NotNullWhen(true)] out BetaToolSearchToolResultErrorParam? value
    )
    {
        value = this.Value as BetaToolSearchToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaToolSearchToolSearchResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaToolSearchToolSearchResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaToolSearchToolSearchResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaToolSearchToolSearchResultBlockParam(
        [NotNullWhen(true)] out BetaToolSearchToolSearchResultBlockParam? value
    )
    {
        value = this.Value as BetaToolSearchToolSearchResultBlockParam;
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
    ///     (BetaToolSearchToolResultErrorParam value) => {...},
    ///     (BetaToolSearchToolSearchResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaToolSearchToolResultErrorParam> betaToolSearchToolResultErrorParam,
        System::Action<BetaToolSearchToolSearchResultBlockParam> betaToolSearchToolSearchResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaToolSearchToolResultErrorParam value:
                betaToolSearchToolResultErrorParam(value);
                break;
            case BetaToolSearchToolSearchResultBlockParam value:
                betaToolSearchToolSearchResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolSearchToolResultBlockParamContent"
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
    ///     (BetaToolSearchToolResultErrorParam value) => {...},
    ///     (BetaToolSearchToolSearchResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaToolSearchToolResultErrorParam, T> betaToolSearchToolResultErrorParam,
        System::Func<
            BetaToolSearchToolSearchResultBlockParam,
            T
        > betaToolSearchToolSearchResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaToolSearchToolResultErrorParam value => betaToolSearchToolResultErrorParam(value),
            BetaToolSearchToolSearchResultBlockParam value =>
                betaToolSearchToolSearchResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaToolSearchToolResultBlockParamContent(
        BetaToolSearchToolResultErrorParam value
    ) => new(value);

    public static implicit operator BetaToolSearchToolResultBlockParamContent(
        BetaToolSearchToolSearchResultBlockParam value
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
    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockParamContent"
            );
        }
    }

    public virtual bool Equals(BetaToolSearchToolResultBlockParamContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaToolSearchToolResultBlockParamContentConverter
    : JsonConverter<BetaToolSearchToolResultBlockParamContent>
{
    public override BetaToolSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultErrorParam>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolSearchResultBlockParam>(
                json,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new(deserialized, json);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            // ignore
        }

        return new(json);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaToolSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
