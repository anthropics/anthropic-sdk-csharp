using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// A vault referenced by the deployment is archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsVaultArchivedRunError,
        BetaManagedAgentsVaultArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsVaultArchivedRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsVaultArchivedRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsVaultArchivedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsVaultArchivedRunError(
        BetaManagedAgentsVaultArchivedRunError betaManagedAgentsVaultArchivedRunError
    )
        : base(betaManagedAgentsVaultArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsVaultArchivedRunError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsVaultArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsVaultArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsVaultArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsVaultArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsVaultArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsVaultArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsVaultArchivedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsVaultArchivedRunErrorTypeConverter))]
public enum BetaManagedAgentsVaultArchivedRunErrorType
{
    VaultArchivedError,
}

sealed class BetaManagedAgentsVaultArchivedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsVaultArchivedRunErrorType>
{
    public override BetaManagedAgentsVaultArchivedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_archived_error" => BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError,
            _ => (BetaManagedAgentsVaultArchivedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsVaultArchivedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsVaultArchivedRunErrorType.VaultArchivedError =>
                    "vault_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
