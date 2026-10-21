using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Return a cropped screenshot of the given viewport region, scaled up for closer
/// inspection — useful for small icons, buttons, or text. Coordinates are in the
/// same viewport-pixel space as a full screenshot.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserZoomInput, BetaBrowserZoomInputFromRaw>))]
public sealed record class BetaBrowserZoomInput : JsonModel
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

    public BetaBrowserZoomInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserZoomInput(BetaBrowserZoomInput betaBrowserZoomInput)
        : base(betaBrowserZoomInput) { }
#pragma warning restore CS8618

    public BetaBrowserZoomInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserZoomInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserZoomInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserZoomInput(IReadOnlyList<long> region)
        : this()
    {
        this.Region = region;
    }
}

class BetaBrowserZoomInputFromRaw : IFromRawJson<BetaBrowserZoomInput>
{
    /// <inheritdoc/>
    public BetaBrowserZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserZoomInput.FromRawUnchecked(rawData);
}
