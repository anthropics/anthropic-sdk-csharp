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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaCitationCharLocation>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<Messages::BetaCitationPageLocation>(
                ref reader,
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

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<Messages::BetaCitationContentBlockLocation>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new CitationVariants::BetaCitationContentBlockLocationVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<Messages::BetaCitationsWebSearchResultLocation>(
                    ref reader,
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

        try
        {
            var deserialized =
                JsonSerializer.Deserialize<Messages::BetaCitationSearchResultLocation>(
                    ref reader,
                    options
                );
            if (deserialized != null)
            {
                return new CitationVariants::BetaCitationSearchResultLocationVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        throw new AggregateException(exceptions);
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
