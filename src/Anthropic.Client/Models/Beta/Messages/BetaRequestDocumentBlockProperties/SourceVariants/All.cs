using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Beta.Messages;

namespace Anthropic.Client.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

public sealed record class BetaBase64PDFSource(Messages::BetaBase64PDFSource Value)
    : Source,
        IVariant<BetaBase64PDFSource, Messages::BetaBase64PDFSource>
{
    public static BetaBase64PDFSource From(Messages::BetaBase64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaPlainTextSource(Messages::BetaPlainTextSource Value)
    : Source,
        IVariant<BetaPlainTextSource, Messages::BetaPlainTextSource>
{
    public static BetaPlainTextSource From(Messages::BetaPlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaContentBlockSource(Messages::BetaContentBlockSource Value)
    : Source,
        IVariant<BetaContentBlockSource, Messages::BetaContentBlockSource>
{
    public static BetaContentBlockSource From(Messages::BetaContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaURLPDFSource(Messages::BetaURLPDFSource Value)
    : Source,
        IVariant<BetaURLPDFSource, Messages::BetaURLPDFSource>
{
    public static BetaURLPDFSource From(Messages::BetaURLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaFileDocumentSource(Messages::BetaFileDocumentSource Value)
    : Source,
        IVariant<BetaFileDocumentSource, Messages::BetaFileDocumentSource>
{
    public static BetaFileDocumentSource From(Messages::BetaFileDocumentSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
