using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

[JsonConverter(typeof(VariantConverter<BetaCitationCharLocationVariant, BetaCitationCharLocation>))]
public sealed record class BetaCitationCharLocationVariant(BetaCitationCharLocation Value)
    : Citation,
        IVariant<BetaCitationCharLocationVariant, BetaCitationCharLocation>
{
    public static BetaCitationCharLocationVariant From(BetaCitationCharLocation value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaCitationPageLocationVariant, BetaCitationPageLocation>))]
public sealed record class BetaCitationPageLocationVariant(BetaCitationPageLocation Value)
    : Citation,
        IVariant<BetaCitationPageLocationVariant, BetaCitationPageLocation>
{
    public static BetaCitationPageLocationVariant From(BetaCitationPageLocation value)
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
        BetaCitationContentBlockLocationVariant,
        BetaCitationContentBlockLocation
    >)
)]
public sealed record class BetaCitationContentBlockLocationVariant(
    BetaCitationContentBlockLocation Value
) : Citation, IVariant<BetaCitationContentBlockLocationVariant, BetaCitationContentBlockLocation>
{
    public static BetaCitationContentBlockLocationVariant From(
        BetaCitationContentBlockLocation value
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
        BetaCitationsWebSearchResultLocationVariant,
        BetaCitationsWebSearchResultLocation
    >)
)]
public sealed record class BetaCitationsWebSearchResultLocationVariant(
    BetaCitationsWebSearchResultLocation Value
)
    : Citation,
        IVariant<BetaCitationsWebSearchResultLocationVariant, BetaCitationsWebSearchResultLocation>
{
    public static BetaCitationsWebSearchResultLocationVariant From(
        BetaCitationsWebSearchResultLocation value
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
        BetaCitationSearchResultLocationVariant,
        BetaCitationSearchResultLocation
    >)
)]
public sealed record class BetaCitationSearchResultLocationVariant(
    BetaCitationSearchResultLocation Value
) : Citation, IVariant<BetaCitationSearchResultLocationVariant, BetaCitationSearchResultLocation>
{
    public static BetaCitationSearchResultLocationVariant From(
        BetaCitationSearchResultLocation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
