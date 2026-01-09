using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<ThinkingBlockParam, ThinkingBlockParamFromRaw>))]
public sealed record class ThinkingBlockParam : JsonModel
{
    public required string Signature
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "signature"); }
        init { JsonModel.Set(this._rawData, "signature", value); }
    }

    public required string Thinking
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "thinking"); }
        init { JsonModel.Set(this._rawData, "thinking", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Signature;
        _ = this.Thinking;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"thinking\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ThinkingBlockParam()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");
    }

    public ThinkingBlockParam(ThinkingBlockParam thinkingBlockParam)
        : base(thinkingBlockParam) { }

    public ThinkingBlockParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"thinking\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ThinkingBlockParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ThinkingBlockParamFromRaw.FromRawUnchecked"/>
    public static ThinkingBlockParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ThinkingBlockParamFromRaw : IFromRawJson<ThinkingBlockParam>
{
    /// <inheritdoc/>
    public ThinkingBlockParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ThinkingBlockParam.FromRawUnchecked(rawData);
}
