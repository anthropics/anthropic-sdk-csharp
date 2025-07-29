using Anthropic = Anthropic;
using Messages = Anthropic.Models.Messages;
using Serialization = System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Messages::Base64PDFSource value) =>
        new SourceVariants::Base64PDFSource(value);

    public static implicit operator Source(Messages::PlainTextSource value) =>
        new SourceVariants::PlainTextSource(value);

    public static implicit operator Source(Messages::ContentBlockSource value) =>
        new SourceVariants::ContentBlockSource(value);

    public static implicit operator Source(Messages::URLPDFSource value) =>
        new SourceVariants::URLPDFSource(value);

    public abstract void Validate();
}
