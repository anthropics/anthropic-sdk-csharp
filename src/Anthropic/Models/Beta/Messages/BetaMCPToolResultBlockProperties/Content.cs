using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties.ContentVariants;

namespace Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<BetaTextBlock> value) =>
        new ContentVariants::BetaMCPToolResultBlockContent(value);

    public abstract void Validate();
}
