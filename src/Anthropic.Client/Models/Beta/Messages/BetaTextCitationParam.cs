using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public record class BetaTextCitationParam
{
    public object Value { get; private init; }

    public string CitedText
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.CitedText,
                citationPageLocation: (x) => x.CitedText,
                citationContentBlockLocation: (x) => x.CitedText,
                citationWebSearchResultLocation: (x) => x.CitedText,
                citationSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (x) => x.DocumentIndex,
                citationPageLocation: (x) => x.DocumentIndex,
                citationContentBlockLocation: (x) => x.DocumentIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (x) => x.DocumentTitle,
                citationPageLocation: (x) => x.DocumentTitle,
                citationContentBlockLocation: (x) => x.DocumentTitle,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                citationCharLocation: (x) => x.Type,
                citationPageLocation: (x) => x.Type,
                citationContentBlockLocation: (x) => x.Type,
                citationWebSearchResultLocation: (x) => x.Type,
                citationSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.EndBlockIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (x) => x.StartBlockIndex,
                citationWebSearchResultLocation: (_) => null,
                citationSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                citationCharLocation: (_) => null,
                citationPageLocation: (_) => null,
                citationContentBlockLocation: (_) => null,
                citationWebSearchResultLocation: (x) => x.Title,
                citationSearchResultLocation: (x) => x.Title
            );
        }
    }

    public BetaTextCitationParam(BetaCitationCharLocationParam value)
    {
        Value = value;
    }

    public BetaTextCitationParam(BetaCitationPageLocationParam value)
    {
        Value = value;
    }

    public BetaTextCitationParam(BetaCitationContentBlockLocationParam value)
    {
        Value = value;
    }

    public BetaTextCitationParam(BetaCitationWebSearchResultLocationParam value)
    {
        Value = value;
    }

    public BetaTextCitationParam(BetaCitationSearchResultLocationParam value)
    {
        Value = value;
    }

    BetaTextCitationParam(UnknownVariant value)
    {
        Value = value;
    }

    public static BetaTextCitationParam CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickCitationCharLocation(
        [NotNullWhen(true)] out BetaCitationCharLocationParam? value
    )
    {
        value = this.Value as BetaCitationCharLocationParam;
        return value != null;
    }

    public bool TryPickCitationPageLocation(
        [NotNullWhen(true)] out BetaCitationPageLocationParam? value
    )
    {
        value = this.Value as BetaCitationPageLocationParam;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out BetaCitationContentBlockLocationParam? value
    )
    {
        value = this.Value as BetaCitationContentBlockLocationParam;
        return value != null;
    }

    public bool TryPickCitationWebSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationWebSearchResultLocationParam? value
    )
    {
        value = this.Value as BetaCitationWebSearchResultLocationParam;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out BetaCitationSearchResultLocationParam? value
    )
    {
        value = this.Value as BetaCitationSearchResultLocationParam;
        return value != null;
    }

    public void Switch(
        Action<BetaCitationCharLocationParam> citationCharLocation,
        Action<BetaCitationPageLocationParam> citationPageLocation,
        Action<BetaCitationContentBlockLocationParam> citationContentBlockLocation,
        Action<BetaCitationWebSearchResultLocationParam> citationWebSearchResultLocation,
        Action<BetaCitationSearchResultLocationParam> citationSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case BetaCitationCharLocationParam value:
                citationCharLocation(value);
                break;
            case BetaCitationPageLocationParam value:
                citationPageLocation(value);
                break;
            case BetaCitationContentBlockLocationParam value:
                citationContentBlockLocation(value);
                break;
            case BetaCitationWebSearchResultLocationParam value:
                citationWebSearchResultLocation(value);
                break;
            case BetaCitationSearchResultLocationParam value:
                citationSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of BetaTextCitationParam"
                );
        }
    }

    public T Match<T>(
        Func<BetaCitationCharLocationParam, T> citationCharLocation,
        Func<BetaCitationPageLocationParam, T> citationPageLocation,
        Func<BetaCitationContentBlockLocationParam, T> citationContentBlockLocation,
        Func<BetaCitationWebSearchResultLocationParam, T> citationWebSearchResultLocation,
        Func<BetaCitationSearchResultLocationParam, T> citationSearchResultLocation
    )
    {
        return this.Value switch
        {
            BetaCitationCharLocationParam value => citationCharLocation(value),
            BetaCitationPageLocationParam value => citationPageLocation(value),
            BetaCitationContentBlockLocationParam value => citationContentBlockLocation(value),
            BetaCitationWebSearchResultLocationParam value => citationWebSearchResultLocation(
                value
            ),
            BetaCitationSearchResultLocationParam value => citationSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitationParam"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is not UnknownVariant)
        {
            throw new AnthropicInvalidDataException(
                "Data did not match any variant of BetaTextCitationParam"
            );
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var json = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try
        {
            type = json.GetProperty("type").GetString();
        }
        catch
        {
            type = null;
        }

        switch (type)
        {
            case "char_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaTextCitationParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationCharLocationParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "page_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaTextCitationParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationPageLocationParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationContentBlockLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaTextCitationParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationContentBlockLocationParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaTextCitationParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationWebSearchResultLocationParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            case "search_result_location":
            {
                List<AnthropicInvalidDataException> exceptions = [];

                try
                {
                    var deserialized =
                        JsonSerializer.Deserialize<BetaCitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new BetaTextCitationParam(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'BetaCitationSearchResultLocationParam'",
                            e
                        )
                    );
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new AnthropicInvalidDataException(
                    "Could not find valid union variant to represent data"
                );
            }
        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaTextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
