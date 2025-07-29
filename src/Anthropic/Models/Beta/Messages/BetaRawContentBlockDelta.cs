using Anthropic = Anthropic;
using BetaRawContentBlockDeltaVariants = Anthropic.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaRawContentBlockDelta>))]
public abstract record class BetaRawContentBlockDelta
{
    internal BetaRawContentBlockDelta() { }

    public static implicit operator BetaRawContentBlockDelta(BetaTextDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaTextDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaInputJSONDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaInputJSONDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaCitationsDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaCitationsDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaThinkingDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaThinkingDelta(value);

    public static implicit operator BetaRawContentBlockDelta(BetaSignatureDelta value) =>
        new BetaRawContentBlockDeltaVariants::BetaSignatureDelta(value);

    public abstract void Validate();
}
