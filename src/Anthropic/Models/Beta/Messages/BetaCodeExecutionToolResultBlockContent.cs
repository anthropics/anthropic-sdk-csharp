using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaCodeExecutionToolResultBlockContentConverter))]
public record class BetaCodeExecutionToolResultBlockContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public JsonElement Type
    {
        get { return Match(error: (x) => x.Type, resultBlock: (x) => x.Type); }
    }

    public BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaCodeExecutionToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickError([NotNullWhen(true)] out BetaCodeExecutionToolResultError? value)
    {
        value = this.Value as BetaCodeExecutionToolResultError;
        return value != null;
    }

    public bool TryPickResultBlock([NotNullWhen(true)] out BetaCodeExecutionResultBlock? value)
    {
        value = this.Value as BetaCodeExecutionResultBlock;
        return value != null;
    }

    public void Switch(
        System::Action<BetaCodeExecutionToolResultError> error,
        System::Action<BetaCodeExecutionResultBlock> resultBlock
    )
    {
        switch (this.Value)
        {
            case BetaCodeExecutionToolResultError value:
                error(value);
                break;
            case BetaCodeExecutionResultBlock value:
                resultBlock(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaCodeExecutionToolResultError, T> error,
        System::Func<BetaCodeExecutionResultBlock, T> resultBlock
    )
    {
        return this.Value switch
        {
            BetaCodeExecutionToolResultError value => error(value),
            BetaCodeExecutionResultBlock value => resultBlock(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) => new(value);

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaCodeExecutionToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaCodeExecutionToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaCodeExecutionToolResultBlockContentConverter
    : JsonConverter<BetaCodeExecutionToolResultBlockContent>
{
    public override BetaCodeExecutionToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<BetaCodeExecutionResultBlock>(
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
        BetaCodeExecutionToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
