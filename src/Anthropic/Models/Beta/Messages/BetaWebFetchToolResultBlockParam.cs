using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaWebFetchToolResultBlockParam>))]
public sealed record class BetaWebFetchToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaWebFetchToolResultBlockParam>
{
    public required BetaWebFetchToolResultBlockParamContent Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaWebFetchToolResultBlockParamContent>(
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

    /// <summary>
    /// Create a cache control breakpoint at this content block.
    /// </summary>
    public BetaCacheControlEphemeral? CacheControl
    {
        get
        {
            if (!this._properties.TryGetValue("cache_control", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<BetaCacheControlEphemeral?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["cache_control"] = JsonSerializer.SerializeToElement(
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
        this.CacheControl?.Validate();
    }

    public BetaWebFetchToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

    public BetaWebFetchToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"web_fetch_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWebFetchToolResultBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaWebFetchToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(BetaWebFetchToolResultBlockParamContentConverter))]
public record class BetaWebFetchToolResultBlockParamContent
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

    public BetaWebFetchToolResultBlockParamContent(BetaWebFetchToolResultErrorBlockParam value)
    {
        Value = value;
    }

    public BetaWebFetchToolResultBlockParamContent(BetaWebFetchBlockParam value)
    {
        Value = value;
    }

    BetaWebFetchToolResultBlockParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaWebFetchToolResultBlockParamContent CreateUnknownVariant(JsonElement value)
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
                    "Data did not match any variant of BetaWebFetchToolResultBlockParamContent"
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

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebFetchToolResultBlockParamContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
                return new BetaWebFetchToolResultBlockParamContent(deserialized);
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
                return new BetaWebFetchToolResultBlockParamContent(deserialized);
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebFetchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
