using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<ContentBlockSourceContent> value) =>
        new ContentVariants::ContentBlockSourceContentVariant(value);

    public abstract void Validate();
}
