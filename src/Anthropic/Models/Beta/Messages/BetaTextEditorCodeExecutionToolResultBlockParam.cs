using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionToolResultBlockParam>))]
public sealed record class BetaTextEditorCodeExecutionToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionToolResultBlockParam>
{
    public required BetaTextEditorCodeExecutionToolResultBlockParamContent Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockParamContent>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        init
        {
            this._rawData["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this._rawData.TryGetValue("tool_use_id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "tool_use_id",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'tool_use_id' cannot be null",
                    new System::ArgumentNullException("tool_use_id")
                );
        }
        init
        {
            this._rawData["tool_use_id"] = JsonSerializer.SerializeToElement(
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

    public static BetaTextEditorCodeExecutionToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
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

    public bool TryPickBetaTextEditorCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlockParam;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlockParam(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlockParam? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlockParam;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockParamContent"
            );
        }
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
