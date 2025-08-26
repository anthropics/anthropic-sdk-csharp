using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.CitationsDeltaProperties.CitationVariants;

public sealed record class CitationCharLocation(Messages::CitationCharLocation Value)
    : Citation,
        IVariant<CitationCharLocation, Messages::CitationCharLocation>
{
    public static CitationCharLocation From(Messages::CitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationPageLocation(Messages::CitationPageLocation Value)
    : Citation,
        IVariant<CitationPageLocation, Messages::CitationPageLocation>
{
    public static CitationPageLocation From(Messages::CitationPageLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationContentBlockLocation(
    Messages::CitationContentBlockLocation Value
) : Citation, IVariant<CitationContentBlockLocation, Messages::CitationContentBlockLocation>
{
    public static CitationContentBlockLocation From(Messages::CitationContentBlockLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationsWebSearchResultLocation(
    Messages::CitationsWebSearchResultLocation Value
) : Citation, IVariant<CitationsWebSearchResultLocation, Messages::CitationsWebSearchResultLocation>
{
    public static CitationsWebSearchResultLocation From(
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

public sealed record class CitationsSearchResultLocation(
    Messages::CitationsSearchResultLocation Value
) : Citation, IVariant<CitationsSearchResultLocation, Messages::CitationsSearchResultLocation>
{
    public static CitationsSearchResultLocation From(Messages::CitationsSearchResultLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
