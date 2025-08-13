using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using CitationVariants = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

[JsonConverter(typeof(CitationConverter))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(Messages::BetaCitationCharLocation value) =>
        new CitationVariants::BetaCitationCharLocationVariant(value);

    public static implicit operator Citation(Messages::BetaCitationPageLocation value) =>
        new CitationVariants::BetaCitationPageLocationVariant(value);

    public static implicit operator Citation(Messages::BetaCitationContentBlockLocation value) =>
        new CitationVariants::BetaCitationContentBlockLocationVariant(value);

    public static implicit operator Citation(
        Messages::BetaCitationsWebSearchResultLocation value
    ) => new CitationVariants::BetaCitationsWebSearchResultLocationVariant(value);

    public static implicit operator Citation(Messages::BetaCitationSearchResultLocation value) =>
        new CitationVariants::BetaCitationSearchResultLocationVariant(value);

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
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::BetaCitationCharLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::BetaCitationCharLocationVariant(deserialized);
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
                    var deserialized =
                        JsonSerializer.Deserialize<Messages::BetaCitationPageLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::BetaCitationPageLocationVariant(deserialized);
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
                        JsonSerializer.Deserialize<Messages::BetaCitationContentBlockLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::BetaCitationContentBlockLocationVariant(
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
                        JsonSerializer.Deserialize<Messages::BetaCitationsWebSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::BetaCitationsWebSearchResultLocationVariant(
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
                        JsonSerializer.Deserialize<Messages::BetaCitationSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new CitationVariants::BetaCitationSearchResultLocationVariant(
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
            CitationVariants::BetaCitationCharLocationVariant(var betaCitationCharLocation) =>
                betaCitationCharLocation,
            CitationVariants::BetaCitationPageLocationVariant(var betaCitationPageLocation) =>
                betaCitationPageLocation,
            CitationVariants::BetaCitationContentBlockLocationVariant(
                var betaCitationContentBlockLocation
            ) => betaCitationContentBlockLocation,
            CitationVariants::BetaCitationsWebSearchResultLocationVariant(
                var betaCitationsWebSearchResultLocation
            ) => betaCitationsWebSearchResultLocation,
            CitationVariants::BetaCitationSearchResultLocationVariant(
                var betaCitationSearchResultLocation
            ) => betaCitationSearchResultLocation,
            _ => throw new ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
