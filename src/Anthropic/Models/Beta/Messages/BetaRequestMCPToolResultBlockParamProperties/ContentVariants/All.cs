using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaRequestMCPToolResultBlockParamProperties.ContentVariants;

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
    typeof(VariantConverter<BetaMCPToolResultBlockParamContent, List<BetaTextBlockParam>>)
)]
public sealed record class BetaMCPToolResultBlockParamContent(List<BetaTextBlockParam> Value)
    : Content,
        IVariant<BetaMCPToolResultBlockParamContent, List<BetaTextBlockParam>>
{
    public static BetaMCPToolResultBlockParamContent From(List<BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
