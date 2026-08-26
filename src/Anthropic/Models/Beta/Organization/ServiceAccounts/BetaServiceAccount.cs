using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ServiceAccounts;

/// <summary>
/// Named non-human identity within the caller's organization.
///
/// <para>A service account is a pure identity: name + org. Authorization lives on
/// whatever references it (federation rules).</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaServiceAccount, BetaServiceAccountFromRaw>))]
public sealed record class BetaServiceAccount : JsonModel
{
    /// <summary>
    /// Tagged ID of the service account.
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

    /// <summary>
    /// If set, this service account is archived.
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that archived this service account.
    /// </summary>
    public required string? ArchivedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("archived_by_actor_id");
        }
        init { this._rawData.Set("archived_by_actor_id", value); }
    }

    /// <summary>
    /// When this service account was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that created this service account.
    /// </summary>
    public required string? CreatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("created_by_actor_id");
        }
        init { this._rawData.Set("created_by_actor_id", value); }
    }

    /// <summary>
    /// Optional free-text description.
    /// </summary>
    public required string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Admin-chosen slug identifier.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Org-level role. A federation rule may only be created or retargeted to grant
    /// `org:admin` scope when this is `admin`. A rule granting `org:admin` whose
    /// target is later demoted to `developer` is rejected at token exchange. Rules
    /// granting `org:admin` are managed in the Console.
    /// </summary>
    public required ApiEnum<string, BetaServiceAccountOrganizationRole> OrganizationRole
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaServiceAccountOrganizationRole>
            >("organization_role");
        }
        init { this._rawData.Set("organization_role", value); }
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

    /// <summary>
    /// When this service account was last updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updated_at");
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// Tagged ID (`user_`/`svac_`) of the actor that last updated this service account.
    /// </summary>
    public required string? UpdatedByActorID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("updated_by_actor_id");
        }
        init { this._rawData.Set("updated_by_actor_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.ArchivedByActorID;
        _ = this.CreatedAt;
        _ = this.CreatedByActorID;
        _ = this.Description;
        _ = this.Name;
        this.OrganizationRole.Validate();
        if (
            !JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("service_account"))
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
        _ = this.UpdatedByActorID;
    }

    public BetaServiceAccount()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaServiceAccount(BetaServiceAccount betaServiceAccount)
        : base(betaServiceAccount) { }
#pragma warning restore CS8618

    public BetaServiceAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaServiceAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaServiceAccountFromRaw.FromRawUnchecked"/>
    public static BetaServiceAccount FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaServiceAccountFromRaw : IFromRawJson<BetaServiceAccount>
{
    /// <inheritdoc/>
    public BetaServiceAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaServiceAccount.FromRawUnchecked(rawData);
}

/// <summary>
/// Org-level role. A federation rule may only be created or retargeted to grant `org:admin`
/// scope when this is `admin`. A rule granting `org:admin` whose target is later
/// demoted to `developer` is rejected at token exchange. Rules granting `org:admin`
/// are managed in the Console.
/// </summary>
[JsonConverter(typeof(BetaServiceAccountOrganizationRoleConverter))]
public enum BetaServiceAccountOrganizationRole
{
    Admin,
    Developer,
}

sealed class BetaServiceAccountOrganizationRoleConverter
    : JsonConverter<BetaServiceAccountOrganizationRole>
{
    public override BetaServiceAccountOrganizationRole Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "admin" => BetaServiceAccountOrganizationRole.Admin,
            "developer" => BetaServiceAccountOrganizationRole.Developer,
            _ => (BetaServiceAccountOrganizationRole)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaServiceAccountOrganizationRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaServiceAccountOrganizationRole.Admin => "admin",
                BetaServiceAccountOrganizationRole.Developer => "developer",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
