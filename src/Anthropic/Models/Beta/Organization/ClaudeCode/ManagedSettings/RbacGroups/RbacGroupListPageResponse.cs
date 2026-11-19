using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

[JsonConverter(
    typeof(JsonModelConverter<RbacGroupListPageResponse, RbacGroupListPageResponseFromRaw>)
)]
public sealed record class RbacGroupListPageResponse : JsonModel
{
    /// <summary>
    /// The RBAC Groups with settings on this page, highest precedence first.
    /// </summary>
    public required IReadOnlyList<BetaClaudeCodeRbacGroupManagedSettingsSummary> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaClaudeCodeRbacGroupManagedSettingsSummary>
            >("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaClaudeCodeRbacGroupManagedSettingsSummary>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.NextPage;
    }

    public RbacGroupListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RbacGroupListPageResponse(RbacGroupListPageResponse rbacGroupListPageResponse)
        : base(rbacGroupListPageResponse) { }
#pragma warning restore CS8618

    public RbacGroupListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RbacGroupListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RbacGroupListPageResponseFromRaw.FromRawUnchecked"/>
    public static RbacGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RbacGroupListPageResponseFromRaw : IFromRawJson<RbacGroupListPageResponse>
{
    /// <inheritdoc/>
    public RbacGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RbacGroupListPageResponse.FromRawUnchecked(rawData);
}
