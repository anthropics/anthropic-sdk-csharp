using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

public sealed record class Base64ImageSourceVariant(Messages::Base64ImageSource Value)
    : Source,
        IVariant<Base64ImageSourceVariant, Messages::Base64ImageSource>
{
    public static Base64ImageSourceVariant From(Messages::Base64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class URLImageSourceVariant(Messages::URLImageSource Value)
    : Source,
        IVariant<URLImageSourceVariant, Messages::URLImageSource>
{
    public static URLImageSourceVariant From(Messages::URLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
