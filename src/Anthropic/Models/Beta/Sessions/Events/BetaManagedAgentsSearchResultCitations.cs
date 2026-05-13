using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Citation settings for a search result.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsSearchResultCitations,
        BetaManagedAgentsSearchResultCitationsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsSearchResultCitations : JsonModel
{
    /// <summary>
    /// Whether citations are enabled for this search result.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
    }

    public BetaManagedAgentsSearchResultCitations() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultCitations(
        BetaManagedAgentsSearchResultCitations betaManagedAgentsSearchResultCitations
    )
        : base(betaManagedAgentsSearchResultCitations) { }
#pragma warning restore CS8618

    public BetaManagedAgentsSearchResultCitations(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsSearchResultCitations(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsSearchResultCitationsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsSearchResultCitations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsSearchResultCitations(bool enabled)
        : this()
    {
        this.Enabled = enabled;
    }
}

class BetaManagedAgentsSearchResultCitationsFromRaw
    : IFromRawJson<BetaManagedAgentsSearchResultCitations>
{
    /// <inheritdoc/>
    public BetaManagedAgentsSearchResultCitations FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsSearchResultCitations.FromRawUnchecked(rawData);
}
