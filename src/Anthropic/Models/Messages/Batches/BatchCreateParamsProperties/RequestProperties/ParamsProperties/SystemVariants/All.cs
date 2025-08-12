using System.Collections.Generic;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.SystemVariants;

public sealed record class String(string Value) : System, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class TextBlockParams(List<Messages::TextBlockParam> Value)
    : System,
        IVariant<TextBlockParams, List<Messages::TextBlockParam>>
{
    public static TextBlockParams From(List<Messages::TextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
