using System.Text.Json.Serialization;
using BlockVariants = Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[JsonConverter(typeof(UnionConverter<Block>))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(BetaTextBlockParam value) =>
        new BlockVariants::BetaTextBlockParamVariant(value);

    public static implicit operator Block(BetaImageBlockParam value) =>
        new BlockVariants::BetaImageBlockParamVariant(value);

    public static implicit operator Block(BetaSearchResultBlockParam value) =>
        new BlockVariants::BetaSearchResultBlockParamVariant(value);

    public abstract void Validate();
}
