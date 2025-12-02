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
    typeof(ModelConverter<BetaToolSearchToolResultBlock, BetaToolSearchToolResultBlockFromRaw>)
)]
public sealed record class BetaToolSearchToolResultBlock : ModelBase
{
    public required BetaToolSearchToolResultBlockContent Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaToolSearchToolResultBlockContent>(
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
                JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaToolSearchToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

    public BetaToolSearchToolResultBlock(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_search_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolSearchToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolSearchToolResultBlockFromRaw : IFromRaw<BetaToolSearchToolResultBlock>
{
    public BetaToolSearchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaToolSearchToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaToolSearchToolResultBlockContentConverter))]
public record class BetaToolSearchToolResultBlockContent
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
                betaToolSearchToolResultError: (x) => x.Type,
                betaToolSearchToolSearchResultBlock: (x) => x.Type
            );
        }
    }

    public BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolSearchResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaToolSearchToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickBetaToolSearchToolResultError(
        [NotNullWhen(true)] out BetaToolSearchToolResultError? value
    )
    {
        value = this.Value as BetaToolSearchToolResultError;
        return value != null;
    }

    public bool TryPickBetaToolSearchToolSearchResultBlock(
        [NotNullWhen(true)] out BetaToolSearchToolSearchResultBlock? value
    )
    {
        value = this.Value as BetaToolSearchToolSearchResultBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaToolSearchToolResultError> betaToolSearchToolResultError,
        System::Action<BetaToolSearchToolSearchResultBlock> betaToolSearchToolSearchResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaToolSearchToolResultError value:
                betaToolSearchToolResultError(value);
                break;
            case BetaToolSearchToolSearchResultBlock value:
                betaToolSearchToolSearchResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaToolSearchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaToolSearchToolResultError, T> betaToolSearchToolResultError,
        System::Func<BetaToolSearchToolSearchResultBlock, T> betaToolSearchToolSearchResultBlock
    )
    {
        return this.Value switch
        {
            BetaToolSearchToolResultError value => betaToolSearchToolResultError(value),
            BetaToolSearchToolSearchResultBlock value => betaToolSearchToolSearchResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolResultError value
    ) => new(value);

    public static implicit operator BetaToolSearchToolResultBlockContent(
        BetaToolSearchToolSearchResultBlock value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaToolSearchToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaToolSearchToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaToolSearchToolResultBlockContentConverter
    : JsonConverter<BetaToolSearchToolResultBlockContent>
{
    public override BetaToolSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolSearchResultBlock>(
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
        BetaToolSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
