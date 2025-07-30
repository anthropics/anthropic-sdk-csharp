using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.Messages.BetaContentBlockSourceContentVariants;

[JsonConverter(typeof(VariantConverter<BetaTextBlockParamVariant, BetaTextBlockParam>))]
public sealed record class BetaTextBlockParamVariant(BetaTextBlockParam Value)
    : BetaContentBlockSourceContent,
        IVariant<BetaTextBlockParamVariant, BetaTextBlockParam>
{
    public static BetaTextBlockParamVariant From(BetaTextBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaImageBlockParamVariant, BetaImageBlockParam>))]
public sealed record class BetaImageBlockParamVariant(BetaImageBlockParam Value)
    : BetaContentBlockSourceContent,
        IVariant<BetaImageBlockParamVariant, BetaImageBlockParam>
{
    public static BetaImageBlockParamVariant From(BetaImageBlockParam value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
