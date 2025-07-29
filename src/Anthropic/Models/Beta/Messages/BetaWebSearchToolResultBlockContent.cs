using Anthropic = Anthropic;
using BetaWebSearchToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;
using Generic = System.Collections.Generic;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::UnionConverter<BetaWebSearchToolResultBlockContent>)
)]
public abstract record class BetaWebSearchToolResultBlockContent
{
    internal BetaWebSearchToolResultBlockContent() { }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) => new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultError(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        Generic::List<BetaWebSearchResultBlock> value
    ) => new BetaWebSearchToolResultBlockContentVariants::UnionMember1(value);

    public abstract void Validate();
}
