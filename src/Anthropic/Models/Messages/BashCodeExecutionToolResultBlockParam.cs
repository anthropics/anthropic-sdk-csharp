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
        BashCodeExecutionToolResultBlockParam,
        BashCodeExecutionToolResultBlockParamFromRaw
    >)
)]
public sealed record class BashCodeExecutionToolResultBlockParam : JsonModel
{
    public required BashCodeExecutionToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BashCodeExecutionToolResultBlockParamContent>(
                "content"
            );
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
                JsonSerializer.SerializeToElement("bash_code_execution_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BashCodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BashCodeExecutionToolResultBlockParam(
        BashCodeExecutionToolResultBlockParam bashCodeExecutionToolResultBlockParam
    )
        : base(bashCodeExecutionToolResultBlockParam) { }
#pragma warning restore CS8618

    public BashCodeExecutionToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bash_code_execution_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BashCodeExecutionToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BashCodeExecutionToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BashCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BashCodeExecutionToolResultBlockParamFromRaw
    : IFromRawJson<BashCodeExecutionToolResultBlockParam>
{
    /// <inheritdoc/>
    public BashCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BashCodeExecutionToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BashCodeExecutionToolResultBlockParamContentConverter))]
public record class BashCodeExecutionToolResultBlockParamContent : ModelBase
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
                bashCodeExecutionToolResultErrorParam: (x) => x.Type,
                bashCodeExecutionResultBlockParam: (x) => x.Type
            );
        }
    }

    public BashCodeExecutionToolResultBlockParamContent(
        BashCodeExecutionToolResultErrorParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BashCodeExecutionToolResultBlockParamContent(
        BashCodeExecutionResultBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BashCodeExecutionToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BashCodeExecutionToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionToolResultErrorParam(out var value)) {
    ///     // `value` is of type `BashCodeExecutionToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BashCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BashCodeExecutionToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BashCodeExecutionResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBashCodeExecutionResultBlockParam(out var value)) {
    ///     // `value` is of type `BashCodeExecutionResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBashCodeExecutionResultBlockParam(
        [NotNullWhen(true)] out BashCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as BashCodeExecutionResultBlockParam;
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
    ///     (BashCodeExecutionToolResultErrorParam value) => {...},
    ///     (BashCodeExecutionResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BashCodeExecutionToolResultErrorParam> bashCodeExecutionToolResultErrorParam,
        System::Action<BashCodeExecutionResultBlockParam> bashCodeExecutionResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BashCodeExecutionToolResultErrorParam value:
                bashCodeExecutionToolResultErrorParam(value);
                break;
            case BashCodeExecutionResultBlockParam value:
                bashCodeExecutionResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BashCodeExecutionToolResultBlockParamContent"
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
    ///     (BashCodeExecutionToolResultErrorParam value) => {...},
    ///     (BashCodeExecutionResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BashCodeExecutionToolResultErrorParam,
            T
        > bashCodeExecutionToolResultErrorParam,
        System::Func<BashCodeExecutionResultBlockParam, T> bashCodeExecutionResultBlockParam
    )
    {
        return this.Value switch
        {
            BashCodeExecutionToolResultErrorParam value => bashCodeExecutionToolResultErrorParam(
                value
            ),
            BashCodeExecutionResultBlockParam value => bashCodeExecutionResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BashCodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BashCodeExecutionToolResultBlockParamContent(
        BashCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator BashCodeExecutionToolResultBlockParamContent(
        BashCodeExecutionResultBlockParam value
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
                "Data did not match any variant of BashCodeExecutionToolResultBlockParamContent"
            );
        }
        this.Switch(
            (bashCodeExecutionToolResultErrorParam) =>
                bashCodeExecutionToolResultErrorParam.Validate(),
            (bashCodeExecutionResultBlockParam) => bashCodeExecutionResultBlockParam.Validate()
        );
    }

    public virtual bool Equals(BashCodeExecutionToolResultBlockParamContent? other) =>
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
            BashCodeExecutionToolResultErrorParam _ => 0,
            BashCodeExecutionResultBlockParam _ => 1,
            _ => -1,
        };
    }
}

sealed class BashCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BashCodeExecutionToolResultBlockParamContent>
{
    public override BashCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BashCodeExecutionToolResultErrorParam>(
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
            var deserialized = JsonSerializer.Deserialize<BashCodeExecutionResultBlockParam>(
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
        BashCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
