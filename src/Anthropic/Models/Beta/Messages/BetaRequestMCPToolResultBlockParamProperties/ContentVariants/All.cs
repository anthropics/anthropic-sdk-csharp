using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaMCPToolResultBlockParamContent(
    List<Messages::BetaTextBlockParam> Value
) : Content, IVariant<BetaMCPToolResultBlockParamContent, List<Messages::BetaTextBlockParam>>
{
    public static BetaMCPToolResultBlockParamContent From(List<Messages::BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
