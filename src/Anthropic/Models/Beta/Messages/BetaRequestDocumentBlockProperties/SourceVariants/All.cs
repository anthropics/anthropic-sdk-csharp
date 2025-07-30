using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaRequestDocumentBlockProperties.SourceVariants;

[JsonConverter(typeof(VariantConverter<BetaBase64PDFSourceVariant, BetaBase64PDFSource>))]
public sealed record class BetaBase64PDFSourceVariant(BetaBase64PDFSource Value)
    : Source,
        IVariant<BetaBase64PDFSourceVariant, BetaBase64PDFSource>
{
    public static BetaBase64PDFSourceVariant From(BetaBase64PDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaPlainTextSourceVariant, BetaPlainTextSource>))]
public sealed record class BetaPlainTextSourceVariant(BetaPlainTextSource Value)
    : Source,
        IVariant<BetaPlainTextSourceVariant, BetaPlainTextSource>
{
    public static BetaPlainTextSourceVariant From(BetaPlainTextSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaContentBlockSourceVariant, BetaContentBlockSource>))]
public sealed record class BetaContentBlockSourceVariant(BetaContentBlockSource Value)
    : Source,
        IVariant<BetaContentBlockSourceVariant, BetaContentBlockSource>
{
    public static BetaContentBlockSourceVariant From(BetaContentBlockSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaURLPDFSourceVariant, BetaURLPDFSource>))]
public sealed record class BetaURLPDFSourceVariant(BetaURLPDFSource Value)
    : Source,
        IVariant<BetaURLPDFSourceVariant, BetaURLPDFSource>
{
    public static BetaURLPDFSourceVariant From(BetaURLPDFSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaFileDocumentSourceVariant, BetaFileDocumentSource>))]
public sealed record class BetaFileDocumentSourceVariant(BetaFileDocumentSource Value)
    : Source,
        IVariant<BetaFileDocumentSourceVariant, BetaFileDocumentSource>
{
    public static BetaFileDocumentSourceVariant From(BetaFileDocumentSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
