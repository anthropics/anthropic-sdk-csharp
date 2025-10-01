using System.Collections.Generic;
using Anthropic.Client.Core;

namespace Anthropic.Client.Models.Beta.Messages.BetaMessageParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaContentBlockParams(List<BetaContentBlockParam> Value)
    : Content,
        IVariant<BetaContentBlockParams, List<BetaContentBlockParam>>
{
    public static BetaContentBlockParams From(List<BetaContentBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
