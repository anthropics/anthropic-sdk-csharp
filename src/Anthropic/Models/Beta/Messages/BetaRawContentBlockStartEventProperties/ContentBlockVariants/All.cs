using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

public sealed record class BetaTextBlockVariant(Messages::BetaTextBlock Value)
    : ContentBlock,
        IVariant<BetaTextBlockVariant, Messages::BetaTextBlock>
{
    public static BetaTextBlockVariant From(Messages::BetaTextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingBlockVariant(Messages::BetaThinkingBlock Value)
    : ContentBlock,
        IVariant<BetaThinkingBlockVariant, Messages::BetaThinkingBlock>
{
    public static BetaThinkingBlockVariant From(Messages::BetaThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRedactedThinkingBlockVariant(
    Messages::BetaRedactedThinkingBlock Value
) : ContentBlock, IVariant<BetaRedactedThinkingBlockVariant, Messages::BetaRedactedThinkingBlock>
{
    public static BetaRedactedThinkingBlockVariant From(Messages::BetaRedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolUseBlockVariant(Messages::BetaToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaToolUseBlockVariant, Messages::BetaToolUseBlock>
{
    public static BetaToolUseBlockVariant From(Messages::BetaToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaServerToolUseBlockVariant(Messages::BetaServerToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaServerToolUseBlockVariant, Messages::BetaServerToolUseBlock>
{
    public static BetaServerToolUseBlockVariant From(Messages::BetaServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchToolResultBlockVariant(
    Messages::BetaWebSearchToolResultBlock Value
)
    : ContentBlock,
        IVariant<BetaWebSearchToolResultBlockVariant, Messages::BetaWebSearchToolResultBlock>
{
    public static BetaWebSearchToolResultBlockVariant From(
        Messages::BetaWebSearchToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionToolResultBlockVariant(
    Messages::BetaCodeExecutionToolResultBlock Value
)
    : ContentBlock,
        IVariant<
            BetaCodeExecutionToolResultBlockVariant,
            Messages::BetaCodeExecutionToolResultBlock
        >
{
    public static BetaCodeExecutionToolResultBlockVariant From(
        Messages::BetaCodeExecutionToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolUseBlockVariant(Messages::BetaMCPToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaMCPToolUseBlockVariant, Messages::BetaMCPToolUseBlock>
{
    public static BetaMCPToolUseBlockVariant From(Messages::BetaMCPToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolResultBlockVariant(Messages::BetaMCPToolResultBlock Value)
    : ContentBlock,
        IVariant<BetaMCPToolResultBlockVariant, Messages::BetaMCPToolResultBlock>
{
    public static BetaMCPToolResultBlockVariant From(Messages::BetaMCPToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

/// <summary>
/// Response model for a file uploaded to the container.
/// </summary>
public sealed record class BetaContainerUploadBlockVariant(Messages::BetaContainerUploadBlock Value)
    : ContentBlock,
        IVariant<BetaContainerUploadBlockVariant, Messages::BetaContainerUploadBlock>
{
    public static BetaContainerUploadBlockVariant From(Messages::BetaContainerUploadBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
