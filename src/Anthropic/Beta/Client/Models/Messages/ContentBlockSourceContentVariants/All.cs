using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.ContentBlockSourceContentVariants;

public sealed record class TextBlockParam(Messages::TextBlockParam Value)
    : Messages::ContentBlockSourceContent,
        IVariant<TextBlockParam, Messages::TextBlockParam>
{
    public static TextBlockParam From(Messages::TextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ImageBlockParam(Messages::ImageBlockParam Value)
    : Messages::ContentBlockSourceContent,
        IVariant<ImageBlockParam, Messages::ImageBlockParam>
{
    public static ImageBlockParam From(Messages::ImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
