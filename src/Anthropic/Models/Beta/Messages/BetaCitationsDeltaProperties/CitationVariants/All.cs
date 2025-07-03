using Anthropic = Anthropic;
using BetaCitationsDeltaProperties = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCitationCharLocation,
        Messages::BetaCitationCharLocation
    >)
)]
public sealed record class BetaCitationCharLocation(Messages::BetaCitationCharLocation Value)
    : BetaCitationsDeltaProperties::Citation,
        Anthropic::IVariant<BetaCitationCharLocation, Messages::BetaCitationCharLocation>
{
    public static BetaCitationCharLocation From(Messages::BetaCitationCharLocation value)
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
        BetaCitationPageLocation,
        Messages::BetaCitationPageLocation
    >)
)]
public sealed record class BetaCitationPageLocation(Messages::BetaCitationPageLocation Value)
    : BetaCitationsDeltaProperties::Citation,
        Anthropic::IVariant<BetaCitationPageLocation, Messages::BetaCitationPageLocation>
{
    public static BetaCitationPageLocation From(Messages::BetaCitationPageLocation value)
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
        BetaCitationContentBlockLocation,
        Messages::BetaCitationContentBlockLocation
    >)
)]
public sealed record class BetaCitationContentBlockLocation(
    Messages::BetaCitationContentBlockLocation Value
)
    : BetaCitationsDeltaProperties::Citation,
        Anthropic::IVariant<
            BetaCitationContentBlockLocation,
            Messages::BetaCitationContentBlockLocation
        >
{
    public static BetaCitationContentBlockLocation From(
        Messages::BetaCitationContentBlockLocation value
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
        BetaCitationsWebSearchResultLocation,
        Messages::BetaCitationsWebSearchResultLocation
    >)
)]
public sealed record class BetaCitationsWebSearchResultLocation(
    Messages::BetaCitationsWebSearchResultLocation Value
)
    : BetaCitationsDeltaProperties::Citation,
        Anthropic::IVariant<
            BetaCitationsWebSearchResultLocation,
            Messages::BetaCitationsWebSearchResultLocation
        >
{
    public static BetaCitationsWebSearchResultLocation From(
        Messages::BetaCitationsWebSearchResultLocation value
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
        BetaSearchResultLocationCitation,
        Messages::BetaSearchResultLocationCitation
    >)
)]
public sealed record class BetaSearchResultLocationCitation(
    Messages::BetaSearchResultLocationCitation Value
)
    : BetaCitationsDeltaProperties::Citation,
        Anthropic::IVariant<
            BetaSearchResultLocationCitation,
            Messages::BetaSearchResultLocationCitation
        >
{
    public static BetaSearchResultLocationCitation From(
        Messages::BetaSearchResultLocationCitation value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
