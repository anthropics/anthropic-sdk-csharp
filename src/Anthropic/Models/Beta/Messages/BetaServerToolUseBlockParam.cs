using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaServerToolUseBlockParam>))]
public sealed record class BetaServerToolUseBlockParam
    : ModelBase,
        IFromRaw<BetaServerToolUseBlockParam>
{
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required Dictionary<string, JsonElement> Input
    {
        get
        {
            if (!this._rawData.TryGetValue("input", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new System::ArgumentOutOfRangeException("input", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'input' cannot be null",
                    new System::ArgumentNullException("input")
                );
        }
        init
        {
            this._rawData["input"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required ApiEnum<string, BetaServerToolUseBlockParamName> Name
    {
        get
        {
            if (!this._rawData.TryGetValue("name", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'name' cannot be null",
                    new System::ArgumentOutOfRangeException("name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ApiEnum<string, BetaServerToolUseBlockParamName>>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._rawData.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Tool invocation directly from the model.
    /// </summary>
    public BetaServerToolUseBlockParamCaller? Caller
    {
        get
        {
            if (!this._rawData.TryGetValue("caller", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaServerToolUseBlockParamCaller?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData["caller"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.Input;
        this.Name.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Caller?.Validate();
    }

    public BetaServerToolUseBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

    public BetaServerToolUseBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"server_tool_use\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServerToolUseBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaServerToolUseBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
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
public record class BetaServerToolUseBlockParamCaller
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(betaDirect: (x) => x.Type, betaServerTool: (x) => x.Type); }
    }

    public BetaServerToolUseBlockParamCaller(BetaDirectCaller value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaServerToolUseBlockParamCaller(BetaServerToolCaller value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaServerToolUseBlockParamCaller(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaDirect([NotNullWhen(true)] out BetaDirectCaller? value)
    {
        value = this.Value as BetaDirectCaller;
        return value != null;
    }

    public bool TryPickBetaServerTool([NotNullWhen(true)] out BetaServerToolCaller? value)
    {
        value = this.Value as BetaServerToolCaller;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaServerToolUseBlockParamCaller"
            );
        }
    }
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
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
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
                    var deserialized = JsonSerializer.Deserialize<BetaDirectCaller>(json, options);
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            case "code_execution_20250825":
            {
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaServerToolCaller>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new(deserialized, json);
                    }
                }
                catch (System::Exception e)
                    when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    // ignore
                }

                return new(json);
            }
            default:
            {
                return new BetaServerToolUseBlockParamCaller(json);
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
