using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaToolUnionVariants;

public sealed record class BetaToolVariant(Messages::BetaTool Value)
    : Messages::BetaToolUnion,
        IVariant<BetaToolVariant, Messages::BetaTool>
{
    public static BetaToolVariant From(Messages::BetaTool value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolBash20241022Variant(Messages::BetaToolBash20241022 Value)
    : Messages::BetaToolUnion,
        IVariant<BetaToolBash20241022Variant, Messages::BetaToolBash20241022>
{
    public static BetaToolBash20241022Variant From(Messages::BetaToolBash20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolBash20250124Variant(Messages::BetaToolBash20250124 Value)
    : Messages::BetaToolUnion,
        IVariant<BetaToolBash20250124Variant, Messages::BetaToolBash20250124>
{
    public static BetaToolBash20250124Variant From(Messages::BetaToolBash20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionTool20250522Variant(
    Messages::BetaCodeExecutionTool20250522 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaCodeExecutionTool20250522Variant, Messages::BetaCodeExecutionTool20250522>
{
    public static BetaCodeExecutionTool20250522Variant From(
        Messages::BetaCodeExecutionTool20250522 value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolComputerUse20241022Variant(
    Messages::BetaToolComputerUse20241022 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolComputerUse20241022Variant, Messages::BetaToolComputerUse20241022>
{
    public static BetaToolComputerUse20241022Variant From(
        Messages::BetaToolComputerUse20241022 value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolComputerUse20250124Variant(
    Messages::BetaToolComputerUse20250124 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolComputerUse20250124Variant, Messages::BetaToolComputerUse20250124>
{
    public static BetaToolComputerUse20250124Variant From(
        Messages::BetaToolComputerUse20250124 value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolTextEditor20241022Variant(
    Messages::BetaToolTextEditor20241022 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolTextEditor20241022Variant, Messages::BetaToolTextEditor20241022>
{
    public static BetaToolTextEditor20241022Variant From(Messages::BetaToolTextEditor20241022 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolTextEditor20250124Variant(
    Messages::BetaToolTextEditor20250124 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolTextEditor20250124Variant, Messages::BetaToolTextEditor20250124>
{
    public static BetaToolTextEditor20250124Variant From(Messages::BetaToolTextEditor20250124 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolTextEditor20250429Variant(
    Messages::BetaToolTextEditor20250429 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolTextEditor20250429Variant, Messages::BetaToolTextEditor20250429>
{
    public static BetaToolTextEditor20250429Variant From(Messages::BetaToolTextEditor20250429 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolTextEditor20250728Variant(
    Messages::BetaToolTextEditor20250728 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaToolTextEditor20250728Variant, Messages::BetaToolTextEditor20250728>
{
    public static BetaToolTextEditor20250728Variant From(Messages::BetaToolTextEditor20250728 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchTool20250305Variant(
    Messages::BetaWebSearchTool20250305 Value
)
    : Messages::BetaToolUnion,
        IVariant<BetaWebSearchTool20250305Variant, Messages::BetaWebSearchTool20250305>
{
    public static BetaWebSearchTool20250305Variant From(Messages::BetaWebSearchTool20250305 value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
