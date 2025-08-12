using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.DocumentBlockParamProperties.SourceVariants;

public sealed record class Base64PDFSourceVariant(Messages::Base64PDFSource Value)
    : Source,
        IVariant<Base64PDFSourceVariant, Messages::Base64PDFSource>
{
    public static Base64PDFSourceVariant From(Messages::Base64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlainTextSourceVariant(Messages::PlainTextSource Value)
    : Source,
        IVariant<PlainTextSourceVariant, Messages::PlainTextSource>
{
    public static PlainTextSourceVariant From(Messages::PlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ContentBlockSourceVariant(Messages::ContentBlockSource Value)
    : Source,
        IVariant<ContentBlockSourceVariant, Messages::ContentBlockSource>
{
    public static ContentBlockSourceVariant From(Messages::ContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class URLPDFSourceVariant(Messages::URLPDFSource Value)
    : Source,
        IVariant<URLPDFSourceVariant, Messages::URLPDFSource>
{
    public static URLPDFSourceVariant From(Messages::URLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
