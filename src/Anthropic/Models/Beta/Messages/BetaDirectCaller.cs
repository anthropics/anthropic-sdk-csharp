using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Tool invocation directly from the model.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDirectCaller, BetaDirectCallerFromRaw>))]
public sealed record class BetaDirectCaller : JsonModel
{
    public JsonElement Type
    {
        get { return JsonModel.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { JsonModel.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"direct\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDirectCaller()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"direct\"");
    }

    public BetaDirectCaller(BetaDirectCaller betaDirectCaller)
        : base(betaDirectCaller) { }

    public BetaDirectCaller(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"direct\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDirectCaller(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDirectCallerFromRaw.FromRawUnchecked"/>
    public static BetaDirectCaller FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDirectCallerFromRaw : IFromRawJson<BetaDirectCaller>
{
    /// <inheritdoc/>
    public BetaDirectCaller FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDirectCaller.FromRawUnchecked(rawData);
}
