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
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocation>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationVariants::BetaCitationCharLocationVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocation>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationVariants::BetaCitationPageLocationVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocation>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationsWebSearchResultLocation>(
                ref reader,
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

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(
                ref reader,
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
