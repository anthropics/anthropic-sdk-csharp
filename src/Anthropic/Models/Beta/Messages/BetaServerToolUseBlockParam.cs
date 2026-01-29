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
    typeof(JsonModelConverter<BetaServerToolUseBlockParam, BetaServerToolUseBlockParamFromRaw>)
)]
public sealed record class BetaServerToolUseBlockParam : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Input
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>("input");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "input",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required ApiEnum<string, BetaServerToolUseBlockParamName> Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaServerToolUseBlockParamName>>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
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
    public BetaServerToolUseBlockParamCaller? Caller
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaServerToolUseBlockParamCaller>("caller");
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
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("server_tool_use"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Caller?.Validate();
    }

    public BetaServerToolUseBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServerToolUseBlockParam(BetaServerToolUseBlockParam betaServerToolUseBlockParam)
        : base(betaServerToolUseBlockParam) { }
#pragma warning restore CS8618

    public BetaServerToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("server_tool_use");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServerToolUseBlockParamFromRaw.FromRawUnchecked"/>
    public static BetaServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaServerToolUseBlockParamFromRaw : IFromRawJson<BetaServerToolUseBlockParam>
{
    /// <inheritdoc/>
    public BetaServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaServerToolUseBlockParam.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaServerToolUseBlockParamNameConverter))]
public enum BetaServerToolUseBlockParamName
{
    WebSearch,
    WebFetch,
    CodeExecution,
    BashCodeExecution,
    TextEditorCodeExecution,
    ToolSearchToolRegex,
    ToolSearchToolBm25,
}

sealed class BetaServerToolUseBlockParamNameConverter
    : JsonConverter<BetaServerToolUseBlockParamName>
{
    public override BetaServerToolUseBlockParamName Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "web_search" => BetaServerToolUseBlockParamName.WebSearch,
            "web_fetch" => BetaServerToolUseBlockParamName.WebFetch,
            "code_execution" => BetaServerToolUseBlockParamName.CodeExecution,
            "bash_code_execution" => BetaServerToolUseBlockParamName.BashCodeExecution,
            "text_editor_code_execution" => BetaServerToolUseBlockParamName.TextEditorCodeExecution,
            "tool_search_tool_regex" => BetaServerToolUseBlockParamName.ToolSearchToolRegex,
            "tool_search_tool_bm25" => BetaServerToolUseBlockParamName.ToolSearchToolBm25,
            _ => (BetaServerToolUseBlockParamName)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaServerToolUseBlockParamName value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaServerToolUseBlockParamName.WebSearch => "web_search",
                BetaServerToolUseBlockParamName.WebFetch => "web_fetch",
                BetaServerToolUseBlockParamName.CodeExecution => "code_execution",
                BetaServerToolUseBlockParamName.BashCodeExecution => "bash_code_execution",
                BetaServerToolUseBlockParamName.TextEditorCodeExecution =>
                    "text_editor_code_execution",
                BetaServerToolUseBlockParamName.ToolSearchToolRegex => "tool_search_tool_regex",
                BetaServerToolUseBlockParamName.ToolSearchToolBm25 => "tool_search_tool_bm25",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(BetaServerToolUseBlockParamCallerConverter))]
public record class BetaServerToolUseBlockParamCaller : ModelBase
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
        get { return Match(betaDirect: (x) => x.Type, betaServerTool: (x) => x.Type); }
    }

    public BetaServerToolUseBlockParamCaller(BetaDirectCaller value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public BetaServerToolUseBlockParamCaller(
        BetaServerToolCaller value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public BetaServerToolUseBlockParamCaller(JsonElement element)
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
    ///     (BetaServerToolCaller value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public void Switch(
        System::Action<BetaDirectCaller> betaDirect,
        System::Action<BetaServerToolCaller> betaServerTool
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
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaServerToolUseBlockParamCaller"
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
    ///     (BetaServerToolCaller value) => {...}
    /// );
    /// </code>
    /// </example>
    /// </summary>
    public T Match<T>(
        System::Func<BetaDirectCaller, T> betaDirect,
        System::Func<BetaServerToolCaller, T> betaServerTool
    )
    {
        return this.Value switch
        {
            BetaDirectCaller value => betaDirect(value),
            BetaServerToolCaller value => betaServerTool(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaServerToolUseBlockParamCaller"
            ),
        };
    }

    public static implicit operator BetaServerToolUseBlockParamCaller(BetaDirectCaller value) =>
        new(value);

    public static implicit operator BetaServerToolUseBlockParamCaller(BetaServerToolCaller value) =>
        new(value);

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
                "Data did not match any variant of BetaServerToolUseBlockParamCaller"
            );
        }
        this.Switch(
            (betaDirect) => betaDirect.Validate(),
            (betaServerTool) => betaServerTool.Validate()
        );
    }

    public virtual bool Equals(BetaServerToolUseBlockParamCaller? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }

    public override string ToString() =>
        JsonSerializer.Serialize(this._element, ModelBase.ToStringSerializerOptions);
}

sealed class BetaServerToolUseBlockParamCallerConverter
    : JsonConverter<BetaServerToolUseBlockParamCaller>
{
    public override BetaServerToolUseBlockParamCaller? Read(
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
            default:
            {
                return new BetaServerToolUseBlockParamCaller(element);
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaServerToolUseBlockParamCaller value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
