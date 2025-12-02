using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockContentConverter))]
public record class BetaWebSearchToolResultBlockContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaWebSearchToolResultBlockContent(
        IReadOnlyList<BetaWebSearchResultBlock> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public BetaWebSearchToolResultBlockContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickError([NotNullWhen(true)] out BetaWebSearchToolResultError? value)
    {
        value = this.Value as BetaWebSearchToolResultError;
        return value != null;
    }

    public bool TryPickBetaWebSearchResultBlocks(
        [NotNullWhen(true)] out IReadOnlyList<BetaWebSearchResultBlock>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaWebSearchResultBlock>;
        return value != null;
    }

    public void Switch(
        System::Action<BetaWebSearchToolResultError> error,
        System::Action<IReadOnlyList<BetaWebSearchResultBlock>> betaWebSearchResultBlocks
    )
    {
        switch (this.Value)
        {
            case BetaWebSearchToolResultError value:
                error(value);
                break;
            case List<BetaWebSearchResultBlock> value:
                betaWebSearchResultBlocks(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockContent"
                );
        }
    }

    public T Match<T>(
        System::Func<BetaWebSearchToolResultError, T> error,
        System::Func<IReadOnlyList<BetaWebSearchResultBlock>, T> betaWebSearchResultBlocks
    )
    {
        return this.Value switch
        {
            BetaWebSearchToolResultError value => error(value),
            IReadOnlyList<BetaWebSearchResultBlock> value => betaWebSearchResultBlocks(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            ),
        };
    }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) => new(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new((IReadOnlyList<BetaWebSearchResultBlock>)value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockContent"
            );
        }
    }

    public virtual bool Equals(BetaWebSearchToolResultBlockContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaWebSearchToolResultBlockContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockContent>
{
    public override BetaWebSearchToolResultBlockContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultError>(
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
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlock>>(
                json,
                options
            );
            if (deserialized != null)
            {
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
        BetaWebSearchToolResultBlockContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
