using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Scroll an element into view.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserScrollToInput, BetaBrowserScrollToInputFromRaw>)
)]
public sealed record class BetaBrowserScrollToInput : JsonModel
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
        _ = this.TabID;
    }

    public BetaBrowserScrollToInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserScrollToInput(BetaBrowserScrollToInput betaBrowserScrollToInput)
        : base(betaBrowserScrollToInput) { }
#pragma warning restore CS8618

    public BetaBrowserScrollToInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserScrollToInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserScrollToInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserScrollToInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaBrowserScrollToInput(BetaBrowserRefTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BetaBrowserScrollToInputFromRaw : IFromRawJson<BetaBrowserScrollToInput>
{
    /// <inheritdoc/>
    public BetaBrowserScrollToInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserScrollToInput.FromRawUnchecked(rawData);
}
