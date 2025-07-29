using Anthropic = Anthropic;
using Serialization = System.Text.Json.Serialization;
using ToolChoiceVariants = Anthropic.Models.Messages.ToolChoiceVariants;

namespace Anthropic.Models.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ToolChoice>))]
public abstract record class ToolChoice
{
    internal ToolChoice() { }

    public static implicit operator ToolChoice(ToolChoiceAuto value) =>
        new ToolChoiceVariants::ToolChoiceAuto(value);

    public static implicit operator ToolChoice(ToolChoiceAny value) =>
        new ToolChoiceVariants::ToolChoiceAny(value);

    public static implicit operator ToolChoice(ToolChoiceTool value) =>
        new ToolChoiceVariants::ToolChoiceTool(value);

    public static implicit operator ToolChoice(ToolChoiceNone value) =>
        new ToolChoiceVariants::ToolChoiceNone(value);

    public abstract void Validate();
}
