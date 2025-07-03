using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using ToolVariants = Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Tool>))]
public abstract record class Tool
{
    internal Tool() { }

    public static ToolVariants::BetaTool Create(Messages::BetaTool value) => new(value);

    public static ToolVariants::BetaToolBash20241022 Create(Messages::BetaToolBash20241022 value) =>
        new(value);

    public static ToolVariants::BetaToolBash20250124 Create(Messages::BetaToolBash20250124 value) =>
        new(value);

    public static ToolVariants::BetaCodeExecutionTool20250522 Create(
        Messages::BetaCodeExecutionTool20250522 value
    ) => new(value);

    public static ToolVariants::BetaToolComputerUse20241022 Create(
        Messages::BetaToolComputerUse20241022 value
    ) => new(value);

    public static ToolVariants::BetaToolComputerUse20250124 Create(
        Messages::BetaToolComputerUse20250124 value
    ) => new(value);

    public static ToolVariants::BetaToolTextEditor20241022 Create(
        Messages::BetaToolTextEditor20241022 value
    ) => new(value);

    public static ToolVariants::BetaToolTextEditor20250124 Create(
        Messages::BetaToolTextEditor20250124 value
    ) => new(value);

    public static ToolVariants::BetaToolTextEditor20250429 Create(
        Messages::BetaToolTextEditor20250429 value
    ) => new(value);

    public static ToolVariants::BetaWebSearchTool20250305 Create(
        Messages::BetaWebSearchTool20250305 value
    ) => new(value);

    public abstract void Validate();
}
