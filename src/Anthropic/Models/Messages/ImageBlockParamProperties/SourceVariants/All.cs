using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

[JsonConverter(typeof(VariantConverter<Base64ImageSourceVariant, Base64ImageSource>))]
public sealed record class Base64ImageSourceVariant(Base64ImageSource Value)
    : Source,
        IVariant<Base64ImageSourceVariant, Base64ImageSource>
{
    public static Base64ImageSourceVariant From(Base64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<URLImageSourceVariant, URLImageSource>))]
public sealed record class URLImageSourceVariant(URLImageSource Value)
    : Source,
        IVariant<URLImageSourceVariant, URLImageSource>
{
    public static URLImageSourceVariant From(URLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
