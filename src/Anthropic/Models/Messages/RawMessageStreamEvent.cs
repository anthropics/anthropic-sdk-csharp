using System.Text.Json.Serialization;
using RawMessageStreamEventVariants = Anthropic.Models.Messages.RawMessageStreamEventVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<RawMessageStreamEvent>))]
public abstract record class RawMessageStreamEvent
{
    internal RawMessageStreamEvent() { }

    public static implicit operator RawMessageStreamEvent(RawMessageStartEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawMessageDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawMessageStopEvent value) =>
        new RawMessageStreamEventVariants::RawMessageStopEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStartEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStartEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockDeltaEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockDeltaEventVariant(value);

    public static implicit operator RawMessageStreamEvent(RawContentBlockStopEvent value) =>
        new RawMessageStreamEventVariants::RawContentBlockStopEventVariant(value);

    public abstract void Validate();
}
