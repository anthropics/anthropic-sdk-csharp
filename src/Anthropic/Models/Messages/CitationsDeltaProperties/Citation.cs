using System.Text.Json.Serialization;
using CitationVariants = Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;

namespace Anthropic.Models.Messages.CitationsDeltaProperties;

[JsonConverter(typeof(UnionConverter<Citation>))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(CitationCharLocation value) =>
        new CitationVariants::CitationCharLocationVariant(value);

    public static implicit operator Citation(CitationPageLocation value) =>
        new CitationVariants::CitationPageLocationVariant(value);

    public static implicit operator Citation(CitationContentBlockLocation value) =>
        new CitationVariants::CitationContentBlockLocationVariant(value);

    public static implicit operator Citation(CitationsWebSearchResultLocation value) =>
        new CitationVariants::CitationsWebSearchResultLocationVariant(value);

    public abstract void Validate();
}
