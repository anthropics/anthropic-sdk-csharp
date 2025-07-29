using Anthropic = Anthropic;
using BlockVariants = Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Block>))]
public abstract record class Block
{
    internal Block() { }

    public static implicit operator Block(Messages::BetaTextBlockParam value) =>
        new BlockVariants::BetaTextBlockParam(value);

    public static implicit operator Block(Messages::BetaImageBlockParam value) =>
        new BlockVariants::BetaImageBlockParam(value);

    public static implicit operator Block(Messages::BetaSearchResultBlockParam value) =>
        new BlockVariants::BetaSearchResultBlockParam(value);

    public abstract void Validate();
}
