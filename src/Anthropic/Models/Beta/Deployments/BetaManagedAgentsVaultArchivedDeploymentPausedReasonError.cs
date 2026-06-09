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
/// A vault referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError,
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultArchivedDeploymentPausedReasonError : JsonModel
{
    public required ApiEnum<
        string,
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType
    > Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
    }

    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonError betaManagedAgentsVaultArchivedDeploymentPausedReasonError
    )
        : base(betaManagedAgentsVaultArchivedDeploymentPausedReasonError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        FrozenDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError(
        ApiEnum<string, BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultArchivedDeploymentPausedReasonError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultArchivedDeploymentPausedReasonError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultArchivedDeploymentPausedReasonError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorTypeConverter))]
public enum BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType
{
    VaultArchivedError,
}

sealed class BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorTypeConverter
    : JsonConverter<BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType>
{
    public override BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_archived_error" =>
                BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError,
            _ => (BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsVaultArchivedDeploymentPausedReasonErrorType.VaultArchivedError =>
                    "vault_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
