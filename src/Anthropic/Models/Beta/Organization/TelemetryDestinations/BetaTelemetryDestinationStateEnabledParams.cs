using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Start deliveries to the telemetry destination again.
///
/// <para>This doesn't reset `delivery_health`.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationStateEnabledParams,
        BetaTelemetryDestinationStateEnabledParamsFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationStateEnabledParams : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("enabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationStateEnabledParams()
    {
        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationStateEnabledParams(
        BetaTelemetryDestinationStateEnabledParams betaTelemetryDestinationStateEnabledParams
    )
        : base(betaTelemetryDestinationStateEnabledParams) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationStateEnabledParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("enabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationStateEnabledParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationStateEnabledParamsFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationStateEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationStateEnabledParamsFromRaw
    : IFromRawJson<BetaTelemetryDestinationStateEnabledParams>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationStateEnabledParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationStateEnabledParams.FromRawUnchecked(rawData);
}
