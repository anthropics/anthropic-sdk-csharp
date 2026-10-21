using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Move the cursor to a coordinate or element without clicking.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserHoverInput, BrowserHoverInputFromRaw>))]
public sealed record class BrowserHoverInput : JsonModel
{
    /// <summary>
    /// Where to act: either a viewport coordinate or an element reference.
    /// </summary>
    public required BrowserClickTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserClickTarget>("target");
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

    public BrowserHoverInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserHoverInput(BrowserHoverInput browserHoverInput)
        : base(browserHoverInput) { }
#pragma warning restore CS8618

    public BrowserHoverInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserHoverInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserHoverInputFromRaw.FromRawUnchecked"/>
    public static BrowserHoverInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserHoverInput(BrowserClickTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserHoverInputFromRaw : IFromRawJson<BrowserHoverInput>
{
    /// <inheritdoc/>
    public BrowserHoverInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserHoverInput.FromRawUnchecked(rawData);
}
