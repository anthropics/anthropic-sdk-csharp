using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults;

/// <summary>
/// Response containing a paginated list of vaults.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VaultListPageResponse, VaultListPageResponseFromRaw>))]
public sealed record class VaultListPageResponse : JsonModel
{
    /// <summary>
    /// List of vaults.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsVault>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsVault>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsVault>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination token for the next page, or null if no more results.
    /// </summary>
    public string? NextPage
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
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public VaultListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public VaultListPageResponse(VaultListPageResponse vaultListPageResponse)
        : base(vaultListPageResponse) { }
#pragma warning restore CS8618

    public VaultListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    VaultListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="VaultListPageResponseFromRaw.FromRawUnchecked"/>
    public static VaultListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class VaultListPageResponseFromRaw : IFromRawJson<VaultListPageResponse>
{
    /// <inheritdoc/>
    public VaultListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => VaultListPageResponse.FromRawUnchecked(rawData);
}
