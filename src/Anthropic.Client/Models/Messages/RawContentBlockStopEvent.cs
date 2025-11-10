using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<RawContentBlockStopEvent>))]
public sealed record class RawContentBlockStopEvent : ModelBase, IFromRaw<RawContentBlockStopEvent>
{
    public required long Index
    {
        get
        {
            if (!this._properties.TryGetValue("index", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'index' cannot be null",
                    new ArgumentOutOfRangeException("index", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["index"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RawContentBlockStopEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"");
    }

    public RawContentBlockStopEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_stop\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RawContentBlockStopEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static RawContentBlockStopEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public RawContentBlockStopEvent(long index)
        : this()
    {
        this.Index = index;
    }
}
