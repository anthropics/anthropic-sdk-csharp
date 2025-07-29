using Anthropic = Anthropic;
using Messages = Anthropic.Models.Beta.Messages;
using Serialization = System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::BetaBase64PDFSource value) =>
        new SourceVariants::BetaBase64PDFSource(value);

    public static implicit operator Source(Messages::BetaPlainTextSource value) =>
        new SourceVariants::BetaPlainTextSource(value);

    public static implicit operator Source(Messages::BetaContentBlockSource value) =>
        new SourceVariants::BetaContentBlockSource(value);

    public static implicit operator Source(Messages::BetaURLPDFSource value) =>
        new SourceVariants::BetaURLPDFSource(value);

    public static implicit operator Source(Messages::BetaFileDocumentSource value) =>
        new SourceVariants::BetaFileDocumentSource(value);

    public abstract void Validate();
}
