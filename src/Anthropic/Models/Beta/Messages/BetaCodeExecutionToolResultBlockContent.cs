using Anthropic = Anthropic;
using BetaCodeExecutionToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::UnionConverter<BetaCodeExecutionToolResultBlockContent>)
)]
public abstract record class BetaCodeExecutionToolResultBlockContent
{
    internal BetaCodeExecutionToolResultBlockContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultError(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) => new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlock(value);

    public abstract void Validate();
}
