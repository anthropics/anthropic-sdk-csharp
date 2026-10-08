using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Middle-click at a viewport coordinate or on an element by reference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserMiddleClickInput, BetaBrowserMiddleClickInputFromRaw>)
)]
public sealed record class BetaBrowserMiddleClickInput : JsonModel
{
    /// <summary>
    /// Where to act: either a viewport coordinate or an element reference.
    /// </summary>
    public required BetaBrowserClickTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserClickTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// Optional modifier key chord to hold for the duration of this action (e.g.
    /// "shift", "ctrl+shift", "cmd+alt").
    /// </summary>
    public string? Modifiers
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("modifiers");
        }
        init { this._rawData.Set("modifiers", value); }
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
        this.Target.Validate();
        _ = this.Modifiers;
        _ = this.TabID;
    }

    public BetaBrowserMiddleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserMiddleClickInput(BetaBrowserMiddleClickInput betaBrowserMiddleClickInput)
        : base(betaBrowserMiddleClickInput) { }
#pragma warning restore CS8618

    public BetaBrowserMiddleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserMiddleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserMiddleClickInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserMiddleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserMiddleClickInput(BetaBrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserMiddleClickInputFromRaw : IFromRawJson<BetaBrowserMiddleClickInput>
{
    /// <inheritdoc/>
    public BetaBrowserMiddleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserMiddleClickInput.FromRawUnchecked(rawData);
}
