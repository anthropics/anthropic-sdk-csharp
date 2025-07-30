using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.MessageParamProperties.ContentVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<ContentBlockParams, List<ContentBlockParam>>))]
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
