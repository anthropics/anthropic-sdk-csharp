using System.Text.Json.Serialization;
using BlockVariants = Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(UnionConverter<Block>))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(TextBlockParam value) =>
        new BlockVariants::TextBlockParamVariant(value);

    public static implicit operator Block(ImageBlockParam value) =>
        new BlockVariants::ImageBlockParamVariant(value);

    public abstract void Validate();
}
