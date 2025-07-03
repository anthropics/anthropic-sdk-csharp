using Anthropic = Anthropic;
using BlockVariants = Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties.BlockVariants;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaToolResultBlockParamProperties.ContentProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Block>))]
public abstract record class Block
{
    internal Block() { }

    public static BlockVariants::BetaTextBlockParam Create(Messages::BetaTextBlockParam value) =>
        new(value);

    public static BlockVariants::BetaImageBlockParam Create(Messages::BetaImageBlockParam value) =>
        new(value);

    public static BlockVariants::BetaSearchResultBlockParam Create(
        Messages::BetaSearchResultBlockParam value
    ) => new(value);

    public abstract void Validate();
}
