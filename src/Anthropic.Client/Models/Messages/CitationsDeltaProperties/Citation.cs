using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages.CitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public record class Citation
{
    public object Value { get; private init; }

    public string CitedText
    {
        get
        {
            return Match(
                charLocation: (x) => x.CitedText,
                pageLocation: (x) => x.CitedText,
                contentBlockLocation: (x) => x.CitedText,
                citationsWebSearchResultLocation: (x) => x.CitedText,
                citationsSearchResultLocation: (x) => x.CitedText
            );
        }
    }

    public long? DocumentIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (x) => x.DocumentIndex,
                pageLocation: (x) => x.DocumentIndex,
                contentBlockLocation: (x) => x.DocumentIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? DocumentTitle
    {
        get
        {
            return Match<string?>(
                charLocation: (x) => x.DocumentTitle,
                pageLocation: (x) => x.DocumentTitle,
                contentBlockLocation: (x) => x.DocumentTitle,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public string? FileID
    {
        get
        {
            return Match<string?>(
                charLocation: (x) => x.FileID,
                pageLocation: (x) => x.FileID,
                contentBlockLocation: (x) => x.FileID,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (_) => null
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            return Match(
                charLocation: (x) => x.Type,
                pageLocation: (x) => x.Type,
                contentBlockLocation: (x) => x.Type,
                citationsWebSearchResultLocation: (x) => x.Type,
                citationsSearchResultLocation: (x) => x.Type
            );
        }
    }

    public long? EndBlockIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.EndBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.EndBlockIndex
            );
        }
    }

    public long? StartBlockIndex
    {
        get
        {
            return Match<long?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (x) => x.StartBlockIndex,
                citationsWebSearchResultLocation: (_) => null,
                citationsSearchResultLocation: (x) => x.StartBlockIndex
            );
        }
    }

    public string? Title
    {
        get
        {
            return Match<string?>(
                charLocation: (_) => null,
                pageLocation: (_) => null,
                contentBlockLocation: (_) => null,
                citationsWebSearchResultLocation: (x) => x.Title,
                citationsSearchResultLocation: (x) => x.Title
            );
        }
    }

    public Citation(CitationCharLocation value)
    {
        Value = value;
    }

    public Citation(CitationPageLocation value)
    {
        Value = value;
    }

    public Citation(CitationContentBlockLocation value)
    {
        Value = value;
    }

    public Citation(CitationsWebSearchResultLocation value)
    {
        Value = value;
    }

    public Citation(CitationsSearchResultLocation value)
    {
        Value = value;
    }

    Citation(UnknownVariant value)
    {
        Value = value;
    }

    public static Citation CreateUnknownVariant(JsonElement value)
    {
        return new(new UnknownVariant(value));
    }

    public bool TryPickCharLocation([NotNullWhen(true)] out CitationCharLocation? value)
    {
        value = this.Value as CitationCharLocation;
        return value != null;
    }

    public bool TryPickPageLocation([NotNullWhen(true)] out CitationPageLocation? value)
    {
        value = this.Value as CitationPageLocation;
        return value != null;
    }

    public bool TryPickContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocation? value
    )
    {
        value = this.Value as CitationContentBlockLocation;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out CitationsWebSearchResultLocation? value
    )
    {
        value = this.Value as CitationsWebSearchResultLocation;
        return value != null;
    }

    public bool TryPickCitationsSearchResultLocation(
        [NotNullWhen(true)] out CitationsSearchResultLocation? value
    )
    {
        value = this.Value as CitationsSearchResultLocation;
        return value != null;
    }

    public void Switch(
        Action<CitationCharLocation> charLocation,
        Action<CitationPageLocation> pageLocation,
        Action<CitationContentBlockLocation> contentBlockLocation,
        Action<CitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        Action<CitationsSearchResultLocation> citationsSearchResultLocation
    )
    {
        switch (this.Value)
        {
            case CitationCharLocation value:
                charLocation(value);
                break;
            case CitationPageLocation value:
                pageLocation(value);
                break;
            case CitationContentBlockLocation value:
                contentBlockLocation(value);
                break;
            case CitationsWebSearchResultLocation value:
                citationsWebSearchResultLocation(value);
                break;
            case CitationsSearchResultLocation value:
                citationsSearchResultLocation(value);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of Citation"
                );
        }
    }

    public T Match<T>(
        Func<CitationCharLocation, T> charLocation,
        Func<CitationPageLocation, T> pageLocation,
        Func<CitationContentBlockLocation, T> contentBlockLocation,
        Func<CitationsWebSearchResultLocation, T> citationsWebSearchResultLocation,
        Func<CitationsSearchResultLocation, T> citationsSearchResultLocation
    )
    {
        return this.Value switch
        {
            CitationCharLocation value => charLocation(value),
            CitationPageLocation value => pageLocation(value),
            CitationContentBlockLocation value => contentBlockLocation(value),
            CitationsWebSearchResultLocation value => citationsWebSearchResultLocation(value),
            CitationsSearchResultLocation value => citationsSearchResultLocation(value),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of Citation"
            ),
        };
    }

    public void Validate()
    {
        if (this.Value is UnknownVariant)
        {
            throw new AnthropicInvalidDataException("Data did not match any variant of Citation");
        }
    }

    private record struct UnknownVariant(JsonElement value);
}

sealed class CitationConverter : JsonConverter<Citation>
{
    public override Citation? Read(
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
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationCharLocation'",
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
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationPageLocation'",
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
                    var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationContentBlockLocation'",
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
                    var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationsWebSearchResultLocation'",
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
                    var deserialized = JsonSerializer.Deserialize<CitationsSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        deserialized.Validate();
                        return new Citation(deserialized);
                    }
                }
                catch (Exception e) when (e is JsonException || e is AnthropicInvalidDataException)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant 'CitationsSearchResultLocation'",
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

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        object variant = value.Value;
        JsonSerializer.Serialize(writer, variant, options);
    }
}
