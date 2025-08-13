using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using CitationVariants = Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.CitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(Messages::CitationCharLocation value) =>
        new CitationVariants::CitationCharLocationVariant(value);

    public static implicit operator Citation(Messages::CitationPageLocation value) =>
        new CitationVariants::CitationPageLocationVariant(value);

    public static implicit operator Citation(Messages::CitationContentBlockLocation value) =>
        new CitationVariants::CitationContentBlockLocationVariant(value);

    public static implicit operator Citation(Messages::CitationsWebSearchResultLocation value) =>
        new CitationVariants::CitationsWebSearchResultLocationVariant(value);

    public static implicit operator Citation(Messages::CitationsSearchResultLocation value) =>
        new CitationVariants::CitationsSearchResultLocationVariant(value);

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
                    var deserialized = JsonSerializer.Deserialize<Messages::CitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationVariants::CitationCharLocationVariant(deserialized);
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
                    var deserialized = JsonSerializer.Deserialize<Messages::CitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new CitationVariants::CitationPageLocationVariant(deserialized);
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
                        JsonSerializer.Deserialize<Messages::CitationContentBlockLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::CitationContentBlockLocationVariant(
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
                        JsonSerializer.Deserialize<Messages::CitationsWebSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::CitationsWebSearchResultLocationVariant(
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
                        JsonSerializer.Deserialize<Messages::CitationsSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::CitationsSearchResultLocationVariant(
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

    public override void Write(Utf8JsonWriter writer, Citation value, JsonSerializerOptions options)
    {
        object variant = value switch
        {
            CitationVariants::CitationCharLocationVariant(var citationCharLocation) =>
                citationCharLocation,
            CitationVariants::CitationPageLocationVariant(var citationPageLocation) =>
                citationPageLocation,
            CitationVariants::CitationContentBlockLocationVariant(
                var citationContentBlockLocation
            ) => citationContentBlockLocation,
            CitationVariants::CitationsWebSearchResultLocationVariant(
                var citationsWebSearchResultLocation
            ) => citationsWebSearchResultLocation,
            CitationVariants::CitationsSearchResultLocationVariant(
                var citationsSearchResultLocation
            ) => citationsSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
