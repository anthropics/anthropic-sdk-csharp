using Anthropic = Anthropic;
using BetaTextCitationParamVariants = Anthropic.Models.Beta.Messages.BetaTextCitationParamVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaTextCitationParam>))]
public abstract record class BetaTextCitationParam
{
    internal BetaTextCitationParam() { }

    public static BetaTextCitationParamVariants::BetaCitationCharLocationParam Create(
        BetaCitationCharLocationParam value
    ) => new(value);

    public static BetaTextCitationParamVariants::BetaCitationPageLocationParam Create(
        BetaCitationPageLocationParam value
    ) => new(value);

    public static BetaTextCitationParamVariants::BetaCitationContentBlockLocationParam Create(
        BetaCitationContentBlockLocationParam value
    ) => new(value);

    public static BetaTextCitationParamVariants::BetaCitationWebSearchResultLocationParam Create(
        BetaCitationWebSearchResultLocationParam value
    ) => new(value);

    public static BetaTextCitationParamVariants::BetaSearchResultLocationCitationParam Create(
        BetaSearchResultLocationCitationParam value
    ) => new(value);

    public abstract void Validate();
}
