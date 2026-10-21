using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Stop deliveries to the telemetry destination.
///
/// <para>Spans produced while it is disabled aren't delivered later. A destination
/// that is already disabled keeps its `reason`.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationStateDisabledParams,
        BetaTelemetryDestinationStateDisabledParamsFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationStateDisabledParams : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationStateDisabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationStateDisabledParams(
        BetaTelemetryDestinationStateDisabledParams betaTelemetryDestinationStateDisabledParams
    )
        : base(betaTelemetryDestinationStateDisabledParams) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationStateDisabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationStateDisabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationStateDisabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationStateDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationStateDisabledParamsFromRaw
    : IFromRawJson<BetaTelemetryDestinationStateDisabledParams>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationStateDisabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationStateDisabledParams.FromRawUnchecked(rawData);
}
