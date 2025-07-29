using Anthropic = Anthropic;
using CitationVariants = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Citation>))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(Messages::BetaCitationCharLocation value) =>
        new CitationVariants::BetaCitationCharLocation(value);

    public static implicit operator Citation(Messages::BetaCitationPageLocation value) =>
        new CitationVariants::BetaCitationPageLocation(value);

    public static implicit operator Citation(Messages::BetaCitationContentBlockLocation value) =>
        new CitationVariants::BetaCitationContentBlockLocation(value);

    public static implicit operator Citation(
        Messages::BetaCitationsWebSearchResultLocation value
    ) => new CitationVariants::BetaCitationsWebSearchResultLocation(value);

    public static implicit operator Citation(Messages::BetaCitationSearchResultLocation value) =>
        new CitationVariants::BetaCitationSearchResultLocation(value);

    public abstract void Validate();
}
