using System.Collections.Generic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class ContentBlockSourceContentVariant(
    List<Messages::ContentBlockSourceContent> Value
) : Content, IVariant<ContentBlockSourceContentVariant, List<Messages::ContentBlockSourceContent>>
{
    public static ContentBlockSourceContentVariant From(
        List<Messages::ContentBlockSourceContent> value
    )
    {
        return new(value);
    }

    public override void Validate() { }
}
