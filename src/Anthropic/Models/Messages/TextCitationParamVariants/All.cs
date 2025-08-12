using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.TextCitationParamVariants;

public sealed record class CitationCharLocationParamVariant(
    Messages::CitationCharLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<CitationCharLocationParamVariant, Messages::CitationCharLocationParam>
{
    public static CitationCharLocationParamVariant From(Messages::CitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationPageLocationParamVariant(
    Messages::CitationPageLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<CitationPageLocationParamVariant, Messages::CitationPageLocationParam>
{
    public static CitationPageLocationParamVariant From(Messages::CitationPageLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationContentBlockLocationParamVariant(
    Messages::CitationContentBlockLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<
            CitationContentBlockLocationParamVariant,
            Messages::CitationContentBlockLocationParam
        >
{
    public static CitationContentBlockLocationParamVariant From(
        Messages::CitationContentBlockLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationWebSearchResultLocationParamVariant(
    Messages::CitationWebSearchResultLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<
            CitationWebSearchResultLocationParamVariant,
            Messages::CitationWebSearchResultLocationParam
        >
{
    public static CitationWebSearchResultLocationParamVariant From(
        Messages::CitationWebSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationSearchResultLocationParamVariant(
    Messages::CitationSearchResultLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<
            CitationSearchResultLocationParamVariant,
            Messages::CitationSearchResultLocationParam
        >
{
    public static CitationSearchResultLocationParamVariant From(
        Messages::CitationSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
