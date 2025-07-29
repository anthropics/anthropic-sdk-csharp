using Anthropic = Anthropic;
using RawMessageStreamEventVariants = Anthropic.Models.Messages.RawMessageStreamEventVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<RawMessageStreamEvent>))]
public abstract record class RawMessageStreamEvent
{
    internal RawMessageStreamEvent() { }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStartEvent(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawMessageDeltaEvent(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStopEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStartEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockDeltaEvent(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStopEvent(value);

    public abstract void Validate();
}
