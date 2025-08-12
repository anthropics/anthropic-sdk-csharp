using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaMCPToolResultBlockContent(List<Messages::BetaTextBlock> Value)
    : Content,
        IVariant<BetaMCPToolResultBlockContent, List<Messages::BetaTextBlock>>
{
    public static BetaMCPToolResultBlockContent From(List<Messages::BetaTextBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
