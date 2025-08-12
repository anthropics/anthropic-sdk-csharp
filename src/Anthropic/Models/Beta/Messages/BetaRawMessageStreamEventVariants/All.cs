using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRawMessageStreamEventVariants;

public sealed record class BetaRawMessageStartEventVariant(Messages::BetaRawMessageStartEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageStartEventVariant, Messages::BetaRawMessageStartEvent>
{
    public static BetaRawMessageStartEventVariant From(Messages::BetaRawMessageStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawMessageDeltaEventVariant(Messages::BetaRawMessageDeltaEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageDeltaEventVariant, Messages::BetaRawMessageDeltaEvent>
{
    public static BetaRawMessageDeltaEventVariant From(Messages::BetaRawMessageDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawMessageStopEventVariant(Messages::BetaRawMessageStopEvent Value)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawMessageStopEventVariant, Messages::BetaRawMessageStopEvent>
{
    public static BetaRawMessageStopEventVariant From(Messages::BetaRawMessageStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockStartEventVariant(
    Messages::BetaRawContentBlockStartEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockStartEventVariant, Messages::BetaRawContentBlockStartEvent>
{
    public static BetaRawContentBlockStartEventVariant From(
        Messages::BetaRawContentBlockStartEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockDeltaEventVariant(
    Messages::BetaRawContentBlockDeltaEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockDeltaEventVariant, Messages::BetaRawContentBlockDeltaEvent>
{
    public static BetaRawContentBlockDeltaEventVariant From(
        Messages::BetaRawContentBlockDeltaEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRawContentBlockStopEventVariant(
    Messages::BetaRawContentBlockStopEvent Value
)
    : Messages::BetaRawMessageStreamEvent,
        IVariant<BetaRawContentBlockStopEventVariant, Messages::BetaRawContentBlockStopEvent>
{
    public static BetaRawContentBlockStopEventVariant From(
        Messages::BetaRawContentBlockStopEvent value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
