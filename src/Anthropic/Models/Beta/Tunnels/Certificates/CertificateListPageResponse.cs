using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Tunnels.Certificates;

/// <summary>
/// The tunnel's certificates.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<CertificateListPageResponse, CertificateListPageResponseFromRaw>)
)]
public sealed record class CertificateListPageResponse : JsonModel
{
    /// <summary>
    /// List of certificates, ordered by created_at descending.
    /// </summary>
    public required IReadOnlyList<BetaTunnelCertificate> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaTunnelCertificate>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaTunnelCertificate>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination cursor for the next page, or null if no more results.
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

    public CertificateListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CertificateListPageResponse(CertificateListPageResponse certificateListPageResponse)
        : base(certificateListPageResponse) { }
#pragma warning restore CS8618

    public CertificateListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CertificateListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CertificateListPageResponseFromRaw.FromRawUnchecked"/>
    public static CertificateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class CertificateListPageResponseFromRaw : IFromRawJson<CertificateListPageResponse>
{
    /// <inheritdoc/>
    public CertificateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CertificateListPageResponse.FromRawUnchecked(rawData);
}
