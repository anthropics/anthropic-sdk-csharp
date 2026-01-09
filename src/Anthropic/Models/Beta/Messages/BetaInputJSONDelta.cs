using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(typeof(JsonModelConverter<BetaInputJSONDelta, BetaInputJSONDeltaFromRaw>))]
public sealed record class BetaInputJSONDelta : JsonModel
{
    public required string PartialJSON
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
        _ = this.PartialJSON;
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

    public BetaInputJSONDelta()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

    public BetaInputJSONDelta(BetaInputJSONDelta betaInputJSONDelta)
        : base(betaInputJSONDelta) { }

    public BetaInputJSONDelta(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputJSONDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaInputJSONDeltaFromRaw.FromRawUnchecked"/>
    public static BetaInputJSONDelta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaInputJSONDelta(string partialJSON)
        : this()
    {
        this.PartialJSON = partialJSON;
    }
}

class BetaInputJSONDeltaFromRaw : IFromRawJson<BetaInputJSONDelta>
{
    /// <inheritdoc/>
    public BetaInputJSONDelta FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaInputJSONDelta.FromRawUnchecked(rawData);
}
