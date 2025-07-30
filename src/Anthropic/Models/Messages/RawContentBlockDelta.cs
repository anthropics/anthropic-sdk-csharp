using System.Text.Json.Serialization;
using RawContentBlockDeltaVariants = Anthropic.Models.Messages.RawContentBlockDeltaVariants;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(UnionConverter<RawContentBlockDelta>))]
public abstract record class RawContentBlockDelta
{
    internal RawContentBlockDelta() { }

    public static implicit operator RawContentBlockDelta(TextDelta value) =>
        new RawContentBlockDeltaVariants::TextDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(InputJSONDelta value) =>
        new RawContentBlockDeltaVariants::InputJSONDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(CitationsDelta value) =>
        new RawContentBlockDeltaVariants::CitationsDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(ThinkingDelta value) =>
        new RawContentBlockDeltaVariants::ThinkingDeltaVariant(value);

    public static implicit operator RawContentBlockDelta(SignatureDelta value) =>
        new RawContentBlockDeltaVariants::SignatureDeltaVariant(value);

    public abstract void Validate();
}
