using Messages = Anthropic.Beta.Client.Models.Beta.Messages;

namespace Anthropic.Beta.Client.Models.Beta.Messages.BetaImageBlockParamProperties.SourceVariants;

public sealed record class BetaBase64ImageSource(Messages::BetaBase64ImageSource Value)
    : Source,
        IVariant<BetaBase64ImageSource, Messages::BetaBase64ImageSource>
{
    public static BetaBase64ImageSource From(Messages::BetaBase64ImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaURLImageSource(Messages::BetaURLImageSource Value)
    : Source,
        IVariant<BetaURLImageSource, Messages::BetaURLImageSource>
{
    public static BetaURLImageSource From(Messages::BetaURLImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaFileImageSource(Messages::BetaFileImageSource Value)
    : Source,
        IVariant<BetaFileImageSource, Messages::BetaFileImageSource>
{
    public static BetaFileImageSource From(Messages::BetaFileImageSource value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
