using System.Collections.Generic;
using Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentVariants;

public sealed record class String(string Value) : Content, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Blocks(List<Block> Value) : Content, IVariant<Blocks, List<Block>>
{
    public static Blocks From(List<Block> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
