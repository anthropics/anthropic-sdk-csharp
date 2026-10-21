using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Return a structured accessibility tree of the page (or the subtree rooted at `ref`),
/// with element references like [ref_7] that can be used as targets on later actions.
/// Output is capped at 50,000 characters — narrow with `ref` or a smaller `depth`
/// when exceeded.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserReadPageInput, BrowserReadPageInputFromRaw>))]
public sealed record class BrowserReadPageInput : JsonModel
{
    /// <summary>
    /// Maximum tree depth. Default 15.
    /// </summary>
    public long? Depth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("depth");
        }
        init { this._rawData.Set("depth", value); }
    }

    /// <summary>
    /// Which elements to include. Omitted: every visible element. "interactive":
    /// interactive elements only. "all": additionally includes off-viewport elements.
    /// </summary>
    public ApiEnum<string, BrowserReadPageFilter>? Filter
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BrowserReadPageFilter>>("filter");
        }
        init { this._rawData.Set("filter", value); }
    }

    /// <summary>
    /// Element reference to read a subtree from. Omit to read from the page root.
    /// </summary>
    public string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
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
        _ = this.Depth;
        this.Filter?.Validate();
        _ = this.Ref;
        _ = this.TabID;
    }

    public BrowserReadPageInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserReadPageInput(BrowserReadPageInput browserReadPageInput)
        : base(browserReadPageInput) { }
#pragma warning restore CS8618

    public BrowserReadPageInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserReadPageInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserReadPageInputFromRaw.FromRawUnchecked"/>
    public static BrowserReadPageInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserReadPageInputFromRaw : IFromRawJson<BrowserReadPageInput>
{
    /// <inheritdoc/>
    public BrowserReadPageInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserReadPageInput.FromRawUnchecked(rawData);
}
