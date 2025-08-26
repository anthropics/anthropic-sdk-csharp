using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

public sealed record class BetaTextBlock(Messages::BetaTextBlock Value)
    : ContentBlock,
        IVariant<BetaTextBlock, Messages::BetaTextBlock>
{
    public static BetaTextBlock From(Messages::BetaTextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaThinkingBlock(Messages::BetaThinkingBlock Value)
    : ContentBlock,
        IVariant<BetaThinkingBlock, Messages::BetaThinkingBlock>
{
    public static BetaThinkingBlock From(Messages::BetaThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRedactedThinkingBlock(Messages::BetaRedactedThinkingBlock Value)
    : ContentBlock,
        IVariant<BetaRedactedThinkingBlock, Messages::BetaRedactedThinkingBlock>
{
    public static BetaRedactedThinkingBlock From(Messages::BetaRedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaToolUseBlock(Messages::BetaToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaToolUseBlock, Messages::BetaToolUseBlock>
{
    public static BetaToolUseBlock From(Messages::BetaToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaServerToolUseBlock(Messages::BetaServerToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaServerToolUseBlock, Messages::BetaServerToolUseBlock>
{
    public static BetaServerToolUseBlock From(Messages::BetaServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaWebSearchToolResultBlock(
    Messages::BetaWebSearchToolResultBlock Value
) : ContentBlock, IVariant<BetaWebSearchToolResultBlock, Messages::BetaWebSearchToolResultBlock>
{
    public static BetaWebSearchToolResultBlock From(Messages::BetaWebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaCodeExecutionToolResultBlock(
    Messages::BetaCodeExecutionToolResultBlock Value
)
    : ContentBlock,
        IVariant<BetaCodeExecutionToolResultBlock, Messages::BetaCodeExecutionToolResultBlock>
{
    public static BetaCodeExecutionToolResultBlock From(
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

public sealed record class BetaMCPToolUseBlock(Messages::BetaMCPToolUseBlock Value)
    : ContentBlock,
        IVariant<BetaMCPToolUseBlock, Messages::BetaMCPToolUseBlock>
{
    public static BetaMCPToolUseBlock From(Messages::BetaMCPToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaMCPToolResultBlock(Messages::BetaMCPToolResultBlock Value)
    : ContentBlock,
        IVariant<BetaMCPToolResultBlock, Messages::BetaMCPToolResultBlock>
{
    public static BetaMCPToolResultBlock From(Messages::BetaMCPToolResultBlock value)
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
public sealed record class BetaContainerUploadBlock(Messages::BetaContainerUploadBlock Value)
    : ContentBlock,
        IVariant<BetaContainerUploadBlock, Messages::BetaContainerUploadBlock>
{
    public static BetaContainerUploadBlock From(Messages::BetaContainerUploadBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
