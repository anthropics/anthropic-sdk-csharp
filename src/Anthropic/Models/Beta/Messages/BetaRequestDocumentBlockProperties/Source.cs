using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[JsonConverter(typeof(UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64PDFSource value) =>
        new SourceVariants::BetaBase64PDFSourceVariant(value);

    public static implicit operator Source(BetaPlainTextSource value) =>
        new SourceVariants::BetaPlainTextSourceVariant(value);

    public static implicit operator Source(BetaContentBlockSource value) =>
        new SourceVariants::BetaContentBlockSourceVariant(value);

    public static implicit operator Source(BetaURLPDFSource value) =>
        new SourceVariants::BetaURLPDFSourceVariant(value);

    public static implicit operator Source(BetaFileDocumentSource value) =>
        new SourceVariants::BetaFileDocumentSourceVariant(value);

    public abstract void Validate();
}
