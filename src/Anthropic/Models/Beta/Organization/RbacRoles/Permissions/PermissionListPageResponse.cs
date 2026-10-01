using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RbacRoles.Permissions;

[JsonConverter(
    typeof(JsonModelConverter<PermissionListPageResponse, PermissionListPageResponseFromRaw>)
)]
public sealed record class PermissionListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaRbacRolePermission> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaRbacRolePermission>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaRbacRolePermission>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates whether there are more results beyond this page.
    /// </summary>
    public required bool HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("has_more");
        }
        init { this._rawData.Set("has_more", value); }
    }

    /// <summary>
    /// Opaque cursor for the next page. Pass as the `page` parameter on the next request.
    /// </summary>
    public required string? NextPage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("next_page");
        }
        init { this._rawData.Set("next_page", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.HasMore;
        _ = this.NextPage;
    }

    public PermissionListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PermissionListPageResponse(PermissionListPageResponse permissionListPageResponse)
        : base(permissionListPageResponse) { }
#pragma warning restore CS8618

    public PermissionListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PermissionListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PermissionListPageResponseFromRaw.FromRawUnchecked"/>
    public static PermissionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PermissionListPageResponseFromRaw : IFromRawJson<PermissionListPageResponse>
{
    /// <inheritdoc/>
    public PermissionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PermissionListPageResponse.FromRawUnchecked(rawData);
}
