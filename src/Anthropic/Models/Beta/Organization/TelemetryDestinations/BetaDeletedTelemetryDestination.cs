using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// Confirmation that a destination was deleted.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaDeletedTelemetryDestination,
        BetaDeletedTelemetryDestinationFromRaw
    >)
)]
public sealed record class BetaDeletedTelemetryDestination : JsonModel
{
    /// <summary>
    /// ID of the deleted destination (`tdst_...`).
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("telemetry_destination_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDeletedTelemetryDestination()
    {
        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDeletedTelemetryDestination(
        BetaDeletedTelemetryDestination betaDeletedTelemetryDestination
    )
        : base(betaDeletedTelemetryDestination) { }
#pragma warning restore CS8618

    public BetaDeletedTelemetryDestination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("telemetry_destination_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDeletedTelemetryDestination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDeletedTelemetryDestinationFromRaw.FromRawUnchecked"/>
    public static BetaDeletedTelemetryDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDeletedTelemetryDestination(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaDeletedTelemetryDestinationFromRaw : IFromRawJson<BetaDeletedTelemetryDestination>
{
    /// <inheritdoc/>
    public BetaDeletedTelemetryDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDeletedTelemetryDestination.FromRawUnchecked(rawData);
}
