using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebSearchToolResultBlockParamContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<WebSearchToolResultBlockParamContent>))]
public abstract record class WebSearchToolResultBlockParamContent
{
    internal WebSearchToolResultBlockParamContent() { }

    public static implicit operator WebSearchToolResultBlockParamContent(
        List<WebSearchResultBlockParam> value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestErrorVariant(value);

    public abstract void Validate();
}
