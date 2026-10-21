using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Analytics.Users;

/// <summary>
/// Response for GET /v1/organizations/analytics/users.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserListPageResponse, UserListPageResponseFromRaw>))]
public sealed record class UserListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaAnalyticsUserActivity> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaAnalyticsUserActivity>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaAnalyticsUserActivity>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results
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
        _ = this.NextPage;
    }

    public UserListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListPageResponse(UserListPageResponse userListPageResponse)
        : base(userListPageResponse) { }
#pragma warning restore CS8618

    public UserListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserListPageResponseFromRaw.FromRawUnchecked"/>
    public static UserListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserListPageResponseFromRaw : IFromRawJson<UserListPageResponse>
{
    /// <inheritdoc/>
    public UserListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserListPageResponse.FromRawUnchecked(rawData);
}
