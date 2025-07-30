using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;

[JsonConverter(typeof(VariantConverter<TextBlockParamVariant, TextBlockParam>))]
public sealed record class TextBlockParamVariant(TextBlockParam Value)
    : Block,
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
    : Block,
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
