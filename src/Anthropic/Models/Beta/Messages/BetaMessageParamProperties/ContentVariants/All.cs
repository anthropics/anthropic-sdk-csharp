using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaMessageParamProperties.ContentVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<BetaContentBlockParams, List<BetaContentBlockParam>>))]
public sealed record class BetaContentBlockParams(List<BetaContentBlockParam> Value)
    : Content,
        IVariant<BetaContentBlockParams, List<BetaContentBlockParam>>
{
    public static BetaContentBlockParams From(List<BetaContentBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
