using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics;

/// <summary>
/// Lines of code added and removed via Claude Code.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaAnalyticsLinesOfCode, BetaAnalyticsLinesOfCodeFromRaw>)
)]
public sealed record class BetaAnalyticsLinesOfCode : JsonModel
{
    /// <summary>
    /// Lines of code added
    /// </summary>
    public required long AddedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("added_count");
        }
        init { this._rawData.Set("added_count", value); }
    }

    /// <summary>
    /// Lines of code removed
    /// </summary>
    public required long RemovedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("removed_count");
        }
        init { this._rawData.Set("removed_count", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AddedCount;
        _ = this.RemovedCount;
    }

    public BetaAnalyticsLinesOfCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaAnalyticsLinesOfCode(BetaAnalyticsLinesOfCode betaAnalyticsLinesOfCode)
        : base(betaAnalyticsLinesOfCode) { }
#pragma warning restore CS8618

    public BetaAnalyticsLinesOfCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaAnalyticsLinesOfCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaAnalyticsLinesOfCodeFromRaw.FromRawUnchecked"/>
    public static BetaAnalyticsLinesOfCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaAnalyticsLinesOfCodeFromRaw : IFromRawJson<BetaAnalyticsLinesOfCode>
{
    /// <inheritdoc/>
    public BetaAnalyticsLinesOfCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaAnalyticsLinesOfCode.FromRawUnchecked(rawData);
}
