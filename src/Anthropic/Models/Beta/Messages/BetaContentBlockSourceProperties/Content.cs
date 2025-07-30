using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties.ContentVariants;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockSourceProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<BetaContentBlockSourceContent> value) =>
        new ContentVariants::BetaContentBlockSourceContentVariant(value);

    public abstract void Validate();
}
