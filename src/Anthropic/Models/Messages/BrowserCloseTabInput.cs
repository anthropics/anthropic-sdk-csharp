using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Close the tab with the given tab_id.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserCloseTabInput, BrowserCloseTabInputFromRaw>))]
public sealed record class BrowserCloseTabInput : JsonModel
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

    public BrowserCloseTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserCloseTabInput(BrowserCloseTabInput browserCloseTabInput)
        : base(browserCloseTabInput) { }
#pragma warning restore CS8618

    public BrowserCloseTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserCloseTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserCloseTabInputFromRaw.FromRawUnchecked"/>
    public static BrowserCloseTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserCloseTabInput(string tabID)
        : this()
    {
        this.TabID = tabID;
    }
}

class BrowserCloseTabInputFromRaw : IFromRawJson<BrowserCloseTabInput>
{
    /// <inheritdoc/>
    public BrowserCloseTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserCloseTabInput.FromRawUnchecked(rawData);
}
