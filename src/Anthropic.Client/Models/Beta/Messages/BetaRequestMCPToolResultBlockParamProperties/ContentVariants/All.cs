using System.Collections.Generic;
using Anthropic.Client.Core;

namespace Anthropic.Client.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaMCPToolResultBlockParamContent(List<BetaTextBlockParam> Value)
    : Content,
        IVariant<BetaMCPToolResultBlockParamContent, List<BetaTextBlockParam>>
{
    public static BetaMCPToolResultBlockParamContent From(List<BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
