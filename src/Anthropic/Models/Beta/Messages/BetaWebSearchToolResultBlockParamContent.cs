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
    public object Value { get; private init; }

    public BetaWebSearchToolResultBlockParamContent(
        IReadOnlyList<BetaWebSearchResultBlockParam> value
    )
    {
        Value = ImmutableArray.ToImmutableArray(value);
    }

    public BetaWebSearchToolResultBlockParamContent(BetaWebSearchToolRequestError value)
    {
        Value = value;
    }

    BetaWebSearchToolResultBlockParamContent(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaWebSearchToolResultBlockParamContent CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
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
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaWebSearchToolResultBlockParamContent"
            );
        }
    }

    record struct UnknownVariant(JsonElement value);
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
        List<AnthropicInvalidDataException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolRequestError>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                deserialized.Validate();
                return new BetaWebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'BetaWebSearchToolRequestError'",
                    e
                )
            );
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<List<BetaWebSearchResultBlockParam>>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaWebSearchToolResultBlockParamContent(deserialized);
            }
        }
        catch (System::Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
        {
            exceptions.Add(
                new AnthropicInvalidDataException(
                    "Data does not match union variant 'List<BetaWebSearchResultBlockParam>'",
                    e
                )
            );
        }

        throw new System::AggregateException(exceptions);
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaWebSearchToolResultBlockParamContent value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
