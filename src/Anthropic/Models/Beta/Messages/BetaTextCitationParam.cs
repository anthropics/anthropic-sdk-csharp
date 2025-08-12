using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaTextCitationParamVariants = Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaTextCitationParamConverter))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(value);

    public abstract void Validate();
}

sealed class BetaTextCitationParamConverter : JsonConverter<BetaTextCitationParam>
{
    public override BetaTextCitationParam? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaCitationCharLocationParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCitationPageLocationParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCitationContentBlockLocationParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCitationWebSearchResultLocationParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocationParam>(
                ref reader,
                options
            );
            if (deserialized != null)
            {
                return new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(
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
        BetaTextCitationParam value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaTextCitationParamVariants::BetaCitationCharLocationParamVariant(
                var betaCitationCharLocationParam
            ) => betaCitationCharLocationParam,
            BetaTextCitationParamVariants::BetaCitationPageLocationParamVariant(
                var betaCitationPageLocationParam
            ) => betaCitationPageLocationParam,
            BetaTextCitationParamVariants::BetaCitationContentBlockLocationParamVariant(
                var betaCitationContentBlockLocationParam
            ) => betaCitationContentBlockLocationParam,
            BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParamVariant(
                var betaCitationWebSearchResultLocationParam
            ) => betaCitationWebSearchResultLocationParam,
            BetaTextCitationParamVariants::BetaCitationSearchResultLocationParamVariant(
                var betaCitationSearchResultLocationParam
            ) => betaCitationSearchResultLocationParam,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
