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
    typeof(JsonModelConverter<
        BetaWebFetchToolResultBlockParam,
        BetaWebFetchToolResultBlockParamFromRaw
    >)
)]
public sealed record class BetaWebFetchToolResultBlockParam : JsonModel
{
    public required BetaWebFetchToolResultBlockParamContent Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaWebFetchToolResultBlockParamContent>(
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
    /// Tool invocation directly from the model.
    /// </summary>
    public BetaWebFetchToolResultBlockParamCaller? Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaWebFetchToolResultBlockParamCaller>("caller");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("caller", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("web_fetch_tool_result")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Caller?.Validate();
    }

    public BetaWebFetchToolResultBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWebFetchToolResultBlockParam(
        BetaWebFetchToolResultBlockParam betaWebFetchToolResultBlockParam
    )
        : base(betaWebFetchToolResultBlockParam) { }
#pragma warning restore CS8618

    public BetaWebFetchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("web_fetch_tool_result");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWebFetchToolResultBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaWebFetchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchToolResultBlockParamFromRaw : IFromRawJson<BetaWebFetchToolResultBlockParam>
{
    /// <inheritdoc/>
    public BetaWebFetchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaWebFetchToolResultBlockParamContentConverter))]
public record class BetaWebFetchToolResultBlockParamContent : ModelBase
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
                betaWebFetchToolResultErrorBlockParam: (x) => x.Type,
                betaWebFetchBlockParam: (x) => x.Type
            );
        }
    }

    public BetaWebFetchToolResultBlockParamContent(
        BetaWebFetchToolResultErrorBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockParamContent(
        BetaWebFetchBlockParam value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockParamContent(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchToolResultErrorBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchToolResultErrorBlockParam(out var value)) {
    ///     // `value` is of type `BetaWebFetchToolResultErrorBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchToolResultErrorBlockParam(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlockParam? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlockParam;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaWebFetchBlockParam"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaWebFetchBlockParam(out var value)) {
    ///     // `value` is of type `BetaWebFetchBlockParam`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaWebFetchBlockParam([NotNullWhen(true)] out BetaWebFetchBlockParam? value)
    {
        value = this.Value as BetaWebFetchBlockParam;
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
    ///     (BetaWebFetchToolResultErrorBlockParam value) => {...},
    ///     (BetaWebFetchBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaWebFetchToolResultErrorBlockParam> betaWebFetchToolResultErrorBlockParam,
        System::Action<BetaWebFetchBlockParam> betaWebFetchBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchToolResultErrorBlockParam value:
                betaWebFetchToolResultErrorBlockParam(value);
                break;
            case BetaWebFetchBlockParam value:
                betaWebFetchBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebFetchToolResultBlockParamContent"
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
    ///     (BetaWebFetchToolResultErrorBlockParam value) => {...},
    ///     (BetaWebFetchBlockParam value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<
            BetaWebFetchToolResultErrorBlockParam,
            T
        > betaWebFetchToolResultErrorBlockParam,
        System::Func<BetaWebFetchBlockParam, T> betaWebFetchBlockParam
    )
    {
        return this.Value switch
        {
            BetaWebFetchToolResultErrorBlockParam value => betaWebFetchToolResultErrorBlockParam(
                value
            ),
            BetaWebFetchBlockParam value => betaWebFetchBlockParam(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaWebFetchToolResultBlockParamContent(
        BetaWebFetchToolResultErrorBlockParam value
    ) => new(value);

    public static implicit operator BetaWebFetchToolResultBlockParamContent(
        BetaWebFetchBlockParam value
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
                "Data did not match any variant of BetaWebFetchToolResultBlockParamContent"
            );
        }
        this.Switch(
            (betaWebFetchToolResultErrorBlockParam) =>
                betaWebFetchToolResultErrorBlockParam.Validate(),
            (betaWebFetchBlockParam) => betaWebFetchBlockParam.Validate()
        );
    }

    public virtual bool Equals(BetaWebFetchToolResultBlockParamContent? other) =>
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
            BetaWebFetchToolResultErrorBlockParam _ => 0,
            BetaWebFetchBlockParam _ => 1,
            _ => -1,
        };
    }
}

sealed class BetaWebFetchToolResultBlockParamContentConverter
    : JsonConverter<BetaWebFetchToolResultBlockParamContent>
{
    public override BetaWebFetchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlockParam>(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlockParam>(element, options);
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
        BetaWebFetchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(BetaWebFetchToolResultBlockParamCallerConverter))]
public record class BetaWebFetchToolResultBlockParamCaller : ModelBase
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
                betaDirect: (x) => x.Type,
                betaServerTool: (x) => x.Type,
                betaServerToolCaller20260120: (x) => x.Type
            );
        }
    }

    public string? ToolID
    {
        get
        {
            return Match<string?>(
                betaDirect: (_) => null,
                betaServerTool: (x) => x.ToolID,
                betaServerToolCaller20260120: (x) => x.ToolID
            );
        }
    }

    public BetaWebFetchToolResultBlockParamCaller(
        BetaDirectCaller value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockParamCaller(
        BetaServerToolCaller value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockParamCaller(
        BetaServerToolCaller20260120 value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaWebFetchToolResultBlockParamCaller(JsonElement element)
    {
        this._element = element;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaDirectCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaDirect(out var value)) {
    ///     // `value` is of type `BetaDirectCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaDirect([NotNullWhen(true)] out BetaDirectCaller? value)
    {
        value = this.Value as BetaDirectCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaServerToolCaller"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaServerTool(out var value)) {
    ///     // `value` is of type `BetaServerToolCaller`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaServerTool([NotNullWhen(true)] out BetaServerToolCaller? value)
    {
        value = this.Value as BetaServerToolCaller;
        return value != null;
    }

    /// <summary>
    /// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
    /// type <see cref="BetaServerToolCaller20260120"/>.
    ///
    /// <para>Consider using <see cref="Switch"> or <see cref="Match"> if you need to handle every variant.</para>
    ///
    /// <example>
    /// <code>
    /// if (instance.TryPickBetaServerToolCaller20260120(out var value)) {
    ///     // `value` is of type `BetaServerToolCaller20260120`
    ///     Console.WriteLine(value);
    /// }
    /// </code>
    /// </example>
    /// </summary>
    public bool TryPickBetaServerToolCaller20260120(
        [NotNullWhen(true)] out BetaServerToolCaller20260120? value
    )
    {
        value = this.Value as BetaServerToolCaller20260120;
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
    ///     (BetaDirectCaller value) => {...},
    ///     (BetaServerToolCaller value) => {...},
    ///     (BetaServerToolCaller20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaDirectCaller> betaDirect,
        System::Action<BetaServerToolCaller> betaServerTool,
        System::Action<BetaServerToolCaller20260120> betaServerToolCaller20260120
    )
    {
        switch (this.Value)
        {
            case BetaDirectCaller value:
                betaDirect(value);
                break;
            case BetaServerToolCaller value:
                betaServerTool(value);
                break;
            case BetaServerToolCaller20260120 value:
                betaServerToolCaller20260120(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebFetchToolResultBlockParamCaller"
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
    ///     (BetaDirectCaller value) => {...},
    ///     (BetaServerToolCaller value) => {...},
    ///     (BetaServerToolCaller20260120 value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaDirectCaller, T> betaDirect,
        System::Func<BetaServerToolCaller, T> betaServerTool,
        System::Func<BetaServerToolCaller20260120, T> betaServerToolCaller20260120
    )
    {
        return this.Value switch
        {
            BetaDirectCaller value => betaDirect(value),
            BetaServerToolCaller value => betaServerTool(value),
            BetaServerToolCaller20260120 value => betaServerToolCaller20260120(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockParamCaller"
            ),
        };
    }

    public static implicit operator BetaWebFetchToolResultBlockParamCaller(
        BetaDirectCaller value
    ) => new(value);

    public static implicit operator BetaWebFetchToolResultBlockParamCaller(
        BetaServerToolCaller value
    ) => new(value);

    public static implicit operator BetaWebFetchToolResultBlockParamCaller(
        BetaServerToolCaller20260120 value
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
                "Data did not match any variant of BetaWebFetchToolResultBlockParamCaller"
            );
        }
        this.Switch(
            (betaDirect) => betaDirect.Validate(),
            (betaServerTool) => betaServerTool.Validate(),
            (betaServerToolCaller20260120) => betaServerToolCaller20260120.Validate()
        );
    }

    public virtual bool Equals(BetaWebFetchToolResultBlockParamCaller? other) =>
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
            BetaDirectCaller _ => 0,
            BetaServerToolCaller _ => 1,
            BetaServerToolCaller20260120 _ => 2,
            _ => -1,
        };
    }
}

sealed class BetaWebFetchToolResultBlockParamCallerConverter
    : JsonConverter<BetaWebFetchToolResultBlockParamCaller>
{
    public override BetaWebFetchToolResultBlockParamCaller? Read(
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
            case "direct":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaDirectCaller>(
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
            case "code_execution_20250825":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller>(
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
            case "code_execution_20260120":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller20260120>(
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
                return new BetaWebFetchToolResultBlockParamCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchToolResultBlockParamCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
