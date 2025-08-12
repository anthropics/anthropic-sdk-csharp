using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;

public sealed record class TextBlockParamVariant(Messages::TextBlockParam Value)
    : Block,
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
    : Block,
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

public sealed record class SearchResultBlockParamVariant(Messages::SearchResultBlockParam Value)
    : Block,
        IVariant<SearchResultBlockParamVariant, Messages::SearchResultBlockParam>
{
    public static SearchResultBlockParamVariant From(Messages::SearchResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
