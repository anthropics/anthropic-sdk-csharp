using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.ThinkingConfigParamVariants;

public sealed record class ThinkingConfigEnabled(Messages::ThinkingConfigEnabled Value)
    : Messages::ThinkingConfigParam,
        IVariant<ThinkingConfigEnabled, Messages::ThinkingConfigEnabled>
{
    public static ThinkingConfigEnabled From(Messages::ThinkingConfigEnabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingConfigDisabled(Messages::ThinkingConfigDisabled Value)
    : Messages::ThinkingConfigParam,
        IVariant<ThinkingConfigDisabled, Messages::ThinkingConfigDisabled>
{
    public static ThinkingConfigDisabled From(Messages::ThinkingConfigDisabled value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
