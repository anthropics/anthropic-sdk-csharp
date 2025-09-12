using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.DocumentBlockParamProperties.SourceVariants;

public sealed record class Base64PDFSource(Messages::Base64PDFSource Value)
    : Source,
        IVariant<Base64PDFSource, Messages::Base64PDFSource>
{
    public static Base64PDFSource From(Messages::Base64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PlainTextSource(Messages::PlainTextSource Value)
    : Source,
        IVariant<PlainTextSource, Messages::PlainTextSource>
{
    public static PlainTextSource From(Messages::PlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ContentBlockSource(Messages::ContentBlockSource Value)
    : Source,
        IVariant<ContentBlockSource, Messages::ContentBlockSource>
{
    public static ContentBlockSource From(Messages::ContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class URLPDFSource(Messages::URLPDFSource Value)
    : Source,
        IVariant<URLPDFSource, Messages::URLPDFSource>
{
    public static URLPDFSource From(Messages::URLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
