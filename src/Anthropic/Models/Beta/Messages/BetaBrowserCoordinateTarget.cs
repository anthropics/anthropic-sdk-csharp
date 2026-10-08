using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// A point in the browser viewport, in viewport pixels (the same frame as a full-viewport screenshot).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaBrowserCoordinateTarget, BetaBrowserCoordinateTargetFromRaw>)
)]
public sealed record class BetaBrowserCoordinateTarget : JsonModel
{
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Pixels from the left edge of the viewport.
    /// </summary>
    public required long X
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("x");
        }
        init { this._rawData.Set("x", value); }
    }

    /// <summary>
    /// Pixels from the top edge of the viewport.
    /// </summary>
    public required long Y
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("y");
        }
        init { this._rawData.Set("y", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("coordinate")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.X;
        _ = this.Y;
    }

    public BetaBrowserCoordinateTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("coordinate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaBrowserCoordinateTarget(BetaBrowserCoordinateTarget betaBrowserCoordinateTarget)
        : base(betaBrowserCoordinateTarget) { }
#pragma warning restore CS8618

    public BetaBrowserCoordinateTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("coordinate");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaBrowserCoordinateTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaBrowserCoordinateTargetFromRaw.FromRawUnchecked"/>
    public static BetaBrowserCoordinateTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaBrowserCoordinateTargetFromRaw : IFromRawJson<BetaBrowserCoordinateTarget>
{
    /// <inheritdoc/>
    public BetaBrowserCoordinateTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaBrowserCoordinateTarget.FromRawUnchecked(rawData);
}
