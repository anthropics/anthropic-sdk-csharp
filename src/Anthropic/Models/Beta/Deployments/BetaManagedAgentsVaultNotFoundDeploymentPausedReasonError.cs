using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Deployments;

/// <summary>
/// A vault referenced by the deployment no longer exists.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError,
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError betaManagedAgentsVaultNotFoundDeploymentPausedReasonError
    )
        : base(betaManagedAgentsVaultNotFoundDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultNotFoundDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType
{
    VaultNotFoundError,
}

sealed class BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_not_found_error" =>
                BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType.VaultNotFoundError,
            _ => (BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsVaultNotFoundDeploymentPausedReasonErrorType.VaultNotFoundError =>
                    "vault_not_found_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
