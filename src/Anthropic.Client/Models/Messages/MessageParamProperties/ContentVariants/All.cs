using System.Collections.Generic;

namespace Anthropic.Client.Models.Messages.MessageParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class ContentBlockParams(List<ContentBlockParam> Value)
    : Content,
        IVariant<ContentBlockParams, List<ContentBlockParam>>
{
    public static ContentBlockParams From(List<ContentBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
