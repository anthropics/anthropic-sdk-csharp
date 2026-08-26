using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.Federation.Issuers;

[JsonConverter(typeof(JsonModelConverter<IssuerListPageResponse, IssuerListPageResponseFromRaw>))]
public sealed record class IssuerListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaFederationIssuer> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaFederationIssuer>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaFederationIssuer>>(
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

    public IssuerListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public IssuerListPageResponse(IssuerListPageResponse issuerListPageResponse)
        : base(issuerListPageResponse) { }
#pragma warning restore CS8618

    public IssuerListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IssuerListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IssuerListPageResponseFromRaw.FromRawUnchecked"/>
    public static IssuerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class IssuerListPageResponseFromRaw : IFromRawJson<IssuerListPageResponse>
{
    /// <inheritdoc/>
    public IssuerListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => IssuerListPageResponse.FromRawUnchecked(rawData);
}
