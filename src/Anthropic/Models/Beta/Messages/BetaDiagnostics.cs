using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Request-level diagnostics: why the prompt cache could not fully reuse the prefix
/// of the request named by `diagnostics.previous_message_id`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDiagnostics, BetaDiagnosticsFromRaw>))]
public sealed record class BetaDiagnostics : JsonModel
{
    /// <summary>
    /// Explains why the prompt cache could not fully reuse the prefix from the request
    /// identified by `diagnostics.previous_message_id`. `null` means diagnosis is
    /// still pending — the response was serialized before the background comparison completed.
    /// </summary>
    public required BetaCacheMissReason? CacheMissReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BetaCacheMissReason>("cache_miss_reason");
        }
        init { this._rawData.Set("cache_miss_reason", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CacheMissReason?.Validate();
    }

    public BetaDiagnostics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDiagnostics(BetaDiagnostics betaDiagnostics)
        : base(betaDiagnostics) { }
#pragma warning restore CS8618

    public BetaDiagnostics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDiagnostics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDiagnosticsFromRaw.FromRawUnchecked"/>
    public static BetaDiagnostics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDiagnostics(BetaCacheMissReason? cacheMissReason)
        : this()
    {
        this.CacheMissReason = cacheMissReason;
    }
}

class BetaDiagnosticsFromRaw : IFromRawJson<BetaDiagnostics>
{
    /// <inheritdoc/>
    public BetaDiagnostics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaDiagnostics.FromRawUnchecked(rawData);
}
