using System.Text.Json.Serialization;
using SourceVariants = Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

namespace Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties;

[JsonConverter(typeof(UnionConverter<Source>))]
public abstract record class Source
{
    internal Source() { }

    public static implicit operator Source(BetaBase64ImageSource value) =>
        new SourceVariants::BetaBase64ImageSourceVariant(value);

    public static implicit operator Source(BetaURLImageSource value) =>
        new SourceVariants::BetaURLImageSourceVariant(value);

    public static implicit operator Source(BetaFileImageSource value) =>
        new SourceVariants::BetaFileImageSourceVariant(value);

    public abstract void Validate();
}
