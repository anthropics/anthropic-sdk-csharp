using Anthropic = Anthropic;
using RawContentBlockDeltaVariants = Anthropic.Models.Messages.RawContentBlockDeltaVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Messages;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<RawContentBlockDelta>))]
public abstract record class RawContentBlockDelta
{
    internal RawContentBlockDelta() { }

    public static implicit operator RawContentBlockDelta(TextDelta value) =>
        new RawContentBlockDeltaVariants::TextDelta(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) =>
        new RawContentBlockDeltaVariants::InputJSONDelta(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) =>
        new RawContentBlockDeltaVariants::CitationsDelta(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) =>
        new RawContentBlockDeltaVariants::ThinkingDelta(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) =>
        new RawContentBlockDeltaVariants::SignatureDelta(value);

    public abstract void Validate();
}
