using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaMCPToolResultBlock>))]
public sealed record class BetaMCPToolResultBlock : ModelBase, IFromRaw<BetaMCPToolResultBlock>
{
    public required BetaMCPToolResultBlockContent Content
    {
        get
        {
            if (!this._properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaMCPToolResultBlockContent>(
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

    public required bool IsError
    {
        get
        {
            if (!this._properties.TryGetValue("is_error", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'is_error' cannot be null",
                    new System::ArgumentOutOfRangeException("is_error", "Missing required argument")
                );

            return JsonSerializer.Deserialize<bool>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["is_error"] = JsonSerializer.SerializeToElement(
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
        _ = this.IsError;
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
    }

    public BetaMCPToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
    }

    public BetaMCPToolResultBlock(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaMCPToolResultBlock(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaMCPToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}

[JsonConverter(typeof(BetaMCPToolResultBlockContentConverter))]
public record class BetaMCPToolResultBlockContent
{
    public object Value { get; private init; }

    public BetaMCPToolResultBlockContent(string value)
    {
        Value = value;
    }

    public BetaMCPToolResultBlockContent(IReadOnlyList<BetaTextBlock> value)
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    BetaMCPToolResultBlockContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaMCPToolResultBlockContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value = this.Value as string;
        return value != null;
    }

    public bool TryPickBetaMCPToolResultBlock(
        [NotNullWhen(true)] out IReadOnlyList<BetaTextBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaTextBlock>;
        return value != null;
    }

    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyList<BetaTextBlock>> betaMCPToolResultBlockContent
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
                    "Data did not match any variant of BetaMCPToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<string, T> @string,
        System::Func<IReadOnlyList<BetaTextBlock>, T> betaMCPToolResultBlockContent
    )
    {
        return this.Value switch
        {
            string value => @string(value),
            IReadOnlyList<BetaTextBlock> value => betaMCPToolResultBlockContent(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMCPToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaMCPToolResultBlockContent(string value) => new(value);

    public static implicit operator BetaMCPToolResultBlockContent(List<BetaTextBlock> value) =>
        new((IReadOnlyList<BetaTextBlock>)value);

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaMCPToolResultBlockContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class BetaMCPToolResultBlockContentConverter : JsonConverter<BetaMCPToolResultBlockContent>
{
    public override BetaMCPToolResultBlockContent? Read(
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
                return new BetaMCPToolResultBlockContent(deserialized);
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
                return new BetaMCPToolResultBlockContent(deserialized);
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

    public override void Write(
        Utf8JsonWriter writer,
        BetaMCPToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
