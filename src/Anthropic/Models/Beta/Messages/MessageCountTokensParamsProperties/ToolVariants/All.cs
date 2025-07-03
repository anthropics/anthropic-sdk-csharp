using Anthropic = Anthropic;
using MessageCountTokensParamsProperties = Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

[Serialization::JsonConverter(typeof(Anthropic::VariantConverter<BetaTool, Messages::BetaTool>))]
public sealed record class BetaTool(Messages::BetaTool Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaTool, Messages::BetaTool>
{
    public static BetaTool From(Messages::BetaTool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaToolBash20241022, Messages::BetaToolBash20241022>)
)]
public sealed record class BetaToolBash20241022(Messages::BetaToolBash20241022 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolBash20241022, Messages::BetaToolBash20241022>
{
    public static BetaToolBash20241022 From(Messages::BetaToolBash20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaToolBash20250124, Messages::BetaToolBash20250124>)
)]
public sealed record class BetaToolBash20250124(Messages::BetaToolBash20250124 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolBash20250124, Messages::BetaToolBash20250124>
{
    public static BetaToolBash20250124 From(Messages::BetaToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCodeExecutionTool20250522,
        Messages::BetaCodeExecutionTool20250522
    >)
)]
public sealed record class BetaCodeExecutionTool20250522(
    Messages::BetaCodeExecutionTool20250522 Value
)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaCodeExecutionTool20250522, Messages::BetaCodeExecutionTool20250522>
{
    public static BetaCodeExecutionTool20250522 From(Messages::BetaCodeExecutionTool20250522 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaToolComputerUse20241022,
        Messages::BetaToolComputerUse20241022
    >)
)]
public sealed record class BetaToolComputerUse20241022(Messages::BetaToolComputerUse20241022 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolComputerUse20241022, Messages::BetaToolComputerUse20241022>
{
    public static BetaToolComputerUse20241022 From(Messages::BetaToolComputerUse20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaToolComputerUse20250124,
        Messages::BetaToolComputerUse20250124
    >)
)]
public sealed record class BetaToolComputerUse20250124(Messages::BetaToolComputerUse20250124 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolComputerUse20250124, Messages::BetaToolComputerUse20250124>
{
    public static BetaToolComputerUse20250124 From(Messages::BetaToolComputerUse20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaToolTextEditor20241022,
        Messages::BetaToolTextEditor20241022
    >)
)]
public sealed record class BetaToolTextEditor20241022(Messages::BetaToolTextEditor20241022 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolTextEditor20241022, Messages::BetaToolTextEditor20241022>
{
    public static BetaToolTextEditor20241022 From(Messages::BetaToolTextEditor20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaToolTextEditor20250124,
        Messages::BetaToolTextEditor20250124
    >)
)]
public sealed record class BetaToolTextEditor20250124(Messages::BetaToolTextEditor20250124 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolTextEditor20250124, Messages::BetaToolTextEditor20250124>
{
    public static BetaToolTextEditor20250124 From(Messages::BetaToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaToolTextEditor20250429,
        Messages::BetaToolTextEditor20250429
    >)
)]
public sealed record class BetaToolTextEditor20250429(Messages::BetaToolTextEditor20250429 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaToolTextEditor20250429, Messages::BetaToolTextEditor20250429>
{
    public static BetaToolTextEditor20250429 From(Messages::BetaToolTextEditor20250429 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaWebSearchTool20250305,
        Messages::BetaWebSearchTool20250305
    >)
)]
public sealed record class BetaWebSearchTool20250305(Messages::BetaWebSearchTool20250305 Value)
    : MessageCountTokensParamsProperties::Tool,
        Anthropic::IVariant<BetaWebSearchTool20250305, Messages::BetaWebSearchTool20250305>
{
    public static BetaWebSearchTool20250305 From(Messages::BetaWebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
