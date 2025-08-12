using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaTextCitationVariants;

public sealed record class BetaCitationCharLocationVariant(Messages::BetaCitationCharLocation Value)
    : Messages::BetaTextCitation,
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
    : Messages::BetaTextCitation,
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
    : Messages::BetaTextCitation,
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
    : Messages::BetaTextCitation,
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
    : Messages::BetaTextCitation,
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
