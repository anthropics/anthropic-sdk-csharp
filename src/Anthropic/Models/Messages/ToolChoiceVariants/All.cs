using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ToolChoiceVariants;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[JsonConverter(typeof(VariantConverter<ToolChoiceAutoVariant, ToolChoiceAuto>))]
public sealed record class ToolChoiceAutoVariant(ToolChoiceAuto Value)
    : ToolChoice,
        IVariant<ToolChoiceAutoVariant, ToolChoiceAuto>
{
    public static ToolChoiceAutoVariant From(ToolChoiceAuto value)
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
[JsonConverter(typeof(VariantConverter<ToolChoiceAnyVariant, ToolChoiceAny>))]
public sealed record class ToolChoiceAnyVariant(ToolChoiceAny Value)
    : ToolChoice,
        IVariant<ToolChoiceAnyVariant, ToolChoiceAny>
{
    public static ToolChoiceAnyVariant From(ToolChoiceAny value)
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
[JsonConverter(typeof(VariantConverter<ToolChoiceToolVariant, ToolChoiceTool>))]
public sealed record class ToolChoiceToolVariant(ToolChoiceTool Value)
    : ToolChoice,
        IVariant<ToolChoiceToolVariant, ToolChoiceTool>
{
    public static ToolChoiceToolVariant From(ToolChoiceTool value)
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
[JsonConverter(typeof(VariantConverter<ToolChoiceNoneVariant, ToolChoiceNone>))]
public sealed record class ToolChoiceNoneVariant(ToolChoiceNone Value)
    : ToolChoice,
        IVariant<ToolChoiceNoneVariant, ToolChoiceNone>
{
    public static ToolChoiceNoneVariant From(ToolChoiceNone value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
