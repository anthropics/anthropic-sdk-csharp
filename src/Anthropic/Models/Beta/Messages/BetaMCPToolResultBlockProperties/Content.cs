using Anthropic = Anthropic;
using ContentVariants = Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties.ContentVariants;
using Generic = System.Collections.Generic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaMCPToolResultBlockProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) =>
        new ContentVariants::UnionMember0(value);

    public static implicit operator Content(Generic::List<Messages::BetaTextBlock> value) =>
        new ContentVariants::BetaMCPToolResultBlockContent(value);

    public abstract void Validate();
}
