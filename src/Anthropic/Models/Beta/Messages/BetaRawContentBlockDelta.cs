using System.Text.Json.Serialization;
using BetaRawContentBlockDeltaVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(UnionConverter<BetaRawContentBlockDelta>))]
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
