using System.Collections.Generic;

namespace Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties.SystemVariants;

public sealed record class String(string Value) : SystemModel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaTextBlockParams(List<BetaTextBlockParam> Value)
    : SystemModel,
        IVariant<BetaTextBlockParams, List<BetaTextBlockParam>>
{
    public static BetaTextBlockParams From(List<BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
