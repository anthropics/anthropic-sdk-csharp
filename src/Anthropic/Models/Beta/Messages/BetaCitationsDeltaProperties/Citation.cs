using System.Text.Json.Serialization;
using CitationVariants = Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties.CitationVariants;

namespace Anthropic.Models.Beta.Messages.BetaCitationsDeltaProperties;

[JsonConverter(typeof(UnionConverter<Citation>))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(BetaCitationCharLocation value) =>
        new CitationVariants::BetaCitationCharLocationVariant(value);

    public static implicit operator Citation(BetaCitationPageLocation value) =>
        new CitationVariants::BetaCitationPageLocationVariant(value);

    public static implicit operator Citation(BetaCitationContentBlockLocation value) =>
        new CitationVariants::BetaCitationContentBlockLocationVariant(value);

    public static implicit operator Citation(BetaCitationsWebSearchResultLocation value) =>
        new CitationVariants::BetaCitationsWebSearchResultLocationVariant(value);

    public static implicit operator Citation(BetaCitationSearchResultLocation value) =>
        new CitationVariants::BetaCitationSearchResultLocationVariant(value);

    public abstract void Validate();
}
