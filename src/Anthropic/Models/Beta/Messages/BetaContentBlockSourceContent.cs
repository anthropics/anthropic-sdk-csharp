using Anthropic = Anthropic;
using BetaContentBlockSourceContentVariants = Anthropic.Models.Beta.Messages.BetaContentBlockSourceContentVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaContentBlockSourceContent>))]
public abstract record class BetaContentBlockSourceContent
{
    internal BetaContentBlockSourceContent() { }

    public static implicit operator BetaContentBlockSourceContent(BetaTextBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaTextBlockParam(value);

    public static implicit operator BetaContentBlockSourceContent(BetaImageBlockParam value) =>
        new BetaContentBlockSourceContentVariants::BetaImageBlockParam(value);

    public abstract void Validate();
}
