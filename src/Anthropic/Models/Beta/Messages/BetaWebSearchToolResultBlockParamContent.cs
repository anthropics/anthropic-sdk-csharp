using System.Collections.Generic;
using System.Text.Json.Serialization;
using BetaWebSearchToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(UnionConverter<BetaWebSearchToolResultBlockParamContent>))]
public abstract record class BetaWebSearchToolResultBlockParamContent
{
    internal BetaWebSearchToolResultBlockParamContent() { }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        List<BetaWebSearchResultBlockParam> value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) =>
        new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestErrorVariant(
            value
        );

    public abstract void Validate();
}
