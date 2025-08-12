using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockSourceContentVariants;

public sealed record class BetaTextBlockParamVariant(Messages::BetaTextBlockParam Value)
    : Messages::BetaContentBlockSourceContent,
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
    : Messages::BetaContentBlockSourceContent,
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
