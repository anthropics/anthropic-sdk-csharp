using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaRawContentBlockDeltaVariants;

public sealed record class BetaTextDelta(Messages::BetaTextDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaTextDelta, Messages::BetaTextDelta>
{
    public static BetaTextDelta From(Messages::BetaTextDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaInputJSONDelta(Messages::BetaInputJSONDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaInputJSONDelta, Messages::BetaInputJSONDelta>
{
    public static BetaInputJSONDelta From(Messages::BetaInputJSONDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationsDelta(Messages::BetaCitationsDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaCitationsDelta, Messages::BetaCitationsDelta>
{
    public static BetaCitationsDelta From(Messages::BetaCitationsDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingDelta(Messages::BetaThinkingDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaThinkingDelta, Messages::BetaThinkingDelta>
{
    public static BetaThinkingDelta From(Messages::BetaThinkingDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaSignatureDelta(Messages::BetaSignatureDelta Value)
    : Messages::BetaRawContentBlockDelta,
        IVariant<BetaSignatureDelta, Messages::BetaSignatureDelta>
{
    public static BetaSignatureDelta From(Messages::BetaSignatureDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
