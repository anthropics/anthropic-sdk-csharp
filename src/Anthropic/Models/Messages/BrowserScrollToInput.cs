using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Scroll an element into view.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserScrollToInput, BrowserScrollToInputFromRaw>))]
public sealed record class BrowserScrollToInput : JsonModel
{
    /// <summary>
    /// An element on the page, identified by a reference from a prior `read_page`
    /// or `find` result. References are scoped to the tab that produced them and
    /// become stale after navigation or a major re-render.
    /// </summary>
    public required BrowserRefTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserRefTarget>("target");
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

    public BrowserScrollToInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserScrollToInput(BrowserScrollToInput browserScrollToInput)
        : base(browserScrollToInput) { }
#pragma warning restore CS8618

    public BrowserScrollToInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserScrollToInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserScrollToInputFromRaw.FromRawUnchecked"/>
    public static BrowserScrollToInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserScrollToInput(BrowserRefTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserScrollToInputFromRaw : IFromRawJson<BrowserScrollToInput>
{
    /// <inheritdoc/>
    public BrowserScrollToInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserScrollToInput.FromRawUnchecked(rawData);
}
