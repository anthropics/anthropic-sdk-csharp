using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaTextCitationVariants;

public sealed record class BetaCitationCharLocation(Messages::BetaCitationCharLocation Value)
    : Messages::BetaTextCitation,
        IVariant<BetaCitationCharLocation, Messages::BetaCitationCharLocation>
{
    public static BetaCitationCharLocation From(Messages::BetaCitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationPageLocation(Messages::BetaCitationPageLocation Value)
    : Messages::BetaTextCitation,
        IVariant<BetaCitationPageLocation, Messages::BetaCitationPageLocation>
{
    public static BetaCitationPageLocation From(Messages::BetaCitationPageLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationContentBlockLocation(
    Messages::BetaCitationContentBlockLocation Value
)
    : Messages::BetaTextCitation,
        IVariant<BetaCitationContentBlockLocation, Messages::BetaCitationContentBlockLocation>
{
    public static BetaCitationContentBlockLocation From(
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

public sealed record class BetaCitationsWebSearchResultLocation(
    Messages::BetaCitationsWebSearchResultLocation Value
)
    : Messages::BetaTextCitation,
        IVariant<
            BetaCitationsWebSearchResultLocation,
            Messages::BetaCitationsWebSearchResultLocation
        >
{
    public static BetaCitationsWebSearchResultLocation From(
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

public sealed record class BetaCitationSearchResultLocation(
    Messages::BetaCitationSearchResultLocation Value
)
    : Messages::BetaTextCitation,
        IVariant<BetaCitationSearchResultLocation, Messages::BetaCitationSearchResultLocation>
{
    public static BetaCitationSearchResultLocation From(
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
