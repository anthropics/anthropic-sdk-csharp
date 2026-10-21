using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Release the left mouse button at a viewport coordinate.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserLeftMouseUpInput, BrowserLeftMouseUpInputFromRaw>))]
public sealed record class BrowserLeftMouseUpInput : JsonModel
{
    /// <summary>
    /// A point in the browser viewport, in viewport pixels (the same frame as a
    /// full-viewport screenshot).
    /// </summary>
    public required BrowserCoordinateTarget Target
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BrowserCoordinateTarget>("target");
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

    public BrowserLeftMouseUpInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserLeftMouseUpInput(BrowserLeftMouseUpInput browserLeftMouseUpInput)
        : base(browserLeftMouseUpInput) { }
#pragma warning restore CS8618

    public BrowserLeftMouseUpInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserLeftMouseUpInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserLeftMouseUpInputFromRaw.FromRawUnchecked"/>
    public static BrowserLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrowserLeftMouseUpInput(BrowserCoordinateTarget target)
        : this()
    {
        this.Target = target;
    }
}

class BrowserLeftMouseUpInputFromRaw : IFromRawJson<BrowserLeftMouseUpInput>
{
    /// <inheritdoc/>
    public BrowserLeftMouseUpInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserLeftMouseUpInput.FromRawUnchecked(rawData);
}
