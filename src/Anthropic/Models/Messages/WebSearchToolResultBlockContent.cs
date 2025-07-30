using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<WebSearchToolResultBlockContent>))]
public abstract record class WebSearchToolResultBlockContent
{
    internal WebSearchToolResultBlockContent() { }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchToolResultErrorVariant(value);

    public static implicit operator WebSearchToolResultBlockContent(
        List<WebSearchResultBlock> value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchResultBlocks(value);

    public abstract void Validate();
}
