using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Organization.Analytics;

/// <summary>
/// Lines of code added and removed via Claude Code.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AnalyticsLinesOfCode, AnalyticsLinesOfCodeFromRaw>))]
public sealed record class AnalyticsLinesOfCode : JsonModel
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

    public AnalyticsLinesOfCode() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AnalyticsLinesOfCode(AnalyticsLinesOfCode analyticsLinesOfCode)
        : base(analyticsLinesOfCode) { }
#pragma warning restore CS8618

    public AnalyticsLinesOfCode(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AnalyticsLinesOfCode(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AnalyticsLinesOfCodeFromRaw.FromRawUnchecked"/>
    public static AnalyticsLinesOfCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AnalyticsLinesOfCodeFromRaw : IFromRawJson<AnalyticsLinesOfCode>
{
    /// <inheritdoc/>
    public AnalyticsLinesOfCode FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AnalyticsLinesOfCode.FromRawUnchecked(rawData);
}
