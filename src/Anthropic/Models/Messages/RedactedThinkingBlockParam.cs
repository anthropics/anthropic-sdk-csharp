using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(JsonModelConverter<RedactedThinkingBlockParam, RedactedThinkingBlockParamFromRaw>)
)]
public sealed record class RedactedThinkingBlockParam : JsonModel
{
    public required string Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("data");
        }
        init { this._rawData.Set("data", value); }
    }

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
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("redacted_thinking")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RedactedThinkingBlockParam()
    {
        this.Type = JsonSerializer.SerializeToElement("redacted_thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RedactedThinkingBlockParam(RedactedThinkingBlockParam redactedThinkingBlockParam)
        : base(redactedThinkingBlockParam) { }
#pragma warning restore CS8618

    public RedactedThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("redacted_thinking");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RedactedThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RedactedThinkingBlockParamFromRaw.FromRawUnchecked"/>
    public static RedactedThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public RedactedThinkingBlockParam(string data)
        : this()
    {
        this.Data = data;
    }
}

class RedactedThinkingBlockParamFromRaw : IFromRawJson<RedactedThinkingBlockParam>
{
    /// <inheritdoc/>
    public RedactedThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RedactedThinkingBlockParam.FromRawUnchecked(rawData);
}
