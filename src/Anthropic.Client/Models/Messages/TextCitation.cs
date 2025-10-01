using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Exceptions;
using TextCitationVariants = Anthropic.Client.Models.Messages.TextCitationVariants;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(TextCitationConverter))]
public abstract record class TextCitation
{
    internal TextCitation() { }

    public static implicit operator TextCitation(CitationCharLocation value) =>
        new TextCitationVariants::CitationCharLocation(value);

    public static implicit operator TextCitation(CitationPageLocation value) =>
        new TextCitationVariants::CitationPageLocation(value);

    public static implicit operator TextCitation(CitationContentBlockLocation value) =>
        new TextCitationVariants::CitationContentBlockLocation(value);

    public static implicit operator TextCitation(CitationsWebSearchResultLocation value) =>
        new TextCitationVariants::CitationsWebSearchResultLocation(value);

    public static implicit operator TextCitation(CitationsSearchResultLocation value) =>
        new TextCitationVariants::CitationsSearchResultLocation(value);

    public bool TryPickCitationCharLocation([NotNullWhen(true)] out CitationCharLocation? value)
    {
        value = (this as TextCitationVariants::CitationCharLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationPageLocation([NotNullWhen(true)] out CitationPageLocation? value)
    {
        value = (this as TextCitationVariants::CitationPageLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocation? value
    )
    {
        value = (this as TextCitationVariants::CitationContentBlockLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocation(
        [NotNullWhen(true)] out CitationsWebSearchResultLocation? value
    )
    {
        value = (this as TextCitationVariants::CitationsWebSearchResultLocation)?.Value;
        return value != null;
    }

    public bool TryPickCitationsSearchResultLocation(
        [NotNullWhen(true)] out CitationsSearchResultLocation? value
    )
    {
        value = (this as TextCitationVariants::CitationsSearchResultLocation)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextCitationVariants::CitationCharLocation> citationCharLocation,
        Action<TextCitationVariants::CitationPageLocation> citationPageLocation,
        Action<TextCitationVariants::CitationContentBlockLocation> citationContentBlockLocation,
        Action<TextCitationVariants::CitationsWebSearchResultLocation> citationsWebSearchResultLocation,
        Action<TextCitationVariants::CitationsSearchResultLocation> citationsSearchResultLocation
    )
    {
        switch (this)
        {
            case TextCitationVariants::CitationCharLocation inner:
                citationCharLocation(inner);
                break;
            case TextCitationVariants::CitationPageLocation inner:
                citationPageLocation(inner);
                break;
            case TextCitationVariants::CitationContentBlockLocation inner:
                citationContentBlockLocation(inner);
                break;
            case TextCitationVariants::CitationsWebSearchResultLocation inner:
                citationsWebSearchResultLocation(inner);
                break;
            case TextCitationVariants::CitationsSearchResultLocation inner:
                citationsSearchResultLocation(inner);
                break;
            default:
                throw new AnthropicInvalidDataException(
                    "Data did not match any variant of TextCitation"
                );
        }
    }

    public T Match<T>(
        Func<TextCitationVariants::CitationCharLocation, T> citationCharLocation,
        Func<TextCitationVariants::CitationPageLocation, T> citationPageLocation,
        Func<TextCitationVariants::CitationContentBlockLocation, T> citationContentBlockLocation,
        Func<
            TextCitationVariants::CitationsWebSearchResultLocation,
            T
        > citationsWebSearchResultLocation,
        Func<TextCitationVariants::CitationsSearchResultLocation, T> citationsSearchResultLocation
    )
    {
        return this switch
        {
            TextCitationVariants::CitationCharLocation inner => citationCharLocation(inner),
            TextCitationVariants::CitationPageLocation inner => citationPageLocation(inner),
            TextCitationVariants::CitationContentBlockLocation inner =>
                citationContentBlockLocation(inner),
            TextCitationVariants::CitationsWebSearchResultLocation inner =>
                citationsWebSearchResultLocation(inner),
            TextCitationVariants::CitationsSearchResultLocation inner =>
                citationsSearchResultLocation(inner),
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextCitation"
            ),
        };
    }

    public abstract void Validate();
}

sealed class TextCitationConverter : JsonConverter<TextCitation>
{
    public override TextCitation? Read(
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
                        return new TextCitationVariants::CitationCharLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant TextCitationVariants::CitationCharLocation",
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
                        return new TextCitationVariants::CitationPageLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant TextCitationVariants::CitationPageLocation",
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
                        return new TextCitationVariants::CitationContentBlockLocation(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant TextCitationVariants::CitationContentBlockLocation",
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
                        return new TextCitationVariants::CitationsWebSearchResultLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant TextCitationVariants::CitationsWebSearchResultLocation",
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
                        return new TextCitationVariants::CitationsSearchResultLocation(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(
                        new AnthropicInvalidDataException(
                            "Data does not match union variant TextCitationVariants::CitationsSearchResultLocation",
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
        TextCitation value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TextCitationVariants::CitationCharLocation(var citationCharLocation) =>
                citationCharLocation,
            TextCitationVariants::CitationPageLocation(var citationPageLocation) =>
                citationPageLocation,
            TextCitationVariants::CitationContentBlockLocation(var citationContentBlockLocation) =>
                citationContentBlockLocation,
            TextCitationVariants::CitationsWebSearchResultLocation(
                var citationsWebSearchResultLocation
            ) => citationsWebSearchResultLocation,
            TextCitationVariants::CitationsSearchResultLocation(
                var citationsSearchResultLocation
            ) => citationsSearchResultLocation,
            _ => throw new AnthropicInvalidDataException(
                "Data did not match any variant of TextCitation"
            ),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
