using Anthropic = Anthropic;
using BetaTextCitationParamVariants = Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaTextCitationParam>))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static implicit operator BetaTextCitationParam(BetaCitationCharLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationCharLocationParam(value);

    public static implicit operator BetaTextCitationParam(BetaCitationPageLocationParam value) =>
        new BetaTextCitationParamVariants::BetaCitationPageLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationContentBlockLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationWebSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam(value);

    public static implicit operator BetaTextCitationParam(
        BetaCitationSearchResultLocationParam value
    ) => new BetaTextCitationParamVariants::BetaCitationSearchResultLocationParam(value);

    public abstract void Validate();
}
