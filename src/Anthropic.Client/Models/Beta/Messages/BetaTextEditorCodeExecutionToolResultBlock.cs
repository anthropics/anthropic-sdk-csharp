using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaTextEditorCodeExecutionToolResultBlock>))]
public sealed record class BetaTextEditorCodeExecutionToolResultBlock
    : ModelBase,
        IFromRaw<BetaTextEditorCodeExecutionToolResultBlock>
{
    public required Content5 Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Content5>(element, ModelBase.SerializerOptions)
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

    public override void Validate()
    {
        this.Content.Validate();
        _ = this.ToolUseID;
        _ = this.Type;
    }

    public BetaTextEditorCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultBlock(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}

[JsonConverter(typeof(Content5Converter))]
public record class Content5
{
    public object Value { get; private init; }

    public JsonElement Type
    {
        get
        {
            return Match(
                betaTextEditorCodeExecutionToolResultError: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlock: (x) => x.Type
            );
        }
    }

    public Content5(BetaTextEditorCodeExecutionToolResultError value)
    {
        Value = value;
    }

    public Content5(BetaTextEditorCodeExecutionViewResultBlock value)
    {
        Value = value;
    }

    public Content5(BetaTextEditorCodeExecutionCreateResultBlock value)
    {
        Value = value;
    }

    public Content5(BetaTextEditorCodeExecutionStrReplaceResultBlock value)
    {
        Value = value;
    }

    Content5(UnknownVariant value)
    {
        Value = value;
    }

    public static Content5 CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickBetaTextEditorCodeExecutionToolResultError(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionToolResultError? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionToolResultError;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionViewResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionViewResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionViewResultBlock;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionCreateResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionCreateResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionCreateResultBlock;
        return value != null;
    }

    public bool TryPickBetaTextEditorCodeExecutionStrReplaceResultBlock(
        [NotNullWhen(true)] out BetaTextEditorCodeExecutionStrReplaceResultBlock? value
    )
    {
        value = this.Value as BetaTextEditorCodeExecutionStrReplaceResultBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaTextEditorCodeExecutionToolResultError> betaTextEditorCodeExecutionToolResultError,
        System::Action<BetaTextEditorCodeExecutionViewResultBlock> betaTextEditorCodeExecutionViewResultBlock,
        System::Action<BetaTextEditorCodeExecutionCreateResultBlock> betaTextEditorCodeExecutionCreateResultBlock,
        System::Action<BetaTextEditorCodeExecutionStrReplaceResultBlock> betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        switch (this.Value)
        {
            case BetaTextEditorCodeExecutionToolResultError value:
                betaTextEditorCodeExecutionToolResultError(value);
                break;
            case BetaTextEditorCodeExecutionViewResultBlock value:
                betaTextEditorCodeExecutionViewResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionCreateResultBlock value:
                betaTextEditorCodeExecutionCreateResultBlock(value);
                break;
            case BetaTextEditorCodeExecutionStrReplaceResultBlock value:
                betaTextEditorCodeExecutionStrReplaceResultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Content5"
                );
        }
    }

    public T Match<T>(
        System::Func<
            BetaTextEditorCodeExecutionToolResultError,
            T
        > betaTextEditorCodeExecutionToolResultError,
        System::Func<
            BetaTextEditorCodeExecutionViewResultBlock,
            T
        > betaTextEditorCodeExecutionViewResultBlock,
        System::Func<
            BetaTextEditorCodeExecutionCreateResultBlock,
            T
        > betaTextEditorCodeExecutionCreateResultBlock,
        System::Func<
            BetaTextEditorCodeExecutionStrReplaceResultBlock,
            T
        > betaTextEditorCodeExecutionStrReplaceResultBlock
    )
    {
        return this.Value switch
        {
            BetaTextEditorCodeExecutionToolResultError value =>
                betaTextEditorCodeExecutionToolResultError(value),
            BetaTextEditorCodeExecutionViewResultBlock value =>
                betaTextEditorCodeExecutionViewResultBlock(value),
            BetaTextEditorCodeExecutionCreateResultBlock value =>
                betaTextEditorCodeExecutionCreateResultBlock(value),
            BetaTextEditorCodeExecutionStrReplaceResultBlock value =>
                betaTextEditorCodeExecutionStrReplaceResultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Content5"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Content5");
        }
    }

    record struct UnknownVariant(JsonElement value);
}

sealed class Content5Converter : JsonConverter<Content5>
{
    public override Content5? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content5(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionToolResultError'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content5(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionViewResultBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content5(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionCreateResultBlock'",
                    e
                )
            );
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlock>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new Content5(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaTextEditorCodeExecutionStrReplaceResultBlock'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(Utf8JsonWriter writer, Content5 value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
