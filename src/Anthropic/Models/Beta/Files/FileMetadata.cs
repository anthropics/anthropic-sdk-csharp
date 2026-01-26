using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(JsonModelConverter<FileMetadata, FileMetadataFromRaw>))]
public sealed record class FileMetadata : JsonModel
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing when the file was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// MIME type of the file.
    /// </summary>
    public required string MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("mime_type");
        }
        init { this._rawData.Set("mime_type", value); }
    }

    /// <summary>
    /// Size of the file in bytes.
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("size_bytes");
        }
        init { this._rawData.Set("size_bytes", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For files, this is always `"file"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether the file can be downloaded.
    /// </summary>
    public bool? Downloadable
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("downloadable");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("downloadable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Filename;
        _ = this.MimeType;
        _ = this.SizeBytes;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("file")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Downloadable;
    }

    public FileMetadata()
    {
        this.Type = JsonSerializer.SerializeToElement("file");
    }

    public FileMetadata(FileMetadata fileMetadata)
        : base(fileMetadata) { }

    public FileMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("file");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileMetadataFromRaw.FromRawUnchecked"/>
    public static FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileMetadataFromRaw : IFromRawJson<FileMetadata>
{
    /// <inheritdoc/>
    public FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileMetadata.FromRawUnchecked(rawData);
}
