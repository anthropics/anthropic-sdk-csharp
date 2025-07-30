using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

[JsonConverter(
    typeof(VariantConverter<BetaCitationCharLocationParamVariant, BetaCitationCharLocationParam>)
)]
public sealed record class BetaCitationCharLocationParamVariant(BetaCitationCharLocationParam Value)
    : BetaTextCitationParam,
        IVariant<BetaCitationCharLocationParamVariant, BetaCitationCharLocationParam>
{
    public static BetaCitationCharLocationParamVariant From(BetaCitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaCitationPageLocationParamVariant, BetaCitationPageLocationParam>)
)]
public sealed record class BetaCitationPageLocationParamVariant(BetaCitationPageLocationParam Value)
    : BetaTextCitationParam,
        IVariant<BetaCitationPageLocationParamVariant, BetaCitationPageLocationParam>
{
    public static BetaCitationPageLocationParamVariant From(BetaCitationPageLocationParam value)
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
        BetaCitationContentBlockLocationParamVariant,
        BetaCitationContentBlockLocationParam
    >)
)]
public sealed record class BetaCitationContentBlockLocationParamVariant(
    BetaCitationContentBlockLocationParam Value
)
    : BetaTextCitationParam,
        IVariant<
            BetaCitationContentBlockLocationParamVariant,
            BetaCitationContentBlockLocationParam
        >
{
    public static BetaCitationContentBlockLocationParamVariant From(
        BetaCitationContentBlockLocationParam value
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
        BetaCitationWebSearchResultLocationParamVariant,
        BetaCitationWebSearchResultLocationParam
    >)
)]
public sealed record class BetaCitationWebSearchResultLocationParamVariant(
    BetaCitationWebSearchResultLocationParam Value
)
    : BetaTextCitationParam,
        IVariant<
            BetaCitationWebSearchResultLocationParamVariant,
            BetaCitationWebSearchResultLocationParam
        >
{
    public static BetaCitationWebSearchResultLocationParamVariant From(
        BetaCitationWebSearchResultLocationParam value
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
        BetaCitationSearchResultLocationParamVariant,
        BetaCitationSearchResultLocationParam
    >)
)]
public sealed record class BetaCitationSearchResultLocationParamVariant(
    BetaCitationSearchResultLocationParam Value
)
    : BetaTextCitationParam,
        IVariant<
            BetaCitationSearchResultLocationParamVariant,
            BetaCitationSearchResultLocationParam
        >
{
    public static BetaCitationSearchResultLocationParamVariant From(
        BetaCitationSearchResultLocationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
