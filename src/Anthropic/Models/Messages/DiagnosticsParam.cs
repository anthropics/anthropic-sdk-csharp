using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Request-level diagnostics. Currently carries the previous response id for prompt-cache
/// divergence reporting.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DiagnosticsParam, DiagnosticsParamFromRaw>))]
public sealed record class DiagnosticsParam : JsonModel
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

    public DiagnosticsParam() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DiagnosticsParam(DiagnosticsParam diagnosticsParam)
        : base(diagnosticsParam) { }
#pragma warning restore CS8618

    public DiagnosticsParam(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DiagnosticsParam(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DiagnosticsParamFromRaw.FromRawUnchecked"/>
    public static DiagnosticsParam FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DiagnosticsParamFromRaw : IFromRawJson<DiagnosticsParam>
{
    /// <inheritdoc/>
    public DiagnosticsParam FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DiagnosticsParam.FromRawUnchecked(rawData);
}
