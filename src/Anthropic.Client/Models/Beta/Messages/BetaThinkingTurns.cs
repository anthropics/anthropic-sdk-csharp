using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaThinkingTurns>))]
public sealed record class BetaThinkingTurns : ModelBase, IFromRaw<BetaThinkingTurns>
{
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

    public required long Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'value' cannot be null",
                    new ArgumentOutOfRangeException("value", "Missing required argument")
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["value"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Value;
    }

    public BetaThinkingTurns()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"");
    }

    public BetaThinkingTurns(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_turns\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaThinkingTurns(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaThinkingTurns FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaThinkingTurns(long value)
        : this()
    {
        this.Value = value;
    }
}
