using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.MessageCountTokensParamsProperties.ToolVariants;

public sealed record class BetaTool(Messages::BetaTool Value)
    : Tool,
        IVariant<BetaTool, Messages::BetaTool>
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

public sealed record class BetaToolBash20241022(Messages::BetaToolBash20241022 Value)
    : Tool,
        IVariant<BetaToolBash20241022, Messages::BetaToolBash20241022>
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

public sealed record class BetaToolBash20250124(Messages::BetaToolBash20250124 Value)
    : Tool,
        IVariant<BetaToolBash20250124, Messages::BetaToolBash20250124>
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

public sealed record class BetaCodeExecutionTool20250522(
    Messages::BetaCodeExecutionTool20250522 Value
) : Tool, IVariant<BetaCodeExecutionTool20250522, Messages::BetaCodeExecutionTool20250522>
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

public sealed record class BetaCodeExecutionTool20250825(
    Messages::BetaCodeExecutionTool20250825 Value
) : Tool, IVariant<BetaCodeExecutionTool20250825, Messages::BetaCodeExecutionTool20250825>
{
    public static BetaCodeExecutionTool20250825 From(Messages::BetaCodeExecutionTool20250825 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolComputerUse20241022(Messages::BetaToolComputerUse20241022 Value)
    : Tool,
        IVariant<BetaToolComputerUse20241022, Messages::BetaToolComputerUse20241022>
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

public sealed record class BetaMemoryTool20250818(Messages::BetaMemoryTool20250818 Value)
    : Tool,
        IVariant<BetaMemoryTool20250818, Messages::BetaMemoryTool20250818>
{
    public static BetaMemoryTool20250818 From(Messages::BetaMemoryTool20250818 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolComputerUse20250124(Messages::BetaToolComputerUse20250124 Value)
    : Tool,
        IVariant<BetaToolComputerUse20250124, Messages::BetaToolComputerUse20250124>
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

public sealed record class BetaToolTextEditor20241022(Messages::BetaToolTextEditor20241022 Value)
    : Tool,
        IVariant<BetaToolTextEditor20241022, Messages::BetaToolTextEditor20241022>
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

public sealed record class BetaToolTextEditor20250124(Messages::BetaToolTextEditor20250124 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250124, Messages::BetaToolTextEditor20250124>
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

public sealed record class BetaToolTextEditor20250429(Messages::BetaToolTextEditor20250429 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250429, Messages::BetaToolTextEditor20250429>
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

public sealed record class BetaToolTextEditor20250728(Messages::BetaToolTextEditor20250728 Value)
    : Tool,
        IVariant<BetaToolTextEditor20250728, Messages::BetaToolTextEditor20250728>
{
    public static BetaToolTextEditor20250728 From(Messages::BetaToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchTool20250305(Messages::BetaWebSearchTool20250305 Value)
    : Tool,
        IVariant<BetaWebSearchTool20250305, Messages::BetaWebSearchTool20250305>
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

public sealed record class BetaWebFetchTool20250910(Messages::BetaWebFetchTool20250910 Value)
    : Tool,
        IVariant<BetaWebFetchTool20250910, Messages::BetaWebFetchTool20250910>
{
    public static BetaWebFetchTool20250910 From(Messages::BetaWebFetchTool20250910 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
