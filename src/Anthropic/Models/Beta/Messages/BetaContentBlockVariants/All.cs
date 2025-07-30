using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockVariants;

[JsonConverter(typeof(VariantConverter<BetaTextBlockVariant, BetaTextBlock>))]
public sealed record class BetaTextBlockVariant(BetaTextBlock Value)
    : BetaContentBlock,
        IVariant<BetaTextBlockVariant, BetaTextBlock>
{
    public static BetaTextBlockVariant From(BetaTextBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaThinkingBlockVariant, BetaThinkingBlock>))]
public sealed record class BetaThinkingBlockVariant(BetaThinkingBlock Value)
    : BetaContentBlock,
        IVariant<BetaThinkingBlockVariant, BetaThinkingBlock>
{
    public static BetaThinkingBlockVariant From(BetaThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaRedactedThinkingBlockVariant, BetaRedactedThinkingBlock>)
)]
public sealed record class BetaRedactedThinkingBlockVariant(BetaRedactedThinkingBlock Value)
    : BetaContentBlock,
        IVariant<BetaRedactedThinkingBlockVariant, BetaRedactedThinkingBlock>
{
    public static BetaRedactedThinkingBlockVariant From(BetaRedactedThinkingBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaToolUseBlockVariant, BetaToolUseBlock>))]
public sealed record class BetaToolUseBlockVariant(BetaToolUseBlock Value)
    : BetaContentBlock,
        IVariant<BetaToolUseBlockVariant, BetaToolUseBlock>
{
    public static BetaToolUseBlockVariant From(BetaToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaServerToolUseBlockVariant, BetaServerToolUseBlock>))]
public sealed record class BetaServerToolUseBlockVariant(BetaServerToolUseBlock Value)
    : BetaContentBlock,
        IVariant<BetaServerToolUseBlockVariant, BetaServerToolUseBlock>
{
    public static BetaServerToolUseBlockVariant From(BetaServerToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaWebSearchToolResultBlockVariant, BetaWebSearchToolResultBlock>)
)]
public sealed record class BetaWebSearchToolResultBlockVariant(BetaWebSearchToolResultBlock Value)
    : BetaContentBlock,
        IVariant<BetaWebSearchToolResultBlockVariant, BetaWebSearchToolResultBlock>
{
    public static BetaWebSearchToolResultBlockVariant From(BetaWebSearchToolResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<
        BetaCodeExecutionToolResultBlockVariant,
        BetaCodeExecutionToolResultBlock
    >)
)]
public sealed record class BetaCodeExecutionToolResultBlockVariant(
    BetaCodeExecutionToolResultBlock Value
)
    : BetaContentBlock,
        IVariant<BetaCodeExecutionToolResultBlockVariant, BetaCodeExecutionToolResultBlock>
{
    public static BetaCodeExecutionToolResultBlockVariant From(
        BetaCodeExecutionToolResultBlock value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaMCPToolUseBlockVariant, BetaMCPToolUseBlock>))]
public sealed record class BetaMCPToolUseBlockVariant(BetaMCPToolUseBlock Value)
    : BetaContentBlock,
        IVariant<BetaMCPToolUseBlockVariant, BetaMCPToolUseBlock>
{
    public static BetaMCPToolUseBlockVariant From(BetaMCPToolUseBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaMCPToolResultBlockVariant, BetaMCPToolResultBlock>))]
public sealed record class BetaMCPToolResultBlockVariant(BetaMCPToolResultBlock Value)
    : BetaContentBlock,
        IVariant<BetaMCPToolResultBlockVariant, BetaMCPToolResultBlock>
{
    public static BetaMCPToolResultBlockVariant From(BetaMCPToolResultBlock value)
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
[JsonConverter(typeof(VariantConverter<BetaContainerUploadBlockVariant, BetaContainerUploadBlock>))]
public sealed record class BetaContainerUploadBlockVariant(BetaContainerUploadBlock Value)
    : BetaContentBlock,
        IVariant<BetaContainerUploadBlockVariant, BetaContainerUploadBlock>
{
    public static BetaContainerUploadBlockVariant From(BetaContainerUploadBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
