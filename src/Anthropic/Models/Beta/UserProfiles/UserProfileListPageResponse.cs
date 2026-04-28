using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.UserProfiles;

[JsonConverter(
    typeof(JsonModelConverter<UserProfileListPageResponse, UserProfileListPageResponseFromRaw>)
)]
public sealed record class UserProfileListPageResponse : JsonModel
{
    /// <summary>
    /// User profiles on this page.
    /// </summary>
    public required IReadOnlyList<BetaUserProfile> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaUserProfile>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaUserProfile>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Cursor for the next page, or `null` when there are no more results.
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

    public UserProfileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileListPageResponse(UserProfileListPageResponse userProfileListPageResponse)
        : base(userProfileListPageResponse) { }
#pragma warning restore CS8618

    public UserProfileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static UserProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileListPageResponseFromRaw : IFromRawJson<UserProfileListPageResponse>
{
    /// <inheritdoc/>
    public UserProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileListPageResponse.FromRawUnchecked(rawData);
}
