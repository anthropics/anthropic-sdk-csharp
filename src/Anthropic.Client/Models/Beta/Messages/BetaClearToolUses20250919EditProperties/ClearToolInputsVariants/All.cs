using System.Collections.Generic;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties.ClearToolInputsVariants;

public sealed record class Bool(bool Value) : ClearToolInputs, IVariant<Bool, bool>
{
    public static Bool From(bool value)
    {
        return new(value);
    }

    public override void Validate() { }
}

public sealed record class Strings(List<string> Value)
    : ClearToolInputs,
        IVariant<Strings, List<string>>
{
    public static Strings From(List<string> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
