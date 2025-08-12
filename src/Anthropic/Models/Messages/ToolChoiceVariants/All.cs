using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
public sealed record class ToolChoiceAutoVariant(Messages::ToolChoiceAuto Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceAutoVariant, Messages::ToolChoiceAuto>
{
    public static ToolChoiceAutoVariant From(Messages::ToolChoiceAuto value)
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
public sealed record class ToolChoiceAnyVariant(Messages::ToolChoiceAny Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceAnyVariant, Messages::ToolChoiceAny>
{
    public static ToolChoiceAnyVariant From(Messages::ToolChoiceAny value)
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
public sealed record class ToolChoiceToolVariant(Messages::ToolChoiceTool Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceToolVariant, Messages::ToolChoiceTool>
{
    public static ToolChoiceToolVariant From(Messages::ToolChoiceTool value)
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
public sealed record class ToolChoiceNoneVariant(Messages::ToolChoiceNone Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceNoneVariant, Messages::ToolChoiceNone>
{
    public static ToolChoiceNoneVariant From(Messages::ToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
