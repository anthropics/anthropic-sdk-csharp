using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BetaRawContentBlockDeltaVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(BetaRawContentBlockDeltaConverter))]
public abstract record class BetaRawContentBlockDelta
{
    internal BetaRawContentBlockDelta() { }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaTextDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJSONDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaInputJSONDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaCitationsDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaThinkingDeltaVariant(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaSignatureDeltaVariant(value);

    public abstract void Validate();
}

sealed class BetaRawContentBlockDeltaConverter : JsonConverter<BetaRawContentBlockDelta>
{
    public override BetaRawContentBlockDelta? Read(
        ref Utf8JsonReader reader,
        global::System.Type _typeToConvert,
        JsonSerializerOptions options
    )
    {
        List<JsonException> exceptions = [];

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaTextDelta>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaRawContentBlockDeltaVariants::BetaTextDeltaVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaInputJSONDelta>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaRawContentBlockDeltaVariants::BetaInputJSONDeltaVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaCitationsDelta>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaRawContentBlockDeltaVariants::BetaCitationsDeltaVariant(
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
            var deserialized = JsonSerializer.Deserialize<BetaThinkingDelta>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaRawContentBlockDeltaVariants::BetaThinkingDeltaVariant(deserialized);
            }
        }
        catch (JsonException e)
        {
            exceptions.Add(e);
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<BetaSignatureDelta>(ref reader, options);
            if (deserialized != null)
            {
                return new BetaRawContentBlockDeltaVariants::BetaSignatureDeltaVariant(
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
        BetaRawContentBlockDelta value,
        JsonSerializerOptions options
    )
    {
        object variant = value switch
        {
            BetaRawContentBlockDeltaVariants::BetaTextDeltaVariant(var betaTextDelta) =>
                betaTextDelta,
            BetaRawContentBlockDeltaVariants::BetaInputJSONDeltaVariant(var betaInputJSONDelta) =>
                betaInputJSONDelta,
            BetaRawContentBlockDeltaVariants::BetaCitationsDeltaVariant(var betaCitationsDelta) =>
                betaCitationsDelta,
            BetaRawContentBlockDeltaVariants::BetaThinkingDeltaVariant(var betaThinkingDelta) =>
                betaThinkingDelta,
            BetaRawContentBlockDeltaVariants::BetaSignatureDeltaVariant(var betaSignatureDelta) =>
                betaSignatureDelta,
            _ => throw new global::System.ArgumentOutOfRangeException(nameof(value)),
        };
        JsonSerializer.Serialize(writer, variant, options);
    }
}
