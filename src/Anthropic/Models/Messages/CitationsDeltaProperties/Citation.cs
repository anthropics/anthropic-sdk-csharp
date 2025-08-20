using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;

namespace Anthropic.Models.Messages.CitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(CitationCharLocation value) =>
        new CitationCharLocationVariant(value);

    public static implicit operator Citation(CitationPageLocation value) =>
        new CitationPageLocationVariant(value);

    public static implicit operator Citation(CitationContentBlockLocation value) =>
        new CitationContentBlockLocationVariant(value);

    public static implicit operator Citation(CitationsWebSearchResultLocation value) =>
        new CitationsWebSearchResultLocationVariant(value);

    public static implicit operator Citation(CitationsSearchResultLocation value) =>
        new CitationsSearchResultLocationVariant(value);

    public bool TryPickCitationCharLocationVariant(
        [NotNullWhen(true)] out CitationCharLocation? value
    )
    {
        value = (this as CitationCharLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickCitationPageLocationVariant(
        [NotNullWhen(true)] out CitationPageLocation? value
    )
    {
        value = (this as CitationPageLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocationVariant(
        [NotNullWhen(true)] out CitationContentBlockLocation? value
    )
    {
        value = (this as CitationContentBlockLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickCitationsWebSearchResultLocationVariant(
        [NotNullWhen(true)] out CitationsWebSearchResultLocation? value
    )
    {
        value = (this as CitationsWebSearchResultLocationVariant)?.Value;
        return value != null;
    }

    public bool TryPickCitationsSearchResultLocationVariant(
        [NotNullWhen(true)] out CitationsSearchResultLocation? value
    )
    {
        value = (this as CitationsSearchResultLocationVariant)?.Value;
        return value != null;
    }

    public void Switch(
        Action<CitationCharLocationVariant> citationCharLocation,
        Action<CitationPageLocationVariant> citationPageLocation,
        Action<CitationContentBlockLocationVariant> citationContentBlockLocation,
        Action<CitationsWebSearchResultLocationVariant> citationsWebSearchResultLocation,
        Action<CitationsSearchResultLocationVariant> citationsSearchResultLocation
    )
    {
        switch (this)
        {
            case CitationCharLocationVariant inner:
                citationCharLocation(inner);
                break;
            case CitationPageLocationVariant inner:
                citationPageLocation(inner);
                break;
            case CitationContentBlockLocationVariant inner:
                citationContentBlockLocation(inner);
                break;
            case CitationsWebSearchResultLocationVariant inner:
                citationsWebSearchResultLocation(inner);
                break;
            case CitationsSearchResultLocationVariant inner:
                citationsSearchResultLocation(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<CitationCharLocationVariant, T> citationCharLocation,
        Func<CitationPageLocationVariant, T> citationPageLocation,
        Func<CitationContentBlockLocationVariant, T> citationContentBlockLocation,
        Func<CitationsWebSearchResultLocationVariant, T> citationsWebSearchResultLocation,
        Func<CitationsSearchResultLocationVariant, T> citationsSearchResultLocation
    )
    {
        return this switch
        {
            CitationCharLocationVariant inner => citationCharLocation(inner),
            CitationPageLocationVariant inner => citationPageLocation(inner),
            CitationContentBlockLocationVariant inner => citationContentBlockLocation(inner),
            CitationsWebSearchResultLocationVariant inner => citationsWebSearchResultLocation(
                inner
            ),
            CitationsSearchResultLocationVariant inner => citationsSearchResultLocation(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class CitationConverter : JsonConverter<Citation>
{
    public override Citation? Read(
        ref Utf8JsonReader reader,
        Type _typeToConvert,
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationCharLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "page_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationPageLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "content_block_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationContentBlockLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "web_search_result_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsWebSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationsWebSearchResultLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            case "search_result_location":
            {
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationsSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationsSearchResultLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new AggregateException(exceptions);
            }
            default:
            {
                throw new Exception();
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            CitationCharLocationVariant(var citationCharLocation) => citationCharLocation,
            CitationPageLocationVariant(var citationPageLocation) => citationPageLocation,
            CitationContentBlockLocationVariant(var citationContentBlockLocation) =>
                citationContentBlockLocation,
            CitationsWebSearchResultLocationVariant(var citationsWebSearchResultLocation) =>
                citationsWebSearchResultLocation,
            CitationsSearchResultLocationVariant(var citationsSearchResultLocation) =>
                citationsSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
