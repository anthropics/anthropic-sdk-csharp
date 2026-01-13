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
        get { return this._rawData.GetNotNullClass<string>("partial_json"); }
        init { this._rawData.Set("partial_json", value); }
    }

    public JsonElement Type
    {
        get { return this._rawData.GetNotNullStruct<JsonElement>("type"); }
        init { this._rawData.Set("type", value); }
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
        this._rawData = new(rawData);

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"input_json_delta\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaInputJsonDelta(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
