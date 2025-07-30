using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;

[JsonConverter(
    typeof(VariantConverter<
        BetaCodeExecutionToolResultErrorParamVariant,
        BetaCodeExecutionToolResultErrorParam
    >)
)]
public sealed record class BetaCodeExecutionToolResultErrorParamVariant(
    BetaCodeExecutionToolResultErrorParam Value
)
    : BetaCodeExecutionToolResultBlockParamContent,
        IVariant<
            BetaCodeExecutionToolResultErrorParamVariant,
            BetaCodeExecutionToolResultErrorParam
        >
{
    public static BetaCodeExecutionToolResultErrorParamVariant From(
        BetaCodeExecutionToolResultErrorParam value
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
    typeof(VariantConverter<
        BetaCodeExecutionResultBlockParamVariant,
        BetaCodeExecutionResultBlockParam
    >)
)]
public sealed record class BetaCodeExecutionResultBlockParamVariant(
    BetaCodeExecutionResultBlockParam Value
)
    : BetaCodeExecutionToolResultBlockParamContent,
        IVariant<BetaCodeExecutionResultBlockParamVariant, BetaCodeExecutionResultBlockParam>
{
    public static BetaCodeExecutionResultBlockParamVariant From(
        BetaCodeExecutionResultBlockParam value
    )
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
