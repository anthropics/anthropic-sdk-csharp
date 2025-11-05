using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaBashCodeExecutionToolResultBlockParam>))]
public sealed record class BetaBashCodeExecutionToolResultBlockParam
    : ModelBase,
        IFromRaw<BetaBashCodeExecutionToolResultBlockParam>
{
    public required ContentModel Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ContentModel>(element, ModelBase.SerializerOptions)
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

    public BetaBashCodeExecutionToolResultBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"bash_code_execution_tool_result\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBashCodeExecutionToolResultBlockParam(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaBashCodeExecutionToolResultBlockParam FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(ContentModelConverter))]
public record class ContentModel
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaBashCodeExecutionToolResultErrorParam: (x) => x.Type,
                betaBashCodeExecutionResultBlockParam: (x) => x.Type
            );
        }
    }

    public ContentModel(BetaBashCodeExecutionToolResultErrorParam value)
    {
        Value = value;
    }

    public ContentModel(BetaBashCodeExecutionResultBlockParam value)
    {
        Value = value;
    }

    ContentModel(UnknownVariant value)
    {
        Value = value;
    }

    public static ContentModel CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaBashCodeExecutionToolResultErrorParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionToolResultErrorParam? value
    )
    {
        value = this.Value as BetaBashCodeExecutionToolResultErrorParam;
        return value != null;
    }

    public bool TryPickBetaBashCodeExecutionResultBlockParam(
        [NotNullWhen(true)] out BetaBashCodeExecutionResultBlockParam? value
    )
    {
        value = this.Value as BetaBashCodeExecutionResultBlockParam;
        return value != null;
    }

    public void Switch(
        System::Action<BetaBashCodeExecutionToolResultErrorParam> betaBashCodeExecutionToolResultErrorParam,
        System::Action<BetaBashCodeExecutionResultBlockParam> betaBashCodeExecutionResultBlockParam
    )
    {
        switch (this.Value)
        {
            case BetaBashCodeExecutionToolResultErrorParam value:
                betaBashCodeExecutionToolResultErrorParam(value);
                break;
            case BetaBashCodeExecutionResultBlockParam value:
                betaBashCodeExecutionResultBlockParam(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of ContentModel"
                );
        }
    }

    public T Match<T>(
        System::Func<
            BetaBashCodeExecutionToolResultErrorParam,
            T
        > betaBashCodeExecutionToolResultErrorParam,
        System::Func<BetaBashCodeExecutionResultBlockParam, T> betaBashCodeExecutionResultBlockParam
    )
    {
        return this.Value switch
        {
            BetaBashCodeExecutionToolResultErrorParam value =>
                betaBashCodeExecutionToolResultErrorParam(value),
            BetaBashCodeExecutionResultBlockParam value => betaBashCodeExecutionResultBlockParam(
                value
            ),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentModel"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of ContentModel"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class ContentModelConverter : JsonConverter<ContentModel>
{
    public override ContentModel? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaBashCodeExecutionToolResultErrorParam>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ContentModel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaBashCodeExecutionToolResultErrorParam'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaBashCodeExecutionResultBlockParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new ContentModel(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaBashCodeExecutionResultBlockParam'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContentModel value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
