using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchToolResultBlockParam>))]
public sealed record class BetaWebFetchToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaWebFetchToolResultBlockParam>
{
    public required Content9 Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content9>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentNullException("content")
                );
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ToolUseID
    {
        get
        {
            if (!this.Properties.TryGetValue("tool_use_id", out JsonElement element))
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
        set
        {
            this.Properties["tool_use_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["cache_control"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        _ = this.Type;
        this.CacheControl?.Validate();
    }

    public BetaWebFetchToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Content9Converter))]
public record class Content9
{
    public object Value { get; private init; }

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

    public Content9(BetaWebFetchToolResultErrorBlockParam value)
    {
        Value = value;
    }

    public Content9(BetaWebFetchBlockParam value)
    {
        Value = value;
    }

    Content9(UnknownVariant value)
    {
        Value = value;
    }

    public static Content9 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaWebFetchToolResultErrorBlockParam(
        [NotNullWhen(true)] out BetaWebFetchToolResultErrorBlockParam? value
    )
    {
        value = this.Value as BetaWebFetchToolResultErrorBlockParam;
        return value != null;
    }

    public bool TryPickBetaWebFetchBlockParam([NotNullWhen(true)] out BetaWebFetchBlockParam? value)
    {
        value = this.Value as BetaWebFetchBlockParam;
        return value != null;
    }

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
                    "Data did not match any variant of Content9"
                );
        }
    }

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
                "Data did not match any variant of Content9"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content9");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content9Converter : JsonConverter<Content9>
{
    public override Content9? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultErrorBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content9(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchToolResultErrorBlockParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebFetchBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content9(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebFetchBlockParam'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content9 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
