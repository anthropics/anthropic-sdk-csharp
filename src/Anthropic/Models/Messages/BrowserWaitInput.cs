using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Pause for the given duration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserWaitInput, BrowserWaitInputFromRaw>))]
public sealed record class BrowserWaitInput : JsonModel
{
    /// <summary>
    /// Seconds to wait (maximum 30).
    /// </summary>
    public required double Duration
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("duration");
        }
        init { this._rawData.Set("duration", value); }
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
        _ = this.Duration;
        _ = this.TabID;
    }

    public BrowserWaitInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserWaitInput(BrowserWaitInput browserWaitInput)
        : base(browserWaitInput) { }
#pragma warning restore CS8618

    public BrowserWaitInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserWaitInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserWaitInputFromRaw.FromRawUnchecked"/>
    public static BrowserWaitInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserWaitInput(double duration)
        : this()
    {
        this.Duration = duration;
    }
}

class BrowserWaitInputFromRaw : IFromRawJson<BrowserWaitInput>
{
    /// <inheritdoc/>
    public BrowserWaitInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserWaitInput.FromRawUnchecked(rawData);
}
