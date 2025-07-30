using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

[JsonConverter(typeof(VariantConverter<WebSearchToolResultErrorVariant, WebSearchToolResultError>))]
public sealed record class WebSearchToolResultErrorVariant(WebSearchToolResultError Value)
    : WebSearchToolResultBlockContent,
        IVariant<WebSearchToolResultErrorVariant, WebSearchToolResultError>
{
    public static WebSearchToolResultErrorVariant From(WebSearchToolResultError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<WebSearchResultBlocks, List<WebSearchResultBlock>>))]
public sealed record class WebSearchResultBlocks(List<WebSearchResultBlock> Value)
    : WebSearchToolResultBlockContent,
        IVariant<WebSearchResultBlocks, List<WebSearchResultBlock>>
{
    public static WebSearchResultBlocks From(List<WebSearchResultBlock> value)
    {
        return new(value);
    }

    public override void Validate() { }
}
