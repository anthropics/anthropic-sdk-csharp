using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentVariants = Anthropic.Models.Messages.MessageParamProperties.ContentVariants;

namespace Anthropic.Models.Messages.MessageParamProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<ContentBlockParam> value) =>
        new ContentVariants::ContentBlockParams(value);

    public abstract void Validate();
}
