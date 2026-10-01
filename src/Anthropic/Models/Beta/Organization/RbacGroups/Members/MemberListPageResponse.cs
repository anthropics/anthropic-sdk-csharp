using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RbacGroups.Members;

[JsonConverter(typeof(JsonModelConverter<MemberListPageResponse, MemberListPageResponseFromRaw>))]
public sealed record class MemberListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaRbacGroupMember> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaRbacGroupMember>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaRbacGroupMember>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Indicates if there are more results in the requested page direction.
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
    /// Token to provide in as `page` in the subsequent request to retrieve the next
    /// page of data.
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

    public MemberListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MemberListPageResponse(MemberListPageResponse memberListPageResponse)
        : base(memberListPageResponse) { }
#pragma warning restore CS8618

    public MemberListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MemberListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MemberListPageResponseFromRaw.FromRawUnchecked"/>
    public static MemberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MemberListPageResponseFromRaw : IFromRawJson<MemberListPageResponse>
{
    /// <inheritdoc/>
    public MemberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => MemberListPageResponse.FromRawUnchecked(rawData);
}
