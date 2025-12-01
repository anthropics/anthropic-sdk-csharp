using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaWebSearchToolResultBlockParamContentConverter))]
public record class BetaWebSearchToolResultBlockParamContent
{
    public object? Value { get; } = null;

    JsonElement? _json = null;

    public JsonElement Json
    {
        get { return this._json ??= JsonSerializer.SerializeToElement(this.Value); }
    }

    public BetaWebSearchToolResultBlockParamContent(
        IReadOnlyList<BetaWebSearchResultBlockParam> value,
        JsonElement? json = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._json = json;
    }

    public BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value,
        JsonElement? json = null
    )
    {
        this.Value = value;
        this._json = json;
    }

    public BetaWebSearchToolResultBlockParamContent(JsonElement json)
    {
        this._json = json;
    }

    public bool TryPickResultBlock(
        [NotNullWhen(true)] out IReadOnlyList<BetaWebSearchResultBlockParam>? value
    )
    {
        value = this.Value as IReadOnlyList<BetaWebSearchResultBlockParam>;
        return value != null;
    }

    public bool TryPickRequestError([NotNullWhen(true)] out BetaWebSearchToolRequestError? value)
    {
        value = this.Value as BetaWebSearchToolRequestError;
        return value != null;
    }

    public void Switch(
        System::Action<IReadOnlyList<BetaWebSearchResultBlockParam>> resultBlock,
        System::Action<BetaWebSearchToolRequestError> requestError
    )
    {
        switch (this.Value)
        {
            case List<BetaWebSearchResultBlockParam> value:
                resultBlock(value);
                break;
            case BetaWebSearchToolRequestError value:
                requestError(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
                );
        }
    }

    public T Match<T>(
        System::Func<IReadOnlyList<BetaWebSearchResultBlockParam>, T> resultBlock,
        System::Func<BetaWebSearchToolRequestError, T> requestError
    )
    {
        return this.Value switch
        {
            IReadOnlyList<BetaWebSearchResultBlockParam> value => resultBlock(value),
            BetaWebSearchToolRequestError value => requestError(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            ),
        };
    }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        List<BetaWebSearchResultBlockParam> value
    ) => new((IReadOnlyList<BetaWebSearchResultBlockParam>)value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) => new(value);

    public void Validate()
    {
        if (this.Value == null)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            );
        }
    }

    public virtual bool Equals(BetaWebSearchToolResultBlockParamContent? other)
    {
        return other != null && JsonElement.DeepEquals(this.Json, other.Json);
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

sealed class BetaWebSearchToolResultBlockParamContentConverter
    : JsonConverter<BetaWebSearchToolResultBlockParamContent>
{
    public override BetaWebSearchToolResultBlockParamContent? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolRequestError>(
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
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlockParam>>(
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
        BetaWebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value.Json, options);
    }
}
