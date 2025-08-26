using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.RawMessageStreamEventVariants;

public sealed record class RawMessageStartEvent(Messages::RawMessageStartEvent Value)
    : Messages::RawMessageStreamEvent,
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
    : Messages::RawMessageStreamEvent,
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
    : Messages::RawMessageStreamEvent,
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
    : Messages::RawMessageStreamEvent,
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
    : Messages::RawMessageStreamEvent,
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
    : Messages::RawMessageStreamEvent,
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
