using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

public sealed record class BetaBase64ImageSourceVariant(Messages::BetaBase64ImageSource Value)
    : Source,
        IVariant<BetaBase64ImageSourceVariant, Messages::BetaBase64ImageSource>
{
    public static BetaBase64ImageSourceVariant From(Messages::BetaBase64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaURLImageSourceVariant(Messages::BetaURLImageSource Value)
    : Source,
        IVariant<BetaURLImageSourceVariant, Messages::BetaURLImageSource>
{
    public static BetaURLImageSourceVariant From(Messages::BetaURLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaFileImageSourceVariant(Messages::BetaFileImageSource Value)
    : Source,
        IVariant<BetaFileImageSourceVariant, Messages::BetaFileImageSource>
{
    public static BetaFileImageSourceVariant From(Messages::BetaFileImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
