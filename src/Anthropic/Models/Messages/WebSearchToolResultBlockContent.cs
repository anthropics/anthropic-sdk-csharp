using Anthropic = Anthropic;
using Generic = System.Collections.Generic;
using Serialization = System.Text.Json.Serialization;
using WebSearchToolResultBlockContentVariants = Anthropic.Models.Messages.WebSearchToolResultBlockContentVariants;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<WebSearchToolResultBlockContent>))]
public abstract record class WebSearchToolResultBlockContent
{
    internal WebSearchToolResultBlockContent() { }

    public static implicit operator WebSearchToolResultBlockContent(
        WebSearchToolResultError value
    ) => new WebSearchToolResultBlockContentVariants::WebSearchToolResultError(value);

    public static implicit operator WebSearchToolResultBlockContent(
        Generic::List<WebSearchResultBlock> value
    ) => new WebSearchToolResultBlockContentVariants::UnionMember1(value);

    public abstract void Validate();
}
