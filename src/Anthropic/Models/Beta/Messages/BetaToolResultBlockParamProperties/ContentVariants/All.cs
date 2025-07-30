using System.Collections.Generic;
using System.Text.Json.Serialization;
using Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentVariants;

[JsonConverter(typeof(VariantConverter<String, string>))]
public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(typeof(VariantConverter<Blocks, List<Block>>))]
public sealed record class Blocks(List<Block> Value) : Content, IVariant<Blocks, List<Block>>
{
    public static Blocks From(List<Block> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
