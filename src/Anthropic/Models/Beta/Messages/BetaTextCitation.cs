using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaTextCitationVariants = Anthropic.Models.Beta.Messages.BetaTextCitationVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationConverter))]
public abstract record class BetaTextCitation
{
    internal BetaTextCitation() { }

    public static implicit operator BetaTextCitation(BetaCitationCharLocation value) =>
        new BetaTextCitationVariants::BetaCitationCharLocationVariant(value);

    public static implicit operator BetaTextCitation(BetaCitationPageLocation value) =>
        new BetaTextCitationVariants::BetaCitationPageLocationVariant(value);

    public static implicit operator BetaTextCitation(BetaCitationContentBlockLocation value) =>
        new BetaTextCitationVariants::BetaCitationContentBlockLocationVariant(value);

    public static implicit operator BetaTextCitation(BetaCitationsWebSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationsWebSearchResultLocationVariant(value);

    public static implicit operator BetaTextCitation(BetaCitationSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationSearchResultLocationVariant(value);

    public abstract void Validate();
}

sealed class BetaTextCitationConverter : JsonConverter<BetaTextCitation>
{
    public override BetaTextCitation? Read(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationCharLocationVariant(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationPageLocationVariant(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationContentBlockLocationVariant(
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
                        JsonSerializer.Deserialize<BetaCitationsWebSearchResultLocation>(
                            json,
                            options
                        );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationsWebSearchResultLocationVariant(
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
                    var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
                        json,
                        options
                    );
                    if (deserialized != null)
                    {
                        return new BetaTextCitationVariants::BetaCitationSearchResultLocationVariant(
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
        BetaTextCitation value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaTextCitationVariants::BetaCitationCharLocationVariant(
                var betaCitationCharLocation
            ) => betaCitationCharLocation,
            BetaTextCitationVariants::BetaCitationPageLocationVariant(
                var betaCitationPageLocation
            ) => betaCitationPageLocation,
            BetaTextCitationVariants::BetaCitationContentBlockLocationVariant(
                var betaCitationContentBlockLocation
            ) => betaCitationContentBlockLocation,
            BetaTextCitationVariants::BetaCitationsWebSearchResultLocationVariant(
                var betaCitationsWebSearchResultLocation
            ) => betaCitationsWebSearchResultLocation,
            BetaTextCitationVariants::BetaCitationSearchResultLocationVariant(
                var betaCitationSearchResultLocation
            ) => betaCitationSearchResultLocation,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
