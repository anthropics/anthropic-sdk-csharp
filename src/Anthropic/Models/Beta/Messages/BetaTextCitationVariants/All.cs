using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaTextCitationVariants;

[JsonConverter(typeof(VariantConverter<BetaCitationCharLocationVariant, BetaCitationCharLocation>))]
public sealed record class BetaCitationCharLocationVariant(BetaCitationCharLocation Value)
    : BetaTextCitation,
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
    : BetaTextCitation,
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
)
    : BetaTextCitation,
        IVariant<BetaCitationContentBlockLocationVariant, BetaCitationContentBlockLocation>
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
    : BetaTextCitation,
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
)
    : BetaTextCitation,
        IVariant<BetaCitationSearchResultLocationVariant, BetaCitationSearchResultLocation>
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
