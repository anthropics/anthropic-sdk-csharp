using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.MessageCountTokensParamsProperties.SystemVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : System, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<TextBlockParams, List<TextBlockParam>>))]
public sealed record class TextBlockParams(List<TextBlockParam> Value)
    : System,
        IVariant<TextBlockParams, List<TextBlockParam>>
{
    public static TextBlockParams From(List<TextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
