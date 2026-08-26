using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Workspaces.Members;

[JsonConverter(typeof(JsonModelConverter<MemberListPageResponse, MemberListPageResponseFromRaw>))]
public sealed record class MemberListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaWorkspaceMember> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaWorkspaceMember>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaWorkspaceMember>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// First ID in the `data` list. Can be used as the `before_id` for the previous page.
    /// </summary>
    public required string? FirstID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_id");
        }
        init { this._rawData.Set("first_id", value); }
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
    /// Last ID in the `data` list. Can be used as the `after_id` for the next page.
    /// </summary>
    public required string? LastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_id");
        }
        init { this._rawData.Set("last_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.FirstID;
        _ = this.HasMore;
        _ = this.LastID;
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
