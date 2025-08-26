using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.ToolResultBlockParamProperties.ContentProperties.BlockVariants;

public sealed record class TextBlockParam(Messages::TextBlockParam Value)
    : Block,
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
    : Block,
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

public sealed record class SearchResultBlockParam(Messages::SearchResultBlockParam Value)
    : Block,
        IVariant<SearchResultBlockParam, Messages::SearchResultBlockParam>
{
    public static SearchResultBlockParam From(Messages::SearchResultBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
