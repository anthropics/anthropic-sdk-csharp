using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(
    typeof(ModelConverter<RedactedThinkingBlockParam, RedactedThinkingBlockParamFromRaw>)
)]
public sealed record class RedactedThinkingBlockParam : ModelBase
{
    public required string Data
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "data"); }
        init { ModelBase.Set(this._rawData, "data", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public RedactedThinkingBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

    public RedactedThinkingBlockParam(RedactedThinkingBlockParam redactedThinkingBlockParam)
        : base(redactedThinkingBlockParam) { }

    public RedactedThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"redacted_thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RedactedThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class RedactedThinkingBlockParamFromRaw : IFromRaw<RedactedThinkingBlockParam>
{
    /// <inheritdoc/>
    public RedactedThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RedactedThinkingBlockParam.FromRawUnchecked(rawData);
}
