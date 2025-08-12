using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

public sealed record class BetaCitationCharLocationParamVariant(
    Messages::BetaCitationCharLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<BetaCitationCharLocationParamVariant, Messages::BetaCitationCharLocationParam>
{
    public static BetaCitationCharLocationParamVariant From(
        Messages::BetaCitationCharLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationPageLocationParamVariant(
    Messages::BetaCitationPageLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<BetaCitationPageLocationParamVariant, Messages::BetaCitationPageLocationParam>
{
    public static BetaCitationPageLocationParamVariant From(
        Messages::BetaCitationPageLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCitationContentBlockLocationParamVariant(
    Messages::BetaCitationContentBlockLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationContentBlockLocationParamVariant,
            Messages::BetaCitationContentBlockLocationParam
        >
{
    public static BetaCitationContentBlockLocationParamVariant From(
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

public sealed record class BetaCitationWebSearchResultLocationParamVariant(
    Messages::BetaCitationWebSearchResultLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationWebSearchResultLocationParamVariant,
            Messages::BetaCitationWebSearchResultLocationParam
        >
{
    public static BetaCitationWebSearchResultLocationParamVariant From(
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

public sealed record class BetaCitationSearchResultLocationParamVariant(
    Messages::BetaCitationSearchResultLocationParam Value
)
    : Messages::BetaTextCitationParam,
        IVariant<
            BetaCitationSearchResultLocationParamVariant,
            Messages::BetaCitationSearchResultLocationParam
        >
{
    public static BetaCitationSearchResultLocationParamVariant From(
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
