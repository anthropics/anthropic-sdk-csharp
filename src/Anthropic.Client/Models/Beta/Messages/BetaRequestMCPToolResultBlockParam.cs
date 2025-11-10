using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRequestMCPToolResultBlockParam>))]
public sealed record class BetaRequestMCPToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaRequestMCPToolResultBlockParam>
{
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

    public Content4? Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Content4?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? IsError
    {
        get
        {
            if (!this._properties.TryGetValue("is_error", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._properties["is_error"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ToolUseID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        this.CacheControl?.Validate();
        this.Content?.Validate();
        _ = this.IsError;
    }

    public BetaRequestMCPToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
    }

    public BetaRequestMCPToolResultBlockParam(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMCPToolResultBlockParam(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaRequestMCPToolResultBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaRequestMCPToolResultBlockParam(string toolUseID)
        : this()
    {
        this.ToolUseID = toolUseID;
    }
}

[JsonConverter(typeof(Content4Converter))]
public record class Content4
{
    public object Value { get; private init; }

    public Content4(string value)
    {
        Value = value;
    }

    public Content4(IReadOnlyList<BetaTextBlockParam> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    Content4(UnknownVariant value)
    {
        Value = value;
    }

    public static Content4 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaMCPToolResultBlockParam(
        [NotNullWhen(true)] out IReadOnlyList<BetaTextBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaTextBlockParam>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<BetaTextBlockParam>> betaMCPToolResultBlockParamContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaTextBlockParam> value:
                betaMCPToolResultBlockParamContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content4"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<BetaTextBlockParam>, T> betaMCPToolResultBlockParamContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<BetaTextBlockParam> value => betaMCPToolResultBlockParamContent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content4"
            ),
        };
    }

    public static implicit operator Content4(string value) => new(value);

    public static implicit operator Content4(List<BetaTextBlockParam> value) =>
        new((IReadOnlyList<BetaTextBlockParam>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content4");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content4Converter : JsonConverter<Content4>
{
    public override Content4? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<string>(ref reader, options);
            if (deserialized != null)
            {
                return new Content4(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException("Data does not match union variant 'string'", e)
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new Content4(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaTextBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content4 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
