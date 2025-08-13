using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using TextCitationParamVariants = Anthropic.Models.Messages.TextCitationParamVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(TextCitationParamConverter))]
public abstract record class TextCitationParam
{
    internal TextCitationParam() { }

    public static implicit operator TextCitationParam(CitationCharLocationParam value) =>
        new TextCitationParamVariants::CitationCharLocationParamVariant(value);

    public static implicit operator TextCitationParam(CitationPageLocationParam value) =>
        new TextCitationParamVariants::CitationPageLocationParamVariant(value);

    public static implicit operator TextCitationParam(CitationContentBlockLocationParam value) =>
        new TextCitationParamVariants::CitationContentBlockLocationParamVariant(value);

    public static implicit operator TextCitationParam(CitationWebSearchResultLocationParam value) =>
        new TextCitationParamVariants::CitationWebSearchResultLocationParamVariant(value);

    public static implicit operator TextCitationParam(CitationSearchResultLocationParam value) =>
        new TextCitationParamVariants::CitationSearchResultLocationParamVariant(value);

    public abstract void Validate();
}

sealed class TextCitationParamConverter : JsonConverter<TextCitationParam>
{
    public override TextCitationParam? Read(
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
                    var deserialized = JsonSerializer.Deserialize<CitationCharLocationParam>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationCharLocationParamVariant(
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
                        return new TextCitationParamVariants::CitationPageLocationParamVariant(
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
                        return new TextCitationParamVariants::CitationContentBlockLocationParamVariant(
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
                    var deserialized =
                        JsonSerializer.Deserialize<CitationWebSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationWebSearchResultLocationParamVariant(
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
                    var deserialized =
                        JsonSerializer.Deserialize<CitationSearchResultLocationParam>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new TextCitationParamVariants::CitationSearchResultLocationParamVariant(
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
        TextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            TextCitationParamVariants::CitationCharLocationParamVariant(
                var citationCharLocationParam
            ) => citationCharLocationParam,
            TextCitationParamVariants::CitationPageLocationParamVariant(
                var citationPageLocationParam
            ) => citationPageLocationParam,
            TextCitationParamVariants::CitationContentBlockLocationParamVariant(
                var citationContentBlockLocationParam
            ) => citationContentBlockLocationParam,
            TextCitationParamVariants::CitationWebSearchResultLocationParamVariant(
                var citationWebSearchResultLocationParam
            ) => citationWebSearchResultLocationParam,
            TextCitationParamVariants::CitationSearchResultLocationParamVariant(
                var citationSearchResultLocationParam
            ) => citationSearchResultLocationParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
