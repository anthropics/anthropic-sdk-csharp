using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

/// <summary>
/// Opaque-cursor page of external keys, ordered by creation time (newest first).
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExternalKeyListPageResponse, ExternalKeyListPageResponseFromRaw>)
)]
public sealed record class ExternalKeyListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaExternalKey> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaExternalKey>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaExternalKey>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page, or null if no more results. Pass as `?page=`
    /// to fetch the next page.
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

    public ExternalKeyListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyListPageResponse(ExternalKeyListPageResponse externalKeyListPageResponse)
        : base(externalKeyListPageResponse) { }
#pragma warning restore CS8618

    public ExternalKeyListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExternalKeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyListPageResponseFromRaw : IFromRawJson<ExternalKeyListPageResponse>
{
    /// <inheritdoc/>
    public ExternalKeyListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyListPageResponse.FromRawUnchecked(rawData);
}
