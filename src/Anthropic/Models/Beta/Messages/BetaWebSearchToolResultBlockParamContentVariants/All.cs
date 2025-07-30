using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockParamContentVariants;

[JsonConverter(typeof(VariantConverter<ResultBlock, List<BetaWebSearchResultBlockParam>>))]
public sealed record class ResultBlock(List<BetaWebSearchResultBlockParam> Value)
    : BetaWebSearchToolResultBlockParamContent,
        IVariant<ResultBlock, List<BetaWebSearchResultBlockParam>>
{
    public static ResultBlock From(List<BetaWebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(
    typeof(VariantConverter<BetaWebSearchToolRequestErrorVariant, BetaWebSearchToolRequestError>)
)]
public sealed record class BetaWebSearchToolRequestErrorVariant(BetaWebSearchToolRequestError Value)
    : BetaWebSearchToolResultBlockParamContent,
        IVariant<BetaWebSearchToolRequestErrorVariant, BetaWebSearchToolRequestError>
{
    public static BetaWebSearchToolRequestErrorVariant From(BetaWebSearchToolRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
