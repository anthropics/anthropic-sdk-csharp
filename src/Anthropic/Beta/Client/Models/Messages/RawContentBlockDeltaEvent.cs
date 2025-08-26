using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Anthropic.Beta.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawContentBlockDeltaEvent>))]
public sealed record class RawContentBlockDeltaEvent
    : ModelBase,
        IFromRaw<RawContentBlockDeltaEvent>
{
    public required RawContentBlockDelta Delta
    {
        get
        {
            if (!this.Properties.TryGetValue("delta", out JsonElement element))
                throw new ArgumentOutOfRangeException("delta", "Missing required argument");

            return JsonSerializer.Deserialize<RawContentBlockDelta>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new ArgumentNullException("delta");
        }
        set
        {
            this.Properties["delta"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required long Index
    {
        get
        {
            if (!this.Properties.TryGetValue("index", out JsonElement element))
                throw new ArgumentOutOfRangeException("index", "Missing required argument");

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out JsonElement element))
                throw new ArgumentOutOfRangeException("type", "Missing required argument");

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Delta.Validate();
        _ = this.Index;
    }

    public RawContentBlockDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawContentBlockDeltaEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static RawContentBlockDeltaEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
