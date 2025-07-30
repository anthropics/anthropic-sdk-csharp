using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ThinkingConfigParamVariants;

[JsonConverter(typeof(VariantConverter<ThinkingConfigEnabledVariant, ThinkingConfigEnabled>))]
public sealed record class ThinkingConfigEnabledVariant(ThinkingConfigEnabled Value)
    : ThinkingConfigParam,
        IVariant<ThinkingConfigEnabledVariant, ThinkingConfigEnabled>
{
    public static ThinkingConfigEnabledVariant From(ThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ThinkingConfigDisabledVariant, ThinkingConfigDisabled>))]
public sealed record class ThinkingConfigDisabledVariant(ThinkingConfigDisabled Value)
    : ThinkingConfigParam,
        IVariant<ThinkingConfigDisabledVariant, ThinkingConfigDisabled>
{
    public static ThinkingConfigDisabledVariant From(ThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
