using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Messages;

[JsonConverter(typeof(ModelConverter<ThinkingDelta>))]
public sealed record class ThinkingDelta : ModelBase, IFromRaw<ThinkingDelta>
{
    public required string Thinking
    {
        get
        {
            if (!this._properties.TryGetValue("thinking", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'thinking' cannot be null",
                    new System::ArgumentOutOfRangeException("thinking", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'thinking' cannot be null",
                    new System::ArgumentNullException("thinking")
                );
        }
        init
        {
            this._properties["thinking"] = JsonSerializer.SerializeToElement(
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
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
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
        _ = this.Thinking;
        _ = this.Type;
    }

    public ThinkingDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

    public ThinkingDelta(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingDelta(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static ThinkingDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public ThinkingDelta(string thinking)
        : this()
    {
        this.Thinking = thinking;
    }
}
