using System.Collections.Generic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.MessageParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class ContentBlockParams(List<Messages::ContentBlockParam> Value)
    : Content,
        IVariant<ContentBlockParams, List<Messages::ContentBlockParam>>
{
    public static ContentBlockParams From(List<Messages::ContentBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
