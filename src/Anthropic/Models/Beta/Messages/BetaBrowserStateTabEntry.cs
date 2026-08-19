using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// One open browser tab reported in a `browser_state` block's `tabs` inventory.
///
/// <para>`tab_id` is the caller-assigned identifier for the tab; `title` and `url`
/// describe the page the tab is currently showing and may be empty strings (a blank
/// tab legitimately has both empty). `active` marks the tab that is active after
/// this call; whenever `tabs` is non-empty, exactly one entry is marked.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserStateTabEntry, BetaBrowserStateTabEntryFromRaw>)
)]
public sealed record class BetaBrowserStateTabEntry : JsonModel
{
    /// <summary>
    /// The caller-assigned identifier for this tab, unique within the inventory.
    /// </summary>
    public required string TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <summary>
    /// The title of the page the tab is showing. May be empty.
    /// </summary>
    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <summary>
    /// The URL of the page the tab is showing. May be empty.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Whether this tab is the active tab after this call. Whenever `tabs` is non-empty,
    /// exactly one entry is marked `active: true`.
    /// </summary>
    public bool? Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("active");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
        _ = this.Title;
        _ = this.Url;
        _ = this.Active;
    }

    public BetaBrowserStateTabEntry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserStateTabEntry(BetaBrowserStateTabEntry betaBrowserStateTabEntry)
        : base(betaBrowserStateTabEntry) { }
#pragma warning restore CS8618

    public BetaBrowserStateTabEntry(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserStateTabEntry(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserStateTabEntryFromRaw.FromRawUnchecked"/>
    public static BetaBrowserStateTabEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserStateTabEntryFromRaw : IFromRawJson<BetaBrowserStateTabEntry>
{
    /// <inheritdoc/>
    public BetaBrowserStateTabEntry FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserStateTabEntry.FromRawUnchecked(rawData);
}
