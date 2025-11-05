using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

[JsonConverter(typeof(ModelConverter<BetaToolUsesTrigger>))]
public sealed record class BetaToolUsesTrigger : ModelBase, IFromRaw<BetaToolUsesTrigger>
{
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

    public required long Value
    {
        get
        {
            if (!this._properties.TryGetValue("value", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'value' cannot be null",
                    new System::ArgumentOutOfRangeException("value", "Missing required argument")
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
        _ = this.Type;
        _ = this.Value;
    }

    public BetaToolUsesTrigger()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

    public BetaToolUsesTrigger(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"tool_uses\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolUsesTrigger(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static BetaToolUsesTrigger FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> properties
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }

    [SetsRequiredMembers]
    public BetaToolUsesTrigger(long value)
        : this()
    {
        this.Value = value;
    }
}
