using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The API disabled the destination because deliveries to it failed, with no successful
/// delivery in between, for longer than a threshold that Anthropic configures and
/// that is not part of this contract. The reason is `invalid_address` instead when
/// the most recent failed delivery failed with an invalid address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationDisabledReasonSustainedFailure,
        BetaTelemetryDestinationDisabledReasonSustainedFailureFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationDisabledReasonSustainedFailure : JsonModel
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("sustained_failure")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationDisabledReasonSustainedFailure()
    {
        this.Type = JsonSerializer.SerializeToElement("sustained_failure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationDisabledReasonSustainedFailure(
        BetaTelemetryDestinationDisabledReasonSustainedFailure betaTelemetryDestinationDisabledReasonSustainedFailure
    )
        : base(betaTelemetryDestinationDisabledReasonSustainedFailure) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationDisabledReasonSustainedFailure(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("sustained_failure");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationDisabledReasonSustainedFailure(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationDisabledReasonSustainedFailureFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationDisabledReasonSustainedFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationDisabledReasonSustainedFailureFromRaw
    : IFromRawJson<BetaTelemetryDestinationDisabledReasonSustainedFailure>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationDisabledReasonSustainedFailure FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationDisabledReasonSustainedFailure.FromRawUnchecked(rawData);
}
