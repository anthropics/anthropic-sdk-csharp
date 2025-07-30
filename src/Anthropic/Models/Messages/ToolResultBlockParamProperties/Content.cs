using System.Collections.Generic;
using System.Text.Json.Serialization;
using ContentProperties = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;
using ContentVariants = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentVariants;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties;

[JsonConverter(typeof(UnionConverter<Content>))]
public abstract record class Content
{
    internal Content() { }

    public static implicit operator Content(string value) => new ContentVariants::String(value);

    public static implicit operator Content(List<ContentProperties::Block> value) =>
        new ContentVariants::Blocks(value);

    public abstract void Validate();
}
