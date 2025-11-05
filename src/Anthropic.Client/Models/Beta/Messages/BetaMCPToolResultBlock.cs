using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMCPToolResultBlock>))]
public sealed record class BetaMCPToolResultBlock : ModelBase, IFromRaw<BetaMCPToolResultBlock>
{
    public required Content2 Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content2>(element, ModelBase.SerializerOptions)
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

    public required bool IsError
    {
        get
        {
            if (!this.Properties.TryGetValue("is_error", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'is_error' cannot be null",
                    new System::ArgumentOutOfRangeException("is_error", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["is_error"] = JsonSerializer.SerializeToElement(
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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.IsError;
        _ = this.ToolUseID;
        _ = this.Type;
    }

    public BetaMCPToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaMCPToolResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Content2Converter))]
public record class Content2
{
    public object Value { get; private init; }

    public Content2(string value)
    {
        Value = value;
    }

    public Content2(List<BetaTextBlock> value)
    {
        Value = value;
    }

    Content2(UnknownVariant value)
    {
        Value = value;
    }

    public static Content2 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaMCPToolResultBlock([NotNullWhen(true)] out List<BetaTextBlock>? value)
    {
        value = this.Value as List<BetaTextBlock>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<List<BetaTextBlock>> betaMCPToolResultBlockContent
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case List<BetaTextBlock> value:
                betaMCPToolResultBlockContent(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content2"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<List<BetaTextBlock>, T> betaMCPToolResultBlockContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            List<BetaTextBlock> value => betaMCPToolResultBlockContent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content2"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content2");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content2Converter : JsonConverter<Content2>
{
    public override Content2? Read(
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
                return new Content2(deserialized);
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
            var deserialized = JsonSerializer.Deserialize<List<BetaTextBlock>>(ref reader, options);
            if (deserialized != null)
            {
                return new Content2(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaTextBlock>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content2 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
