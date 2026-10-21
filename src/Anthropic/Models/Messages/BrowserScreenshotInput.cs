using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Capture the current browser viewport.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserScreenshotInput, BrowserScreenshotInputFromRaw>))]
public sealed record class BrowserScreenshotInput : JsonModel
{
    /// <summary>
    /// Tab to act on. Defaults to the active tab when omitted.
    /// </summary>
    public string? TabID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tab_id");
        }
        init { this._rawData.Set("tab_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.TabID;
    }

    public BrowserScreenshotInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserScreenshotInput(BrowserScreenshotInput browserScreenshotInput)
        : base(browserScreenshotInput) { }
#pragma warning restore CS8618

    public BrowserScreenshotInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserScreenshotInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserScreenshotInputFromRaw.FromRawUnchecked"/>
    public static BrowserScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserScreenshotInputFromRaw : IFromRawJson<BrowserScreenshotInput>
{
    /// <inheritdoc/>
    public BrowserScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserScreenshotInput.FromRawUnchecked(rawData);
}
