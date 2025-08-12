using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaMessageParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaContentBlockParams(List<Messages::BetaContentBlockParam> Value)
    : Content,
        IVariant<BetaContentBlockParams, List<Messages::BetaContentBlockParam>>
{
    public static BetaContentBlockParams From(List<Messages::BetaContentBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
