using System.Collections.Generic;
using Anthropic.Client.Core;

namespace Anthropic.Client.Models.Beta.Messages.BetaMCPToolResultBlockProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaMCPToolResultBlockContent(List<BetaTextBlock> Value)
    : Content,
        IVariant<BetaMCPToolResultBlockContent, List<BetaTextBlock>>
{
    public static BetaMCPToolResultBlockContent From(List<BetaTextBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
