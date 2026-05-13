using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Request-level diagnostics. Currently carries the previous response id for prompt-cache
/// divergence reporting.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDiagnosticsParam, BetaDiagnosticsParamFromRaw>))]
public sealed record class BetaDiagnosticsParam : JsonModel
{
    /// <summary>
    /// The `id` (`msg_...`) from this client's previous /v1/messages response. The
    /// server compares that request's prompt fingerprint against this one and returns
    /// `diagnostics.cache_miss_reason` when the prompt-cache prefix could not be
    /// reused. Pass `null` on the first turn to opt in without a prior message to compare.
    /// </summary>
    public string? PreviousMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("previous_message_id");
        }
        init { this._rawData.Set("previous_message_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PreviousMessageID;
    }

    public BetaDiagnosticsParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDiagnosticsParam(BetaDiagnosticsParam betaDiagnosticsParam)
        : base(betaDiagnosticsParam) { }
#pragma warning restore CS8618

    public BetaDiagnosticsParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDiagnosticsParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDiagnosticsParamFromRaw.FromRawUnchecked"/>
    public static BetaDiagnosticsParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaDiagnosticsParamFromRaw : IFromRawJson<BetaDiagnosticsParam>
{
    /// <inheritdoc/>
    public BetaDiagnosticsParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDiagnosticsParam.FromRawUnchecked(rawData);
}
