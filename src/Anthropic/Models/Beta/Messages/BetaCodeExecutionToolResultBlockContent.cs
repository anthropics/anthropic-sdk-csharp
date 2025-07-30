using System.Text.Json.Serialization;
using BetaCodeExecutionToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaCodeExecutionToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(UnionConverter<BetaCodeExecutionToolResultBlockContent>))]
public abstract record class BetaCodeExecutionToolResultBlockContent
{
    internal BetaCodeExecutionToolResultBlockContent() { }

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionToolResultError value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionToolResultErrorVariant(
            value
        );

    public static implicit operator BetaCodeExecutionToolResultBlockContent(
        BetaCodeExecutionResultBlock value
    ) =>
        new BetaCodeExecutionToolResultBlockContentVariants::BetaCodeExecutionResultBlockVariant(
            value
        );

    public abstract void Validate();
}
