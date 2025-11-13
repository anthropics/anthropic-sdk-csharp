using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchToolResultBlock>))]
public sealed record class BetaWebFetchToolResultBlock
    : ModelBase,
        IFromRaw<BetaWebFetchToolResultBlock>
{
    public required BetaWebFetchToolResultBlockContent Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
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
            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this._properties.TryGetValue("tool_use_id", out JsonElement element))
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
            this._properties["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
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

    public BetaWebFetchToolResultBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(BetaWebFetchToolResultBlockContentConverter))]
public record class BetaWebFetchToolResultBlockContent
{
    public object Value { get; private init; }

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

    public BetaWebFetchToolResultBlockContent(BetaWebFetchToolResultErrorBlock value)
    {
        Value = value;
    }

    public BetaWebFetchToolResultBlockContent(BetaWebFetchBlock value)
    {
        Value = value;
    }

    BetaWebFetchToolResultBlockContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaWebFetchToolResultBlockContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlock>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaWebFetchToolResultBlockContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchToolResultErrorBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlock>(ref reader, options);
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaWebFetchToolResultBlockContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchBlock'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
