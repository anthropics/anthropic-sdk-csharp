using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ServiceAccounts;

[JsonConverter(
    typeof(JsonModelConverter<
        ServiceAccountListPageResponse,
        ServiceAccountListPageResponseFromRaw
    >)
)]
public sealed record class ServiceAccountListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaServiceAccount> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaServiceAccount>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaServiceAccount>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results.
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

    public ServiceAccountListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServiceAccountListPageResponse(
        ServiceAccountListPageResponse serviceAccountListPageResponse
    )
        : base(serviceAccountListPageResponse) { }
#pragma warning restore CS8618

    public ServiceAccountListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServiceAccountListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServiceAccountListPageResponseFromRaw.FromRawUnchecked"/>
    public static ServiceAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServiceAccountListPageResponseFromRaw : IFromRawJson<ServiceAccountListPageResponse>
{
    /// <inheritdoc/>
    public ServiceAccountListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServiceAccountListPageResponse.FromRawUnchecked(rawData);
}
