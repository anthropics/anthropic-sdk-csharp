using Anthropic = Anthropic;
using BetaWebSearchToolResultBlockParamContentVariants = Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;
using Generic = System.Collections.Generic;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::UnionConverter<BetaWebSearchToolResultBlockParamContent>)
)]
public abstract record class BetaWebSearchToolResultBlockParamContent
{
    internal BetaWebSearchToolResultBlockParamContent() { }

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        Generic::List<BetaWebSearchResultBlockParam> value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::ResultBlock(value);

    public static implicit operator BetaWebSearchToolResultBlockParamContent(
        BetaWebSearchToolRequestError value
    ) => new BetaWebSearchToolResultBlockParamContentVariants::BetaWebSearchToolRequestError(value);

    public abstract void Validate();
}
