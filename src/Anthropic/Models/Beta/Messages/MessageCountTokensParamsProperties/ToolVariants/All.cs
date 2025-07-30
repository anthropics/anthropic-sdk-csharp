using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

[JsonConverter(typeof(VariantConverter<BetaToolVariant, BetaTool>))]
public sealed record class BetaToolVariant(BetaTool Value)
    : Tool,
        IVariant<BetaToolVariant, BetaTool>
{
    public static BetaToolVariant From(BetaTool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaToolBash20241022Variant, BetaToolBash20241022>))]
public sealed record class BetaToolBash20241022Variant(BetaToolBash20241022 Value)
    : Tool,
        IVariant<BetaToolBash20241022Variant, BetaToolBash20241022>
{
    public static BetaToolBash20241022Variant From(BetaToolBash20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaToolBash20250124Variant, BetaToolBash20250124>))]
public sealed record class BetaToolBash20250124Variant(BetaToolBash20250124 Value)
    : Tool,
        IVariant<BetaToolBash20250124Variant, BetaToolBash20250124>
{
    public static BetaToolBash20250124Variant From(BetaToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaCodeExecutionTool20250522Variant, BetaCodeExecutionTool20250522>)
)]
public sealed record class BetaCodeExecutionTool20250522Variant(BetaCodeExecutionTool20250522 Value)
    : Tool,
        IVariant<BetaCodeExecutionTool20250522Variant, BetaCodeExecutionTool20250522>
{
    public static BetaCodeExecutionTool20250522Variant From(BetaCodeExecutionTool20250522 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolComputerUse20241022Variant, BetaToolComputerUse20241022>)
)]
public sealed record class BetaToolComputerUse20241022Variant(BetaToolComputerUse20241022 Value)
    : Tool,
        IVariant<BetaToolComputerUse20241022Variant, BetaToolComputerUse20241022>
{
    public static BetaToolComputerUse20241022Variant From(BetaToolComputerUse20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolComputerUse20250124Variant, BetaToolComputerUse20250124>)
)]
public sealed record class BetaToolComputerUse20250124Variant(BetaToolComputerUse20250124 Value)
    : Tool,
        IVariant<BetaToolComputerUse20250124Variant, BetaToolComputerUse20250124>
{
    public static BetaToolComputerUse20250124Variant From(BetaToolComputerUse20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolTextEditor20241022Variant, BetaToolTextEditor20241022>)
)]
public sealed record class BetaToolTextEditor20241022Variant(BetaToolTextEditor20241022 Value)
    : Tool,
        IVariant<BetaToolTextEditor20241022Variant, BetaToolTextEditor20241022>
{
    public static BetaToolTextEditor20241022Variant From(BetaToolTextEditor20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolTextEditor20250124Variant, BetaToolTextEditor20250124>)
)]
public sealed record class BetaToolTextEditor20250124Variant(BetaToolTextEditor20250124 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250124Variant, BetaToolTextEditor20250124>
{
    public static BetaToolTextEditor20250124Variant From(BetaToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolTextEditor20250429Variant, BetaToolTextEditor20250429>)
)]
public sealed record class BetaToolTextEditor20250429Variant(BetaToolTextEditor20250429 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250429Variant, BetaToolTextEditor20250429>
{
    public static BetaToolTextEditor20250429Variant From(BetaToolTextEditor20250429 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaToolTextEditor20250728Variant, BetaToolTextEditor20250728>)
)]
public sealed record class BetaToolTextEditor20250728Variant(BetaToolTextEditor20250728 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250728Variant, BetaToolTextEditor20250728>
{
    public static BetaToolTextEditor20250728Variant From(BetaToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaWebSearchTool20250305Variant, BetaWebSearchTool20250305>)
)]
public sealed record class BetaWebSearchTool20250305Variant(BetaWebSearchTool20250305 Value)
    : Tool,
        IVariant<BetaWebSearchTool20250305Variant, BetaWebSearchTool20250305>
{
    public static BetaWebSearchTool20250305Variant From(BetaWebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
