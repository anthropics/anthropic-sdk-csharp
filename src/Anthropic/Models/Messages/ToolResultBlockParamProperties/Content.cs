using Anthropic = Anthropic;
using ContentProperties = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;
using ContentVariants = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentVariants;
using Generic = System.Collections.Generic;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) =>
        new ContentVariants::UnionMember0(value);

    public static implicit operator Content(Generic::List<ContentProperties::Block> value) =>
        new ContentVariants::UnionMember1(value);

    public abstract void Validate();
}
