using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.RateLimits;

[JsonConverter(
    typeof(JsonModelConverter<RateLimitListPageResponse, RateLimitListPageResponseFromRaw>)
)]
public sealed record class RateLimitListPageResponse : JsonModel
{
    /// <summary>
    /// Rate-limit entries for the organization, one per group.
    /// </summary>
    public required IReadOnlyList<BetaOrganizationRateLimit> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaOrganizationRateLimit>>(
                "data"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaOrganizationRateLimit>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page of results, or `null` when no entries remain
    /// beyond this response.
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

    public RateLimitListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RateLimitListPageResponse(RateLimitListPageResponse rateLimitListPageResponse)
        : base(rateLimitListPageResponse) { }
#pragma warning restore CS8618

    public RateLimitListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RateLimitListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RateLimitListPageResponseFromRaw.FromRawUnchecked"/>
    public static RateLimitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RateLimitListPageResponseFromRaw : IFromRawJson<RateLimitListPageResponse>
{
    /// <inheritdoc/>
    public RateLimitListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RateLimitListPageResponse.FromRawUnchecked(rawData);
}
