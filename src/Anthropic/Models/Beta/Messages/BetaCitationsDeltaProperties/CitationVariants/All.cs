using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

public sealed record class BetaCitationCharLocationVariant(Messages::BetaCitationCharLocation Value)
    : Citation,
        IVariant<BetaCitationCharLocationVariant, Messages::BetaCitationCharLocation>
{
    public static BetaCitationCharLocationVariant From(Messages::BetaCitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationPageLocationVariant(Messages::BetaCitationPageLocation Value)
    : Citation,
        IVariant<BetaCitationPageLocationVariant, Messages::BetaCitationPageLocation>
{
    public static BetaCitationPageLocationVariant From(Messages::BetaCitationPageLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationContentBlockLocationVariant(
    Messages::BetaCitationContentBlockLocation Value
)
    : Citation,
        IVariant<
            BetaCitationContentBlockLocationVariant,
            Messages::BetaCitationContentBlockLocation
        >
{
    public static BetaCitationContentBlockLocationVariant From(
        Messages::BetaCitationContentBlockLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationsWebSearchResultLocationVariant(
    Messages::BetaCitationsWebSearchResultLocation Value
)
    : Citation,
        IVariant<
            BetaCitationsWebSearchResultLocationVariant,
            Messages::BetaCitationsWebSearchResultLocation
        >
{
    public static BetaCitationsWebSearchResultLocationVariant From(
        Messages::BetaCitationsWebSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationSearchResultLocationVariant(
    Messages::BetaCitationSearchResultLocation Value
)
    : Citation,
        IVariant<
            BetaCitationSearchResultLocationVariant,
            Messages::BetaCitationSearchResultLocation
        >
{
    public static BetaCitationSearchResultLocationVariant From(
        Messages::BetaCitationSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
