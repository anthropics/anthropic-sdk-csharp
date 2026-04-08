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
/// Confirmation of a deleted credential.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsDeletedCredential,
        BetaManagedAgentsDeletedCredentialFromRaw
    >)
)]
public sealed record class BetaManagedAgentsDeletedCredential : JsonModel
{
    /// <summary>
    /// Unique identifier of the deleted credential.
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

    public required ApiEnum<string, BetaManagedAgentsDeletedCredentialType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsDeletedCredentialType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public BetaManagedAgentsDeletedCredential() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedCredential(
        BetaManagedAgentsDeletedCredential betaManagedAgentsDeletedCredential
    )
        : base(betaManagedAgentsDeletedCredential) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedCredential(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedCredential(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedCredentialFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeletedCredentialFromRaw : IFromRawJson<BetaManagedAgentsDeletedCredential>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedCredential.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsDeletedCredentialTypeConverter))]
public enum BetaManagedAgentsDeletedCredentialType
{
    VaultCredentialDeleted,
}

sealed class BetaManagedAgentsDeletedCredentialTypeConverter
    : JsonConverter<BetaManagedAgentsDeletedCredentialType>
{
    public override BetaManagedAgentsDeletedCredentialType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_credential_deleted" =>
                BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted,
            _ => (BetaManagedAgentsDeletedCredentialType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsDeletedCredentialType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsDeletedCredentialType.VaultCredentialDeleted =>
                    "vault_credential_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
