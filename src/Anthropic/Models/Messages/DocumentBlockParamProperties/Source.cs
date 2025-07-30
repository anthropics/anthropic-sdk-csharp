using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties;

[JsonConverter(typeof(UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64PDFSource value) =>
        new SourceVariants::Base64PDFSourceVariant(value);

    public static implicit operator Source(PlainTextSource value) =>
        new SourceVariants::PlainTextSourceVariant(value);

    public static implicit operator Source(ContentBlockSource value) =>
        new SourceVariants::ContentBlockSourceVariant(value);

    public static implicit operator Source(URLPDFSource value) =>
        new SourceVariants::URLPDFSourceVariant(value);

    public abstract void Validate();
}
