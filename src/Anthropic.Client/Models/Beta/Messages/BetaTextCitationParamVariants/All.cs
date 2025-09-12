using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaTextCitationParamVariants;

public sealed record class BetaCitationCharLocationParam(
    Messages::BetaCitationCharLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<BetaCitationCharLocationParam, Messages::BetaCitationCharLocationParam>
{
    public static BetaCitationCharLocationParam From(Messages::BetaCitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationPageLocationParam(
    Messages::BetaCitationPageLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<BetaCitationPageLocationParam, Messages::BetaCitationPageLocationParam>
{
    public static BetaCitationPageLocationParam From(Messages::BetaCitationPageLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationContentBlockLocationParam(
    Messages::BetaCitationContentBlockLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationContentBlockLocationParam,
            Messages::BetaCitationContentBlockLocationParam
        >
{
    public static BetaCitationContentBlockLocationParam From(
        Messages::BetaCitationContentBlockLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationWebSearchResultLocationParam(
    Messages::BetaCitationWebSearchResultLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationWebSearchResultLocationParam,
            Messages::BetaCitationWebSearchResultLocationParam
        >
{
    public static BetaCitationWebSearchResultLocationParam From(
        Messages::BetaCitationWebSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationSearchResultLocationParam(
    Messages::BetaCitationSearchResultLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationSearchResultLocationParam,
            Messages::BetaCitationSearchResultLocationParam
        >
{
    public static BetaCitationSearchResultLocationParam From(
        Messages::BetaCitationSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
