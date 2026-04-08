using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Vaults.Credentials;

/// <summary>
/// Response containing a paginated list of credentials.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CredentialListPageResponse, CredentialListPageResponseFromRaw>)
)]
public sealed record class CredentialListPageResponse : JsonModel
{
    /// <summary>
    /// List of credentials.
    /// </summary>
    public IReadOnlyList<BetaManagedAgentsCredential>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<BetaManagedAgentsCredential>>(
                "data"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<BetaManagedAgentsCredential>?>(
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

    public CredentialListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialListPageResponse(CredentialListPageResponse credentialListPageResponse)
        : base(credentialListPageResponse) { }
#pragma warning restore CS8618

    public CredentialListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CredentialListPageResponseFromRaw.FromRawUnchecked"/>
    public static CredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CredentialListPageResponseFromRaw : IFromRawJson<CredentialListPageResponse>
{
    /// <inheritdoc/>
    public CredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CredentialListPageResponse.FromRawUnchecked(rawData);
}
