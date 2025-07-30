using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(
    typeof(VariantConverter<ContentBlockSourceContentVariant, List<ContentBlockSourceContent>>)
)]
public sealed record class ContentBlockSourceContentVariant(List<ContentBlockSourceContent> Value)
    : Content,
        IVariant<ContentBlockSourceContentVariant, List<ContentBlockSourceContent>>
{
    public static ContentBlockSourceContentVariant From(List<ContentBlockSourceContent> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
