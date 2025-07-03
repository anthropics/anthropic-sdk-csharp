using Anthropic = Anthropic;
using ContentProperties = Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaTextBlockParam, Messages::BetaTextBlockParam>)
)]
public sealed record class BetaTextBlockParam(Messages::BetaTextBlockParam Value)
    : ContentProperties::Block,
        Anthropic::IVariant<BetaTextBlockParam, Messages::BetaTextBlockParam>
{
    public static BetaTextBlockParam From(Messages::BetaTextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaImageBlockParam, Messages::BetaImageBlockParam>)
)]
public sealed record class BetaImageBlockParam(Messages::BetaImageBlockParam Value)
    : ContentProperties::Block,
        Anthropic::IVariant<BetaImageBlockParam, Messages::BetaImageBlockParam>
{
    public static BetaImageBlockParam From(Messages::BetaImageBlockParam value)
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
        BetaSearchResultBlockParam,
        Messages::BetaSearchResultBlockParam
    >)
)]
public sealed record class BetaSearchResultBlockParam(Messages::BetaSearchResultBlockParam Value)
    : ContentProperties::Block,
        Anthropic::IVariant<BetaSearchResultBlockParam, Messages::BetaSearchResultBlockParam>
{
    public static BetaSearchResultBlockParam From(Messages::BetaSearchResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
