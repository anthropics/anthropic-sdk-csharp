using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Return the network requests (method, URL, status, MIME type, timing) recorded
/// since the driver attached to the tab and since the last read, one line per entry.
/// An empty result does not mean no traffic for a tab that predates attach.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserReadNetworkInput, BrowserReadNetworkInputFromRaw>))]
public sealed record class BrowserReadNetworkInput : JsonModel
{
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
        _ = this.TabID;
    }

    public BrowserReadNetworkInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserReadNetworkInput(BrowserReadNetworkInput browserReadNetworkInput)
        : base(browserReadNetworkInput) { }
#pragma warning restore CS8618

    public BrowserReadNetworkInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserReadNetworkInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserReadNetworkInputFromRaw.FromRawUnchecked"/>
    public static BrowserReadNetworkInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserReadNetworkInputFromRaw : IFromRawJson<BrowserReadNetworkInput>
{
    /// <inheritdoc/>
    public BrowserReadNetworkInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrowserReadNetworkInput.FromRawUnchecked(rawData);
}
