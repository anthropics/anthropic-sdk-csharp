using System.Collections.Generic;

namespace Anthropic.Beta.Client.Models.Messages.Batches.BatchCreateParamsProperties.RequestProperties.ParamsProperties.SystemVariants;

public sealed record class String(string Value) : SystemModel, IVariant<String, string>
{
    public static String From(string value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class TextBlockParams(List<TextBlockParam> Value)
    : SystemModel,
        IVariant<TextBlockParams, List<TextBlockParam>>
{
    public static TextBlockParams From(List<TextBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
