using Anthropic = Anthropic;
using BetaTextCitationVariants = Anthropic.Models.Beta.Messages.BetaTextCitationVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaTextCitation>))]
public abstract record class BetaTextCitation
{
    internal BetaTextCitation() { }

    public static implicit operator BetaTextCitation(BetaCitationCharLocation value) =>
        new BetaTextCitationVariants::BetaCitationCharLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationPageLocation value) =>
        new BetaTextCitationVariants::BetaCitationPageLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationContentBlockLocation value) =>
        new BetaTextCitationVariants::BetaCitationContentBlockLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationsWebSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationsWebSearchResultLocation(value);

    public static implicit operator BetaTextCitation(BetaCitationSearchResultLocation value) =>
        new BetaTextCitationVariants::BetaCitationSearchResultLocation(value);

    public abstract void Validate();
}
