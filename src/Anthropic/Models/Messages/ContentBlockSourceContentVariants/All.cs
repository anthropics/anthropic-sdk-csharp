using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ContentBlockSourceContentVariants;

[JsonConverter(typeof(VariantConverter<TextBlockParamVariant, TextBlockParam>))]
public sealed record class TextBlockParamVariant(TextBlockParam Value)
    : ContentBlockSourceContent,
        IVariant<TextBlockParamVariant, TextBlockParam>
{
    public static TextBlockParamVariant From(TextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ImageBlockParamVariant, ImageBlockParam>))]
public sealed record class ImageBlockParamVariant(ImageBlockParam Value)
    : ContentBlockSourceContent,
        IVariant<ImageBlockParamVariant, ImageBlockParam>
{
    public static ImageBlockParamVariant From(ImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
