using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.RawMessageStreamEventVariants;

public sealed record class RawMessageStartEventVariant(Messages::RawMessageStartEvent Value)
    : Messages::RawMessageStreamEvent,
        IVariant<RawMessageStartEventVariant, Messages::RawMessageStartEvent>
{
    public static RawMessageStartEventVariant From(Messages::RawMessageStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawMessageDeltaEventVariant(Messages::RawMessageDeltaEvent Value)
    : Messages::RawMessageStreamEvent,
        IVariant<RawMessageDeltaEventVariant, Messages::RawMessageDeltaEvent>
{
    public static RawMessageDeltaEventVariant From(Messages::RawMessageDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawMessageStopEventVariant(Messages::RawMessageStopEvent Value)
    : Messages::RawMessageStreamEvent,
        IVariant<RawMessageStopEventVariant, Messages::RawMessageStopEvent>
{
    public static RawMessageStopEventVariant From(Messages::RawMessageStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockStartEventVariant(
    Messages::RawContentBlockStartEvent Value
)
    : Messages::RawMessageStreamEvent,
        IVariant<RawContentBlockStartEventVariant, Messages::RawContentBlockStartEvent>
{
    public static RawContentBlockStartEventVariant From(Messages::RawContentBlockStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockDeltaEventVariant(
    Messages::RawContentBlockDeltaEvent Value
)
    : Messages::RawMessageStreamEvent,
        IVariant<RawContentBlockDeltaEventVariant, Messages::RawContentBlockDeltaEvent>
{
    public static RawContentBlockDeltaEventVariant From(Messages::RawContentBlockDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RawContentBlockStopEventVariant(Messages::RawContentBlockStopEvent Value)
    : Messages::RawMessageStreamEvent,
        IVariant<RawContentBlockStopEventVariant, Messages::RawContentBlockStopEvent>
{
    public static RawContentBlockStopEventVariant From(Messages::RawContentBlockStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
