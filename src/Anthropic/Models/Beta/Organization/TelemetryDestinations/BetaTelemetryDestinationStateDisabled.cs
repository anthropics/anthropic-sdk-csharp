using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The API doesn't deliver anything to the telemetry destination.
///
/// <para>Spans produced while it is disabled aren't delivered later.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationStateDisabled,
        BetaTelemetryDestinationStateDisabledFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationStateDisabled : JsonModel
{
    /// <summary>
    /// Whether a caller or the API disabled the destination and, when the API did,
    /// why. Read-only.
    /// </summary>
    public required BetaTelemetryDestinationDisabledReason Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaTelemetryDestinationDisabledReason>("reason");
        }
        init { this._rawData.Set("reason", value); }
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
        this.Reason.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("disabled")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationStateDisabled()
    {
        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationStateDisabled(
        BetaTelemetryDestinationStateDisabled betaTelemetryDestinationStateDisabled
    )
        : base(betaTelemetryDestinationStateDisabled) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationStateDisabled(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("disabled");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationStateDisabled(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationStateDisabledFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaTelemetryDestinationStateDisabled(BetaTelemetryDestinationDisabledReason reason)
        : this()
    {
        this.Reason = reason;
    }
}

class BetaTelemetryDestinationStateDisabledFromRaw
    : IFromRawJson<BetaTelemetryDestinationStateDisabled>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationStateDisabled FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationStateDisabled.FromRawUnchecked(rawData);
}
