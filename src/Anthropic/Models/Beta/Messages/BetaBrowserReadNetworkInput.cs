using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Return the network requests (method, URL, status, MIME type, timing) recorded
/// since the driver attached to the tab and since the last read, one line per entry.
/// An empty result does not mean no traffic for a tab that predates attach.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserReadNetworkInput, BetaBrowserReadNetworkInputFromRaw>)
)]
public sealed record class BetaBrowserReadNetworkInput : JsonModel
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

    public BetaBrowserReadNetworkInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserReadNetworkInput(BetaBrowserReadNetworkInput betaBrowserReadNetworkInput)
        : base(betaBrowserReadNetworkInput) { }
#pragma warning restore CS8618

    public BetaBrowserReadNetworkInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserReadNetworkInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserReadNetworkInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserReadNetworkInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserReadNetworkInputFromRaw : IFromRawJson<BetaBrowserReadNetworkInput>
{
    /// <inheritdoc/>
    public BetaBrowserReadNetworkInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserReadNetworkInput.FromRawUnchecked(rawData);
}
