using System.Collections.Generic;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.ContentBlockSourceProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class ContentBlockSourceContent(
    List<Messages::ContentBlockSourceContent> Value
) : Content, IVariant<ContentBlockSourceContent, List<Messages::ContentBlockSourceContent>>
{
    public static ContentBlockSourceContent From(List<Messages::ContentBlockSourceContent> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
