using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Messages.ImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Messages.ImageBlockParamProperties;

[JsonConverter(typeof(UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(Base64ImageSource value) =>
        new SourceVariants::Base64ImageSourceVariant(value);

    public static implicit operator Source(URLImageSource value) =>
        new SourceVariants::URLImageSourceVariant(value);

    public abstract void Validate();
}
