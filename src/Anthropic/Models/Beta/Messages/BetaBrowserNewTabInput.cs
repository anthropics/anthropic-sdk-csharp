using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Open a new empty tab and return its tab_id.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaBrowserNewTabInput, BetaBrowserNewTabInputFromRaw>))]
public sealed record class BetaBrowserNewTabInput : JsonModel
{
    /// <inheritdoc/>
    public override void Validate() { }

    public BetaBrowserNewTabInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserNewTabInput(BetaBrowserNewTabInput betaBrowserNewTabInput)
        : base(betaBrowserNewTabInput) { }
#pragma warning restore CS8618

    public BetaBrowserNewTabInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserNewTabInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserNewTabInputFromRaw.FromRawUnchecked"/>
    public static BetaBrowserNewTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserNewTabInputFromRaw : IFromRawJson<BetaBrowserNewTabInput>
{
    /// <inheritdoc/>
    public BetaBrowserNewTabInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserNewTabInput.FromRawUnchecked(rawData);
}
