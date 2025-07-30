using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;

[JsonConverter(typeof(VariantConverter<CitationCharLocationVariant, CitationCharLocation>))]
public sealed record class CitationCharLocationVariant(CitationCharLocation Value)
    : Citation,
        IVariant<CitationCharLocationVariant, CitationCharLocation>
{
    public static CitationCharLocationVariant From(CitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<CitationPageLocationVariant, CitationPageLocation>))]
public sealed record class CitationPageLocationVariant(CitationPageLocation Value)
    : Citation,
        IVariant<CitationPageLocationVariant, CitationPageLocation>
{
    public static CitationPageLocationVariant From(CitationPageLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<CitationContentBlockLocationVariant, CitationContentBlockLocation>)
)]
public sealed record class CitationContentBlockLocationVariant(CitationContentBlockLocation Value)
    : Citation,
        IVariant<CitationContentBlockLocationVariant, CitationContentBlockLocation>
{
    public static CitationContentBlockLocationVariant From(CitationContentBlockLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        CitationsWebSearchResultLocationVariant,
        CitationsWebSearchResultLocation
    >)
)]
public sealed record class CitationsWebSearchResultLocationVariant(
    CitationsWebSearchResultLocation Value
) : Citation, IVariant<CitationsWebSearchResultLocationVariant, CitationsWebSearchResultLocation>
{
    public static CitationsWebSearchResultLocationVariant From(
        CitationsWebSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
