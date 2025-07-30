using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaWebSearchToolResultBlockContentVariants;

[JsonConverter(
    typeof(VariantConverter<BetaWebSearchToolResultErrorVariant, BetaWebSearchToolResultError>)
)]
public sealed record class BetaWebSearchToolResultErrorVariant(BetaWebSearchToolResultError Value)
    : BetaWebSearchToolResultBlockContent,
        IVariant<BetaWebSearchToolResultErrorVariant, BetaWebSearchToolResultError>
{
    public static BetaWebSearchToolResultErrorVariant From(BetaWebSearchToolResultError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaWebSearchResultBlocks, List<BetaWebSearchResultBlock>>))]
public sealed record class BetaWebSearchResultBlocks(List<BetaWebSearchResultBlock> Value)
    : BetaWebSearchToolResultBlockContent,
        IVariant<BetaWebSearchResultBlocks, List<BetaWebSearchResultBlock>>
{
    public static BetaWebSearchResultBlocks From(List<BetaWebSearchResultBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
