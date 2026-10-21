using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.RbacGroups;

[JsonConverter(typeof(JsonModelConverter<BetaRbacGroup, BetaRbacGroupFromRaw>))]
public sealed record class BetaRbacGroup : JsonModel
{
    /// <summary>
    /// ID of the RBAC Group.
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
    /// RFC 3339 timestamp of when the RBAC Group was created.
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
    /// Name of the RBAC Group. Not uniqueness-enforced.
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
    /// RBAC Role IDs attached to this RBAC Group. Role attachment is managed in the
    /// admin settings and is read-only on this API. `null` means role data was temporarily
    /// unavailable — retry to distinguish from an empty list.
    /// </summary>
    public required IReadOnlyList<string>? RoleIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("role_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "role_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// How the RBAC Group was created: `"direct"` for groups created directly (for
    /// example, in the organization's admin settings), `"scim"` for groups provisioned
    /// by the identity provider.
    /// </summary>
    public required ApiEnum<string, SourceType> SourceType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SourceType>>("source_type");
        }
        init { this._rawData.Set("source_type", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For RBAC Groups, this is always `"rbac_group"`.</para>
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

    /// <summary>
    /// RFC 3339 timestamp of when the RBAC Group was last updated.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.RoleIds;
        this.SourceType.Validate();
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("rbac_group")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.UpdatedAt;
    }

    public BetaRbacGroup()
    {
        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRbacGroup(BetaRbacGroup betaRbacGroup)
        : base(betaRbacGroup) { }
#pragma warning restore CS8618

    public BetaRbacGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("rbac_group");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRbacGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRbacGroupFromRaw.FromRawUnchecked"/>
    public static BetaRbacGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRbacGroupFromRaw : IFromRawJson<BetaRbacGroup>
{
    /// <inheritdoc/>
    public BetaRbacGroup FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaRbacGroup.FromRawUnchecked(rawData);
}

/// <summary>
/// How the RBAC Group was created: `"direct"` for groups created directly (for example,
/// in the organization's admin settings), `"scim"` for groups provisioned by the
/// identity provider.
/// </summary>
[JsonConverter(typeof(SourceTypeConverter))]
public enum SourceType
{
    Direct,
    Scim,
}

sealed class SourceTypeConverter : JsonConverter<SourceType>
{
    public override SourceType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "direct" => SourceType.Direct,
            "scim" => SourceType.Scim,
            _ => (SourceType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SourceType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SourceType.Direct => "direct",
                SourceType.Scim => "scim",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
