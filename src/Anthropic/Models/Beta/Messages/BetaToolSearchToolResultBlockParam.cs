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
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaToolSearchToolResultBlockParamContent>(
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

    public static BetaToolSearchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultBlockParamFromRaw : IFromRaw<BetaToolSearchToolResultBlockParam>
{
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

    public bool TryPickBetaToolSearchToolResultErrorParam(
        [NotNullWhen(true)] out BetaToolSearchToolResultErrorParam? value
    )
    {
        value = this.Value as BetaToolSearchToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaToolSearchToolSearchResultBlockParam(
        [NotNullWhen(true)] out BetaToolSearchToolSearchResultBlockParam? value
    )
    {
        value = this.Value as BetaToolSearchToolSearchResultBlockParam;
        return value != null;
    }

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

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockParamContent"
            );
        }
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
