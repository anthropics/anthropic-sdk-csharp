using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Triple left-click at a viewport coordinate or on an element by reference (typically
/// selects a line or paragraph).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserTripleClickInput, BetaBrowserTripleClickInputFromRaw>)
)]
public sealed record class BetaBrowserTripleClickInput : JsonModel
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

    public BetaBrowserTripleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserTripleClickInput(BetaBrowserTripleClickInput betaBrowserTripleClickInput)
        : base(betaBrowserTripleClickInput) { }
#pragma warning restore CS8618

    public BetaBrowserTripleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserTripleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserTripleClickInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserTripleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserTripleClickInput(BetaBrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserTripleClickInputFromRaw : IFromRawJson<BetaBrowserTripleClickInput>
{
    /// <inheritdoc/>
    public BetaBrowserTripleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserTripleClickInput.FromRawUnchecked(rawData);
}
