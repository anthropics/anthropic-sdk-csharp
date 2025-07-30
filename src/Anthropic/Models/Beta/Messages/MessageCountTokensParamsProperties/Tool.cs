using System.Text.Json.Serialization;
using ToolVariants = Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;

[JsonConverter(typeof(UnionConverter<Tool>))]
public abstract record class Tool
{
    internal Tool() { }

    public static implicit operator Tool(BetaTool value) =>
        new ToolVariants::BetaToolVariant(value);

    public static implicit operator Tool(BetaToolBash20241022 value) =>
        new ToolVariants::BetaToolBash20241022Variant(value);

    public static implicit operator Tool(BetaToolBash20250124 value) =>
        new ToolVariants::BetaToolBash20250124Variant(value);

    public static implicit operator Tool(BetaCodeExecutionTool20250522 value) =>
        new ToolVariants::BetaCodeExecutionTool20250522Variant(value);

    public static implicit operator Tool(BetaToolComputerUse20241022 value) =>
        new ToolVariants::BetaToolComputerUse20241022Variant(value);

    public static implicit operator Tool(BetaToolComputerUse20250124 value) =>
        new ToolVariants::BetaToolComputerUse20250124Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20241022 value) =>
        new ToolVariants::BetaToolTextEditor20241022Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250124 value) =>
        new ToolVariants::BetaToolTextEditor20250124Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250429 value) =>
        new ToolVariants::BetaToolTextEditor20250429Variant(value);

    public static implicit operator Tool(BetaToolTextEditor20250728 value) =>
        new ToolVariants::BetaToolTextEditor20250728Variant(value);

    public static implicit operator Tool(BetaWebSearchTool20250305 value) =>
        new ToolVariants::BetaWebSearchTool20250305Variant(value);

    public abstract void Validate();
}
