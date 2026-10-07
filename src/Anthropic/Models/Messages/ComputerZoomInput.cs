using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

/// <summary>
/// Take a screenshot of a rectangular region. Region coordinates are in the full-screenshot
/// space (not physical display pixels). The crop is scaled up to fill the image budget
/// so fine details become legible.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ComputerZoomInput, ComputerZoomInputFromRaw>))]
public sealed record class ComputerZoomInput : JsonModel
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

    public ComputerZoomInput() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ComputerZoomInput(ComputerZoomInput computerZoomInput)
        : base(computerZoomInput) { }
#pragma warning restore CS8618

    public ComputerZoomInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ComputerZoomInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ComputerZoomInputFromRaw.FromRawUnchecked"/>
    public static ComputerZoomInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ComputerZoomInput(IReadOnlyList<long> region)
        : this()
    {
        this.Region = region;
    }
}

class ComputerZoomInputFromRaw : IFromRawJson<ComputerZoomInput>
{
    /// <inheritdoc/>
    public ComputerZoomInput FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ComputerZoomInput.FromRawUnchecked(rawData);
}
