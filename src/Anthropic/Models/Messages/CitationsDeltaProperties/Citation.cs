using Anthropic = Anthropic;
using CitationVariants = Anthropic.Models.Messages.CitationsDeltaProperties.CitationVariants;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.CitationsDeltaProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Citation>))]
public abstract record class Citation
{
    internal Citation() { }

    public static implicit operator Citation(Messages::CitationCharLocation value) =>
        new CitationVariants::CitationCharLocation(value);

    public static implicit operator Citation(Messages::CitationPageLocation value) =>
        new CitationVariants::CitationPageLocation(value);

    public static implicit operator Citation(Messages::CitationContentBlockLocation value) =>
        new CitationVariants::CitationContentBlockLocation(value);

    public static implicit operator Citation(Messages::CitationsWebSearchResultLocation value) =>
        new CitationVariants::CitationsWebSearchResultLocation(value);

    public abstract void Validate();
}
