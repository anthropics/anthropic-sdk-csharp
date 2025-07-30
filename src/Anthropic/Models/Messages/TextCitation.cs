using System.Text.Json.Serialization;
using TextCitationVariants = Anthropic.Models.Messages.TextCitationVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<TextCitation>))]
public abstract record class TextCitation
{
    internal TextCitation() { }

    public static implicit operator TextCitation(CitationCharLocation value) =>
        new TextCitationVariants::CitationCharLocationVariant(value);

    public static implicit operator TextCitation(CitationPageLocation value) =>
        new TextCitationVariants::CitationPageLocationVariant(value);

    public static implicit operator TextCitation(CitationContentBlockLocation value) =>
        new TextCitationVariants::CitationContentBlockLocationVariant(value);

    public static implicit operator TextCitation(CitationsWebSearchResultLocation value) =>
        new TextCitationVariants::CitationsWebSearchResultLocationVariant(value);

    public abstract void Validate();
}
