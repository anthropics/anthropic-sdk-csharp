using Anthropic = Anthropic;
using BetaToolUnionVariants = Anthropic.Models.Beta.Messages.BetaToolUnionVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaToolUnion>))]
public abstract record class BetaToolUnion
{
    internal BetaToolUnion() { }

    public static BetaToolUnionVariants::BetaTool Create(BetaTool value) => new(value);

    public static BetaToolUnionVariants::BetaToolBash20241022 Create(BetaToolBash20241022 value) =>
        new(value);

    public static BetaToolUnionVariants::BetaToolBash20250124 Create(BetaToolBash20250124 value) =>
        new(value);

    public static BetaToolUnionVariants::BetaCodeExecutionTool20250522 Create(
        BetaCodeExecutionTool20250522 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaToolComputerUse20241022 Create(
        BetaToolComputerUse20241022 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaToolComputerUse20250124 Create(
        BetaToolComputerUse20250124 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaToolTextEditor20241022 Create(
        BetaToolTextEditor20241022 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaToolTextEditor20250124 Create(
        BetaToolTextEditor20250124 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaToolTextEditor20250429 Create(
        BetaToolTextEditor20250429 value
    ) => new(value);

    public static BetaToolUnionVariants::BetaWebSearchTool20250305 Create(
        BetaWebSearchTool20250305 value
    ) => new(value);

    public abstract void Validate();
}
