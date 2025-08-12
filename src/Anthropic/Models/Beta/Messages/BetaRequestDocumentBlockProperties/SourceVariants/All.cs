using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

public sealed record class BetaBase64PDFSourceVariant(Messages::BetaBase64PDFSource Value)
    : Source,
        IVariant<BetaBase64PDFSourceVariant, Messages::BetaBase64PDFSource>
{
    public static BetaBase64PDFSourceVariant From(Messages::BetaBase64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaPlainTextSourceVariant(Messages::BetaPlainTextSource Value)
    : Source,
        IVariant<BetaPlainTextSourceVariant, Messages::BetaPlainTextSource>
{
    public static BetaPlainTextSourceVariant From(Messages::BetaPlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaContentBlockSourceVariant(Messages::BetaContentBlockSource Value)
    : Source,
        IVariant<BetaContentBlockSourceVariant, Messages::BetaContentBlockSource>
{
    public static BetaContentBlockSourceVariant From(Messages::BetaContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaURLPDFSourceVariant(Messages::BetaURLPDFSource Value)
    : Source,
        IVariant<BetaURLPDFSourceVariant, Messages::BetaURLPDFSource>
{
    public static BetaURLPDFSourceVariant From(Messages::BetaURLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaFileDocumentSourceVariant(Messages::BetaFileDocumentSource Value)
    : Source,
        IVariant<BetaFileDocumentSourceVariant, Messages::BetaFileDocumentSource>
{
    public static BetaFileDocumentSourceVariant From(Messages::BetaFileDocumentSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
