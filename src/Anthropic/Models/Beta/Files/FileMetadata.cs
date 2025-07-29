using Anthropic = Anthropic;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using Generic = System.Collections.Generic;
using Json = System.Text.Json;
using Serialization = System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Files;

[Serialization::JsonConverter(typeof(Anthropic::ModelConverter<FileMetadata>))]
public sealed record class FileMetadata : Anthropic::ModelBase, Anthropic::IFromRaw<FileMetadata>
{
    /// <summary>
    /// Unique object identifier.
    ///
    /// The format and length of IDs may change over time.
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this.Properties.TryGetValue("id", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("id", "Missing required argument");

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("id");
        }
        set { this.Properties["id"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// RFC 3339 datetime string representing when the file was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this.Properties.TryGetValue("created_at", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "created_at",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<System::DateTime>(element);
        }
        set { this.Properties["created_at"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string Filename
    {
        get
        {
            if (!this.Properties.TryGetValue("filename", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "filename",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("filename");
        }
        set { this.Properties["filename"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// MIME type of the file.
    /// </summary>
    public required string MimeType
    {
        get
        {
            if (!this.Properties.TryGetValue("mime_type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "mime_type",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<string>(element)
                ?? throw new System::ArgumentNullException("mime_type");
        }
        set { this.Properties["mime_type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Size of the file in bytes.
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            if (!this.Properties.TryGetValue("size_bytes", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException(
                    "size_bytes",
                    "Missing required argument"
                );

            return Json::JsonSerializer.Deserialize<long>(element);
        }
        set { this.Properties["size_bytes"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Object type.
    ///
    /// For files, this is always `"file"`.
    /// </summary>
    public Json::JsonElement Type
    {
        get
        {
            if (!this.Properties.TryGetValue("type", out Json::JsonElement element))
                throw new System::ArgumentOutOfRangeException("type", "Missing required argument");

            return Json::JsonSerializer.Deserialize<Json::JsonElement>(element);
        }
        set { this.Properties["type"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether the file can be downloaded.
    /// </summary>
    public bool? Downloadable
    {
        get
        {
            if (!this.Properties.TryGetValue("downloadable", out Json::JsonElement element))
                return null;

            return Json::JsonSerializer.Deserialize<bool?>(element);
        }
        set { this.Properties["downloadable"] = Json::JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Filename;
        _ = this.MimeType;
        _ = this.SizeBytes;
        _ = this.Downloadable;
    }

    public FileMetadata()
    {
        this.Type = Json::JsonSerializer.Deserialize<Json::JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [CodeAnalysis::SetsRequiredMembers]
    FileMetadata(Generic::Dictionary<string, Json::JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileMetadata FromRawUnchecked(
        Generic::Dictionary<string, Json::JsonElement> properties
    )
    {
        return new(properties);
    }
}
