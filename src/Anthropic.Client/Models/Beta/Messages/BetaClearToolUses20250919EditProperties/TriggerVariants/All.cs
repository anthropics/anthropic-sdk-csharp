using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaClearToolUses20250919EditProperties.TriggerVariants;

public sealed record class BetaInputTokensTrigger(Messages::BetaInputTokensTrigger Value)
    : Trigger,
        IVariant<BetaInputTokensTrigger, Messages::BetaInputTokensTrigger>
{
    public static BetaInputTokensTrigger From(Messages::BetaInputTokensTrigger value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolUsesTrigger(Messages::BetaToolUsesTrigger Value)
    : Trigger,
        IVariant<BetaToolUsesTrigger, Messages::BetaToolUsesTrigger>
{
    public static BetaToolUsesTrigger From(Messages::BetaToolUsesTrigger value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
