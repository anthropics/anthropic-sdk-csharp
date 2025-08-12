using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaThinkingConfigParamVariants;

public sealed record class BetaThinkingConfigEnabledVariant(
    Messages::BetaThinkingConfigEnabled Value
)
    : Messages::BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigEnabledVariant, Messages::BetaThinkingConfigEnabled>
{
    public static BetaThinkingConfigEnabledVariant From(Messages::BetaThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingConfigDisabledVariant(
    Messages::BetaThinkingConfigDisabled Value
)
    : Messages::BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigDisabledVariant, Messages::BetaThinkingConfigDisabled>
{
    public static BetaThinkingConfigDisabledVariant From(Messages::BetaThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
