using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(ModelConverter<FileMetadata, FileMetadataFromRaw>))]
public sealed record class FileMetadata : ModelBase
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// <para>The format and length of IDs may change over time.</para>
    /// </summary>
    public required string ID
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "id"); }
        init { ModelBase.Set(this._rawData, "id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing when the file was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get { return ModelBase.GetNotNullStruct<DateTimeOffset>(this.RawData, "created_at"); }
        init { ModelBase.Set(this._rawData, "created_at", value); }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string Filename
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "filename"); }
        init { ModelBase.Set(this._rawData, "filename", value); }
    }

    /// <summary>
    /// MIME type of the file.
    /// </summary>
    public required string MimeType
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "mime_type"); }
        init { ModelBase.Set(this._rawData, "mime_type", value); }
    }

    /// <summary>
    /// Size of the file in bytes.
    /// </summary>
    public required long SizeBytes
    {
        get { return ModelBase.GetNotNullStruct<long>(this.RawData, "size_bytes"); }
        init { ModelBase.Set(this._rawData, "size_bytes", value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For files, this is always `"file"`.</para>
    /// </summary>
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Whether the file can be downloaded.
    /// </summary>
    public bool? Downloadable
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "downloadable"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "downloadable", value);
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"file\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Downloadable;
    }

    public FileMetadata()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

    public FileMetadata(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMetadata(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileMetadataFromRaw.FromRawUnchecked"/>
    public static FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileMetadataFromRaw : IFromRaw<FileMetadata>
{
    /// <inheritdoc/>
    public FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        FileMetadata.FromRawUnchecked(rawData);
}
