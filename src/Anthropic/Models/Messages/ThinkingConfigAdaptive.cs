using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ThinkingConfigAdaptive, ThinkingConfigAdaptiveFromRaw>))]
public sealed record class ThinkingConfigAdaptive : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("adaptive")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThinkingConfigAdaptive()
    {
        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingConfigAdaptive(ThinkingConfigAdaptive thinkingConfigAdaptive)
        : base(thinkingConfigAdaptive) { }
#pragma warning restore CS8618

    public ThinkingConfigAdaptive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("adaptive");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigAdaptive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingConfigAdaptiveFromRaw.FromRawUnchecked"/>
    public static ThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThinkingConfigAdaptiveFromRaw : IFromRawJson<ThinkingConfigAdaptive>
{
    /// <inheritdoc/>
    public ThinkingConfigAdaptive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThinkingConfigAdaptive.FromRawUnchecked(rawData);
}
