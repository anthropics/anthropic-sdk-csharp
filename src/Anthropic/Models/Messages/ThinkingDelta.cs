using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<ThinkingDelta, ThinkingDeltaFromRaw>))]
public sealed record class ThinkingDelta : ModelBase
{
    public required string Thinking
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "thinking"); }
        init { ModelBase.Set(this._rawData, "thinking", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Thinking;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThinkingDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

    public ThinkingDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingDeltaFromRaw.FromRawUnchecked"/>
    public static ThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ThinkingDelta(string thinking)
        : this()
    {
        this.Thinking = thinking;
    }
}

class ThinkingDeltaFromRaw : IFromRaw<ThinkingDelta>
{
    /// <inheritdoc/>
    public ThinkingDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThinkingDelta.FromRawUnchecked(rawData);
}
