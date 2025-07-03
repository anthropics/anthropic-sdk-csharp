using Anthropic = Anthropic;
using CitationVariants = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Citation>))]
public abstract record class Citation
{
    internal Citation() { }

    public static CitationVariants::BetaCitationCharLocation Create(
        Messages::BetaCitationCharLocation value
    ) => new(value);

    public static CitationVariants::BetaCitationPageLocation Create(
        Messages::BetaCitationPageLocation value
    ) => new(value);

    public static CitationVariants::BetaCitationContentBlockLocation Create(
        Messages::BetaCitationContentBlockLocation value
    ) => new(value);

    public static CitationVariants::BetaCitationsWebSearchResultLocation Create(
        Messages::BetaCitationsWebSearchResultLocation value
    ) => new(value);

    public static CitationVariants::BetaSearchResultLocationCitation Create(
        Messages::BetaSearchResultLocationCitation value
    ) => new(value);

    public abstract void Validate();
}
