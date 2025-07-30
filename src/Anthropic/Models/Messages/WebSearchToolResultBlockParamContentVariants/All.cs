using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.WebSearchToolResultBlockParamContentVariants;

[JsonConverter(
    typeof(VariantConverter<WebSearchToolResultBlockItem, List<WebSearchResultBlockParam>>)
)]
public sealed record class WebSearchToolResultBlockItem(List<WebSearchResultBlockParam> Value)
    : WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolResultBlockItem, List<WebSearchResultBlockParam>>
{
    public static WebSearchToolResultBlockItem From(List<WebSearchResultBlockParam> value)
    {
        return new(value);
    }

    public override void Validate() { }
}

[JsonConverter(
    typeof(VariantConverter<WebSearchToolRequestErrorVariant, WebSearchToolRequestError>)
)]
public sealed record class WebSearchToolRequestErrorVariant(WebSearchToolRequestError Value)
    : WebSearchToolResultBlockParamContent,
        IVariant<WebSearchToolRequestErrorVariant, WebSearchToolRequestError>
{
    public static WebSearchToolRequestErrorVariant From(WebSearchToolRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
