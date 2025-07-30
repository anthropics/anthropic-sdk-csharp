using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.RawContentBlockDeltaVariants;

[JsonConverter(typeof(VariantConverter<TextDeltaVariant, TextDelta>))]
public sealed record class TextDeltaVariant(TextDelta Value)
    : RawContentBlockDelta,
        IVariant<TextDeltaVariant, TextDelta>
{
    public static TextDeltaVariant From(TextDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<InputJSONDeltaVariant, InputJSONDelta>))]
public sealed record class InputJSONDeltaVariant(InputJSONDelta Value)
    : RawContentBlockDelta,
        IVariant<InputJSONDeltaVariant, InputJSONDelta>
{
    public static InputJSONDeltaVariant From(InputJSONDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<CitationsDeltaVariant, CitationsDelta>))]
public sealed record class CitationsDeltaVariant(CitationsDelta Value)
    : RawContentBlockDelta,
        IVariant<CitationsDeltaVariant, CitationsDelta>
{
    public static CitationsDeltaVariant From(CitationsDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<ThinkingDeltaVariant, ThinkingDelta>))]
public sealed record class ThinkingDeltaVariant(ThinkingDelta Value)
    : RawContentBlockDelta,
        IVariant<ThinkingDeltaVariant, ThinkingDelta>
{
    public static ThinkingDeltaVariant From(ThinkingDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<SignatureDeltaVariant, SignatureDelta>))]
public sealed record class SignatureDeltaVariant(SignatureDelta Value)
    : RawContentBlockDelta,
        IVariant<SignatureDeltaVariant, SignatureDelta>
{
    public static SignatureDeltaVariant From(SignatureDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
