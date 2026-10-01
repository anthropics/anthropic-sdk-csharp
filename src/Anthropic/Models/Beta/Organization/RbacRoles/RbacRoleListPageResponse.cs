using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RbacRoles;

[JsonConverter(
    typeof(JsonModelConverter<RbacRoleListPageResponse, RbacRoleListPageResponseFromRaw>)
)]
public sealed record class RbacRoleListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaRbacRole> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaRbacRole>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaRbacRole>>(
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

    public RbacRoleListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacRoleListPageResponse(RbacRoleListPageResponse rbacRoleListPageResponse)
        : base(rbacRoleListPageResponse) { }
#pragma warning restore CS8618

    public RbacRoleListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacRoleListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacRoleListPageResponseFromRaw.FromRawUnchecked"/>
    public static RbacRoleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacRoleListPageResponseFromRaw : IFromRawJson<RbacRoleListPageResponse>
{
    /// <inheritdoc/>
    public RbacRoleListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacRoleListPageResponse.FromRawUnchecked(rawData);
}
