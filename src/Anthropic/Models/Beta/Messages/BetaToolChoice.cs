using Anthropic = Anthropic;
using BetaToolChoiceVariants = Anthropic.Models.Beta.Messages.BetaToolChoiceVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaToolChoice>))]
public abstract record class BetaToolChoice
{
    internal BetaToolChoice() { }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAuto(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAny(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) =>
        new BetaToolChoiceVariants::BetaToolChoiceTool(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) =>
        new BetaToolChoiceVariants::BetaToolChoiceNone(value);

    public abstract void Validate();
}
