using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

public sealed record class BetaTextDeltaVariant(Messages::BetaTextDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaTextDeltaVariant, Messages::BetaTextDelta>
{
    public static BetaTextDeltaVariant From(Messages::BetaTextDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaInputJSONDeltaVariant(Messages::BetaInputJSONDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaInputJSONDeltaVariant, Messages::BetaInputJSONDelta>
{
    public static BetaInputJSONDeltaVariant From(Messages::BetaInputJSONDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationsDeltaVariant(Messages::BetaCitationsDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaCitationsDeltaVariant, Messages::BetaCitationsDelta>
{
    public static BetaCitationsDeltaVariant From(Messages::BetaCitationsDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingDeltaVariant(Messages::BetaThinkingDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaThinkingDeltaVariant, Messages::BetaThinkingDelta>
{
    public static BetaThinkingDeltaVariant From(Messages::BetaThinkingDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaSignatureDeltaVariant(Messages::BetaSignatureDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaSignatureDeltaVariant, Messages::BetaSignatureDelta>
{
    public static BetaSignatureDeltaVariant From(Messages::BetaSignatureDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
