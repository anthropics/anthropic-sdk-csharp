using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<ThinkingConfigBetweenTools, ThinkingConfigBetweenToolsFromRaw>)
)]
public sealed record class ThinkingConfigBetweenTools : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("between_tools")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThinkingConfigBetweenTools()
    {
        this.Type = JsonSerializer.SerializeToElement("between_tools");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ThinkingConfigBetweenTools(ThinkingConfigBetweenTools thinkingConfigBetweenTools)
        : base(thinkingConfigBetweenTools) { }
#pragma warning restore CS8618

    public ThinkingConfigBetweenTools(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("between_tools");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingConfigBetweenTools(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingConfigBetweenToolsFromRaw.FromRawUnchecked"/>
    public static ThinkingConfigBetweenTools FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThinkingConfigBetweenToolsFromRaw : IFromRawJson<ThinkingConfigBetweenTools>
{
    /// <inheritdoc/>
    public ThinkingConfigBetweenTools FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ThinkingConfigBetweenTools.FromRawUnchecked(rawData);
}
