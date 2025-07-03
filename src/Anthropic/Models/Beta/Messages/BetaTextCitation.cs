using Anthropic = Anthropic;
using BetaTextCitationVariants = Anthropic.Models.Beta.Messages.BetaTextCitationVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaTextCitation>))]
public abstract record class BetaTextCitation
{
    internal BetaTextCitation() { }

    public static BetaTextCitationVariants::BetaCitationCharLocation Create(
        BetaCitationCharLocation value
    ) => new(value);

    public static BetaTextCitationVariants::BetaCitationPageLocation Create(
        BetaCitationPageLocation value
    ) => new(value);

    public static BetaTextCitationVariants::BetaCitationContentBlockLocation Create(
        BetaCitationContentBlockLocation value
    ) => new(value);

    public static BetaTextCitationVariants::BetaCitationsWebSearchResultLocation Create(
        BetaCitationsWebSearchResultLocation value
    ) => new(value);

    public static BetaTextCitationVariants::BetaSearchResultLocationCitation Create(
        BetaSearchResultLocationCitation value
    ) => new(value);

    public abstract void Validate();
}
