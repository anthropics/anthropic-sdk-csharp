using Anthropic = Anthropic;
using Serialization = System.Text.Json.Serialization;
using TextCitationParamVariants = Anthropic.Models.Messages.TextCitationParamVariants;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<TextCitationParam>))]
public abstract record class TextCitationParam
{
    internal TextCitationParam() { }

    public static implicit operator TextCitationParam(CitationCharLocationParam value) =>
        new TextCitationParamVariants::CitationCharLocationParam(value);

    public static implicit operator TextCitationParam(CitationPageLocationParam value) =>
        new TextCitationParamVariants::CitationPageLocationParam(value);

    public static implicit operator TextCitationParam(CitationContentBlockLocationParam value) =>
        new TextCitationParamVariants::CitationContentBlockLocationParam(value);

    public static implicit operator TextCitationParam(CitationWebSearchResultLocationParam value) =>
        new TextCitationParamVariants::CitationWebSearchResultLocationParam(value);

    public abstract void Validate();
}
