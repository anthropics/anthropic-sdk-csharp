using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.ExternalStorage;

/// <summary>
/// A page of External Storage, newest first.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ExternalStorageListPageResponse,
        ExternalStorageListPageResponseFromRaw
    >)
)]
public sealed record class ExternalStorageListPageResponse : JsonModel
{
    public required IReadOnlyList<BetaExternalStorage> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaExternalStorage>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaExternalStorage>>(
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

    public ExternalStorageListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalStorageListPageResponse(
        ExternalStorageListPageResponse externalStorageListPageResponse
    )
        : base(externalStorageListPageResponse) { }
#pragma warning restore CS8618

    public ExternalStorageListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalStorageListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalStorageListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExternalStorageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalStorageListPageResponseFromRaw : IFromRawJson<ExternalStorageListPageResponse>
{
    /// <inheritdoc/>
    public ExternalStorageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalStorageListPageResponse.FromRawUnchecked(rawData);
}
