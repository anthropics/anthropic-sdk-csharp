using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties.ContentVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<BetaMCPToolResultBlockContent, List<BetaTextBlock>>))]
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
