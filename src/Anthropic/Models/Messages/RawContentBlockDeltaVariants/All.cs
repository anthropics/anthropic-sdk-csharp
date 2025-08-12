using Messages = Anthropic.Models.Messages;

namespace Anthropic.Models.Messages.RawContentBlockDeltaVariants;

public sealed record class TextDeltaVariant(Messages::TextDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<TextDeltaVariant, Messages::TextDelta>
{
    public static TextDeltaVariant From(Messages::TextDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class InputJSONDeltaVariant(Messages::InputJSONDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<InputJSONDeltaVariant, Messages::InputJSONDelta>
{
    public static InputJSONDeltaVariant From(Messages::InputJSONDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationsDeltaVariant(Messages::CitationsDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<CitationsDeltaVariant, Messages::CitationsDelta>
{
    public static CitationsDeltaVariant From(Messages::CitationsDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingDeltaVariant(Messages::ThinkingDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<ThinkingDeltaVariant, Messages::ThinkingDelta>
{
    public static ThinkingDeltaVariant From(Messages::ThinkingDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SignatureDeltaVariant(Messages::SignatureDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<SignatureDeltaVariant, Messages::SignatureDelta>
{
    public static SignatureDeltaVariant From(Messages::SignatureDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
