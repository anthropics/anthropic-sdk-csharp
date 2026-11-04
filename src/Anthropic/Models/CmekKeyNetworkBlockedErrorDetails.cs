using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

/// <summary>
/// The key management service's network access controls blocked the request to the
/// workspace's customer-managed encryption key. The key itself may be healthy.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        CmekKeyNetworkBlockedErrorDetails,
        CmekKeyNetworkBlockedErrorDetailsFromRaw
    >)
)]
public sealed record class CmekKeyNetworkBlockedErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("cmek_key_network_blocked")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public CmekKeyNetworkBlockedErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_network_blocked");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CmekKeyNetworkBlockedErrorDetails(
        CmekKeyNetworkBlockedErrorDetails cmekKeyNetworkBlockedErrorDetails
    )
        : base(cmekKeyNetworkBlockedErrorDetails) { }
#pragma warning restore CS8618

    public CmekKeyNetworkBlockedErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("cmek_key_network_blocked");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CmekKeyNetworkBlockedErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CmekKeyNetworkBlockedErrorDetailsFromRaw.FromRawUnchecked"/>
    public static CmekKeyNetworkBlockedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CmekKeyNetworkBlockedErrorDetailsFromRaw : IFromRawJson<CmekKeyNetworkBlockedErrorDetails>
{
    /// <inheritdoc/>
    public CmekKeyNetworkBlockedErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CmekKeyNetworkBlockedErrorDetails.FromRawUnchecked(rawData);
}
