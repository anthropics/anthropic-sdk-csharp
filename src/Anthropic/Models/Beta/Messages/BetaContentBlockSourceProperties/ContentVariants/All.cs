using System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class BetaContentBlockSourceContentVariant(
    List<Messages::BetaContentBlockSourceContent> Value
)
    : Content,
        IVariant<
            BetaContentBlockSourceContentVariant,
            List<Messages::BetaContentBlockSourceContent>
        >
{
    public static BetaContentBlockSourceContentVariant From(
        List<Messages::BetaContentBlockSourceContent> value
    )
    {
        return new(value);
    }

    public override void Validate() { }
}
