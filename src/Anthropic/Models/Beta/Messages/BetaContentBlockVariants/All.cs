using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockVariants;

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaTextBlock, Messages::BetaTextBlock>)
)]
public sealed record class BetaTextBlock(Messages::BetaTextBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaTextBlock, Messages::BetaTextBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaThinkingBlock, Messages::BetaThinkingBlock>)
)]
public sealed record class BetaThinkingBlock(Messages::BetaThinkingBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaThinkingBlock, Messages::BetaThinkingBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaRedactedThinkingBlock,
        Messages::BetaRedactedThinkingBlock
    >)
)]
public sealed record class BetaRedactedThinkingBlock(Messages::BetaRedactedThinkingBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaRedactedThinkingBlock, Messages::BetaRedactedThinkingBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaToolUseBlock, Messages::BetaToolUseBlock>)
)]
public sealed record class BetaToolUseBlock(Messages::BetaToolUseBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaToolUseBlock, Messages::BetaToolUseBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaServerToolUseBlock, Messages::BetaServerToolUseBlock>)
)]
public sealed record class BetaServerToolUseBlock(Messages::BetaServerToolUseBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaServerToolUseBlock, Messages::BetaServerToolUseBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaWebSearchToolResultBlock,
        Messages::BetaWebSearchToolResultBlock
    >)
)]
public sealed record class BetaWebSearchToolResultBlock(
    Messages::BetaWebSearchToolResultBlock Value
)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaWebSearchToolResultBlock, Messages::BetaWebSearchToolResultBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaCodeExecutionToolResultBlock,
        Messages::BetaCodeExecutionToolResultBlock
    >)
)]
public sealed record class BetaCodeExecutionToolResultBlock(
    Messages::BetaCodeExecutionToolResultBlock Value
)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<
            BetaCodeExecutionToolResultBlock,
            Messages::BetaCodeExecutionToolResultBlock
        >
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaMCPToolUseBlock, Messages::BetaMCPToolUseBlock>)
)]
public sealed record class BetaMCPToolUseBlock(Messages::BetaMCPToolUseBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaMCPToolUseBlock, Messages::BetaMCPToolUseBlock>
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

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaMCPToolResultBlock, Messages::BetaMCPToolResultBlock>)
)]
public sealed record class BetaMCPToolResultBlock(Messages::BetaMCPToolResultBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaMCPToolResultBlock, Messages::BetaMCPToolResultBlock>
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
[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<
        BetaContainerUploadBlock,
        Messages::BetaContainerUploadBlock
    >)
)]
public sealed record class BetaContainerUploadBlock(Messages::BetaContainerUploadBlock Value)
    : Messages::BetaContentBlock,
        Anthropic::IVariant<BetaContainerUploadBlock, Messages::BetaContainerUploadBlock>
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
