using Anthropic.Client.Core;
using Messages = Anthropic.Client.Models.Messages;

namespace Anthropic.Client.Models.Messages.ImageBlockParamProperties.SourceVariants;

public sealed record class Base64ImageSource(Messages::Base64ImageSource Value)
    : Source,
        IVariant<Base64ImageSource, Messages::Base64ImageSource>
{
    public static Base64ImageSource From(Messages::Base64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class URLImageSource(Messages::URLImageSource Value)
    : Source,
        IVariant<URLImageSource, Messages::URLImageSource>
{
    public static URLImageSource From(Messages::URLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
