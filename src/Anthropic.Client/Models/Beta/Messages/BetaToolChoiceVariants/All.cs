using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
public sealed record class BetaToolChoiceAuto(Messages::BetaToolChoiceAuto Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceAuto, Messages::BetaToolChoiceAuto>
{
    public static BetaToolChoiceAuto From(Messages::BetaToolChoiceAuto value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will use any available tools.
/// </summary>
public sealed record class BetaToolChoiceAny(Messages::BetaToolChoiceAny Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceAny, Messages::BetaToolChoiceAny>
{
    public static BetaToolChoiceAny From(Messages::BetaToolChoiceAny value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will use the specified tool with `tool_choice.name`.
/// </summary>
public sealed record class BetaToolChoiceTool(Messages::BetaToolChoiceTool Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceTool, Messages::BetaToolChoiceTool>
{
    public static BetaToolChoiceTool From(Messages::BetaToolChoiceTool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
public sealed record class BetaToolChoiceNone(Messages::BetaToolChoiceNone Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceNone, Messages::BetaToolChoiceNone>
{
    public static BetaToolChoiceNone From(Messages::BetaToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
