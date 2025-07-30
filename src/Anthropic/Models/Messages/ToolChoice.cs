using System.Text.Json.Serialization;
using ToolChoiceVariants = Anthropic.Models.Messages.ToolChoiceVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(UnionConverter<ToolChoice>))]
public abstract record class ToolChoice
{
    internal ToolChoice() { }

    public static implicit operator ToolChoice(ToolChoiceAuto value) =>
        new ToolChoiceVariants::ToolChoiceAutoVariant(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) =>
        new ToolChoiceVariants::ToolChoiceAnyVariant(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) =>
        new ToolChoiceVariants::ToolChoiceToolVariant(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) =>
        new ToolChoiceVariants::ToolChoiceNoneVariant(value);

    public abstract void Validate();
}
