using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using ToolVariants = Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Tool>))]
public abstract record class Tool
{
    internal Tool() { }

    public static implicit operator Tool(Messages::BetaTool value) =>
        new ToolVariants::BetaTool(value);

    public static implicit operator Tool(Messages::BetaToolBash20241022 value) =>
        new ToolVariants::BetaToolBash20241022(value);

    public static implicit operator Tool(Messages::BetaToolBash20250124 value) =>
        new ToolVariants::BetaToolBash20250124(value);

    public static implicit operator Tool(Messages::BetaCodeExecutionTool20250522 value) =>
        new ToolVariants::BetaCodeExecutionTool20250522(value);

    public static implicit operator Tool(Messages::BetaToolComputerUse20241022 value) =>
        new ToolVariants::BetaToolComputerUse20241022(value);

    public static implicit operator Tool(Messages::BetaToolComputerUse20250124 value) =>
        new ToolVariants::BetaToolComputerUse20250124(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20241022 value) =>
        new ToolVariants::BetaToolTextEditor20241022(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20250124 value) =>
        new ToolVariants::BetaToolTextEditor20250124(value);

    public static implicit operator Tool(Messages::BetaToolTextEditor20250429 value) =>
        new ToolVariants::BetaToolTextEditor20250429(value);

    public static implicit operator Tool(Messages::BetaWebSearchTool20250305 value) =>
        new ToolVariants::BetaWebSearchTool20250305(value);

    public abstract void Validate();
}
