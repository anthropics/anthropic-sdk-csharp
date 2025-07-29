using Anthropic = Anthropic;
using ContentVariants = Anthropic.Models.Messages.ContentBlockSourceProperties.ContentVariants;
using Generic = System.Collections.Generic;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockSourceProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) =>
        new ContentVariants::UnionMember0(value);

    public static implicit operator Content(
        Generic::List<Messages::ContentBlockSourceContent> value
    ) => new ContentVariants::ContentBlockSourceContent(value);

    public abstract void Validate();
}
