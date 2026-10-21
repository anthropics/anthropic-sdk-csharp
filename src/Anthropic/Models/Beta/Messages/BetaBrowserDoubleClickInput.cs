using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Double left-click at a viewport coordinate or on an element by reference.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserDoubleClickInput, BetaBrowserDoubleClickInputFromRaw>)
)]
public sealed record class BetaBrowserDoubleClickInput : JsonModel
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

    public BetaBrowserDoubleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserDoubleClickInput(BetaBrowserDoubleClickInput betaBrowserDoubleClickInput)
        : base(betaBrowserDoubleClickInput) { }
#pragma warning restore CS8618

    public BetaBrowserDoubleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserDoubleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserDoubleClickInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserDoubleClickInput(BetaBrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserDoubleClickInputFromRaw : IFromRawJson<BetaBrowserDoubleClickInput>
{
    /// <inheritdoc/>
    public BetaBrowserDoubleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserDoubleClickInput.FromRawUnchecked(rawData);
}
