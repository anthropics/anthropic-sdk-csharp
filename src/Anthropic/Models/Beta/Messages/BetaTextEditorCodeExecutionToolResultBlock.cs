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
    typeof(ModelConverter<
        BetaTextEditorCodeExecutionToolResultBlock,
        BetaTextEditorCodeExecutionToolResultBlockFromRaw
    >)
)]
public sealed record class BetaTextEditorCodeExecutionToolResultBlock : ModelBase
{
    public required BetaTextEditorCodeExecutionToolResultBlockContent Content
    {
        get
        {
            if (!this._rawData.TryGetValue("content", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'content' cannot be null",
                    new System::ArgumentOutOfRangeException("content", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultBlockContent>(
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
                JsonSerializer.Deserialize<JsonElement>(
                    "\"text_editor_code_execution_tool_result\""
                )
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTextEditorCodeExecutionToolResultBlock()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

    public BetaTextEditorCodeExecutionToolResultBlock(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_tool_result\""
        );
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTextEditorCodeExecutionToolResultBlock(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaTextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTextEditorCodeExecutionToolResultBlockFromRaw
    : IFromRaw<BetaTextEditorCodeExecutionToolResultBlock>
{
    public BetaTextEditorCodeExecutionToolResultBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTextEditorCodeExecutionToolResultBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaTextEditorCodeExecutionToolResultBlockContentConverter))]
public record class BetaTextEditorCodeExecutionToolResultBlockContent
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
                betaTextEditorCodeExecutionToolResultError: (x) => x.Type,
                betaTextEditorCodeExecutionViewResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionCreateResultBlock: (x) => x.Type,
                betaTextEditorCodeExecutionStrReplaceResultBlock: (x) => x.Type
            );
        }
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionViewResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionCreateResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaTextEditorCodeExecutionToolResultBlockContent(JsonElement json)
    {
        this._json = json;
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
                    "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
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
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionViewResultBlock value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionCreateResultBlock value
    ) => new(value);

    public static implicit operator BetaTextEditorCodeExecutionToolResultBlockContent(
        BetaTextEditorCodeExecutionStrReplaceResultBlock value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextEditorCodeExecutionToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaTextEditorCodeExecutionToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaTextEditorCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaTextEditorCodeExecutionToolResultBlockContent>
{
    public override BetaTextEditorCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionToolResultError>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionCreateResultBlock>(
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
            var deserialized =
                JsonSerializer.Deserialize<BetaTextEditorCodeExecutionStrReplaceResultBlock>(
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
        BetaTextEditorCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
