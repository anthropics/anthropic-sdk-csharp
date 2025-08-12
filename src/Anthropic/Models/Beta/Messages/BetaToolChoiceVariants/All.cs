using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
public sealed record class BetaToolChoiceAutoVariant(Messages::BetaToolChoiceAuto Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceAutoVariant, Messages::BetaToolChoiceAuto>
{
    public static BetaToolChoiceAutoVariant From(Messages::BetaToolChoiceAuto value)
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
public sealed record class BetaToolChoiceAnyVariant(Messages::BetaToolChoiceAny Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceAnyVariant, Messages::BetaToolChoiceAny>
{
    public static BetaToolChoiceAnyVariant From(Messages::BetaToolChoiceAny value)
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
public sealed record class BetaToolChoiceToolVariant(Messages::BetaToolChoiceTool Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceToolVariant, Messages::BetaToolChoiceTool>
{
    public static BetaToolChoiceToolVariant From(Messages::BetaToolChoiceTool value)
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
public sealed record class BetaToolChoiceNoneVariant(Messages::BetaToolChoiceNone Value)
    : Messages::BetaToolChoice,
        IVariant<BetaToolChoiceNoneVariant, Messages::BetaToolChoiceNone>
{
    public static BetaToolChoiceNoneVariant From(Messages::BetaToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
