using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

public sealed record class BetaTextBlockParamVariant(Messages::BetaTextBlockParam Value)
    : Block,
        IVariant<BetaTextBlockParamVariant, Messages::BetaTextBlockParam>
{
    public static BetaTextBlockParamVariant From(Messages::BetaTextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaImageBlockParamVariant(Messages::BetaImageBlockParam Value)
    : Block,
        IVariant<BetaImageBlockParamVariant, Messages::BetaImageBlockParam>
{
    public static BetaImageBlockParamVariant From(Messages::BetaImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaSearchResultBlockParamVariant(
    Messages::BetaSearchResultBlockParam Value
) : Block, IVariant<BetaSearchResultBlockParamVariant, Messages::BetaSearchResultBlockParam>
{
    public static BetaSearchResultBlockParamVariant From(Messages::BetaSearchResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
