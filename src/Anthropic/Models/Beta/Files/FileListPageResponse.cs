using System.Collections.Frozen;
using System.Collections.Generic;
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
        get { return JsonModel.GetNotNullClass<List<FileMetadata>>(this.RawData, "data"); }
        init { JsonModel.Set(this._rawData, "data", value); }
    }

    /// <summary>
    /// ID of the first file in this page of results.
    /// </summary>
    public string? FirstID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "first_id"); }
        init { JsonModel.Set(this._rawData, "first_id", value); }
    }

    /// <summary>
    /// Whether there are more results available.
    /// </summary>
    public bool? HasMore
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "has_more"); }
        init
        {
            if (value == null)
            {
                return;
            }

            JsonModel.Set(this._rawData, "has_more", value);
        }
    }

    /// <summary>
    /// ID of the last file in this page of results.
    /// </summary>
    public string? LastID
    {
        get { return JsonModel.GetNullableClass<string>(this.RawData, "last_id"); }
        init { JsonModel.Set(this._rawData, "last_id", value); }
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

    public FileListPageResponse(FileListPageResponse fileListPageResponse)
        : base(fileListPageResponse) { }

    public FileListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
    public FileListPageResponse(List<FileMetadata> data)
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
