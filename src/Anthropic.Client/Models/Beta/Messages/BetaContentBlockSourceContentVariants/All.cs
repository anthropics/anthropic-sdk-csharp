using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaContentBlockSourceContentVariants;

public sealed record class BetaTextBlockParam(Messages::BetaTextBlockParam Value)
    : Messages::BetaContentBlockSourceContent,
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
    : Messages::BetaContentBlockSourceContent,
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
