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
    typeof(ModelConverter<BetaWebFetchToolResultBlock, BetaWebFetchToolResultBlockFromRaw>)
)]
public sealed record class BetaWebFetchToolResultBlock : ModelBase
{
    public required BetaWebFetchToolResultBlockContent Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaWebFetchToolResultBlockContent>(
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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWebFetchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

    public BetaWebFetchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWebFetchToolResultBlockFromRaw : IFromRaw<BetaWebFetchToolResultBlock>
{
    public BetaWebFetchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaWebFetchToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaWebFetchToolResultBlockContentConverter))]
public record class BetaWebFetchToolResultBlockContent
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
                betaWebFetchToolResultErrorBlock: (x) => x.Type,
                betaWebFetchBlock: (x) => x.Type
            );
        }
    }

    public BetaWebFetchToolResultBlockContent(
        BetaWebFetchToolResultErrorBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaWebFetchToolResultBlockContent(BetaWebFetchBlock value, JsonElement? json = null)
    {
        this.Value = value;
        this._json = json;
    }

    public BetaWebFetchToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaWebFetchToolResultErrorBlock(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlock? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlock;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlock([NotNullWhen(true)] out BetaWebFetchBlock? value)
    {
        value = this.Value as BetaWebFetchBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaWebFetchToolResultErrorBlock> betaWebFetchToolResultErrorBlock,
        System::Action<BetaWebFetchBlock> betaWebFetchBlock
    )
    {
        switch (this.Value)
        {
            case BetaWebFetchToolResultErrorBlock value:
                betaWebFetchToolResultErrorBlock(value);
                break;
            case BetaWebFetchBlock value:
                betaWebFetchBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebFetchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaWebFetchToolResultErrorBlock, T> betaWebFetchToolResultErrorBlock,
        System::Func<BetaWebFetchBlock, T> betaWebFetchBlock
    )
    {
        return this.Value switch
        {
            BetaWebFetchToolResultErrorBlock value => betaWebFetchToolResultErrorBlock(value),
            BetaWebFetchBlock value => betaWebFetchBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaWebFetchToolResultBlockContent(
        BetaWebFetchToolResultErrorBlock value
    ) => new(value);

    public static implicit operator BetaWebFetchToolResultBlockContent(BetaWebFetchBlock value) =>
        new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaWebFetchToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaWebFetchToolResultBlockContentConverter
    : JsonConverter<BetaWebFetchToolResultBlockContent>
{
    public override BetaWebFetchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlock>(
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
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(json, options);
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
        BetaWebFetchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
