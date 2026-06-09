using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// The secret is substituted on any host the session's Environment network policy
/// permits egress to.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse,
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnrestrictedCredentialNetworkingResponse : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponse betaManagedAgentsUnrestrictedCredentialNetworkingResponse
    )
        : base(betaManagedAgentsUnrestrictedCredentialNetworkingResponse) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnrestrictedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse(
        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsUnrestrictedCredentialNetworkingResponseFromRaw
    : IFromRawJson<BetaManagedAgentsUnrestrictedCredentialNetworkingResponse>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnrestrictedCredentialNetworkingResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnrestrictedCredentialNetworkingResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUnrestrictedCredentialNetworkingResponseTypeConverter))]
public enum BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType
{
    Unrestricted,
}

sealed class BetaManagedAgentsUnrestrictedCredentialNetworkingResponseTypeConverter
    : JsonConverter<BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType>
{
    public override BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unrestricted" =>
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted,
            _ => (BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUnrestrictedCredentialNetworkingResponseType.Unrestricted =>
                    "unrestricted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
