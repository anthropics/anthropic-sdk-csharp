using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TextCitationParamVariants = Anthropic.Beta.Client.Models.Messages.TextCitationParamVariants;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(TextCitationParamConverter))]
public abstract record class TextCitationParam
{
    internal TextCitationParam() { }

    public static implicit operator TextCitationParam(CitationCharLocationParam value) =>
        new TextCitationParamVariants::CitationCharLocationParam(value);

    public static implicit operator TextCitationParam(CitationPageLocationParam value) =>
        new TextCitationParamVariants::CitationPageLocationParam(value);

    public static implicit operator TextCitationParam(CitationContentBlockLocationParam value) =>
        new TextCitationParamVariants::CitationContentBlockLocationParam(value);

    public static implicit operator TextCitationParam(CitationWebSearchResultLocationParam value) =>
        new TextCitationParamVariants::CitationWebSearchResultLocationParam(value);

    public static implicit operator TextCitationParam(CitationSearchResultLocationParam value) =>
        new TextCitationParamVariants::CitationSearchResultLocationParam(value);

    public bool TryPickCitationCharLocation(
        [NotNullWhen(true)] out CitationCharLocationParam? value
    )
    {
        value = (this as TextCitationParamVariants::CitationCharLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationPageLocation(
        [NotNullWhen(true)] out CitationPageLocationParam? value
    )
    {
        value = (this as TextCitationParamVariants::CitationPageLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationContentBlockLocation(
        [NotNullWhen(true)] out CitationContentBlockLocationParam? value
    )
    {
        value = (this as TextCitationParamVariants::CitationContentBlockLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationWebSearchResultLocation(
        [NotNullWhen(true)] out CitationWebSearchResultLocationParam? value
    )
    {
        value = (this as TextCitationParamVariants::CitationWebSearchResultLocationParam)?.Value;
        return value != null;
    }

    public bool TryPickCitationSearchResultLocation(
        [NotNullWhen(true)] out CitationSearchResultLocationParam? value
    )
    {
        value = (this as TextCitationParamVariants::CitationSearchResultLocationParam)?.Value;
        return value != null;
    }

    public void Switch(
        Action<TextCitationParamVariants::CitationCharLocationParam> citationCharLocation,
        Action<TextCitationParamVariants::CitationPageLocationParam> citationPageLocation,
        Action<TextCitationParamVariants::CitationContentBlockLocationParam> citationContentBlockLocation,
        Action<TextCitationParamVariants::CitationWebSearchResultLocationParam> citationWebSearchResultLocation,
        Action<TextCitationParamVariants::CitationSearchResultLocationParam> citationSearchResultLocation
    )
    {
        switch (this)
        {
            case TextCitationParamVariants::CitationCharLocationParam inner:
                citationCharLocation(inner);
                break;
            case TextCitationParamVariants::CitationPageLocationParam inner:
                citationPageLocation(inner);
                break;
            case TextCitationParamVariants::CitationContentBlockLocationParam inner:
                citationContentBlockLocation(inner);
                break;
            case TextCitationParamVariants::CitationWebSearchResultLocationParam inner:
                citationWebSearchResultLocation(inner);
                break;
            case TextCitationParamVariants::CitationSearchResultLocationParam inner:
                citationSearchResultLocation(inner);
                break;
            default:
                throw new InvalidOperationException();
        }
    }

    public T Match<T>(
        Func<TextCitationParamVariants::CitationCharLocationParam, T> citationCharLocation,
        Func<TextCitationParamVariants::CitationPageLocationParam, T> citationPageLocation,
        Func<
            TextCitationParamVariants::CitationContentBlockLocationParam,
            T
        > citationContentBlockLocation,
        Func<
            TextCitationParamVariants::CitationWebSearchResultLocationParam,
            T
        > citationWebSearchResultLocation,
        Func<
            TextCitationParamVariants::CitationSearchResultLocationParam,
            T
        > citationSearchResultLocation
    )
    {
        return this switch
        {
            TextCitationParamVariants::CitationCharLocationParam inner => citationCharLocation(
                inner
            ),
            TextCitationParamVariants::CitationPageLocationParam inner => citationPageLocation(
                inner
            ),
            TextCitationParamVariants::CitationContentBlockLocationParam inner =>
                citationContentBlockLocation(inner),
            TextCitationParamVariants::CitationWebSearchResultLocationParam inner =>
                citationWebSearchResultLocation(inner),
            TextCitationParamVariants::CitationSearchResultLocationParam inner =>
                citationSearchResultLocation(inner),
            _ => throw new InvalidOperationException(),
        };
    }

    public abstract void Validate();
}

sealed class TextCitationParamConverter : JsonConverter<TextCitationParam>
{
    public override TextCitationParam? Read(
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
                List<JsonException> exceptions = [];

                try
                {
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationCharLocationParam(
                            deserialized
                        );
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
                    var deserialized = JsonSerializer.Deserialize<CitationPageLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationPageLocationParam(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<CitationContentBlockLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationContentBlockLocationParam(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<CitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationWebSearchResultLocationParam(
                            deserialized
                        );
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
                    var deserialized =
                        JsonSerializer.Deserialize<CitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationSearchResultLocationParam(
                            deserialized
                        );
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

    public override void Write(
        Utf8JsonWriter writer,
        TextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TextCitationParamVariants::CitationCharLocationParam(var citationCharLocation) =>
                citationCharLocation,
            TextCitationParamVariants::CitationPageLocationParam(var citationPageLocation) =>
                citationPageLocation,
            TextCitationParamVariants::CitationContentBlockLocationParam(
                var citationContentBlockLocation
            ) => citationContentBlockLocation,
            TextCitationParamVariants::CitationWebSearchResultLocationParam(
                var citationWebSearchResultLocation
            ) => citationWebSearchResultLocation,
            TextCitationParamVariants::CitationSearchResultLocationParam(
                var citationSearchResultLocation
            ) => citationSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
