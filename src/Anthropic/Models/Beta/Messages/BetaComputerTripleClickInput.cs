using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Triple-click the left mouse button at the specified (x, y) pixel coordinate,
/// or the current cursor position if `coordinate` is omitted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaComputerTripleClickInput, BetaComputerTripleClickInputFromRaw>)
)]
public sealed record class BetaComputerTripleClickInput : JsonModel
{
    /// <summary>
    /// (x, y): x pixels from the left edge, y pixels from the top edge.
    /// </summary>
    public IReadOnlyList<long>? Coordinate
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>("coordinate");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>?>(
                "coordinate",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional key combination to hold down during this action (e.g. "ctrl", "shift", "ctrl+shift").
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Coordinate;
        _ = this.Text;
    }

    public BetaComputerTripleClickInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerTripleClickInput(BetaComputerTripleClickInput betaComputerTripleClickInput)
        : base(betaComputerTripleClickInput) { }
#pragma warning restore CS8618

    public BetaComputerTripleClickInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerTripleClickInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerTripleClickInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerTripleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaComputerTripleClickInputFromRaw : IFromRawJson<BetaComputerTripleClickInput>
{
    /// <inheritdoc/>
    public BetaComputerTripleClickInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerTripleClickInput.FromRawUnchecked(rawData);
}
