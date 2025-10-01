using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

public sealed record class BetaCitationCharLocation(Messages::BetaCitationCharLocation Value)
    : Citation,
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
    : Citation,
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
) : Citation, IVariant<BetaCitationContentBlockLocation, Messages::BetaCitationContentBlockLocation>
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
    : Citation,
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
) : Citation, IVariant<BetaCitationSearchResultLocation, Messages::BetaCitationSearchResultLocation>
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
