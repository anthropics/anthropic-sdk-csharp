using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Users;

[JsonConverter(typeof(JsonModelConverter<BetaOrganizationUser, BetaOrganizationUserFromRaw>))]
public sealed record class BetaOrganizationUser : JsonModel
{
    /// <summary>
    /// ID of the User.
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
    /// RFC 3339 datetime string indicating when the User joined the Organization.
    /// </summary>
    public required DateTimeOffset AddedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("added_at");
        }
        init { this._rawData.Set("added_at", value); }
    }

    /// <summary>
    /// Email of the User.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Name of the User.
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
    /// Organization role of the User.
    /// </summary>
    public required ApiEnum<string, BetaOrganizationRole> Role
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BetaOrganizationRole>>("role");
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Users, this is always `"user"`.</para>
    /// </summary>
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
        _ = this.AddedAt;
        _ = this.Email;
        _ = this.Name;
        this.Role.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("user")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOrganizationUser()
    {
        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOrganizationUser(BetaOrganizationUser betaOrganizationUser)
        : base(betaOrganizationUser) { }
#pragma warning restore CS8618

    public BetaOrganizationUser(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("user");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOrganizationUser(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOrganizationUserFromRaw.FromRawUnchecked"/>
    public static BetaOrganizationUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOrganizationUserFromRaw : IFromRawJson<BetaOrganizationUser>
{
    /// <inheritdoc/>
    public BetaOrganizationUser FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOrganizationUser.FromRawUnchecked(rawData);
}
