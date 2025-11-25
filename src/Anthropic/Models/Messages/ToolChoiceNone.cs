using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(ModelConverter<ToolChoiceNone, ToolChoiceNoneFromRaw>))]
public sealed record class ToolChoiceNone : ModelBase
{
    public JsonElement Type
    {
        get
        {
            if (!this._rawData.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"none\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolChoiceNone()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

    public ToolChoiceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"none\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static ToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolChoiceNoneFromRaw : IFromRaw<ToolChoiceNone>
{
    public ToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolChoiceNone.FromRawUnchecked(rawData);
}
