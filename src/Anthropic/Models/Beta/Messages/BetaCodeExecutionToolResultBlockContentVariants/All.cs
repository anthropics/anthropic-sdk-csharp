using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

[JsonConverter(
    typeof(VariantConverter<
        BetaCodeExecutionToolResultErrorVariant,
        BetaCodeExecutionToolResultError
    >)
)]
public sealed record class BetaCodeExecutionToolResultErrorVariant(
    BetaCodeExecutionToolResultError Value
)
    : BetaCodeExecutionToolResultBlockContent,
        IVariant<BetaCodeExecutionToolResultErrorVariant, BetaCodeExecutionToolResultError>
{
    public static BetaCodeExecutionToolResultErrorVariant From(
        BetaCodeExecutionToolResultError value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<BetaCodeExecutionResultBlockVariant, BetaCodeExecutionResultBlock>)
)]
public sealed record class BetaCodeExecutionResultBlockVariant(BetaCodeExecutionResultBlock Value)
    : BetaCodeExecutionToolResultBlockContent,
        IVariant<BetaCodeExecutionResultBlockVariant, BetaCodeExecutionResultBlock>
{
    public static BetaCodeExecutionResultBlockVariant From(BetaCodeExecutionResultBlock value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
