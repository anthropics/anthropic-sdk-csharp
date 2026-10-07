using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// List all open tabs with each tab's tab_id, title, and URL.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserListTabsInput, BetaBrowserListTabsInputFromRaw>)
)]
public sealed record class BetaBrowserListTabsInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaBrowserListTabsInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserListTabsInput(BetaBrowserListTabsInput betaBrowserListTabsInput)
        : base(betaBrowserListTabsInput) { }
#pragma warning restore CS8618

    public BetaBrowserListTabsInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserListTabsInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserListTabsInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserListTabsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserListTabsInputFromRaw : IFromRawJson<BetaBrowserListTabsInput>
{
    /// <inheritdoc/>
    public BetaBrowserListTabsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserListTabsInput.FromRawUnchecked(rawData);
}
