using System.Collections.Generic;
using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaContentBlockSourceProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaContentBlockSourceContent(
    List<Messages::BetaContentBlockSourceContent> Value
) : Content, IVariant<BetaContentBlockSourceContent, List<Messages::BetaContentBlockSourceContent>>
{
    public static BetaContentBlockSourceContent From(
        List<Messages::BetaContentBlockSourceContent> value
    )
    {
        return new(value);
    }

    public override void Validate() { }
}
