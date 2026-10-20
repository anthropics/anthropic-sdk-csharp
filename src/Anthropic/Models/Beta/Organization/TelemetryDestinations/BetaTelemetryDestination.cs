using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// An OpenTelemetry destination: an OTLP/HTTP endpoint, the request headers sent
/// with every delivery to it, what the exported spans contain, and which workspaces
/// it covers. A destination belongs to an organization. A workspace's spans go to
/// every enabled destination that covers it.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaTelemetryDestination, BetaTelemetryDestinationFromRaw>)
)]
public sealed record class BetaTelemetryDestination : JsonModel
{
    /// <summary>
    /// The unique ID of the destination (`tdst_...`).
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

    /// <summary>
    /// Time the destination was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// The most recent delivery results for this destination.
    /// </summary>
    public required BetaTelemetryDestinationDeliveryHealth DeliveryHealth
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaTelemetryDestinationDeliveryHealth>(
                "delivery_health"
            );
        }
        init { this._rawData.Set("delivery_health", value); }
    }

    /// <summary>
    /// Human-readable name for the destination. Null when none was set.
    /// </summary>
    public required string? DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("display_name");
        }
        init { this._rawData.Set("display_name", value); }
    }

    /// <summary>
    /// The base URL of the destination's OTLP/HTTP endpoint, exactly as registered.
    ///
    /// <para>The API appends the per-signal path, such as `/v1/traces`, on delivery,
    /// unless `traces.endpoint_url` is set.</para>
    /// </summary>
    public required string EndpointUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("endpoint_url");
        }
        init { this._rawData.Set("endpoint_url", value); }
    }

    /// <summary>
    /// Names of the registered request headers. Header values are write-only and
    /// are never returned.
    /// </summary>
    public required IReadOnlyList<string> HeaderNames
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("header_names");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "header_names",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Whether the destination receives deliveries.
    /// </summary>
    public required BetaTelemetryDestinationState State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaTelemetryDestinationState>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// The destination's settings for the traces it receives.
    /// </summary>
    public required BetaTelemetryDestinationTraces Traces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaTelemetryDestinationTraces>("traces");
        }
        init { this._rawData.Set("traces", value); }
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

    /// <summary>
    /// Time of the last change to the destination's configuration or state. Changes
    /// to `delivery_health` don't change it.
    ///
    /// <para>An update that sets a header value always changes it, even when the
    /// value is the same as before. Adding or removing a single workspace on the
    /// destination's list doesn't change it. An update that changes the list does.</para>
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Which of the organization's workspaces the destination covers.
    /// </summary>
    public required BetaTelemetryDestinationWorkspaces Workspaces
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaTelemetryDestinationWorkspaces>("workspaces");
        }
        init { this._rawData.Set("workspaces", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.DeliveryHealth.Validate();
        _ = this.DisplayName;
        _ = this.EndpointUrl;
        _ = this.HeaderNames;
        this.State.Validate();
        this.Traces.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("telemetry_destination")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        this.Workspaces.Validate();
    }

    public BetaTelemetryDestination()
    {
        this.Type = JsonSerializer.SerializeToElement("telemetry_destination");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestination(BetaTelemetryDestination betaTelemetryDestination)
        : base(betaTelemetryDestination) { }
#pragma warning restore CS8618

    public BetaTelemetryDestination(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("telemetry_destination");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestination(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationFromRaw : IFromRawJson<BetaTelemetryDestination>
{
    /// <inheritdoc/>
    public BetaTelemetryDestination FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestination.FromRawUnchecked(rawData);
}
