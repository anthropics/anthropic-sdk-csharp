using Anthropic = Anthropic;
using ContentVariants = Anthropic.Models.Messages.MessageParamProperties.ContentVariants;
using Generic = System.Collections.Generic;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.MessageParamProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) =>
        new ContentVariants::UnionMember0(value);

    public static implicit operator Content(Generic::List<Messages::ContentBlockParam> value) =>
        new ContentVariants::UnionMember1(value);

    public abstract void Validate();
}
