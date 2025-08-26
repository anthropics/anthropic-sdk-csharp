using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

public sealed record class BetaTextBlockParam(Messages::BetaTextBlockParam Value)
    : Block,
        IVariant<BetaTextBlockParam, Messages::BetaTextBlockParam>
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

public sealed record class BetaImageBlockParam(Messages::BetaImageBlockParam Value)
    : Block,
        IVariant<BetaImageBlockParam, Messages::BetaImageBlockParam>
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

public sealed record class BetaSearchResultBlockParam(Messages::BetaSearchResultBlockParam Value)
    : Block,
        IVariant<BetaSearchResultBlockParam, Messages::BetaSearchResultBlockParam>
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
