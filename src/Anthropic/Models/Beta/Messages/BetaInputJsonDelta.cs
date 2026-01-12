using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaInputJsonDelta, BetaInputJsonDeltaFromRaw>))]
public sealed record class BetaInputJsonDelta : JsonModel
{
    public required string PartialJson
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "partial_json"); }
        init { JsonModel.Set(this._rawData, "partial_json", value); }
    }

    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PartialJson;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaInputJsonDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

    public BetaInputJsonDelta(BetaInputJsonDelta betaInputJsonDelta)
        : base(betaInputJsonDelta) { }

    public BetaInputJsonDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputJsonDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInputJsonDeltaFromRaw.FromRawUnchecked"/>
    public static BetaInputJsonDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaInputJsonDelta(string partialJson)
        : this()
    {
        this.PartialJson = partialJson;
    }
}

class BetaInputJsonDeltaFromRaw : IFromRawJson<BetaInputJsonDelta>
{
    /// <inheritdoc/>
    public BetaInputJsonDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaInputJsonDelta.FromRawUnchecked(rawData);
}
