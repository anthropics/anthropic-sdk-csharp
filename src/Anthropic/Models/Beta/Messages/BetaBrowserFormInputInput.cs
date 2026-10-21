using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Set the value of a form element (input, textarea, select, checkbox). Use a boolean
/// for checkboxes, an option value or text for selects.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserFormInputInput, BetaBrowserFormInputInputFromRaw>)
)]
public sealed record class BetaBrowserFormInputInput : JsonModel
{
    /// <summary>
    /// An element on the page, identified by a reference from a prior `read_page`
    /// or `find` result. References are scoped to the tab that produced them and
    /// become stale after navigation or a major re-render.
    /// </summary>
    public required BetaBrowserRefTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserRefTarget>("target");
        }
        init { this._rawData.Set("target", value); }
    }

    /// <summary>
    /// The value to set.
    /// </summary>
    public required BetaBrowserFormInputValue Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaBrowserFormInputValue>("value");
        }
        init { this._rawData.Set("value", value); }
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
        this.Value.Validate();
        _ = this.TabID;
    }

    public BetaBrowserFormInputInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserFormInputInput(BetaBrowserFormInputInput betaBrowserFormInputInput)
        : base(betaBrowserFormInputInput) { }
#pragma warning restore CS8618

    public BetaBrowserFormInputInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserFormInputInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserFormInputInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserFormInputInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserFormInputInputFromRaw : IFromRawJson<BetaBrowserFormInputInput>
{
    /// <inheritdoc/>
    public BetaBrowserFormInputInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserFormInputInput.FromRawUnchecked(rawData);
}
