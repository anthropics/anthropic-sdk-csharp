using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCitationCharLocationParam,
        Messages::BetaCitationCharLocationParam
    >)
)]
public sealed record class BetaCitationCharLocationParam(
    Messages::BetaCitationCharLocationParam Value
)
    : Messages::BetaTextCitationParam,
        Anthropic::IVariant<BetaCitationCharLocationParam, Messages::BetaCitationCharLocationParam>
{
    public static BetaCitationCharLocationParam From(Messages::BetaCitationCharLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCitationPageLocationParam,
        Messages::BetaCitationPageLocationParam
    >)
)]
public sealed record class BetaCitationPageLocationParam(
    Messages::BetaCitationPageLocationParam Value
)
    : Messages::BetaTextCitationParam,
        Anthropic::IVariant<BetaCitationPageLocationParam, Messages::BetaCitationPageLocationParam>
{
    public static BetaCitationPageLocationParam From(Messages::BetaCitationPageLocationParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCitationContentBlockLocationParam,
        Messages::BetaCitationContentBlockLocationParam
    >)
)]
public sealed record class BetaCitationContentBlockLocationParam(
    Messages::BetaCitationContentBlockLocationParam Value
)
    : Messages::BetaTextCitationParam,
        Anthropic::IVariant<
            BetaCitationContentBlockLocationParam,
            Messages::BetaCitationContentBlockLocationParam
        >
{
    public static BetaCitationContentBlockLocationParam From(
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCitationWebSearchResultLocationParam,
        Messages::BetaCitationWebSearchResultLocationParam
    >)
)]
public sealed record class BetaCitationWebSearchResultLocationParam(
    Messages::BetaCitationWebSearchResultLocationParam Value
)
    : Messages::BetaTextCitationParam,
        Anthropic::IVariant<
            BetaCitationWebSearchResultLocationParam,
            Messages::BetaCitationWebSearchResultLocationParam
        >
{
    public static BetaCitationWebSearchResultLocationParam From(
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaSearchResultLocationCitationParam,
        Messages::BetaSearchResultLocationCitationParam
    >)
)]
public sealed record class BetaSearchResultLocationCitationParam(
    Messages::BetaSearchResultLocationCitationParam Value
)
    : Messages::BetaTextCitationParam,
        Anthropic::IVariant<
            BetaSearchResultLocationCitationParam,
            Messages::BetaSearchResultLocationCitationParam
        >
{
    public static BetaSearchResultLocationCitationParam From(
        Messages::BetaSearchResultLocationCitationParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
