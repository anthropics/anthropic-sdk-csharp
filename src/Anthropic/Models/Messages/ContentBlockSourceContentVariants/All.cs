using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ContentBlockSourceContentVariants;

public sealed record class TextBlockParamVariant(Messages::TextBlockParam Value)
    : Messages::ContentBlockSourceContent,
        IVariant<TextBlockParamVariant, Messages::TextBlockParam>
{
    public static TextBlockParamVariant From(Messages::TextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ImageBlockParamVariant(Messages::ImageBlockParam Value)
    : Messages::ContentBlockSourceContent,
        IVariant<ImageBlockParamVariant, Messages::ImageBlockParam>
{
    public static ImageBlockParamVariant From(Messages::ImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
