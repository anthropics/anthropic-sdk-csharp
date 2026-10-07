using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Take a screenshot of a rectangular region. Region coordinates are in the full-screenshot
/// space (not physical display pixels). The crop is scaled up to fill the image budget
/// so fine details become legible.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaComputerZoomInput, BetaComputerZoomInputFromRaw>))]
public sealed record class BetaComputerZoomInput : JsonModel
{
    /// <summary>
    /// (x0, y0, x1, y1): The region to capture.
    /// </summary>
    public required IReadOnlyList<long> Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<long>>("region");
        }
        init
        {
            this._rawData.Set<ImmutableArray<long>>(
                "region",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Region;
    }

    public BetaComputerZoomInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaComputerZoomInput(BetaComputerZoomInput betaComputerZoomInput)
        : base(betaComputerZoomInput) { }
#pragma warning restore CS8618

    public BetaComputerZoomInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaComputerZoomInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaComputerZoomInputFromRaw.FromRawUnchecked"/>
    public static BetaComputerZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaComputerZoomInput(IReadOnlyList<long> region)
        : this()
    {
        this.Region = region;
    }
}

class BetaComputerZoomInputFromRaw : IFromRawJson<BetaComputerZoomInput>
{
    /// <inheritdoc/>
    public BetaComputerZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaComputerZoomInput.FromRawUnchecked(rawData);
}
