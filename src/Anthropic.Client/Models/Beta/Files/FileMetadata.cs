using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Files;

[JsonConverter(typeof(ModelConverter<FileMetadata>))]
public sealed record class FileMetadata : ModelBase, IFromRaw<FileMetadata>
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
            if (!this._properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        init
        {
            this._properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// RFC 3339 datetime string representing when the file was created.
    /// </summary>
    public required System::DateTime CreatedAt
    {
        get
        {
            if (!this._properties.TryGetValue("created_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'created_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "created_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._properties["created_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Original filename of the uploaded file.
    /// </summary>
    public required string Filename
    {
        get
        {
            if (!this._properties.TryGetValue("filename", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'filename' cannot be null",
                    new System::ArgumentOutOfRangeException("filename", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'filename' cannot be null",
                    new System::ArgumentNullException("filename")
                );
        }
        init
        {
            this._properties["filename"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// MIME type of the file.
    /// </summary>
    public required string MimeType
    {
        get
        {
            if (!this._properties.TryGetValue("mime_type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'mime_type' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "mime_type",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'mime_type' cannot be null",
                    new System::ArgumentNullException("mime_type")
                );
        }
        init
        {
            this._properties["mime_type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Size of the file in bytes.
    /// </summary>
    public required long SizeBytes
    {
        get
        {
            if (!this._properties.TryGetValue("size_bytes", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'size_bytes' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "size_bytes",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<long>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["size_bytes"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Object type.
    ///
    /// For files, this is always `"file"`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            if (!this._properties.TryGetValue("type", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'type' cannot be null",
                    new System::ArgumentOutOfRangeException("type", "Missing required argument")
                );

            return JsonSerializer.Deserialize<JsonElement>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["type"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Whether the file can be downloaded.
    /// </summary>
    public bool? Downloadable
    {
        get
        {
            if (!this._properties.TryGetValue("downloadable", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["downloadable"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Filename;
        _ = this.MimeType;
        _ = this.SizeBytes;
        _ = this.Type;
        _ = this.Downloadable;
    }

    public FileMetadata()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

    public FileMetadata(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"file\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileMetadata(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static FileMetadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
