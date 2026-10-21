using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Capture the current browser viewport.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserScreenshotInput, BetaBrowserScreenshotInputFromRaw>)
)]
public sealed record class BetaBrowserScreenshotInput : JsonModel
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

    public BetaBrowserScreenshotInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserScreenshotInput(BetaBrowserScreenshotInput betaBrowserScreenshotInput)
        : base(betaBrowserScreenshotInput) { }
#pragma warning restore CS8618

    public BetaBrowserScreenshotInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserScreenshotInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserScreenshotInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserScreenshotInputFromRaw : IFromRawJson<BetaBrowserScreenshotInput>
{
    /// <inheritdoc/>
    public BetaBrowserScreenshotInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserScreenshotInput.FromRawUnchecked(rawData);
}
