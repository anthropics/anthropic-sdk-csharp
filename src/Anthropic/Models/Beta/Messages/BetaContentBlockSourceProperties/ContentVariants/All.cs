using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties.ContentVariants;

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
    typeof(VariantConverter<
        BetaContentBlockSourceContentVariant,
        List<BetaContentBlockSourceContent>
    >)
)]
public sealed record class BetaContentBlockSourceContentVariant(
    List<BetaContentBlockSourceContent> Value
) : Content, IVariant<BetaContentBlockSourceContentVariant, List<BetaContentBlockSourceContent>>
{
    public static BetaContentBlockSourceContentVariant From(
        List<BetaContentBlockSourceContent> value
    )
    {
        return new(value);
    }

    public override void Validate() { }
}
