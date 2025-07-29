using Anthropic = Anthropic;
using BetaRawMessageStreamEventVariants = Anthropic.Models.Beta.Messages.BetaRawMessageStreamEventVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaRawMessageStreamEvent>))]
public abstract record class BetaRawMessageStreamEvent
{
    internal BetaRawMessageStreamEvent() { }

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStartEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStartEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageDeltaEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageDeltaEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawMessageStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawMessageStopEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockStartEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockStartEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(
        BetaRawContentBlockDeltaEvent value
    ) => new BetaRawMessageStreamEventVariants::BetaRawContentBlockDeltaEvent(value);

    public static implicit operator BetaRawMessageStreamEvent(BetaRawContentBlockStopEvent value) =>
        new BetaRawMessageStreamEventVariants::BetaRawContentBlockStopEvent(value);

    public abstract void Validate();
}
