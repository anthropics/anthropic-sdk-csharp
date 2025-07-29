using Anthropic = Anthropic;
using BetaToolUnionVariants = Anthropic.Models.Beta.Messages.BetaToolUnionVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaToolUnion>))]
public abstract record class BetaToolUnion
{
    internal BetaToolUnion() { }

    public static implicit operator BetaToolUnion(BetaTool value) =>
        new BetaToolUnionVariants::BetaTool(value);

    public static implicit operator BetaToolUnion(BetaToolBash20241022 value) =>
        new BetaToolUnionVariants::BetaToolBash20241022(value);

    public static implicit operator BetaToolUnion(BetaToolBash20250124 value) =>
        new BetaToolUnionVariants::BetaToolBash20250124(value);

    public static implicit operator BetaToolUnion(BetaCodeExecutionTool20250522 value) =>
        new BetaToolUnionVariants::BetaCodeExecutionTool20250522(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20241022 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20241022(value);

    public static implicit operator BetaToolUnion(BetaToolComputerUse20250124 value) =>
        new BetaToolUnionVariants::BetaToolComputerUse20250124(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20241022 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20241022(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250124 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250124(value);

    public static implicit operator BetaToolUnion(BetaToolTextEditor20250429 value) =>
        new BetaToolUnionVariants::BetaToolTextEditor20250429(value);

    public static implicit operator BetaToolUnion(BetaWebSearchTool20250305 value) =>
        new BetaToolUnionVariants::BetaWebSearchTool20250305(value);

    public abstract void Validate();
}
