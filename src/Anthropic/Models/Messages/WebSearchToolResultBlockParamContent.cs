using Anthropic = Anthropic;
using Generic = System.Collections.Generic;
using Serialization = System.Text.Json.Serialization;
using WebSearchToolResultBlockParamContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(
    typeof(Anthropic::UnionConverter<WebSearchToolResultBlockParamContent>)
)]
public abstract record class WebSearchToolResultBlockParamContent
{
    internal WebSearchToolResultBlockParamContent() { }

    public static implicit operator WebSearchToolResultBlockParamContent(
        Generic::List<WebSearchResultBlockParam> value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolResultBlockItem(value);

    public static implicit operator WebSearchToolResultBlockParamContent(
        WebSearchToolRequestError value
    ) => new WebSearchToolResultBlockParamContentVariants::WebSearchToolRequestError(value);

    public abstract void Validate();
}
