using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TextCitationVariants = Anthropic.Models.Messages.TextCitationVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(TextCitationConverter))]
public abstract record class TextCitation
{
    internal TextCitation() { }

    public static implicit operator TextCitation(CitationCharLocation value) =>
        new TextCitationVariants::CitationCharLocationVariant(value);

    public static implicit operator TextCitation(CitationPageLocation value) =>
        new TextCitationVariants::CitationPageLocationVariant(value);

    public static implicit operator TextCitation(CitationContentBlockLocation value) =>
        new TextCitationVariants::CitationContentBlockLocationVariant(value);

    public static implicit operator TextCitation(CitationsWebSearchResultLocation value) =>
        new TextCitationVariants::CitationsWebSearchResultLocationVariant(value);

    public static implicit operator TextCitation(CitationsSearchResultLocation value) =>
        new TextCitationVariants::CitationsSearchResultLocationVariant(value);

    public abstract void Validate();
}

sealed class TextCitationConverter : JsonConverter<TextCitation>
{
    public override TextCitation? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
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
                        return new TextCitationVariants::CitationCharLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new TextCitationVariants::CitationPageLocationVariant(deserialized);
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new TextCitationVariants::CitationContentBlockLocationVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new TextCitationVariants::CitationsWebSearchResultLocationVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
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
                        return new TextCitationVariants::CitationsSearchResultLocationVariant(
                            deserialized
                        );
                    }
                }
                catch (JsonException e)
                {
                    exceptions.Add(e);
                }

                throw new global::System.AggregateException(exceptions);
            }
            default:
            {
                throw new global::System.Exception();
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
            TextCitationVariants::CitationCharLocationVariant(var citationCharLocation) =>
                citationCharLocation,
            TextCitationVariants::CitationPageLocationVariant(var citationPageLocation) =>
                citationPageLocation,
            TextCitationVariants::CitationContentBlockLocationVariant(
                var citationContentBlockLocation
            ) => citationContentBlockLocation,
            TextCitationVariants::CitationsWebSearchResultLocationVariant(
                var citationsWebSearchResultLocation
            ) => citationsWebSearchResultLocation,
            TextCitationVariants::CitationsSearchResultLocationVariant(
                var citationsSearchResultLocation
            ) => citationsSearchResultLocation,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
