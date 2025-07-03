using Anthropic = Anthropic;
using BetaRawContentBlockStartEventProperties = Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaRawContentBlockStartEventProperties.ContentBlockVariants;

[Serialization::JsonConverter(
    typeof(Anthropic::VariantConverter<BetaTextBlock, Messages::BetaTextBlock>)
)]
public sealed record class BetaTextBlock(Messages::BetaTextBlock Value)
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
    : BetaRawContentBlockStartEventProperties::ContentBlock,
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
