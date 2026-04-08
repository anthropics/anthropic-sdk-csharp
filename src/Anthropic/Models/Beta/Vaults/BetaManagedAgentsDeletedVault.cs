using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Vaults;

/// <summary>
/// Confirmation of a deleted vault.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaManagedAgentsDeletedVault, BetaManagedAgentsDeletedVaultFromRaw>)
)]
public sealed record class BetaManagedAgentsDeletedVault : JsonModel
{
    /// <summary>
    /// Unique identifier of the deleted vault.
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

    public required ApiEnum<string, global::Anthropic.Models.Beta.Vaults.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Beta.Vaults.Type>
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

    public BetaManagedAgentsDeletedVault() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedVault(
        BetaManagedAgentsDeletedVault betaManagedAgentsDeletedVault
    )
        : base(betaManagedAgentsDeletedVault) { }
#pragma warning restore CS8618

    public BetaManagedAgentsDeletedVault(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsDeletedVault(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsDeletedVaultFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsDeletedVault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsDeletedVaultFromRaw : IFromRawJson<BetaManagedAgentsDeletedVault>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedVault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedVault.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    VaultDeleted,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Beta.Vaults.Type>
{
    public override global::Anthropic.Models.Beta.Vaults.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "vault_deleted" => global::Anthropic.Models.Beta.Vaults.Type.VaultDeleted,
            _ => (global::Anthropic.Models.Beta.Vaults.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Beta.Vaults.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Beta.Vaults.Type.VaultDeleted => "vault_deleted",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
