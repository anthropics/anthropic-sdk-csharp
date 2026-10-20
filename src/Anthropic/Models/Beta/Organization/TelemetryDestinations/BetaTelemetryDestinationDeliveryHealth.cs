using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The most recent delivery results that the API records for a telemetry destination.
///
/// <para>Changes to the destination's configuration or state don't reset these fields.
/// Changes to these fields don't change `updated_at`. The values can lag behind the
/// latest deliveries.</para>
///
/// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-and-health)
/// to learn how the API delivers spans and when it disables a destination.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationDeliveryHealth,
        BetaTelemetryDestinationDeliveryHealthFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationDeliveryHealth : JsonModel
{
    /// <summary>
    /// A message that describes the most recent failed delivery to the destination,
    /// or `null` if no delivery has failed yet.
    ///
    /// <para>Examples are `temporary DNS failure`, `TLS failure`, `timeout`, `connection
    /// failure`, `invalid address`, `HTTP error (status 503)`, and `redirect (status
    /// 301)`. The message is `invalid address` both for a hostname that doesn't exist
    /// and for an address that isn't publicly routable. It never contains the endpoint's
    /// response body, a header value, a network address, or TLS details.</para>
    ///
    /// <para>`last_error` and `last_error_at` always change together. A later successful
    /// delivery doesn't clear them. If `last_success_at` is later than `last_error_at`,
    /// a delivery has succeeded since this failure.</para>
    ///
    /// <para>See the [OpenTelemetry export guide](https://platform.claude.com/docs/en/manage-claude/opentelemetry#delivery-errors)
    /// to learn the likely cause of each error.</para>
    /// </summary>
    public required string? LastError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_error");
        }
        init { this._rawData.Set("last_error", value); }
    }

    /// <summary>
    /// Time of the failure that `last_error` describes. Changes together with `last_error`.
    /// Null until a delivery first fails.
    /// </summary>
    public required DateTimeOffset? LastErrorAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_error_at");
        }
        init { this._rawData.Set("last_error_at", value); }
    }

    /// <summary>
    /// Time of the most recent successful delivery to the destination, or `null`
    /// if no delivery has succeeded yet.
    /// </summary>
    public required DateTimeOffset? LastSuccessAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("last_success_at");
        }
        init { this._rawData.Set("last_success_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LastError;
        _ = this.LastErrorAt;
        _ = this.LastSuccessAt;
    }

    public BetaTelemetryDestinationDeliveryHealth() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationDeliveryHealth(
        BetaTelemetryDestinationDeliveryHealth betaTelemetryDestinationDeliveryHealth
    )
        : base(betaTelemetryDestinationDeliveryHealth) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationDeliveryHealth(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationDeliveryHealth(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationDeliveryHealthFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationDeliveryHealth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationDeliveryHealthFromRaw
    : IFromRawJson<BetaTelemetryDestinationDeliveryHealth>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationDeliveryHealth FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationDeliveryHealth.FromRawUnchecked(rawData);
}
