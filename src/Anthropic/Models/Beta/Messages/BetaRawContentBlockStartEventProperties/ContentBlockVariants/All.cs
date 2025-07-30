using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

[JsonConverter(typeof(VariantConverter<BetaTextBlockVariant, BetaTextBlock>))]
public sealed record class BetaTextBlockVariant(BetaTextBlock Value)
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
    : ContentBlock,
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
