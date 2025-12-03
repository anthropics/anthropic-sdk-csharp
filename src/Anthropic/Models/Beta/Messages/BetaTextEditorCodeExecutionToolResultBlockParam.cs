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
        BetaTextEditorCodeExecutionToolResultBlockParam,
        BetaTextEditorCodeExecutionToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultBlockParam : ModelBase
{
    public required BetaTextEditorCodeExecutionToolResultBlockParamContent Content
    {
        get
        {
            return ModelBase.GetNotNullClass<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
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
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_tool_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
    }

    public BetaTextEditorCodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultBlockParam(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTextEditorCodeExecutionToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaTextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionToolResultBlockParamFromRaw
    : IFromRaw<BetaTextEditorCodeExecutionToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaTextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionToolResultBlockParamContentConverter))]
public record class BetaTextEditorCodeExecutionToolResultBlockParamContent
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
                betaTextEditorCodeExecutionToolResultErrorParam: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlockParam: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlockParam: (x) => x.Type
            );
        }
    }

    public BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionToolResultErrorParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionViewResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionCreateResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionToolResultErrorParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionToolResultErrorParam(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionToolResultErrorParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultErrorParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionViewResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionViewResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionViewResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionCreateResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionCreateResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaTextEditorCodeExecutionStrReplaceResultBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(out var value)) {
    ///     // `value` is of type `BetaTextEditorCodeExecutionStrReplaceResultBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlockParam;
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
    ///     (BetaTextEditorCodeExecutionToolResultErrorParam value) => {...},
    ///     (BetaTextEditorCodeExecutionViewResultBlockParam value) => {...},
    ///     (BetaTextEditorCodeExecutionCreateResultBlockParam value) => {...},
    ///     (BetaTextEditorCodeExecutionStrReplaceResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaTextEditorCodeExecutionToolResultErrorParam> betaTextEditorCodeExecutionToolResultErrorParam,
        System::Action<BetaTextEditorCodeExecutionViewResultBlockParam> betaTextEditorCodeExecutionViewResultBlockParam,
        System::Action<BetaTextEditorCodeExecutionCreateResultBlockParam> betaTextEditorCodeExecutionCreateResultBlockParam,
        System::Action<BetaTextEditorCodeExecutionStrReplaceResultBlockParam> betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultErrorParam value:
                betaTextEditorCodeExecutionToolResultErrorParam(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlockParam value:
                betaTextEditorCodeExecutionViewResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlockParam value:
                betaTextEditorCodeExecutionCreateResultBlockParam(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlockParam value:
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockParamContent"
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
    ///     (BetaTextEditorCodeExecutionToolResultErrorParam value) => {...},
    ///     (BetaTextEditorCodeExecutionViewResultBlockParam value) => {...},
    ///     (BetaTextEditorCodeExecutionCreateResultBlockParam value) => {...},
    ///     (BetaTextEditorCodeExecutionStrReplaceResultBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaTextEditorCodeExecutionToolResultErrorParam,
            T
        > betaTextEditorCodeExecutionToolResultErrorParam,
        System::Func<
            BetaTextEditorCodeExecutionViewResultBlockParam,
            T
        > betaTextEditorCodeExecutionViewResultBlockParam,
        System::Func<
            BetaTextEditorCodeExecutionCreateResultBlockParam,
            T
        > betaTextEditorCodeExecutionCreateResultBlockParam,
        System::Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultErrorParam value =>
                betaTextEditorCodeExecutionToolResultErrorParam(value),
            BetaTextEditorCodeExecutionViewResultBlockParam value =>
                betaTextEditorCodeExecutionViewResultBlockParam(value),
            BetaTextEditorCodeExecutionCreateResultBlockParam value =>
                betaTextEditorCodeExecutionCreateResultBlockParam(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlockParam value =>
                betaTextEditorCodeExecutionStrReplaceResultBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionToolResultErrorParam value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionViewResultBlockParam value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionCreateResultBlockParam value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockParamContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlockParam value
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
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockParamContent"
            );
        }
    }

    public virtual bool Equals(BetaTextEditorCodeExecutionToolResultBlockParamContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaTextEditorCodeExecutionToolResultBlockParamContentConverter
    : JsonConverter<BetaTextEditorCodeExecutionToolResultBlockParamContent>
{
    public override BetaTextEditorCodeExecutionToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultErrorParam>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlockParam>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlockParam>(
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
        BetaTextEditorCodeExecutionToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
