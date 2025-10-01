using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.TextCitationParamVariants;

public sealed record class CitationCharLocationParam(Messages::CitationCharLocationParam Value)
    : Messages::TextCitationParam,
        IVariant<CitationCharLocationParam, Messages::CitationCharLocationParam>
{
    public static CitationCharLocationParam From(Messages::CitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationPageLocationParam(Messages::CitationPageLocationParam Value)
    : Messages::TextCitationParam,
        IVariant<CitationPageLocationParam, Messages::CitationPageLocationParam>
{
    public static CitationPageLocationParam From(Messages::CitationPageLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationContentBlockLocationParam(
    Messages::CitationContentBlockLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<CitationContentBlockLocationParam, Messages::CitationContentBlockLocationParam>
{
    public static CitationContentBlockLocationParam From(
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

public sealed record class CitationWebSearchResultLocationParam(
    Messages::CitationWebSearchResultLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<
            CitationWebSearchResultLocationParam,
            Messages::CitationWebSearchResultLocationParam
        >
{
    public static CitationWebSearchResultLocationParam From(
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

public sealed record class CitationSearchResultLocationParam(
    Messages::CitationSearchResultLocationParam Value
)
    : Messages::TextCitationParam,
        IVariant<CitationSearchResultLocationParam, Messages::CitationSearchResultLocationParam>
{
    public static CitationSearchResultLocationParam From(
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
