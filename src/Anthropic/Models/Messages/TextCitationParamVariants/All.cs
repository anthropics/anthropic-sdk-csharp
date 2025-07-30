using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.TextCitationParamVariants;

[JsonConverter(
    typeof(VariantConverter<CitationCharLocationParamVariant, CitationCharLocationParam>)
)]
public sealed record class CitationCharLocationParamVariant(CitationCharLocationParam Value)
    : TextCitationParam,
        IVariant<CitationCharLocationParamVariant, CitationCharLocationParam>
{
    public static CitationCharLocationParamVariant From(CitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<CitationPageLocationParamVariant, CitationPageLocationParam>)
)]
public sealed record class CitationPageLocationParamVariant(CitationPageLocationParam Value)
    : TextCitationParam,
        IVariant<CitationPageLocationParamVariant, CitationPageLocationParam>
{
    public static CitationPageLocationParamVariant From(CitationPageLocationParam value)
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
        CitationContentBlockLocationParamVariant,
        CitationContentBlockLocationParam
    >)
)]
public sealed record class CitationContentBlockLocationParamVariant(
    CitationContentBlockLocationParam Value
)
    : TextCitationParam,
        IVariant<CitationContentBlockLocationParamVariant, CitationContentBlockLocationParam>
{
    public static CitationContentBlockLocationParamVariant From(
        CitationContentBlockLocationParam value
    )
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
        CitationWebSearchResultLocationParamVariant,
        CitationWebSearchResultLocationParam
    >)
)]
public sealed record class CitationWebSearchResultLocationParamVariant(
    CitationWebSearchResultLocationParam Value
)
    : TextCitationParam,
        IVariant<CitationWebSearchResultLocationParamVariant, CitationWebSearchResultLocationParam>
{
    public static CitationWebSearchResultLocationParamVariant From(
        CitationWebSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
