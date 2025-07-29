using Anthropic = Anthropic;
using BlockVariants = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Block>))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(Messages::TextBlockParam value) =>
        new BlockVariants::TextBlockParam(value);

    public static implicit operator Block(Messages::ImageBlockParam value) =>
        new BlockVariants::ImageBlockParam(value);

    public abstract void Validate();
}
