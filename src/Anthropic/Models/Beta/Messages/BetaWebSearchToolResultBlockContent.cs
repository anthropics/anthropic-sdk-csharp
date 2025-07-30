using System.Collections.Generic;
using System.Text.Json.Serialization;
using BetaWebSearchToolResultBlockContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(UnionConverter<BetaWebSearchToolResultBlockContent>))]
public abstract record class BetaWebSearchToolResultBlockContent
{
    internal BetaWebSearchToolResultBlockContent() { }

    public static implicit operator BetaWebSearchToolResultBlockContent(
        BetaWebSearchToolResultError value
    ) =>
        new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchToolResultErrorVariant(value);

    public static implicit operator BetaWebSearchToolResultBlockContent(
        List<BetaWebSearchResultBlock> value
    ) => new BetaWebSearchToolResultBlockContentVariants::BetaWebSearchResultBlocks(value);

    public abstract void Validate();
}
