using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.SystemVariants;

public sealed record class String(string Value) : System, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaTextBlockParams(List<Messages::BetaTextBlockParam> Value)
    : System,
        IVariant<BetaTextBlockParams, List<Messages::BetaTextBlockParam>>
{
    public static BetaTextBlockParams From(List<Messages::BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
