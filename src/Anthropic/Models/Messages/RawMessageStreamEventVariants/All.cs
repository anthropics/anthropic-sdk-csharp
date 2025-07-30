using System.Text.Json.Serialization;

namespace Anthropic.Models.Messages.RawMessageStreamEventVariants;

[JsonConverter(typeof(VariantConverter<RawMessageStartEventVariant, RawMessageStartEvent>))]
public sealed record class RawMessageStartEventVariant(RawMessageStartEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageStartEventVariant, RawMessageStartEvent>
{
    public static RawMessageStartEventVariant From(RawMessageStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<RawMessageDeltaEventVariant, RawMessageDeltaEvent>))]
public sealed record class RawMessageDeltaEventVariant(RawMessageDeltaEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageDeltaEventVariant, RawMessageDeltaEvent>
{
    public static RawMessageDeltaEventVariant From(RawMessageDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<RawMessageStopEventVariant, RawMessageStopEvent>))]
public sealed record class RawMessageStopEventVariant(RawMessageStopEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawMessageStopEventVariant, RawMessageStopEvent>
{
    public static RawMessageStopEventVariant From(RawMessageStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<RawContentBlockStartEventVariant, RawContentBlockStartEvent>)
)]
public sealed record class RawContentBlockStartEventVariant(RawContentBlockStartEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockStartEventVariant, RawContentBlockStartEvent>
{
    public static RawContentBlockStartEventVariant From(RawContentBlockStartEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(
    typeof(VariantConverter<RawContentBlockDeltaEventVariant, RawContentBlockDeltaEvent>)
)]
public sealed record class RawContentBlockDeltaEventVariant(RawContentBlockDeltaEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockDeltaEventVariant, RawContentBlockDeltaEvent>
{
    public static RawContentBlockDeltaEventVariant From(RawContentBlockDeltaEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<RawContentBlockStopEventVariant, RawContentBlockStopEvent>))]
public sealed record class RawContentBlockStopEventVariant(RawContentBlockStopEvent Value)
    : RawMessageStreamEvent,
        IVariant<RawContentBlockStopEventVariant, RawContentBlockStopEvent>
{
    public static RawContentBlockStopEventVariant From(RawContentBlockStopEvent value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
