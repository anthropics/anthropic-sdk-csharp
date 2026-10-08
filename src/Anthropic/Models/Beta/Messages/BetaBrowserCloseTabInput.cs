using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Close the tab with the given tab_id.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserCloseTabInput, BetaBrowserCloseTabInputFromRaw>)
)]
public sealed record class BetaBrowserCloseTabInput : JsonModel
{
    /// <summary>
    /// The tab to close.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
    }

    public BetaBrowserCloseTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserCloseTabInput(BetaBrowserCloseTabInput betaBrowserCloseTabInput)
        : base(betaBrowserCloseTabInput) { }
#pragma warning restore CS8618

    public BetaBrowserCloseTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserCloseTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserCloseTabInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserCloseTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserCloseTabInput(string tabID)
        : this()
    {
        this.TabID = tabID;
    }
}

class BetaBrowserCloseTabInputFromRaw : IFromRawJson<BetaBrowserCloseTabInput>
{
    /// <inheritdoc/>
    public BetaBrowserCloseTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserCloseTabInput.FromRawUnchecked(rawData);
}
