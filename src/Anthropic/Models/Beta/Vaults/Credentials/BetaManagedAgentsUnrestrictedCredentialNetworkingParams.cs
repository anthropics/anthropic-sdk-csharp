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
/// Substitute the secret on any host the session's Environment network policy permits
/// egress to. The Environment's network policy is the only boundary on where the
/// secret can reach.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams,
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsUnrestrictedCredentialNetworkingParams : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        BetaManagedAgentsUnrestrictedCredentialNetworkingParams betaManagedAgentsUnrestrictedCredentialNetworkingParams
    )
        : base(betaManagedAgentsUnrestrictedCredentialNetworkingParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsUnrestrictedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams(
        ApiEnum<string, BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsUnrestrictedCredentialNetworkingParamsFromRaw
    : IFromRawJson<BetaManagedAgentsUnrestrictedCredentialNetworkingParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsUnrestrictedCredentialNetworkingParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsUnrestrictedCredentialNetworkingParams.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsUnrestrictedCredentialNetworkingParamsTypeConverter))]
public enum BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType
{
    Unrestricted,
}

sealed class BetaManagedAgentsUnrestrictedCredentialNetworkingParamsTypeConverter
    : JsonConverter<BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType>
{
    public override BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unrestricted" =>
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted,
            _ => (BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsUnrestrictedCredentialNetworkingParamsType.Unrestricted =>
                    "unrestricted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
