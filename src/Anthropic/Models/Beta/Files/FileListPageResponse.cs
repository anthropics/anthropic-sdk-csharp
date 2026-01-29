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
    public required IReadOnlyList<FileMetadata> Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FileMetadata>>("data");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FileMetadata>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ID of the first file in this page of results.
    /// </summary>
    public string? FirstID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("first_id");
        }
        init { this._rawData.Set("first_id", value); }
    }

    /// <summary>
    /// Whether there are more results available.
    /// </summary>
    public bool? HasMore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("has_more");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("has_more", value);
        }
    }

    /// <summary>
    /// ID of the last file in this page of results.
    /// </summary>
    public string? LastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("last_id");
        }
        init { this._rawData.Set("last_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.FirstID;
        _ = this.HasMore;
        _ = this.LastID;
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
    public FileListPageResponse(IReadOnlyList<FileMetadata> data)
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
