using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaRawContentBlockDeltaEvent>))]
public sealed record class BetaRawContentBlockDeltaEvent
    : ModelBase,
        IFromRaw<BetaRawContentBlockDeltaEvent>
{
    public required BetaRawContentBlockDelta Delta
    {
        get
        {
            if (!this._properties.TryGetValue("delta", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'delta' cannot be null",
                    new ArgumentOutOfRangeException("delta", "Missing required argument")
                );

            return JsonSerializer.Deserialize<BetaRawContentBlockDelta>(
                    element,
                    ModelBase.SerializerOptions
                )
                ?? throw new AnthropicInvalidDataException(
                    "'delta' cannot be null",
                    new ArgumentNullException("delta")
                );
        }
        init
        {
            this._properties["delta"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

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
        this.Delta.Validate();
        _ = this.Index;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaRawContentBlockDeltaEvent()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

    public BetaRawContentBlockDeltaEvent(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRawContentBlockDeltaEvent(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaRawContentBlockDeltaEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
