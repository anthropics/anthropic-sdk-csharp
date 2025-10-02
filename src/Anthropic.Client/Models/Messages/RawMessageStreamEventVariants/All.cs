using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.RawMessageStreamEventVariants;

public sealed record class RawMessageStartEvent(Messages::RawMessageStartEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageStartEvent, Messages::RawMessageStartEvent>
{
    public static RawMessageStartEvent From(Messages::RawMessageStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawMessageDeltaEvent(Messages::RawMessageDeltaEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageDeltaEvent, Messages::RawMessageDeltaEvent>
{
    public static RawMessageDeltaEvent From(Messages::RawMessageDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawMessageStopEvent(Messages::RawMessageStopEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageStopEvent, Messages::RawMessageStopEvent>
{
    public static RawMessageStopEvent From(Messages::RawMessageStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockStartEvent(Messages::RawContentBlockStartEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockStartEvent, Messages::RawContentBlockStartEvent>
{
    public static RawContentBlockStartEvent From(Messages::RawContentBlockStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockDeltaEvent(Messages::RawContentBlockDeltaEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockDeltaEvent, Messages::RawContentBlockDeltaEvent>
{
    public static RawContentBlockDeltaEvent From(Messages::RawContentBlockDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockStopEvent(Messages::RawContentBlockStopEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockStopEvent, Messages::RawContentBlockStopEvent>
{
    public static RawContentBlockStopEvent From(Messages::RawContentBlockStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
