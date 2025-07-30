using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

[JsonConverter(typeof(VariantConverter<Base64PDFSourceVariant, Base64PDFSource>))]
public sealed record class Base64PDFSourceVariant(Base64PDFSource Value)
    : Source,
        IVariant<Base64PDFSourceVariant, Base64PDFSource>
{
    public static Base64PDFSourceVariant From(Base64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<PlainTextSourceVariant, PlainTextSource>))]
public sealed record class PlainTextSourceVariant(PlainTextSource Value)
    : Source,
        IVariant<PlainTextSourceVariant, PlainTextSource>
{
    public static PlainTextSourceVariant From(PlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ContentBlockSourceVariant, ContentBlockSource>))]
public sealed record class ContentBlockSourceVariant(ContentBlockSource Value)
    : Source,
        IVariant<ContentBlockSourceVariant, ContentBlockSource>
{
    public static ContentBlockSourceVariant From(ContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<URLPDFSourceVariant, URLPDFSource>))]
public sealed record class URLPDFSourceVariant(URLPDFSource Value)
    : Source,
        IVariant<URLPDFSourceVariant, URLPDFSource>
{
    public static URLPDFSourceVariant From(URLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
