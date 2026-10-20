using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The API disabled the destination because deliveries to it failed for longer than
/// the same threshold as for `sustained_failure`, and the most recent failed delivery
/// failed with an invalid address: the DNS answer says that the endpoint's hostname
/// doesn't exist or doesn't have an address, or the address that the API would connect
/// to isn't publicly routable or is reserved, for example a loopback, link-local,
/// private-network, or cloud-metadata address. The API doesn't connect to such an
/// address, and retries the delivery a bounded number of times as it does after
/// a timeout. A timeout or a server failure of the DNS lookup is a temporary DNS
/// failure instead, not an invalid address.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationDisabledReasonInvalidAddress,
        BetaTelemetryDestinationDisabledReasonInvalidAddressFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationDisabledReasonInvalidAddress : JsonModel
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
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("invalid_address"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaTelemetryDestinationDisabledReasonInvalidAddress()
    {
        this.Type = JsonSerializer.SerializeToElement("invalid_address");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationDisabledReasonInvalidAddress(
        BetaTelemetryDestinationDisabledReasonInvalidAddress betaTelemetryDestinationDisabledReasonInvalidAddress
    )
        : base(betaTelemetryDestinationDisabledReasonInvalidAddress) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationDisabledReasonInvalidAddress(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invalid_address");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationDisabledReasonInvalidAddress(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationDisabledReasonInvalidAddressFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationDisabledReasonInvalidAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationDisabledReasonInvalidAddressFromRaw
    : IFromRawJson<BetaTelemetryDestinationDisabledReasonInvalidAddress>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationDisabledReasonInvalidAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationDisabledReasonInvalidAddress.FromRawUnchecked(rawData);
}
