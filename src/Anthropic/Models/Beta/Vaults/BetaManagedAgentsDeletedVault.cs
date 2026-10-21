using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// The unique ID of the deleted vault (`vlt_...`).
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
        _ = this.ID;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("vault_deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeletedVault()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_deleted");
    }

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

        this.Type = JsonSerializer.SerializeToElement("vault_deleted");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedVault(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeletedVaultFromRaw : IFromRawJson<BetaManagedAgentsDeletedVault>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedVault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedVault.FromRawUnchecked(rawData);
}
