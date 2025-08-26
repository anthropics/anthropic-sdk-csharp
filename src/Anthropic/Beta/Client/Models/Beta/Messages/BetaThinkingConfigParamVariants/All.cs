using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaThinkingConfigParamVariants;

public sealed record class BetaThinkingConfigEnabled(Messages::BetaThinkingConfigEnabled Value)
    : Messages::BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigEnabled, Messages::BetaThinkingConfigEnabled>
{
    public static BetaThinkingConfigEnabled From(Messages::BetaThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingConfigDisabled(Messages::BetaThinkingConfigDisabled Value)
    : Messages::BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigDisabled, Messages::BetaThinkingConfigDisabled>
{
    public static BetaThinkingConfigDisabled From(Messages::BetaThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
