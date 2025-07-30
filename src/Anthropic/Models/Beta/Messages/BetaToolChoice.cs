using System.Text.Json.Serialization;
using BetaToolChoiceVariants = Anthropic.Models.Beta.Messages.BetaToolChoiceVariants;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// How the model should use the provided tools. The model can use a specific tool,
/// any available tool, decide by itself, or not use tools at all.
/// </summary>
[JsonConverter(typeof(UnionConverter<BetaToolChoice>))]
public abstract record class BetaToolChoice
{
    internal BetaToolChoice() { }

    public static implicit operator BetaToolChoice(BetaToolChoiceAuto value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAutoVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceAny value) =>
        new BetaToolChoiceVariants::BetaToolChoiceAnyVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceTool value) =>
        new BetaToolChoiceVariants::BetaToolChoiceToolVariant(value);

    public static implicit operator BetaToolChoice(BetaToolChoiceNone value) =>
        new BetaToolChoiceVariants::BetaToolChoiceNoneVariant(value);

    public abstract void Validate();
}
