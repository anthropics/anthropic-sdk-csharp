using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(JsonModelConverter<FileListPageResponse, FileListPageResponseFromRaw>))]
public sealed record class FileListPageResponse : JsonModel
{
    /// <summary>
    /// List of file metadata objects.
    /// </summary>
    public required IReadOnlyList<BetaFileMetadata> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BetaFileMetadata>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaFileMetadata>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Opaque cursor for the next page. Supply as `?page=` to fetch the next page;
    /// null when there are no more results.
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
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.NextPage;
    }

    public FileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileListPageResponse(FileListPageResponse fileListPageResponse)
        : base(fileListPageResponse) { }
#pragma warning restore CS8618

    public FileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileListPageResponseFromRaw.FromRawUnchecked"/>
    public static FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FileListPageResponse(IReadOnlyList<BetaFileMetadata> data)
        : this()
    {
        this.Data = data;
    }
}

class FileListPageResponseFromRaw : IFromRawJson<FileListPageResponse>
{
    /// <inheritdoc/>
    public FileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileListPageResponse.FromRawUnchecked(rawData);
}
