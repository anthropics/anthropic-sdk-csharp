using Anthropic = Anthropic;
using BetaCodeExecutionToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockParamContentVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::UnionConverter<BetaCodeExecutionToolResultBlockParamContent>)
)]
public abstract record class BetaCodeExecutionToolResultBlockParamContent
{
    internal BetaCodeExecutionToolResultBlockParamContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionToolResultErrorParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionToolResultErrorParam(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockParamContent(
        BetaCodeExecutionResultBlockParam value
    ) =>
        new BetaCodeExecutionToolResultBlockParamContentVariants::BetaCodeExecutionResultBlockParam(
            value
        );

    public abstract void Validate();
}
