using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;

public sealed record class CitationCharLocationVariant(Messages::CitationCharLocation Value)
    : Citation,
        IVariant<CitationCharLocationVariant, Messages::CitationCharLocation>
{
    public static CitationCharLocationVariant From(Messages::CitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationPageLocationVariant(Messages::CitationPageLocation Value)
    : Citation,
        IVariant<CitationPageLocationVariant, Messages::CitationPageLocation>
{
    public static CitationPageLocationVariant From(Messages::CitationPageLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationContentBlockLocationVariant(
    Messages::CitationContentBlockLocation Value
) : Citation, IVariant<CitationContentBlockLocationVariant, Messages::CitationContentBlockLocation>
{
    public static CitationContentBlockLocationVariant From(
        Messages::CitationContentBlockLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationsWebSearchResultLocationVariant(
    Messages::CitationsWebSearchResultLocation Value
)
    : Citation,
        IVariant<
            CitationsWebSearchResultLocationVariant,
            Messages::CitationsWebSearchResultLocation
        >
{
    public static CitationsWebSearchResultLocationVariant From(
        Messages::CitationsWebSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationsSearchResultLocationVariant(
    Messages::CitationsSearchResultLocation Value
)
    : Citation,
        IVariant<CitationsSearchResultLocationVariant, Messages::CitationsSearchResultLocation>
{
    public static CitationsSearchResultLocationVariant From(
        Messages::CitationsSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
