using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Open a new empty tab and return its tab_id.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrowserNewTabInput, BrowserNewTabInputFromRaw>))]
public sealed record class BrowserNewTabInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BrowserNewTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrowserNewTabInput(BrowserNewTabInput browserNewTabInput)
        : base(browserNewTabInput) { }
#pragma warning restore CS8618

    public BrowserNewTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrowserNewTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrowserNewTabInputFromRaw.FromRawUnchecked"/>
    public static BrowserNewTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrowserNewTabInputFromRaw : IFromRawJson<BrowserNewTabInput>
{
    /// <inheritdoc/>
    public BrowserNewTabInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrowserNewTabInput.FromRawUnchecked(rawData);
}
