using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.SystemVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : System, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<BetaTextBlockParams, List<BetaTextBlockParam>>))]
public sealed record class BetaTextBlockParams(List<BetaTextBlockParam> Value)
    : System,
        IVariant<BetaTextBlockParams, List<BetaTextBlockParam>>
{
    public static BetaTextBlockParams From(List<BetaTextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
