using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaThinkingConfigParamVariants;

[JsonConverter(
    typeof(VariantConverter<BetaThinkingConfigEnabledVariant, BetaThinkingConfigEnabled>)
)]
public sealed record class BetaThinkingConfigEnabledVariant(BetaThinkingConfigEnabled Value)
    : BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigEnabledVariant, BetaThinkingConfigEnabled>
{
    public static BetaThinkingConfigEnabledVariant From(BetaThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaThinkingConfigDisabledVariant, BetaThinkingConfigDisabled>)
)]
public sealed record class BetaThinkingConfigDisabledVariant(BetaThinkingConfigDisabled Value)
    : BetaThinkingConfigParam,
        IVariant<BetaThinkingConfigDisabledVariant, BetaThinkingConfigDisabled>
{
    public static BetaThinkingConfigDisabledVariant From(BetaThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
