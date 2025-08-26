using Messages = Anthropic.Beta.Client.Models.Messages;

namespace Anthropic.Beta.Client.Models.Messages.RawContentBlockDeltaVariants;

public sealed record class TextDelta(Messages::TextDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<TextDelta, Messages::TextDelta>
{
    public static TextDelta From(Messages::TextDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class InputJSONDelta(Messages::InputJSONDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<InputJSONDelta, Messages::InputJSONDelta>
{
    public static InputJSONDelta From(Messages::InputJSONDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class CitationsDelta(Messages::CitationsDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<CitationsDelta, Messages::CitationsDelta>
{
    public static CitationsDelta From(Messages::CitationsDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class ThinkingDelta(Messages::ThinkingDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<ThinkingDelta, Messages::ThinkingDelta>
{
    public static ThinkingDelta From(Messages::ThinkingDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class SignatureDelta(Messages::SignatureDelta Value)
    : Messages::RawContentBlockDelta,
        IVariant<SignatureDelta, Messages::SignatureDelta>
{
    public static SignatureDelta From(Messages::SignatureDelta value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
