using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ThinkingConfigParamVariants;

public sealed record class ThinkingConfigEnabledVariant(Messages::ThinkingConfigEnabled Value)
    : Messages::ThinkingConfigParam,
        IVariant<ThinkingConfigEnabledVariant, Messages::ThinkingConfigEnabled>
{
    public static ThinkingConfigEnabledVariant From(Messages::ThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingConfigDisabledVariant(Messages::ThinkingConfigDisabled Value)
    : Messages::ThinkingConfigParam,
        IVariant<ThinkingConfigDisabledVariant, Messages::ThinkingConfigDisabled>
{
    public static ThinkingConfigDisabledVariant From(Messages::ThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
