using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.ToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
public sealed record class ToolChoiceAuto(Messages::ToolChoiceAuto Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceAuto, Messages::ToolChoiceAuto>
{
    public static ToolChoiceAuto From(Messages::ToolChoiceAuto value)
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
public sealed record class ToolChoiceAny(Messages::ToolChoiceAny Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceAny, Messages::ToolChoiceAny>
{
    public static ToolChoiceAny From(Messages::ToolChoiceAny value)
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
public sealed record class ToolChoiceTool(Messages::ToolChoiceTool Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceTool, Messages::ToolChoiceTool>
{
    public static ToolChoiceTool From(Messages::ToolChoiceTool value)
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
public sealed record class ToolChoiceNone(Messages::ToolChoiceNone Value)
    : Messages::ToolChoice,
        IVariant<ToolChoiceNone, Messages::ToolChoiceNone>
{
    public static ToolChoiceNone From(Messages::ToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
