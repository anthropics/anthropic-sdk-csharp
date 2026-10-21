using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Return a cropped screenshot of the given viewport region, scaled up for closer
/// inspection — useful for small icons, buttons, or text. Coordinates are in the
/// same viewport-pixel space as a full screenshot.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserZoomInput, BrowserZoomInputFromRaw>))]
public sealed record class BrowserZoomInput : JsonModel
{
    /// <summary>
    /// [x0, y0, x1, y1] in viewport pixels.
    /// </summary>
    public required IReadOnlyList<long> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("region");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "region",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
        _ = this.Region;
        _ = this.TabID;
    }

    public BrowserZoomInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserZoomInput(BrowserZoomInput browserZoomInput)
        : base(browserZoomInput) { }
#pragma warning restore CS8618

    public BrowserZoomInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserZoomInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserZoomInputFromRaw.FromRawUnchecked"/>
    public static BrowserZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserZoomInput(IReadOnlyList<long> region)
        : this()
    {
        this.Region = region;
    }
}

class BrowserZoomInputFromRaw : IFromRawJson<BrowserZoomInput>
{
    /// <inheritdoc/>
    public BrowserZoomInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserZoomInput.FromRawUnchecked(rawData);
}
