using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

public sealed record class BetaRawMessageStartEvent(Messages::BetaRawMessageStartEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageStartEvent, Messages::BetaRawMessageStartEvent>
{
    public static BetaRawMessageStartEvent From(Messages::BetaRawMessageStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawMessageDeltaEvent(Messages::BetaRawMessageDeltaEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageDeltaEvent, Messages::BetaRawMessageDeltaEvent>
{
    public static BetaRawMessageDeltaEvent From(Messages::BetaRawMessageDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawMessageStopEvent(Messages::BetaRawMessageStopEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageStopEvent, Messages::BetaRawMessageStopEvent>
{
    public static BetaRawMessageStopEvent From(Messages::BetaRawMessageStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockStartEvent(
    Messages::BetaRawContentBlockStartEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockStartEvent, Messages::BetaRawContentBlockStartEvent>
{
    public static BetaRawContentBlockStartEvent From(Messages::BetaRawContentBlockStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockDeltaEvent(
    Messages::BetaRawContentBlockDeltaEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockDeltaEvent, Messages::BetaRawContentBlockDeltaEvent>
{
    public static BetaRawContentBlockDeltaEvent From(Messages::BetaRawContentBlockDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockStopEvent(
    Messages::BetaRawContentBlockStopEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockStopEvent, Messages::BetaRawContentBlockStopEvent>
{
    public static BetaRawContentBlockStopEvent From(Messages::BetaRawContentBlockStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
