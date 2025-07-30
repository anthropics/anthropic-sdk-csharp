using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

[JsonConverter(typeof(VariantConverter<BetaBase64ImageSourceVariant, BetaBase64ImageSource>))]
public sealed record class BetaBase64ImageSourceVariant(BetaBase64ImageSource Value)
    : Source,
        IVariant<BetaBase64ImageSourceVariant, BetaBase64ImageSource>
{
    public static BetaBase64ImageSourceVariant From(BetaBase64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaURLImageSourceVariant, BetaURLImageSource>))]
public sealed record class BetaURLImageSourceVariant(BetaURLImageSource Value)
    : Source,
        IVariant<BetaURLImageSourceVariant, BetaURLImageSource>
{
    public static BetaURLImageSourceVariant From(BetaURLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaFileImageSourceVariant, BetaFileImageSource>))]
public sealed record class BetaFileImageSourceVariant(BetaFileImageSource Value)
    : Source,
        IVariant<BetaFileImageSourceVariant, BetaFileImageSource>
{
    public static BetaFileImageSourceVariant From(BetaFileImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
