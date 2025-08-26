using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Beta.Client.Models.Beta.Messages.BetaRawContentBlockStartEventProperties;

namespace Anthropic.Beta.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRawContentBlockStartEvent>))]
public sealed record class BetaRawContentBlockStartEvent
    : ModelBase,
        IFromRaw<BetaRawContentBlockStartEvent>
{
    /// <summary>
    /// Response model for a file uploaded to the container.
    /// </summary>
    public required ContentBlock ContentBlock
    {
        get
        {
            if (!this.Properties.TryGetValue("content_block", out JsonElement element))
                throw new ArgumentOutOfRangeException("content_block", "Missing required argument");

            return JsonSerializer.Deserialize<ContentBlock>(element, ModelBase.SerializerOptions)
                ?? throw new ArgumentNullException("content_block");
        }
        set
        {
            this.Properties["content_block"] = JsonSerializer.SerializeToElement(
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
        this.ContentBlock.Validate();
        _ = this.Index;
    }

    public BetaRawContentBlockStartEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockStartEvent(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaRawContentBlockStartEvent FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
