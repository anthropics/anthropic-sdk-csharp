using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

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
    /// The unique ID of the deleted credential (`vcrd_...`).
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
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("vault_credential_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsDeletedCredential()
    {
        this.Type = JsonSerializer.SerializeToElement("vault_credential_deleted");
    }

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

        this.Type = JsonSerializer.SerializeToElement("vault_credential_deleted");
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

    [SetsRequiredMembers]
    public BetaManagedAgentsDeletedCredential(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaManagedAgentsDeletedCredentialFromRaw : IFromRawJson<BetaManagedAgentsDeletedCredential>
{
    /// <inheritdoc/>
    public BetaManagedAgentsDeletedCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsDeletedCredential.FromRawUnchecked(rawData);
}
